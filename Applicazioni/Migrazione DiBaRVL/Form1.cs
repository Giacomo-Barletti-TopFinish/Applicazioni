using Applicazioni.BLL;
using Applicazioni.Common;
using Applicazioni.Entities;
using Applicazioni.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migrazione_DiBaRVL
{
    public partial class MainForm : BaseForm
    {
        private MigrazioneDiBaDS _ds = new MigrazioneDiBaDS();
        public MainForm()
        {
            InitializeComponent();
        }

        private void CaricaMagazz()
        {
            _ds.MAGAZZ.Clear();
            MigrazioneDiBaBLL bll = new MigrazioneDiBaBLL();
            bll.FillMAGAZZ(_ds);
        }

        private void CaricaBC_Anagrafica()
        {
            _ds.BC_ANAGRAFICA.Clear();
            MigrazioneDiBaBLL bll = new MigrazioneDiBaBLL();
            bll.FillBC_ANAGRAFICA(_ds);
        }
        private void btnCercaFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";

                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFile.Text = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore nella ricerca file");
            }

        }

        private void btnApri_Click(object sender, EventArgs e)
        {
            TipoExcel tipoExcel = TipoExcel.Sconosciuto;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                btnApri.Enabled = false;

                txtRisultati.Text = string.Empty;
                if (string.IsNullOrEmpty(txtFile.Text))
                {
                    txtRisultati.Text = "Selezionare un file";
                    return;
                }

                if (!File.Exists(txtFile.Text))
                {
                    txtRisultati.Text = "Il file specificato non esiste";
                    return;
                }


                ExcelHelper excel = new ExcelHelper();
                tipoExcel = excel.IdentificaTipoFIleExcelneExcelDibaRVL(txtFile.Text);
                string nomefile = txtFile.Text;

                if (tipoExcel == TipoExcel.RVL)
                {
                    FileInfo fi = new FileInfo(txtFile.Text);
                    nomefile = fi.FullName.Replace(fi.Extension, string.Empty);
                    nomefile = string.Format("{0} v1.0{1}", nomefile, fi.Extension);

                    if (File.Exists(nomefile))
                        File.Delete(nomefile);
                    File.Copy(txtFile.Text, nomefile);
                    CaricaMagazz();
                }

                CaricaBC_Anagrafica();
                string messaggioErrore;
                if (!LeggiExcel(nomefile, Contesto.Utente.FULLNAMEUSER, tipoExcel, out messaggioErrore))
                {
                    string messaggio = string.Format("Errore nel caricamento del file excel. Errore: {0}", messaggioErrore);
                    MessageBox.Show(messaggio, "ERRORE LETTURA FILE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Operazione completata", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                ScriviLogErrore("ERRORE");
                ExceptionFrm frm = new ExceptionFrm(ex);
                frm.ShowDialog();
            }
            finally
            {
                switch (tipoExcel)
                {
                    case TipoExcel.IdMagazz:
                        txtRisultati.Text = "FILE DI TIPO IDMAGAZZ";
                        break;
                    case TipoExcel.RVL:
                        txtRisultati.Text = "FILE DI TIPO RVL";
                        break;
                    case TipoExcel.Sconosciuto:
                        txtRisultati.Text = "FILE DI TIPO SCONOSCIUTO";
                        break;
                }
                btnApri.Enabled = true;
                Cursor.Current = Cursors.Default;


            }
        }

        private bool LeggiExcel(string filePath, string utente, TipoExcel tipoExcel, out string messaggioErrore)
        {          
            messaggioErrore = string.Empty;
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
            {
                MemoryStream ms = new MemoryStream();
                byte[] dati = new byte[fs.Length];
                fs.Read(dati, 0, (int)fs.Length);

                ExcelHelper excel = new ExcelHelper();

                switch (tipoExcel)
                {
                    case TipoExcel.IdMagazz:
                        if (!excel.LeggiFileExcelTipoIDMAGAZ(fs, _ds, out messaggioErrore))
                        {
                            messaggioErrore = "Errore nella lettura del file " + messaggioErrore;
                            return false;
                        }
                        PulisciDataset();
                        if (!EstraiAnagrafiche(out messaggioErrore))
                        {
                            messaggioErrore = "Errore nell'estrazione delle anagrafiche dal file " + messaggioErrore;
                            return false;
                        }

                        List<Ciclo> cicli = new List<Ciclo>();
                        if (!PreparaCicli(out messaggioErrore, out cicli))
                        {
                            messaggioErrore = "Errore nell'estrazione dei cicli dal file " + messaggioErrore;
                            return false;
                        }

                        List<Distinta> distinte = new List<Distinta>();
                        if (!PreparaDistinte(out messaggioErrore, out distinte))
                        {
                            messaggioErrore = "Errore nell'estrazione delle distinte dal file " + messaggioErrore;
                            return false;
                        }

                        break;
                    case TipoExcel.RVL:
                        if (!excel.AggiungiColonneExcelDibaRVL(_ds, fs, out messaggioErrore))
                        {
                            messaggioErrore = messaggioErrore + "Errore nella modifica del file ";
                            return false;
                        }
                        break;
                    default:
                        break;
                }

                fs.Flush();
                fs.Close();
            }
            return true;
        }

        private bool PreparaCicli(out string messaggioErrore, out List<Ciclo> cicli)
        {
            cicli = new List<Ciclo>();
            try
            {
                messaggioErrore = string.Empty;
                MigrazioneDiBaBLL bll = new MigrazioneDiBaBLL();

                List<MigrazioneDiBaDS.DATIEXCELRow> righeConAnagrafica = _ds.DATIEXCEL.Where(x => !string.IsNullOrEmpty(x.ANAGRAFICA)).OrderByDescending(x => x.IDDATAEXCEL).ToList();
                if (righeConAnagrafica.Count == 0)
                {
                    messaggioErrore = "Nessuna anagrafica trovata";
                    return false;
                }

                int idInizioCiclo = 0;
                int avanti = 0;
                foreach (MigrazioneDiBaDS.DATIEXCELRow riga in righeConAnagrafica)
                {
                    if (idInizioCiclo == 0)
                    {
                        idInizioCiclo = riga.IDDATAEXCEL;
                        avanti = riga.AVANTI;
                    }
                    else if (idInizioCiclo > 0)
                    {
                        if (riga.AVANTI < avanti)
                        {
                            cicli.Add(new Ciclo(idInizioCiclo, riga.IDDATAEXCEL, riga.ANAGRAFICA));
                        }
                        idInizioCiclo = riga.IDDATAEXCEL;
                        avanti = riga.AVANTI;
                    }
                }

                foreach (Ciclo c in cicli)
                {
                    int operazione = 10;
                    for (int i = c.Inizio - 1; i >= c.Fine; i--)
                    {
                        MigrazioneDiBaDS.DATIEXCELRow riga = _ds.DATIEXCEL.Where(x => x.IDDATAEXCEL == i).FirstOrDefault();
                        if (riga != null)
                        {
                            Fase f = new Fase();
                            f.Operazione = operazione;
                            operazione += 10;

                            f.AreaProduzione = riga.REPARTO;
                            f.TempoLavorazione = riga.PEZZIORARI > 0 ? 1 / riga.PEZZIORARI : 0;
                            f.Collegamento = riga.COLLEGAMENTO;
                            f.Task = riga.CODICEFASE;
                            if (!string.IsNullOrEmpty(riga.NOTA))
                                f.Commenti.Add(riga.NOTA);
                            c.Fasi.Add(f);
                        }
                    }
                }
                ImpaginaMessaggioCicli(cicli);
                return true;
            }
            catch (Exception ex)
            {
                messaggioErrore = ex.Message;
                return false;

            }
        }

        private bool PreparaDistinte(out string messaggioErrore, out List<Distinta> distinte)
        {
            distinte = new List<Distinta>();
            try
            {
                messaggioErrore = string.Empty;
                MigrazioneDiBaBLL bll = new MigrazioneDiBaBLL();

                List<MigrazioneDiBaDS.DATIEXCELRow> righeConAnagrafica = _ds.DATIEXCEL.Where(x => !string.IsNullOrEmpty(x.ANAGRAFICA)).OrderBy(x => x.IDDATAEXCEL).ToList();
                if (righeConAnagrafica.Count == 0)
                {
                    messaggioErrore = "Nessuna anagrafica trovata";
                    return false;
                }

                MigrazioneDiBaDS.DATIEXCELRow riga = righeConAnagrafica.FirstOrDefault();
                int avantiMassimo = _ds.DATIEXCEL.Max(x => x.AVANTI);
                creaDistinta(riga, 1, _ds.DATIEXCEL.Rows.Count, distinte, righeConAnagrafica, avantiMassimo);

                ImpaginaMessaggioDistinte(distinte);
                return true;
            }
            catch (Exception ex)
            {
                messaggioErrore = ex.Message;
                return false;

            }

        }

        private void creaDistinta(MigrazioneDiBaDS.DATIEXCELRow riga, int indiceMinimo, int indiceMassimo, List<Distinta> distinte, List<MigrazioneDiBaDS.DATIEXCELRow> righeConAnagrafica, int avantiMassimo)
        {
            int indice = 0;

            List<MigrazioneDiBaDS.DATIEXCELRow> righeFiglie = new List<MigrazioneDiBaDS.DATIEXCELRow>();
            do
            {
                indice++;
                if (indice > avantiMassimo)
                    return;

                righeFiglie = righeConAnagrafica.Where(x => x.AVANTI == riga.AVANTI + indice && x.IDDATAEXCEL > indiceMinimo && x.IDDATAEXCEL < indiceMassimo).ToList();
            } while (righeFiglie.Count == 0);

            List<Componente> componenti = new List<Componente>();
            righeFiglie.ForEach(x => componenti.Add(new Componente(x.ANAGRAFICA,x.QUANTITA)));

            distinte.Add(new Distinta(riga.ANAGRAFICA, componenti));

            for (int i = 0; i < righeFiglie.Count; i++)
            {
                if (i < righeFiglie.Count - 1)
                    creaDistinta(righeFiglie[i], righeFiglie[i].IDDATAEXCEL, righeFiglie[i + 1].IDDATAEXCEL, distinte, righeConAnagrafica, avantiMassimo);
                else
                    creaDistinta(righeFiglie[i], righeFiglie[i].IDDATAEXCEL, indiceMassimo, distinte, righeConAnagrafica, avantiMassimo);
            }

        }

        private void PulisciDataset()
        {
            _ds.DATIEXCEL.Where(x => x.IsMODELLONull()).ToList().ForEach(x => x.Delete());
        }
        private bool EstraiAnagrafiche(out string messaggioErrore)
        {
            try
            {
                messaggioErrore = string.Empty;
                MigrazioneDiBaBLL bll = new MigrazioneDiBaBLL();

                List<MigrazioneDiBaDS.DATIEXCELRow> datiExcelConAnagrafica = _ds.DATIEXCEL.Where(x => !x.IsANAGRAFICANull() && !string.IsNullOrEmpty(x.ANAGRAFICA)).ToList();
                List<string> anagraficheCensite = new List<string>();
                List<string> anagraficheModificate = new List<string>();
                List<string> anagraficheNuove = new List<string>();
                foreach (MigrazioneDiBaDS.DATIEXCELRow datoExcelConAnagrafica in datiExcelConAnagrafica)
                {
                    MigrazioneDiBaDS.BC_ANAGRAFICARow riga = _ds.BC_ANAGRAFICA.Where(x => x.IDMAGAZZ == datoExcelConAnagrafica.IDMAGAZZ).FirstOrDefault();
                    if (riga != null)
                    {
                        if (riga.BC != datoExcelConAnagrafica.ANAGRAFICA)
                        {
                            anagraficheModificate.Add(string.Format("{2} associazione modificata {0} -> {1}", riga.BC, datoExcelConAnagrafica.ANAGRAFICA, datoExcelConAnagrafica.MODELLO));
                            riga.BC = datoExcelConAnagrafica.ANAGRAFICA;
                        }
                        else
                            anagraficheCensite.Add(riga.BC);
                    }
                    else
                    {
                        MigrazioneDiBaDS.BC_ANAGRAFICARow nuovaRiga = _ds.BC_ANAGRAFICA.NewBC_ANAGRAFICARow();
                        nuovaRiga.BC = datoExcelConAnagrafica.ANAGRAFICA;
                        nuovaRiga.IDMAGAZZ = datoExcelConAnagrafica.IDMAGAZZ;
                        _ds.BC_ANAGRAFICA.AddBC_ANAGRAFICARow(nuovaRiga);
                        anagraficheNuove.Add(string.Format("{0} associata a {1}", datoExcelConAnagrafica.MODELLO, datoExcelConAnagrafica.ANAGRAFICA));
                    }
                }
                if (chkSalvaAnagrafiche.Checked)
                    bll.SalvaBC_ANAGRAFICA(_ds);

                ImpaginaMessaggioAnagrafiche(anagraficheCensite, anagraficheModificate, anagraficheNuove);

                return true;
            }
            catch (Exception ex)
            {
                messaggioErrore = ex.Message;
                return false;
            }
        }

        private void ImpaginaMessaggioAnagrafiche(List<string> anagraficheCensite, List<string> anagraficheModificate, List<string> anagraficheNuove)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NUOVE ANAGRAFICHE");
            sb.AppendLine("-----------------");
            anagraficheNuove.ForEach(x => sb.AppendLine(x));
            sb.AppendLine(string.Empty);

            sb.AppendLine("ANAGRAFICHE MODIFICATE");
            sb.AppendLine("----------------------");
            anagraficheModificate.ForEach(x => sb.AppendLine(x));
            sb.AppendLine(string.Empty);

            sb.AppendLine("ANAGRAFICHE GIA' CENSITE");
            sb.AppendLine("------------------------");
            anagraficheCensite.ForEach(x => sb.AppendLine(x));
            sb.AppendLine(string.Empty);

            txtMsgAnagrafiche.Text = sb.ToString();
        }

        private void ImpaginaMessaggioCicli(List<Ciclo> cicli)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CICLI");
            sb.AppendLine("-----");

            foreach (Ciclo c in cicli)
            {
                sb.AppendLine(c.Codice);
                foreach (Fase f in c.Fasi)
                {
                    sb.AppendLine(string.Format("        {0} {1} {2} {3}", f.Operazione, f.AreaProduzione, f.Task, f.Collegamento));
                    foreach (string commento in f.Commenti)
                    {
                        sb.AppendLine(string.Format("                {0}", commento));

                    }

                }
                sb.AppendLine(string.Empty);
            }

            txtMsgCicli.Text = sb.ToString();
        }

        private void ImpaginaMessaggioDistinte(List<Distinta> distinte)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DISTINTA");
            sb.AppendLine("--------");

            foreach (Distinta d in distinte)
            {
                sb.AppendLine(d.Codice);
                foreach (Componente c in d.Componenti)
                {
                    sb.AppendLine(string.Format("        {0} {1} ", c.Anagrafica, c.Quantita));

                }
                sb.AppendLine(string.Empty);
            }

            txtMsgDistinte.Text = sb.ToString();
        }
    }
}

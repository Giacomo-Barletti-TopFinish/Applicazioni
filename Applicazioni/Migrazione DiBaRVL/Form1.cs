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
                }

                CaricaMagazz();
                CaricaBC_Anagrafica();
                string messaggioErrore;
                if (!LeggiExcel(nomefile, Contesto.Utente.FULLNAMEUSER, tipoExcel, out messaggioErrore))
                {
                    string messaggio = string.Format("Errore nel caricamento del file excel. Errore: {0}", messaggioErrore);
                    MessageBox.Show(messaggio, "ERRORE LETTURA FILE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


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
                            messaggioErrore = messaggioErrore + "Errore nella lettura del file ";
                            return false;
                        }
                        if (!ElaboraFileExcel())
                        {
                            messaggioErrore = messaggioErrore + "Errore nella lettura del file ";
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

        private bool ElaboraFileExcel()
        {
            MigrazioneDiBaBLL bll = new MigrazioneDiBaBLL();
            _ds.DATIEXCEL.Where(x => x.IsMODELLONull()).ToList().ForEach(x => x.Delete());

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
            bll.SalvaBC_ANAGRAFICA(_ds);
            ImpaginaMessaggioAnagrafiche(anagraficheCensite, anagraficheModificate, anagraficheNuove);



            return true;
        }

        private void ImpaginaMessaggioAnagrafiche(List<string> anagraficheCensite, List<string> anagraficheModificate, List<string> anagraficheNuove)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NUOVE ANAGRAFICHE");
            sb.AppendLine("-----------------");
            anagraficheNuove.ForEach(x => sb.AppendLine(x));
            sb.AppendLine(string.Empty);

            sb.AppendLine("NUOVE MODIFICATE");
            sb.AppendLine("----------------");
            anagraficheModificate.ForEach(x => sb.AppendLine(x));
            sb.AppendLine(string.Empty);

            sb.AppendLine("NUOVE CENSITE");
            sb.AppendLine("-------------");
            anagraficheCensite.ForEach(x => sb.AppendLine(x));
            sb.AppendLine(string.Empty);

            txtMsgAnagrafiche.Text = sb.ToString();
        }
    }
}

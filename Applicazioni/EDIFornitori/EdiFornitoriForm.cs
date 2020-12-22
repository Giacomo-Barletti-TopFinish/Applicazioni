using Applicazioni.Common;
using Applicazioni.Data.EDIFornitori;
using Applicazioni.Entities;
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

namespace EDIFornitori
{
    public partial class EdiFornitoriForm : BaseForm
    {
        private EDIFornitoriDS _ds = new EDIFornitoriDS();

        public EdiFornitoriForm()
        {
            InitializeComponent();
            dgvRisultati.AutoGenerateColumns = false;

        }

        private void btnTrova_Click(object sender, EventArgs e)
        {
            try
            {
                string codiceFornitore = verificaRadioButton();
                if (string.IsNullOrEmpty(codiceFornitore))
                {
                    MessageBox.Show("Attenzione indicare l'azienda METALPLUS o TOP FINISH", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (dtDal.Value.Date > dtAl.Value.Date)
                {
                    MessageBox.Show("Attenzione la data DAL è successiva alla data AL", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (EDIFornitoriBusiness bEDI = new EDIFornitoriBusiness())
                {
                    _ds = new EDIFornitoriDS();
                    bEDI.FillBOLLE_VENDITATESTATA(_ds, dtDal.Value, dtAl.Value, codiceFornitore);
                    dgvRisultati.DataSource = _ds;
                    dgvRisultati.DataMember = _ds.BOLLE_VENDITA.TableName;
                }
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in trova bolle");
            }

        }

        private string verificaRadioButton()
        {
            if (rbMetal.Checked) return ParametriEDIFornitori.MetalPlus;
            if (rbTopFinish.Checked) return ParametriEDIFornitori.TopFinish;
            return string.Empty;
        }

        private void btnCreaFiles_Click(object sender, EventArgs e)
        {
            bool riferimentoAssente = false;
            try
            {
                List<string> idTestate = new List<string>();
                foreach (DataGridViewRow riga in dgvRisultati.Rows)
                {
                    object selezione = riga.Cells[SELEZIONATA.Index].Value;
                    if (selezione != null)
                    {
                        bool valore = (bool)selezione;
                        if (valore)
                        {
                            string idTestata = (string)riga.Cells[IDVENDITET.Index].Value;
                            idTestate.Add(idTestata);

                            if (riga.Cells[RIFERIMENTO.Index].Value == DBNull.Value)
                                riferimentoAssente = true;
                        }
                    }
                }

                if (idTestate.Count == 0)
                {
                    MessageBox.Show("Nessuna bolla selezionata", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                if (riferimentoAssente)
                {
                    MessageBox.Show("Sono state selezionate bolle prive di RIFERIMENTO. Impossibile procedere", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() != DialogResult.OK)
                    return;

                string path = fbd.SelectedPath;

                EDIFornitoriDS ds = new EDIFornitoriDS();
                string codiceFornitore = verificaRadioButton();

                using (EDIFornitoriBusiness bEDI = new EDIFornitoriBusiness())
                {
                    bEDI.FillBOLLE_VENDITA(ds, dtDal.Value, dtAl.Value, codiceFornitore);
                    bEDI.FillACCESSORISTI(ds);
                }

                StringBuilder sbMessaggio = new StringBuilder();
                idTestate = idTestate.Distinct().ToList();

                foreach (string testata in idTestate)
                {
                    EDIFornitoriDS.BOLLE_VENDITARow primoDettaglio = ds.BOLLE_VENDITA.Where(x => x.IDVENDITET == testata).FirstOrDefault();
                    string numeroddt = primoDettaglio.NUMDOC;
                    string nomefile = creaNomeFile(codiceFornitore, numeroddt);
                    string pathCompleto = path + Path.DirectorySeparatorChar + nomefile;

                    if (File.Exists(pathCompleto))
                        File.Delete(pathCompleto);

                    FileStream fs = new FileStream(pathCompleto, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    try
                    {
                        foreach (EDIFornitoriDS.BOLLE_VENDITARow dettaglio in ds.BOLLE_VENDITA.Where(x => x.IDVENDITET == testata))
                        {
                            string AccessoristaNonTrovato;
                            string riga = creaRigaFile(codiceFornitore, dettaglio, ds, out AccessoristaNonTrovato);
                            sw.WriteLine(riga);
                            sbMessaggio.AppendLine(AccessoristaNonTrovato);

                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        sw.Flush();
                        fs.Flush();
                        fs.Close();
                    }
                }

                if (sbMessaggio.ToString().Trim().Length > 0)
                {
                    sbMessaggio.Insert(0, @"I seguenti ACCESSORISTI non sono stati trovati: " + Environment.NewLine);
                    MessageBox.Show(sbMessaggio.ToString().Trim());
                }
                else
                    MessageBox.Show("Operazione terminata correttamente", "INFORMAZIONI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in fase di creazione dei file");
            }

        }

        private string creaNomeFile(string codiceFornitore, string numeroDDT)
        {

            DateTime dt = DateTime.Now;
            string day = dt.Day.ToString().PadLeft(2, '0');
            string month = dt.Month.ToString().PadLeft(2, '0');
            string year = (dt.Year % 100).ToString().PadLeft(2, '0');
            string hh = dt.Hour.ToString().PadLeft(2, '0');
            string mm = dt.Minute.ToString().PadLeft(2, '0');
            string ss = dt.Second.ToString().PadLeft(2, '0');

            if (numeroDDT.Length > 8) throw new ArgumentException("Numero DDT più lungo di 8 caratteri");
            if (codiceFornitore.Length > 6) throw new ArgumentException("Codice fornitore più lungo di 8 caratteri");

            string fornitore = codiceFornitore.PadLeft(6, '0');
            string ddt = numeroDDT.PadLeft(8, '0');

            return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}.txt", fornitore, day, month, year, hh, mm, ss, ddt);
        }

        private string creaRigaFile(string codiceFornitore, EDIFornitoriDS.BOLLE_VENDITARow dettaglio, EDIFornitoriDS ds, out string AccessoristaNonTrovato)
        {
            string codiceAzienda = "06";
            string fornitore = aggiustaStringa(codiceFornitore, 6, '0');
            string documentoRiferimento = aggiustaStringa(dettaglio.NUMDOC, 10, '0');
            string dataDocumentoRiferimento = dettaglio.DATDOC.ToString("ddMMyyyy");
            string codiceMagazzinoDestinazione = EstraiCodiceMagazzinoDestinazione(dettaglio);
            string causaleMagazzino = "  ";
            string dataCompetenza = "00000000";
            string dataDocumento = "00000000";

            string codiceGucciAccessorista = "      ";
            AccessoristaNonTrovato = String.Empty;

            EDIFornitoriDS.ACCESSORISTIRow accessorista = ds.ACCESSORISTI.Where(x => x.CODCF == dettaglio.CODICECLIFO && x.CODIND == dettaglio.CODINDSP).FirstOrDefault();
            if (accessorista != null)
                codiceGucciAccessorista = accessorista.CODICE;
            else
                AccessoristaNonTrovato = string.Format("CLIFO:{0} IND:{1}", dettaglio.CODICECLIFO, dettaglio.CODINDSP);

            string EnteCommessaGucci = "    ";
            string AnnoCommessaGucci = "    ";
            string NumeroCommessaGucci = "     ";
            string RigaCommessaGucci = " ";
            string AvanzamentoCommessaGucci = " ";
            string FaseCommessaGucci = "  ";
            string OperazioneCommessaGucci = "   ";

            string EnteOrdineFornitore = "    ";
            string AnnoOrdineFornitore = "    ";
            string NumeroOrdineFornitore = "     ";
            string RigaOrdineFornitore = "   ";

            string codiceModello = "      ";
            string codiceCombinazione = "000";
            string suffissoParte = "      ";
            string codiceParte = "     ";
            string codiceColoreParte = "     ";
            string misuraParte = "   ";

            string drop = "  ";
            string tipoVariante = " ";
            string variante = "      ";
            string cartellino = "  ";
            string etichetta = "  ";
            string codicefornitore = "      ";
            string pezza = "00000";
            string quantita = "00000000000";
            string stringaTaglie = "00";
            string progressivoTaglie = " ";
            string posizioneTaglia = "00";
            string filler = "    ";
            string descrizioneTaglia = "00000";
            string dataInizioLavorazione = "00000000";

            if (dettaglio.CODICECAUTR.Trim() == "01")
            {
                // ORDINI
                causaleMagazzino = "FM";

                EnteCommessaGucci = "    ";
                AnnoCommessaGucci = "0000";
                NumeroCommessaGucci = "00000";
                RigaCommessaGucci = " ";
                AvanzamentoCommessaGucci = " ";
                FaseCommessaGucci = "00";
                OperazioneCommessaGucci = "000";

                string[] ente = dettaglio.RIFERIMENTO.Trim().Split(' ');
                if (ente.Length == 3)
                {
                    EnteOrdineFornitore = aggiustaStringa(ente[0], 4, 'X');
                    AnnoOrdineFornitore = aggiustaStringa(ente[1], 4, 'X');
                    NumeroOrdineFornitore = aggiustaStringa(ente[2], 5, '0');
                    RigaOrdineFornitore = aggiustaStringa(dettaglio.RIFERIMENTORIGA, 3, '0');
                }

                string[] articolo = dettaglio.MODELLO.Split('-');
                if (articolo.Length == 4)
                {
                    suffissoParte = aggiustaStringa(articolo[0], 6, '0');
                    codiceParte = aggiustaStringa(articolo[1], 5, '0');
                    codiceColoreParte = aggiustaStringa(articolo[2], 5, ' ',true);
                    if (codiceColoreParte.Trim() == "MOD")
                        codiceColoreParte = "     ";
                }
                if (articolo.Length == 3)
                {
                    suffissoParte = aggiustaStringa(articolo[0], 6, '0');
                    codiceParte = aggiustaStringa(articolo[1], 5, ' ');
                    codiceColoreParte = "     ";
                }
            }
            else
            {
                // COMMESSA
                causaleMagazzino = "AV";

                //string AvanzamentoCommessaGucci = " ";  TBD
                //string FaseCommessaGucci = "00";
                //string OperazioneCommessaGucci = "000";

                string[] ente = dettaglio.RIFERIMENTO.Trim().Split(' ');
                if (ente.Length == 3)
                {
                    EnteCommessaGucci = aggiustaStringa(ente[0], 4, 'X');
                    AnnoCommessaGucci = aggiustaStringa(ente[1], 4, 'X');
                    NumeroCommessaGucci = aggiustaStringa(ente[2], 5, '0');
                    RigaCommessaGucci = aggiustaStringa(dettaglio.RIFERIMENTORIGA, 1, '0');
                }

                if (ente.Length > 3)
                {
                    EnteCommessaGucci = aggiustaStringa(ente[0], 4, 'X');
                    AnnoCommessaGucci = aggiustaStringa(ente[1], 4, 'X');
                    NumeroCommessaGucci = aggiustaStringa(ente[2], 5, '0');

                    if (ente[3].Length == 6)
                    {
                        AvanzamentoCommessaGucci = ente[3].Substring(0, 1);
                        FaseCommessaGucci = ente[3].Substring(1, 2);
                        OperazioneCommessaGucci = ente[3].Substring(3, 3);
                    }
                    RigaCommessaGucci = aggiustaStringa(dettaglio.RIFERIMENTORIGA, 1, '0');
                }

                EnteOrdineFornitore = "    ";
                AnnoOrdineFornitore = "0000";
                NumeroOrdineFornitore = "00000";
                RigaOrdineFornitore = "   ";

                string[] articolo = dettaglio.MODELLO.Split('-');
                if (articolo.Length == 4)
                {
                    suffissoParte = "      ";
                    codiceModello = aggiustaStringa(articolo[0], 6, '0');
                    codiceParte = aggiustaStringa(articolo[1], 5, '0');
                    codiceColoreParte = aggiustaStringa(articolo[2], 5, ' ',true);
                    if (codiceColoreParte.Trim() == "MOD")
                        codiceColoreParte = "     ";
                }
                if (articolo.Length == 3)
                {
                    suffissoParte = "      ";
                    codiceModello = aggiustaStringa(articolo[0], 6, '0');
                    codiceParte = aggiustaStringa(articolo[1], 5, ' ');
                    codiceColoreParte = "     ";
                }
            }
            quantita = dettaglio.QTATOT.ToString();
            quantita = quantita + "000";
            quantita = aggiustaStringa(quantita, 11, '0');

            return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}{16}{17}{18}{19}{20}{21}{22}{23}{24}{25}{26}{27}{28}{29}{30}{31}{32}{33}{34}{35}{36}{37}{38}{39}",
                codiceAzienda,
                fornitore,
                documentoRiferimento,
                dataDocumentoRiferimento,
                codiceMagazzinoDestinazione,
                causaleMagazzino,
                dataCompetenza,
                dataDocumento,
                codiceGucciAccessorista,
                EnteCommessaGucci,
                AnnoCommessaGucci,
                NumeroCommessaGucci,
                RigaCommessaGucci,
                AvanzamentoCommessaGucci,
                FaseCommessaGucci,
                OperazioneCommessaGucci,
                EnteOrdineFornitore,
                AnnoOrdineFornitore,
                NumeroOrdineFornitore,
                RigaOrdineFornitore,
                codiceModello,
                codiceCombinazione,
                suffissoParte,
                codiceParte,
                codiceColoreParte,
                misuraParte,
                drop,
                tipoVariante,
                variante,
                cartellino,
                etichetta,
                codicefornitore,
                pezza,
                quantita,
                stringaTaglie,
                progressivoTaglie,
                posizioneTaglia,
                filler,
                descrizioneTaglia,
                dataInizioLavorazione
                );
        }

        private string aggiustaStringa(string stringa, int lunghezza, char riempimento)
        {
            if (stringa.Length > lunghezza) return stringa.Substring(0, lunghezza);
            return stringa.PadLeft(lunghezza, riempimento);
        }

        private string aggiustaStringa(string stringa, int lunghezza, char riempimento, bool aDestra)
        {
            if (stringa.Length > lunghezza) return stringa.Substring(0, lunghezza);
            if (aDestra)
                return stringa.PadRight(lunghezza, riempimento);

            return aggiustaStringa(stringa, lunghezza, riempimento);

        }
        private string EstraiCodiceMagazzinoDestinazione(EDIFornitoriDS.BOLLE_VENDITARow dettaglio)
        {
            if (dettaglio.CODICECAUTR.Trim() == "01")
            {
                // ORDINI
                switch (dettaglio.CODICETIPOO.Trim())
                {
                    case "EACO":
                    case "EAMO":
                        return "TERO";
                    case "EACP":
                    case "EAMP":
                    case "EMFS":
                    case "EACS":
                        return "TERZ";
                    case "EAGV":
                    case "EAMV":
                        return "TERV";
                    default:
                        return "    ";
                }
            }
            else
            {
                // COMMESSA
                switch (dettaglio.CODICETIPOO.Trim())
                {
                    case "EACO":
                        return "TERO";
                    case "EACP":
                    case "EMFS":
                    case "EACS":
                        return "TERZ";
                    case "EAGV":
                        return "TERV";
                    default:
                        return "    ";
                }
            }
        }

        private void EdiFornitoriForm_Load(object sender, EventArgs e)
        {
        }

        private void EdiFornitoriForm_Shown(object sender, EventArgs e)
        {
            rbMetal.Checked = true;
            rbTopFinish.Checked = false;

        }
    }
}

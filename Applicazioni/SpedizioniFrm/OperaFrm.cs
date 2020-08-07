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

namespace SpedizioniFrm
{
    public partial class OperaFrm : ChildBaseForm
    {
        private string _brand;
        private SpedizioniDS _ds = new SpedizioniDS();

        private bool _inSimulazione = false;
        public OperaFrm(string Brand)
        {
            _brand = Brand;
            InitializeComponent();

            this.Text = string.Format("OPERA {0}", _brand);
        }

        private void btnCerca_Click(object sender, EventArgs e)
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
                MostraEccezione("Errore nella ricerca file", ex);
            }
        }

        private void leggiFile_click(object sender, EventArgs e)
        {
            try
            {
                btnSimula.Enabled = true;

                _inSimulazione = true;
                _ds = new SpedizioniDS();
                lblMessage.Text = string.Empty;
                if (string.IsNullOrEmpty(txtFile.Text))
                {
                    lblMessage.Text = "Selezionare un file";
                    return;
                }

                if (!File.Exists(txtFile.Text))
                {
                    lblMessage.Text = "Il file specificato non esiste";
                    return;
                }

                Spedizioni spedizioni = new Spedizioni();

                string messaggioErrore;

                if (!spedizioni.LeggiFileExcelOpera(_ds, txtFile.Text, _brand, out messaggioErrore))
                {
                    string messaggio = string.Format("Errore nel caricamento del file excel. Errore: {0}", messaggioErrore);
                    MessageBox.Show(messaggio, "ERRORE LETTURA FILE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_ds.SPOPERA.Count == 0)
                {
                    lblMessage.Text = "Il file è vuoto";
                    return;
                }

                dgvExcelCaricato.AutoGenerateColumns = true;
                //                dgvExcelCaricato.DataSource = _ds;

                caricaGriglia();



            }
            catch (Exception ex)
            {
                ExceptionFrm frm = new ExceptionFrm(ex);
                frm.ShowDialog();
            }
            finally
            {
                _inSimulazione = false;
            }
        }

        private void caricaGriglia()
        {
            DataView dataview1;
            dataview1 = _ds.SPOPERA.DefaultView;
            dataview1.Sort = "[MODELLO_CODICE] ASC, [DATA_RICHIESTA] ASC, SEQUENZA";
            dgvExcelCaricato.DataSource = dataview1;

            //                dgvExcelCaricato.DataMember = _ds.SPOPERA.TableName;
            dgvExcelCaricato.Columns[1].Visible = false;
            dgvExcelCaricato.Columns[3].Width = 200;
            dgvExcelCaricato.Columns[5].Width = 130;
            dgvExcelCaricato.Columns[7].Width = 200;
            dgvExcelCaricato.Columns[6].Visible = false;
            dgvExcelCaricato.Columns[10].Visible = false;
            dgvExcelCaricato.Columns[11].Visible = false;
            dgvExcelCaricato.Columns[12].Visible = false;
            dgvExcelCaricato.Columns[14].Visible = false;
            dgvExcelCaricato.Columns[15].Visible = false;
            dgvExcelCaricato.Columns[16].Visible = false;
            dgvExcelCaricato.Columns[17].Visible = false;

            for (int i = 0; i < dgvExcelCaricato.Columns.Count; i++)
                dgvExcelCaricato.Columns[i].ReadOnly = true;

            dgvExcelCaricato.Columns[5].ReadOnly = false;
            dgvExcelCaricato.Columns[20].ReadOnly = false;
            dgvExcelCaricato.Columns[21].ReadOnly = false;
            dgvExcelCaricato.Columns[23].ReadOnly = false;

        }

        private void OperaFrm_Load(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
        }

        private void btnSimula_Click(object sender, EventArgs e)
        {
            try
            {
                btnSimula.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;

                _inSimulazione = true;

                if (_ds.SPOPERA.Any(x => x.IsDATA_RICHIESTANull()))
                {
                    MessageBox.Show("Ci sono righe con data richiesta non valorizzata. Impossibile procedere", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSimula.Enabled = true;
                    return;
                }

                Spedizioni spedizioni = new Spedizioni();
                spedizioni.FillSaldi(_ds, string.Empty, string.Empty);
                spedizioni.FillUbicazioni(_ds, false);

                SpedizioniDS dsAlternativo = new SpedizioniDS();

                int totaleRighe = dgvExcelCaricato.Rows.Count;
                for (int indiceRighe = 0; indiceRighe < totaleRighe; indiceRighe++)
                {
                    DataGridViewRow riga = dgvExcelCaricato.Rows[indiceRighe];
                    string modello = (string)riga.Cells[7].Value;
                    decimal quantitaDaSpedire = (decimal)riga.Cells[9].Value;
                    DateTime dataRichiesta = (DateTime)riga.Cells[5].Value;
                    int righe = dgvExcelCaricato.Rows.Count;

                    SpedizioniDS.MAGAZZRow magazz = spedizioni.GetMagazz(_ds, modello);
                    if (magazz == null) continue;

                    SpedizioniDS.SPSALDIEXTRow saldoPerfetto = _ds.SPSALDIEXT.Where(x => x.QUANTITA == quantitaDaSpedire && x.IDMAGAZZ == magazz.IDMAGAZZ).FirstOrDefault();
                    if (saldoPerfetto != null)
                    {
                        string codiceUbicazione = _ds.SPUBICAZIONI.Where(x => x.IDUBICAZIONE == saldoPerfetto.IDUBICAZIONE).Select(x => x.CODICE).FirstOrDefault();

                        riga.Cells[17].Value = saldoPerfetto.IDUBICAZIONE;
                        riga.Cells[18].Value = codiceUbicazione;
                        riga.Cells[19].Value = saldoPerfetto.QUANTITA;
                        riga.Cells[20].Value = saldoPerfetto.QUANTITA;
                        riga.Cells[21].Value = 0;

                        saldoPerfetto.QUANTITA = 0;
                    }
                    else
                    {
                        bool primariga = true;
                        decimal quantitaImpegnata = 0;
                        decimal sequenza = 0;
                        List<SpedizioniDS.SPSALDIEXTRow> saldi = _ds.SPSALDIEXT.Where(x => x.QUANTITA > 0 && x.IDMAGAZZ == magazz.IDMAGAZZ).OrderBy(x => x.QUANTITA).ToList();

                        //if (saldi == 0)
                        //riga.Cells[24].Value = "Nessun articolo in giacenza";



                        while (quantitaImpegnata < quantitaDaSpedire && saldi.Count > 0)
                        {
                            sequenza++;
                            SpedizioniDS.SPSALDIEXTRow saldo = saldi[0];
                            string codiceUbicazione = _ds.SPUBICAZIONI.Where(x => x.IDUBICAZIONE == saldo.IDUBICAZIONE).Select(x => x.CODICE).FirstOrDefault();
                            decimal quantitaNecessaria = quantitaDaSpedire - quantitaImpegnata;

                            if (!primariga)
                            {

                                SpedizioniDS.SPOPERARow nuovaRiga = dsAlternativo.SPOPERA.NewSPOPERARow();
                                nuovaRiga.BRAND = string.Empty;// (string)riga.Cells[0].Value;
                                nuovaRiga.RAGIONE_SOCIALE_RIGA = string.Empty;//riga.Cells[1].Value == DBNull.Value ? string.Empty : (string)riga.Cells[1].Value;
                                nuovaRiga.STAGIONE_DESCRIZIONE_TESTATA = string.Empty;//(string)riga.Cells[2].Value;
                                nuovaRiga.RIFERIMENTO_TESTATA = string.Empty;//(string)riga.Cells[3].Value;
                                nuovaRiga.NUMERO_RIGA = string.Empty;//(string)riga.Cells[4].Value;
                                nuovaRiga.DATA_RICHIESTA = (DateTime)riga.Cells[5].Value;
                                nuovaRiga.DATA_CREAZIONE = (DateTime)riga.Cells[6].Value;
                                nuovaRiga.MODELLO_CODICE = (string)riga.Cells[7].Value;
                                nuovaRiga.DESMODELLO = (string)riga.Cells[8].Value;
                                nuovaRiga.QTANOSPE = (decimal)riga.Cells[9].Value;
                                nuovaRiga.PREZZO_UNITARIO = (decimal)riga.Cells[10].Value;
                                nuovaRiga.QTAACCESI = (decimal)riga.Cells[11].Value;
                                nuovaRiga.QTAEST = (decimal)riga.Cells[12].Value;
                                nuovaRiga.QTATOT = (decimal)riga.Cells[13].Value;
                                nuovaRiga.QTAACCCON = (decimal)riga.Cells[14].Value;
                                nuovaRiga.QTANOACC = (decimal)riga.Cells[15].Value;
                                nuovaRiga.QTASPE = (decimal)riga.Cells[16].Value;

                                nuovaRiga.IDUBICAZIONE = saldo.IDUBICAZIONE;
                                nuovaRiga.CODICE = codiceUbicazione;
                                nuovaRiga.QTAUBI = saldo.QUANTITA;
                                nuovaRiga.SEQUENZA = sequenza;
                                nuovaRiga.VALIDATA = false;

                                if (quantitaNecessaria > saldo.QUANTITA)
                                {
                                    nuovaRiga.QTAUBIUTIL = saldo.QUANTITA;
                                    quantitaImpegnata += saldo.QUANTITA;
                                    nuovaRiga.QTAUBIRES = 0;
                                    saldo.QUANTITA = 0;
                                }
                                else
                                {
                                    nuovaRiga.QTAUBIUTIL = quantitaNecessaria;
                                    quantitaImpegnata += quantitaNecessaria;
                                    nuovaRiga.QTAUBIRES = saldo.QUANTITA - quantitaNecessaria;
                                    saldo.QUANTITA = saldo.QUANTITA - quantitaNecessaria;
                                }
                                dsAlternativo.SPOPERA.AddSPOPERARow(nuovaRiga);
                                //aggiungi riga
                            }
                            else
                            {
                                primariga = false;
                                riga.Cells[17].Value = saldo.IDUBICAZIONE;
                                riga.Cells[18].Value = codiceUbicazione;
                                riga.Cells[19].Value = saldo.QUANTITA;

                                if (quantitaNecessaria > saldo.QUANTITA)
                                {
                                    riga.Cells[20].Value = saldo.QUANTITA;
                                    quantitaImpegnata += saldo.QUANTITA;
                                    riga.Cells[21].Value = 0;
                                    saldo.QUANTITA = 0;
                                }
                                else
                                {
                                    riga.Cells[20].Value = quantitaNecessaria;
                                    quantitaImpegnata += quantitaNecessaria;
                                    riga.Cells[21].Value = saldo.QUANTITA - quantitaNecessaria;
                                    saldo.QUANTITA = saldo.QUANTITA - quantitaNecessaria;
                                }

                            }
                            saldi = _ds.SPSALDIEXT.Where(x => x.QUANTITA > 0 && x.IDMAGAZZ == magazz.IDMAGAZZ).OrderBy(x => x.QUANTITA).ToList();
                        }
                    }

                }
                foreach (SpedizioniDS.SPOPERARow riga in dsAlternativo.SPOPERA)
                    _ds.SPOPERA.ImportRow(riga);

                caricaGriglia();
            }
            catch (Exception ex)
            {
                ExceptionFrm frm = new ExceptionFrm(ex);
                frm.ShowDialog();
                btnSimula.Enabled = true;

            }

            finally
            {
                Cursor.Current = Cursors.Default;
                _inSimulazione = false;
            }

        }

        private void dgvExcelCaricato_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (_inSimulazione) return;
            try
            {
                _inSimulazione = true;

                if (e.ColumnIndex < 19 || e.ColumnIndex > 22) return;
                if (dgvExcelCaricato.Rows[e.RowIndex].Cells[19].Value == DBNull.Value) return;
                if (dgvExcelCaricato.Rows[e.RowIndex].Cells[20].Value == DBNull.Value) return;
                if (dgvExcelCaricato.Rows[e.RowIndex].Cells[21].Value == DBNull.Value) return;

                bool validata = (bool)dgvExcelCaricato.Rows[e.RowIndex].Cells[23].Value;

                decimal valoreUbicato = (decimal)dgvExcelCaricato.Rows[e.RowIndex].Cells[19].Value;
                decimal valoreUtilizzato = (decimal)dgvExcelCaricato.Rows[e.RowIndex].Cells[20].Value;
                decimal valoreResiduo = (decimal)dgvExcelCaricato.Rows[e.RowIndex].Cells[21].Value;
                decimal sequenzaRiga = (decimal)dgvExcelCaricato.Rows[e.RowIndex].Cells[22].Value;

                Spedizioni spedizioni = new Spedizioni();
                string modello = (string)dgvExcelCaricato.Rows[e.RowIndex].Cells[7].Value;
                SpedizioniDS.MAGAZZRow magazz = spedizioni.GetMagazz(_ds, modello);
                if (magazz == null) return;

                DateTime dataRichiesta = (DateTime)dgvExcelCaricato.Rows[e.RowIndex].Cells[5].Value;

                decimal idUbicazione = (decimal)dgvExcelCaricato.Rows[e.RowIndex].Cells[17].Value;
                SpedizioniDS.SPSALDIEXTRow saldo = _ds.SPSALDIEXT.Where(x => x.IDMAGAZZ == magazz.IDMAGAZZ && x.IDUBICAZIONE == idUbicazione).FirstOrDefault();
                if (saldo == null) return;

                SpedizioniDS dsAlternativo = new SpedizioniDS();
                decimal valoreUtilizzatoVecchio = 0;
                if (e.ColumnIndex == 20)
                {
                    valoreUtilizzatoVecchio = valoreUbicato - valoreResiduo;
                    if (valoreUtilizzatoVecchio == valoreUtilizzato) return;

                    if ((valoreUbicato - valoreUtilizzato) >= 0 && !validata)
                    {
                        valoreResiduo = valoreUbicato - valoreUtilizzato;
                        saldo.QUANTITA += valoreUtilizzatoVecchio - valoreUtilizzato;
                    }
                    else
                        valoreUtilizzato = valoreUtilizzatoVecchio;

                }

                if (e.ColumnIndex == 21)
                {
                    decimal valoreResiduoVecchio = valoreUbicato - valoreUtilizzato;
                    if (valoreResiduoVecchio == valoreResiduo) return;
                    valoreUtilizzatoVecchio = valoreUtilizzato;
                    if ((valoreUbicato - valoreResiduo) >= 0 && !validata)
                    {
                        valoreUtilizzato = valoreUbicato - valoreResiduo;
                        saldo.QUANTITA += valoreUtilizzatoVecchio - valoreUtilizzato;
                    }
                    else
                        valoreResiduo = valoreUbicato - valoreUtilizzato;

                }

                dgvExcelCaricato.Rows[e.RowIndex].Cells[20].Value = valoreUtilizzato;
                dgvExcelCaricato.Rows[e.RowIndex].Cells[21].Value = valoreResiduo;

                ricalcolaFratelli(dsAlternativo, dataRichiesta, modello, sequenzaRiga, magazz.IDMAGAZZ);
                //         if (valoreUtilizzatoVecchio - valoreUtilizzato < 0)
                //  {

                List<SpedizioniDS.SPOPERARow> altreUbicazioni = _ds.SPOPERA.Where(x => !x.IsIDUBICAZIONENull() && x.IDUBICAZIONE == idUbicazione && x.MODELLO_CODICE == modello && x.DATA_RICHIESTA != dataRichiesta && x.SEQUENZA == 1).ToList();
                if (altreUbicazioni.Count == 0) return;

                foreach (SpedizioniDS.SPOPERARow altraUbicazione in altreUbicazioni)
                    ricalcolaFratelli(dsAlternativo, altraUbicazione.DATA_RICHIESTA, modello, 0, magazz.IDMAGAZZ);

                foreach (SpedizioniDS.SPOPERARow riga in dsAlternativo.SPOPERA)
                    _ds.SPOPERA.ImportRow(riga);

                caricaGriglia();

                //  }
            }
            catch (Exception ex)
            {
                ExceptionFrm frm = new ExceptionFrm(ex);
                frm.ShowDialog();
            }

            finally
            {
                _inSimulazione = false;
            }


        }

        private void ricalcolaFratelli(SpedizioniDS dsAlternativo, DateTime dataRichiesta, string modello, decimal sequenza, string idmagazz)
        {
            decimal quantitaImpegnata = 0;
            List<SpedizioniDS.SPOPERARow> fratelli = _ds.SPOPERA.Where(x => x.MODELLO_CODICE == modello && x.DATA_RICHIESTA == dataRichiesta).ToList();
            if (fratelli.Count == 0) return;

            SpedizioniDS.SPOPERARow rigaOperaGenerica = fratelli[0];
            decimal quantitaDaSpedire = fratelli[0].QTANOSPE;
            decimal quantitaNecessaria = quantitaDaSpedire - quantitaImpegnata;
            for (int i = 0; i < fratelli.Count; i++)
            {
                if (fratelli[i].SEQUENZA <= sequenza)
                {
                    quantitaImpegnata += fratelli[i].QTAUBIUTIL;
                    quantitaNecessaria = quantitaDaSpedire - quantitaImpegnata;
                }

                //if (fratelli[i].SEQUENZA == sequenza && !fratelli[i].VALIDATA)
                //{
                //    SpedizioniDS.SPSALDIEXTRow saldo = _ds.SPSALDIEXT.Where(x => x.IDMAGAZZ == idmagazz && x.IDUBICAZIONE == idUbicazione).FirstOrDefault();
                //    if (saldo == null) return;
                //    saldo.QUANTITA += fratelli[i].QTAUBIUTIL;
                //    fratelli[i].QTAUBI = saldo.QUANTITA;

                //    if (quantitaNecessaria > saldo.QUANTITA)
                //    {
                //        fratelli[i].QTAUBIUTIL = saldo.QUANTITA;
                //        quantitaImpegnata += saldo.QUANTITA;
                //        fratelli[i].QTAUBIRES = 0;
                //        saldo.QUANTITA = 0;
                //    }
                //    else
                //    {
                //        fratelli[i].QTAUBIUTIL = quantitaNecessaria;
                //        quantitaImpegnata += quantitaNecessaria;
                //        fratelli[i].QTAUBIRES = saldo.QUANTITA - quantitaNecessaria;
                //        saldo.QUANTITA = saldo.QUANTITA - quantitaNecessaria;
                //    }
                //}

                if (fratelli[i].SEQUENZA > sequenza && !fratelli[i].VALIDATA)
                {
                    SpedizioniDS.SPSALDIEXTRow saldoRiga = _ds.SPSALDIEXT.Where(x => x.IDUBICAZIONE == fratelli[i].IDUBICAZIONE && x.IDMAGAZZ == idmagazz).FirstOrDefault();
                    if (saldoRiga == null) return;

                    saldoRiga.QUANTITA += fratelli[i].QTAUBIUTIL;
                    fratelli[i].QTAUBI = saldoRiga.QUANTITA;

                    if (quantitaNecessaria > saldoRiga.QUANTITA)
                    {
                        fratelli[i].QTAUBIUTIL = saldoRiga.QUANTITA;
                        quantitaImpegnata += saldoRiga.QUANTITA;
                        fratelli[i].QTAUBIRES = 0;
                        saldoRiga.QUANTITA = 0;
                    }
                    else
                    {
                        fratelli[i].QTAUBIUTIL = quantitaNecessaria;
                        quantitaImpegnata += quantitaNecessaria;
                        fratelli[i].QTAUBIRES = saldoRiga.QUANTITA - quantitaNecessaria;
                        saldoRiga.QUANTITA = saldoRiga.QUANTITA - quantitaNecessaria;
                    }
                }
            }
            int sequenzaAggiuntiva = fratelli.Count;

            if (quantitaImpegnata < quantitaDaSpedire)
            {
                List<SpedizioniDS.SPSALDIEXTRow> saldi = _ds.SPSALDIEXT.Where(x => x.QUANTITA > 0 && x.IDMAGAZZ == idmagazz).OrderBy(x => x.QUANTITA).ToList();
                while (quantitaImpegnata < quantitaDaSpedire && saldi.Count > 0)
                {
                    sequenzaAggiuntiva++;

                    SpedizioniDS.SPOPERARow nuovaRiga = dsAlternativo.SPOPERA.NewSPOPERARow();
                    nuovaRiga.BRAND = string.Empty;// (string)riga.Cells[0].Value;
                    nuovaRiga.RAGIONE_SOCIALE_RIGA = string.Empty;//riga.Cells[1].Value == DBNull.Value ? string.Empty : (string)riga.Cells[1].Value;
                    nuovaRiga.STAGIONE_DESCRIZIONE_TESTATA = string.Empty;//(string)riga.Cells[2].Value;
                    nuovaRiga.RIFERIMENTO_TESTATA = string.Empty;//(string)riga.Cells[3].Value;
                    nuovaRiga.NUMERO_RIGA = string.Empty;//(string)riga.Cells[4].Value;
                    nuovaRiga.DATA_RICHIESTA = rigaOperaGenerica.DATA_RICHIESTA;
                    nuovaRiga.DATA_CREAZIONE = rigaOperaGenerica.DATA_CREAZIONE;
                    nuovaRiga.MODELLO_CODICE = rigaOperaGenerica.MODELLO_CODICE;
                    nuovaRiga.DESMODELLO = rigaOperaGenerica.DESMODELLO;
                    nuovaRiga.QTANOSPE = rigaOperaGenerica.QTANOSPE;
                    nuovaRiga.PREZZO_UNITARIO = rigaOperaGenerica.PREZZO_UNITARIO;
                    nuovaRiga.QTAACCESI = rigaOperaGenerica.QTAACCESI;
                    nuovaRiga.QTAEST = rigaOperaGenerica.QTAEST;
                    nuovaRiga.QTATOT = rigaOperaGenerica.QTATOT;
                    nuovaRiga.QTAACCCON = rigaOperaGenerica.QTAACCCON;
                    nuovaRiga.QTANOACC = rigaOperaGenerica.QTANOACC;
                    nuovaRiga.QTASPE = rigaOperaGenerica.QTASPE;

                    nuovaRiga.IDUBICAZIONE = saldi[0].IDUBICAZIONE;
                    string codiceUbicazione = _ds.SPUBICAZIONI.Where(x => x.IDUBICAZIONE == saldi[0].IDUBICAZIONE).Select(x => x.CODICE).FirstOrDefault();
                    nuovaRiga.CODICE = codiceUbicazione;
                    nuovaRiga.QTAUBI = saldi[0].QUANTITA;
                    nuovaRiga.SEQUENZA = sequenzaAggiuntiva;
                    nuovaRiga.VALIDATA = false;

                    if (quantitaNecessaria > saldi[0].QUANTITA)
                    {
                        nuovaRiga.QTAUBIUTIL = saldi[0].QUANTITA;
                        quantitaImpegnata += saldi[0].QUANTITA;
                        nuovaRiga.QTAUBIRES = 0;
                        saldi[0].QUANTITA = 0;
                    }
                    else
                    {
                        nuovaRiga.QTAUBIUTIL = quantitaNecessaria;
                        quantitaImpegnata += quantitaNecessaria;
                        nuovaRiga.QTAUBIRES = saldi[0].QUANTITA - quantitaNecessaria;
                        saldi[0].QUANTITA = saldi[0].QUANTITA - quantitaNecessaria;
                    }
                    dsAlternativo.SPOPERA.AddSPOPERARow(nuovaRiga);
                    saldi = _ds.SPSALDIEXT.Where(x => x.QUANTITA > 0 && x.IDMAGAZZ == idmagazz).OrderBy(x => x.QUANTITA).ToList();
                    //aggiungi riga
                }
            }

        }

        private void btnCreaOpera_Click(object sender, EventArgs e)
        {
            try
            {
                List<SpedizioniDS.SPOPERARow> righeDaSalvare = _ds.SPOPERA.Where(x => x.VALIDATA && !x.IsIDUBICAZIONENull()).ToList();

                if (righeDaSalvare.Count == 0)
                {
                    MessageBox.Show("NESSUNA RIGA VALIDATA. Non ci sono righe da salvare.", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SpedizioniDS dsSalvataggi = new SpedizioniDS();
                Spedizioni spedizioni = new Spedizioni();

                foreach (SpedizioniDS.SPOPERARow rigaDaSalvare in righeDaSalvare)
                {
                    dsSalvataggi.SPSALDI.Clear();
                    spedizioni.FillSaldi(dsSalvataggi, rigaDaSalvare.CODICE, rigaDaSalvare.MODELLO_CODICE);
                    SpedizioniDS.MAGAZZRow magazz = spedizioni.GetMagazz(_ds, rigaDaSalvare.MODELLO_CODICE);

                    SpedizioniDS.SPSALDIEXTRow saldo = dsSalvataggi.SPSALDIEXT.Where(x => x.IDUBICAZIONE == rigaDaSalvare.IDUBICAZIONE && x.IDMAGAZZ == magazz.IDMAGAZZ).FirstOrDefault();
                    if (saldo == null)
                    {
                        rigaDaSalvare.NOTE = string.Format("Errore nell'estrazione del saldo. CODICE = {0} MODELLO = {1}", rigaDaSalvare.CODICE, magazz.MODELLO);
                        continue;
                    }

                    if (saldo.QUANTITA < rigaDaSalvare.QTAUBIUTIL)
                    {
                        rigaDaSalvare.NOTE = string.Format("Errore quantità in saldo non sufficiente. CODICE = {0} MODELLO= {1}", rigaDaSalvare.CODICE, magazz.MODELLO);

                        continue;
                    }

                    decimal quantitaUtilizzata = rigaDaSalvare.QTAUBIUTIL;
                    if (saldo.QUANTITA < quantitaUtilizzata)
                    {
                        rigaDaSalvare.NOTE = string.Format("Errore quantità in saldo non sufficiente. CODICE = {0} MODELLO= {1}", rigaDaSalvare.CODICE, magazz.MODELLO);
                        continue;
                    }

                    string causale = string.Format("OPERA {0} - {1}", _brand, rigaDaSalvare.DATA_RICHIESTA.ToShortDateString());
                    rigaDaSalvare.NOTE = spedizioni.Movimenta(dsSalvataggi, saldo.IDSALDO, quantitaUtilizzata, causale, "PRELIEVO", _utenteConnesso);
                }

                if (righeDaSalvare.Count > 0)
                    CreaFileExcelOpera(righeDaSalvare);
            }
            catch (Exception ex)
            {
                ExceptionFrm frm = new ExceptionFrm(ex);
                frm.ShowDialog();
            }

        }
        private void CreaFileExcelOpera(List<SpedizioniDS.SPOPERARow> righeDaSalvare)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
            sfd.DefaultExt = "xlsx";
            sfd.AddExtension = true;
            sfd.FileName = string.Format("OPERA {0} {1}.xlsx", _brand, DateTime.Today.ToString("dd.MM.yyyy"));
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExcelHelper excel = new ExcelHelper();
                byte[] file = excel.CreaExcelOpera(righeDaSalvare);

                FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                try
                {
                    fs.Write(file, 0, file.Length);
                    fs.Flush();

                }
                finally
                {
                    fs.Close();
                }
            }

        }

    }
}

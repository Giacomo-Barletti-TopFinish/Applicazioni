using Applicazioni.BLL;
using Applicazioni.Common;
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
                _inSimulazione = true;
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
                        while (quantitaImpegnata < quantitaDaSpedire && saldi.Count > 0)
                        {
                            sequenza++;
                            SpedizioniDS.SPSALDIEXTRow saldo = saldi[0];
                            string codiceUbicazione = _ds.SPUBICAZIONI.Where(x => x.IDUBICAZIONE == saldo.IDUBICAZIONE).Select(x => x.CODICE).FirstOrDefault();
                            decimal quantitaNecessaria = quantitaDaSpedire - quantitaImpegnata;

                            if (!primariga)
                            {

                                SpedizioniDS.SPOPERARow nuovaRiga = _ds.SPOPERA.NewSPOPERARow();
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
            finally
            {
                _inSimulazione = false;
            }

        }

        private void dgvExcelCaricato_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 19 || e.ColumnIndex > 22) return;
            if (dgvExcelCaricato.Rows[e.RowIndex].Cells[19].Value == DBNull.Value) return;
            if (dgvExcelCaricato.Rows[e.RowIndex].Cells[20].Value == DBNull.Value) return;
            if (dgvExcelCaricato.Rows[e.RowIndex].Cells[21].Value == DBNull.Value) return;

            bool validata = (bool)dgvExcelCaricato.Rows[e.RowIndex].Cells[23].Value;

            decimal valoreUbicato = (decimal)dgvExcelCaricato.Rows[e.RowIndex].Cells[19].Value;
            decimal valoreUtilizzato = (decimal)dgvExcelCaricato.Rows[e.RowIndex].Cells[20].Value;
            decimal valoreResiduo = (decimal)dgvExcelCaricato.Rows[e.RowIndex].Cells[21].Value;

            Spedizioni spedizioni = new Spedizioni();
            string modello = (string)dgvExcelCaricato.Rows[e.RowIndex].Cells[7].Value;
            SpedizioniDS.MAGAZZRow magazz = spedizioni.GetMagazz(_ds, modello);
            if (magazz == null) return;

            decimal idUbicazione = (decimal)dgvExcelCaricato.Rows[e.RowIndex].Cells[17].Value;
            SpedizioniDS.SPSALDIEXTRow saldo = _ds.SPSALDIEXT.Where(x => x.IDMAGAZZ == magazz.IDMAGAZZ && x.IDUBICAZIONE == idUbicazione).FirstOrDefault();
            if (saldo == null) return;



            if (e.ColumnIndex == 20)
            {
                decimal valoreUtilizzatoVecchio = valoreUbicato - valoreResiduo;
                if ((valoreUbicato - valoreUtilizzato) > 0 && !validata)
                {
                    valoreResiduo = valoreUbicato - valoreUtilizzato;
                    saldo.QUANTITA = valoreUtilizzatoVecchio - valoreUtilizzato;
                }
                else
                    valoreUtilizzato = valoreUtilizzatoVecchio;

            }

            if (e.ColumnIndex == 21)
            {
                decimal valoreUtilizzatoVecchio = valoreUtilizzato;
                if ((valoreUbicato - valoreResiduo) > 0 && !validata)
                {
                    valoreUtilizzato = valoreUbicato - valoreResiduo;
                    saldo.QUANTITA = valoreUtilizzatoVecchio - valoreUtilizzato;
                }
                else
                    valoreResiduo = valoreUbicato - valoreUtilizzato;

            }

            dgvExcelCaricato.Rows[e.RowIndex].Cells[20].Value = valoreUtilizzato;
            dgvExcelCaricato.Rows[e.RowIndex].Cells[21].Value = valoreResiduo;

            if (saldo.QUANTITA < 0)
            {
                // c'è da rivedere la simulazione





            }

        }
    }
}

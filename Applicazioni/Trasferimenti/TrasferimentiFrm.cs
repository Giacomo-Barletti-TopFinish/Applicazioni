using Applicazioni.BLL;
using Applicazioni.Common;
using Applicazioni.Data.Trasferimenti;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trasferimenti
{
    public partial class TrasferimentiFrm : Form
    {
        private bool _inRicezione;

        private TrasferimentiDS _ds;
        private DataSet _dsGriglia = new DataSet();
        private string _tabellaGriglia = "Griglia";
        TrasferimentiDS.AP_TTRASFERIMENTIRow _trasferimentoInCorso;
        private Anagrafica _anagrafica = new Anagrafica();

        private void ImpostaInRicezione(bool valore)
        {
            _inRicezione = valore;
            if (valore)
                txtLedInTrasferimento.BackColor = Color.Green;
            else
                txtLedInTrasferimento.BackColor = SystemColors.Control;

        }

        public TrasferimentiFrm()
        {
            InitializeComponent();
        }
        protected void MostraEccezione(Exception ex, string messaggioLog)
        {
            ExceptionFrm frm = new ExceptionFrm(ex);
            frm.ShowDialog();
        }
        private void TrasferimentiFrm_Load(object sender, EventArgs e)
        {
            txtBarcode.Focus();
            lblMessaggi.Text = string.Empty;
            _ds = new TrasferimentiDS();
            using (TrasferimentiBusiness bTrasferimenti = new TrasferimentiBusiness())
            {
                bTrasferimenti.FillUSR_PRD_TIPOMOVFASI(_ds);
            }

            CreaDSGriglia();
            CreaGriglia();
            ImpostaInRicezione(false);
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblMessaggi.Text = string.Empty;
                string barcode = txtBarcode.Text;
                txtBarcode.Text = string.Empty;
                ElaboraBarcode(barcode);
            }

        }

        private void ElaboraBarcode(string barcode)
        {
            try
            {
                string tipoBarcode = barcode.Substring(0, 3);
                switch (tipoBarcode)
                {
                    case "RSF":
                        if (_dsGriglia.Tables[_tabellaGriglia].Rows.Count > 0)
                        {
                            if (!_inRicezione)
                            {
                                string messaggio = string.Format("Assegno questi documenti all'operatore con barcode {0}", barcode);
                                if (MessageBox.Show(messaggio, "ASSEGNAZIONE DOCUMENTI", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                {
                                    if (VerificaEsistenzaTrasferimento(barcode))
                                    {
                                        SalvaTrasferimento(barcode);
                                        lblMessaggi.Text = "TRASFERIMENTO REGISTRATO CON SUCCESSO";
                                        PulisciArchivi();
                                        ImpostaInRicezione(false);
                                    }
                                    else
                                    {
                                        lblMessaggi.Text = "ESISTE GIA' UN TRASFERIMENTO ATTIVO PER QUESTO OPERATORE";
                                    }
                                }
                            }
                            else
                            {
                                if(_trasferimentoInCorso.BARCODE_PARTENZA==barcode)
                                {
                                    lblMessaggi.Text = "IL BARCODE DI DESTINAZIONE E' LO STESSO DI QUELLO DI PARTENZA";
                                    return;
                                }

                                if (VerificaEsistenzaTrasferimento(barcode))
                                {
                                    ChiudiTrasferimento(barcode);
                                    lblMessaggi.Text = "TRASFERIMENTO REGISTRATO CON SUCCESSO";
                                    PulisciArchivi();
                                    ImpostaInRicezione(false);
                                }
                                else
                                {
                                    lblMessaggi.Text = "ESISTE GIA' UN TRASFERIMENTO ATTIVO PER QUESTO OPERATORE";
                                }
                            }
                        }
                        else
                        {
                            PulisciArchivi();
                            CaricaTrasferimentoDaBarcodePartenza(barcode);
                        }
                        break;
                    case "ODP":
                    case "ODL":
                    case "ODU":
                    case "RRF":
                    case "ODM":
                    case "ODS":
                        if (_inRicezione)
                        {
                            lblMessaggi.Text = "IN RICEZIONE TRASFERIMENTO non è possibile aggiungere ODL";
                            return;
                        }
                        if (VerificaBarcode(barcode))
                            CaricaODL(barcode);
                        break;
                }
                txtBarcode.Focus();
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in elabora barcode");
            }
        }

        private void ChiudiTrasferimento(string barcode)
        {
            _trasferimentoInCorso.BARCODE_ARRIVO = barcode;
            _trasferimentoInCorso.DATA_ARRIVO = DateTime.Now;
            using (TrasferimentiBusiness bTrasferimenti = new TrasferimentiBusiness())
                bTrasferimenti.SalvaTrasferimenti(_ds);
        }
        private bool VerificaEsistenzaTrasferimento(string barcode)
        {
            using (TrasferimentiBusiness bTrasferimenti = new TrasferimentiBusiness())
            {
                bTrasferimenti.FillAP_TTRASFERIMENTIDaBarcodePartenza(_ds, barcode);
                return !_ds.AP_TTRASFERIMENTI.Any(x => x.BARCODE_PARTENZA == barcode && x.IsBARCODE_ARRIVONull());
            }
        }
        private void CaricaTrasferimentoDaBarcodePartenza(string barcode)
        {
            using (TrasferimentiBusiness bTrasferimenti = new TrasferimentiBusiness())
            {
                bTrasferimenti.FillAP_TTRASFERIMENTIDaBarcodePartenza(_ds, barcode);
                List<TrasferimentiDS.AP_TTRASFERIMENTIRow> trasferimenti = _ds.AP_TTRASFERIMENTI.Where(x => x.BARCODE_PARTENZA == barcode && x.IsBARCODE_ARRIVONull()).ToList();
                if (trasferimenti.Count == 0)
                {
                    lblMessaggi.Text = "NESSUN TRASFERIMENTO ATTIVO ASSOCIATO A QUESTO OPERATORE";
                    ImpostaInRicezione(false);
                    return;
                }
                if (trasferimenti.Count > 1)
                {
                    lblMessaggi.Text = "CI SONO DUE O PIU' TRASFERIMENTI ASSICIATI A QUESTO OPERATORE";
                    ImpostaInRicezione(false);
                    return;
                }
                _trasferimentoInCorso = trasferimenti[0];
                bTrasferimenti.FillAP_DTRASFERIMENTIDaIDTRASFERIMENTO(_ds, _trasferimentoInCorso.IDTRASFERIMENTO);

                List<string> barcodeOdl = _ds.AP_DTRASFERIMENTI.Where(x => x.IDTRASFERIMENTO == _trasferimentoInCorso.IDTRASFERIMENTO).Select(x => x.BARCODE_ODL).ToList();

                foreach (string odl in barcodeOdl)
                    CaricaODL(odl);

                ImpostaInRicezione(true);
            }
        }

        private void SalvaTrasferimento(string barcode)
        {
            using (TrasferimentiBusiness bTrasferimenti = new TrasferimentiBusiness())
            {
                TrasferimentiDS.AP_TTRASFERIMENTIRow trasferimento = _ds.AP_TTRASFERIMENTI.NewAP_TTRASFERIMENTIRow();
                trasferimento.IDTRASFERIMENTO = bTrasferimenti.GetID();
                trasferimento.BARCODE_PARTENZA = barcode;
                trasferimento.DATA_PARTENZA = DateTime.Now;
                trasferimento.ATTIVO = 1;
                _ds.AP_TTRASFERIMENTI.AddAP_TTRASFERIMENTIRow(trasferimento);

                foreach (DataGridViewRow riga in dgvTrasferimenti.Rows)
                {
                    TrasferimentiDS.AP_DTRASFERIMENTIRow destinazione = _ds.AP_DTRASFERIMENTI.NewAP_DTRASFERIMENTIRow();
                    destinazione.IDDTRASFERIMENTO = bTrasferimenti.GetID();
                    destinazione.IDTRASFERIMENTO = trasferimento.IDTRASFERIMENTO;
                    destinazione.BARCODE_ODL = riga.Cells[(int)colonneGriglia.BARCODE].Value.ToString();
                    destinazione.NUMMOVFASE = riga.Cells[(int)colonneGriglia.NUMMOVFASE].Value.ToString();
                    destinazione.REPARTO = riga.Cells[(int)colonneGriglia.REPARTO].Value.ToString();
                    destinazione.MODELLO = riga.Cells[(int)colonneGriglia.MODELLO].Value.ToString();
                    destinazione.QTA = (decimal)riga.Cells[(int)colonneGriglia.QUANTITA].Value;
                    _ds.AP_DTRASFERIMENTI.AddAP_DTRASFERIMENTIRow(destinazione);
                }
                bTrasferimenti.SalvaTrasferimenti(_ds);
            }
        }

        private bool VerificaBarcode(string barcode)
        {
            if (_ds.USR_PRD_MOVFASI.Any(x => x.BARCODE == barcode))
            {
                lblMessaggi.Text = "BARCODE GIA' INSERITO";
                return false;
            }
            return true;
        }
        private void CaricaODL(string barcode)
        {
            using (TrasferimentiBusiness bTrasferimenti = new TrasferimentiBusiness())
            {
                if (!_ds.USR_PRD_MOVFASI.Any(x => x.BARCODE == barcode))
                    bTrasferimenti.FillUSR_PRD_MOVFASI(_ds, barcode);

                TrasferimentiDS.USR_PRD_MOVFASIRow odl = _ds.USR_PRD_MOVFASI.Where(x => x.BARCODE == barcode).FirstOrDefault();
                if (odl == null)
                {
                    lblMessaggi.Text = "BARCODE NON TROVATO";
                    return;
                }
                AnagraficaDS.MAGAZZRow articolo = _anagrafica.GetMAGAZZ(odl.IDMAGAZZ);

                DataTable dtGriglia = _dsGriglia.Tables[_tabellaGriglia];

                DataRow riga = dtGriglia.NewRow();

                riga[(int)colonneGriglia.BARCODE] = odl.IsBARCODENull() ? string.Empty : odl.BARCODE;
                riga[(int)colonneGriglia.MODELLO] = articolo == null ? string.Empty : articolo.MODELLO;
                riga[(int)colonneGriglia.NUMMOVFASE] = odl.IsNUMMOVFASENull() ? string.Empty : odl.NUMMOVFASE;
                riga[(int)colonneGriglia.REPARTO] = odl.IsCODICECLIFODESTNull() ? string.Empty : odl.CODICECLIFODEST;
                riga[(int)colonneGriglia.QUANTITA] = odl.QTA;

                dtGriglia.Rows.Add(riga);

            }
        }
        enum colonneGriglia { BARCODE, NUMMOVFASE, REPARTO, MODELLO, QUANTITA }
        private void CreaDSGriglia()
        {
            DataTable dtGriglia = _dsGriglia.Tables.Add();
            dtGriglia.TableName = _tabellaGriglia;

            int numeroColonne = Enum.GetNames(typeof(colonneGriglia)).Length;
            for (int i = 0; i < numeroColonne; i++)
            {
                string colonna = Enum.GetName(typeof(colonneGriglia), i);
                switch (i)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        dtGriglia.Columns.Add(colonna, Type.GetType("System.String"));
                        break;
                    case 4:
                        dtGriglia.Columns.Add(colonna, Type.GetType("System.Decimal"));
                        break;
                }
            }
        }

        private void CreaGriglia()
        {
            dgvTrasferimenti.DataSource = _dsGriglia;
            dgvTrasferimenti.DataMember = _tabellaGriglia;

            dgvTrasferimenti.Columns[(int)colonneGriglia.BARCODE].Width = 150;
            dgvTrasferimenti.Columns[(int)colonneGriglia.NUMMOVFASE].Width = 150;
            dgvTrasferimenti.Columns[(int)colonneGriglia.REPARTO].Width = 120;
            dgvTrasferimenti.Columns[(int)colonneGriglia.MODELLO].Width = 200;
            dgvTrasferimenti.Columns[(int)colonneGriglia.QUANTITA].Width = 100;
        }

        private void btnPulisci_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = string.Empty;
            lblMessaggi.Text = string.Empty;
            PulisciArchivi();
            ImpostaInRicezione(false);
            txtBarcode.Focus();
        }
        private void PulisciArchivi()
        {
            _dsGriglia.Tables[_tabellaGriglia].Clear();
            _ds.USR_PRD_MOVFASI.Clear();
            _ds.AP_TTRASFERIMENTI.Clear();
            _ds.AP_DTRASFERIMENTI.Clear();
        }
    }
}

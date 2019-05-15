using Applicazioni.BLL;
using Applicazioni.Data.Anagrafica;
using Applicazioni.Data.Preventivi;
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

namespace Preventivi
{
    public partial class BalenciagaFrm : BaseChildForm
    {
        private PreventiviDS.USR_VENDITEPFRow _IDVENDITEPF;
        private PreventiviDS.USR_VENDITEPDRow _IDVENDITEPD;

        private DataSet _dsGrigliaDettaglio = new DataSet();
        private string _tabellaGrigliaDettaglio = "grigliaDettaglio";

        private string _IDVENDITEPFDIBA;
        private PreventiviDS _dsPreventivi = new PreventiviDS();
        private Anagrafica anagrafica = new Anagrafica();

        public BalenciagaFrm()
        {
            InitializeComponent();
        }

        private void BalenciagaFrm_Load(object sender, EventArgs e)
        {
            txtRiferimento.Focus();
            CreaDSGrigliaDettaglio();
        }

        private void btnTrova_Click(object sender, EventArgs e)
        {
            try
            {
                string filtro = Properties.Settings.Default.FiltroBalenciaga;
                RicercaPreventiviFrm frm = new RicercaPreventiviFrm(filtro, "BALENCIAGA", txtRiferimento.Text);
                frm.ShowDialog();
                _IDVENDITEPF = frm.USR_VENDITEPF;
                if (_IDVENDITEPF == null)
                    return;
                _IDVENDITEPD = frm.USR_VENDITEPD;
                if (_IDVENDITEPD == null)
                    return;

                caricaPreventivo();
                VisualizzaDatiPreventivo();
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "ERRORE IN TROVA PREVENTIVO");
            }
        }

        private void caricaPreventivo()
        {
            _IDVENDITEPFDIBA = string.Empty;
            using (PreventiviBusiness bPreventivi = new PreventiviBusiness())
            {
                bPreventivi.FillUSR_VENDITEPF_DIBA(_dsPreventivi, _IDVENDITEPF.IDVENDITEPF);

                PreventiviDS.USR_VENDITEPF_DIBARow rDiba = _dsPreventivi.USR_VENDITEPF_DIBA.Where(x => x.IDVENDITEPF == _IDVENDITEPF.IDVENDITEPF).FirstOrDefault();
                if (rDiba == null) throw new ArgumentException("Impossibile trovare la struttura diba del preventivo IDVENDITEPF: " + _IDVENDITEPF);

                _IDVENDITEPFDIBA = rDiba.IDVENDITEPFDIBA;

                bPreventivi.FillUSR_VENDITEPF_DIBATREE(_dsPreventivi, _IDVENDITEPFDIBA);
                bPreventivi.FillUSR_VENDITEPF_DIBACOS(_dsPreventivi, _IDVENDITEPFDIBA);
                bPreventivi.FillUSR_VENDITEPF_GRUPPOT(_dsPreventivi, _IDVENDITEPFDIBA);
                bPreventivi.FillUSR_VENDITEPF_GRUPPOD(_dsPreventivi, _IDVENDITEPFDIBA);
                bPreventivi.FillUSR_VENDITEPF_TOTPREV(_dsPreventivi, _IDVENDITEPFDIBA);
            }
        }

        private void VisualizzaDatiPreventivo()
        {
            txtScaglione.Text = _IDVENDITEPF.QTA.ToString();
            AnagraficaDS.MAGAZZRow magazz = anagrafica.GetMAGAZZ(_IDVENDITEPD.IDMAGAZZ);
            if (magazz != null)
                txtModello.Text = magazz.MODELLO + " - " + magazz.DESMAGAZZ;

            PreventiviDS.USR_VENDITEPF_TOTPREVRow totali = _dsPreventivi.USR_VENDITEPF_TOTPREV.Where(x => x.IDVENDITEPF == _IDVENDITEPF.IDVENDITEPF).FirstOrDefault();
            if (totali != null)
            {
                txtCosto.Text = totali.TOTALECOSTI.ToString();
                txtRicarico.Text = totali.TOTALERICARICO.ToString();
                decimal perc = (totali.TOTALERICARICO / totali.TOTALECOSTI) * 100;
                perc = Math.Round(perc, 2);
                txtRicaricoPerc.Text = perc.ToString();
                txtPrezzo.Text = totali.TOTALEVENDITA.ToString();
            }

            dgvCostiFissi.DataSource = _dsPreventivi;
            dgvGruppi.DataSource = _dsPreventivi;
        }

        private void CreaDSGrigliaDettaglio()
        {
            DataTable dtGriglia = _dsGrigliaDettaglio.Tables.Add();
            dtGriglia.TableName = _tabellaGrigliaDettaglio;
            dtGriglia.Columns.Add("IDVENDITEPFGRUPPOD", Type.GetType("System.String")).ReadOnly = true;
            dtGriglia.Columns.Add("Descrizione", Type.GetType("System.String")).ReadOnly = true;
            dtGriglia.Columns.Add("Valore costo distinta", Type.GetType("System.Decimal")).ReadOnly = true;
            dtGriglia.Columns.Add("Valore costo fisso", Type.GetType("System.Decimal")).ReadOnly = true;
            dtGriglia.Columns.Add("Valore costo", Type.GetType("System.Decimal")).ReadOnly = true;
            dtGriglia.Columns.Add("Percentuale ricarico", Type.GetType("System.Decimal")).ReadOnly = true;
            dtGriglia.Columns.Add("Valore ricarico", Type.GetType("System.Decimal")).ReadOnly = true;
            dtGriglia.Columns.Add("Valore calcolato", Type.GetType("System.Decimal")).ReadOnly = true;
            dtGriglia.Columns.Add("Valore manuale", Type.GetType("System.Decimal")).ReadOnly = true;
            dtGriglia.Columns.Add("Valore manuale totale", Type.GetType("System.Decimal")).ReadOnly = true;
            dtGriglia.Columns.Add("Codice", Type.GetType("System.String")).ReadOnly = true;
            dtGriglia.Columns.Add("Sequenza", Type.GetType("System.Decimal")).ReadOnly = true;
        }

        private void CreaGrigliaDettaglio()
        {
            dgvGruppiDettaglio.DataSource = _dsGrigliaDettaglio;
            dgvGruppiDettaglio.DataMember = _tabellaGrigliaDettaglio;

            dgvGruppiDettaglio.Columns[0].Visible = false;
            dgvGruppiDettaglio.Columns[1].Width = 150;
            dgvGruppiDettaglio.Columns[2].Width = 80;
            dgvGruppiDettaglio.Columns[3].Width = 80;
            dgvGruppiDettaglio.Columns[4].Width = 80;
            dgvGruppiDettaglio.Columns[5].Width = 80;
            dgvGruppiDettaglio.Columns[6].Width = 80;
            dgvGruppiDettaglio.Columns[7].Width = 80;
            dgvGruppiDettaglio.Columns[8].Width = 80;
            dgvGruppiDettaglio.Columns[9].Width = 80;
            dgvGruppiDettaglio.Columns[10].Width = 120;
            dgvGruppiDettaglio.Columns[11].Width = 80;
        }

        private void PopolaDSGrigliaDettaglio(string IDVENDITEPFGRUPPOT)
        {
            DataTable dtGriglia = _dsGrigliaDettaglio.Tables[_tabellaGrigliaDettaglio];
            dtGriglia.Clear();
            foreach (PreventiviDS.USR_VENDITEPF_GRUPPODRow dettaglio in _dsPreventivi.USR_VENDITEPF_GRUPPOD.Where(x => x.IDVENDITEPFGRUPPOT == IDVENDITEPFGRUPPOT))
            {
                DataRow riga = dtGriglia.NewRow();

                riga[0] = dettaglio.IDVENDITEPFGRUPPOD;

                if (!dettaglio.IsIDORIGINENull())
                {
                    PreventiviDS.USR_VENDITEPF_DIBATREERow diba = _dsPreventivi.USR_VENDITEPF_DIBATREE.Where(x => x.IDVENDITEPFDIBATREE == dettaglio.IDORIGINE).FirstOrDefault();
                    if (diba != null)
                    {
                        riga[10] = diba.IsMODELLONull() ? string.Empty : diba.MODELLO;
                        riga[1] = diba.IsDESMAGAZZNull() ? string.Empty : diba.DESMAGAZZ;
                    }
                }

                riga[2] = dettaglio.VALORECOSTODIBA;
                riga[3] = dettaglio.VALORECOSTOFISSO;
                riga[4] = dettaglio.VALORECOSTO;
                riga[5] = dettaglio.PERCRICARICO;
                riga[6] = dettaglio.VALORERICARICO;
                riga[7] = dettaglio.VALORECALCOLATO;
                riga[8] = dettaglio.VALOREMANUALE;
                riga[9] = dettaglio.VALOREMANUALET;
                riga[11] = dettaglio.SEQUENZA;

                dtGriglia.Rows.Add(riga);
            }

        }

        private void dgvGruppi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            string IDVENDITEPF_GRUPPOT = (string)dgvGruppi.Rows[e.RowIndex].Cells[0].Value;
            PopolaDSGrigliaDettaglio(IDVENDITEPF_GRUPPOT);
            CreaGrigliaDettaglio();
        }
    }
}

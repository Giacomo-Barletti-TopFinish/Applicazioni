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
        private string _tabellaGrigliaGruppi = "grigliaGruppi";

        private string _IDVENDITEPFDIBA;
        private PreventiviDS _dsPreventivi = new PreventiviDS();
        private Anagrafica anagrafica = new Anagrafica();

        public BalenciagaFrm()
        {
            InitializeComponent();
        }

        private void BalenciagaFrm_Load(object sender, EventArgs e)
        {
            lblPrezzo.Text = string.Empty;
            txtRiferimento.Focus();
            CreaDSGrigliaDettaglio();
            CreaDSGrigliagGruppi();
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
            {
                txtModello.Text = magazz.MODELLO + " - " + magazz.DESMAGAZZ;
                this.Text = String.Format("BALENCIAGA - {0} - {1}", magazz.MODELLO, txtScaglione.Text);
            }
            else
            {
                this.Text = "BALENCIAGA";
            }

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
            PopolaDSGrigliaGruppi();
            CreaGrigliaGruppi();
            lblPrezzo.Text = CalcolaPrezzoUnitario().ToString();
        }
        private enum colonneDettaglio
        {
            IDVENDITEPFGRUPPOD,
            Sequenza,
            Codice,
            Descrizione,
            ValoreCostoDistinta,
            ValoreCostoFisso,
            ValoreCosto,
            Ricarico,
            ValoreRicarico,
            ValoreCalcolato,
            ValoreManuale,
            ValoreManualeTotale,
            ValoreConRicarico
        }

        private enum colonneGruppo
        {
            IDVENDITEGRUPPOT,
            GRUPPO,
            DESCRIZIONEGRUPPO,
            IDVENDITEPF,
            IDVENDITEPD,
            IDVENDITEPFDIBA,
            IDPREVGRUPPO,
            SEQUENZA,
            TOTALECOSTI,
            TOTALERICARICO,
            TOTALEVENDITACALCOLATO,
            TOTALEVENDITAMANUALETOTALE,
            TOTALEVENDITAMANUALEGRUPPO,
            TOTALECONRICARICO
        }

        private void CreaDSGrigliagGruppi()
        {
            DataTable dtGriglia = _dsGrigliaDettaglio.Tables.Add();
            dtGriglia.TableName = _tabellaGrigliaGruppi;
            dtGriglia.Columns.Add("IDVENDITEGRUPPOT", Type.GetType("System.String")).ReadOnly = true;
            dtGriglia.Columns.Add("Gruppo", Type.GetType("System.String")).ReadOnly = true;
            dtGriglia.Columns.Add("Descrizione gruppo", Type.GetType("System.String")).ReadOnly = true;
            dtGriglia.Columns.Add("IDVENTITEPF", Type.GetType("System.String")).ReadOnly = true;
            dtGriglia.Columns.Add("IDVENTITEPD", Type.GetType("System.String")).ReadOnly = true;
            dtGriglia.Columns.Add("IDVENTITEPFDIBA", Type.GetType("System.String")).ReadOnly = true;
            dtGriglia.Columns.Add("IDPREVGRUPPO", Type.GetType("System.String")).ReadOnly = true;
            dtGriglia.Columns.Add("Sequenza", Type.GetType("System.Decimal")).ReadOnly = true;
            dtGriglia.Columns.Add("Totale costi", Type.GetType("System.Decimal")).ReadOnly = true;
            dtGriglia.Columns.Add("Totale ricarico", Type.GetType("System.Decimal")).ReadOnly = true;
            dtGriglia.Columns.Add("Totale vendita calcolato", Type.GetType("System.Decimal")).ReadOnly = true;
            dtGriglia.Columns.Add("Totale vendita manuale totale", Type.GetType("System.Decimal")).ReadOnly = true;
            dtGriglia.Columns.Add("Totale vendita manuale gruppo", Type.GetType("System.Decimal")).ReadOnly = true;
            dtGriglia.Columns.Add("Totale con ricarico", Type.GetType("System.Decimal"));
        }


        private void CreaDSGrigliaDettaglio()
        {
            DataTable dtGriglia = _dsGrigliaDettaglio.Tables.Add();
            dtGriglia.TableName = _tabellaGrigliaDettaglio;
            dtGriglia.Columns.Add("IDVENDITEPFGRUPPOD", Type.GetType("System.String")).ReadOnly = true;
            dtGriglia.Columns.Add("Sequenza", Type.GetType("System.Decimal")).ReadOnly = true;
            dtGriglia.Columns.Add("Codice", Type.GetType("System.String")).ReadOnly = true;
            dtGriglia.Columns.Add("Descrizione", Type.GetType("System.String")).ReadOnly = true;
            dtGriglia.Columns.Add("Valore costo distinta", Type.GetType("System.Decimal")).ReadOnly = true;
            dtGriglia.Columns.Add("Valore costo fisso", Type.GetType("System.Decimal")).ReadOnly = true;
            dtGriglia.Columns.Add("Valore costo", Type.GetType("System.Decimal")).ReadOnly = true;
            dtGriglia.Columns.Add("Percentuale ricarico", Type.GetType("System.Decimal")).ReadOnly = true;
            dtGriglia.Columns.Add("Valore ricarico", Type.GetType("System.Decimal")).ReadOnly = true;
            dtGriglia.Columns.Add("Valore calcolato", Type.GetType("System.Decimal")).ReadOnly = true;
            dtGriglia.Columns.Add("Valore manuale", Type.GetType("System.Decimal")).ReadOnly = true;
            dtGriglia.Columns.Add("Valore manuale totale", Type.GetType("System.Decimal")).ReadOnly = true;
            dtGriglia.Columns.Add("Valore con ricarico", Type.GetType("System.Decimal"));
        }

        private void CreaGrigliaDettaglio()
        {
            dgvGruppiDettaglio.DataSource = _dsGrigliaDettaglio;
            dgvGruppiDettaglio.DataMember = _tabellaGrigliaDettaglio;

            dgvGruppiDettaglio.Columns[(int)colonneDettaglio.IDVENDITEPFGRUPPOD].Visible = false;
            dgvGruppiDettaglio.Columns[(int)colonneDettaglio.Descrizione].Width = 150;
            dgvGruppiDettaglio.Columns[(int)colonneDettaglio.ValoreCostoDistinta].Width = 80;
            dgvGruppiDettaglio.Columns[(int)colonneDettaglio.ValoreCostoFisso].Width = 80;
            dgvGruppiDettaglio.Columns[(int)colonneDettaglio.ValoreCosto].Width = 80;
            dgvGruppiDettaglio.Columns[(int)colonneDettaglio.Ricarico].Width = 80;
            dgvGruppiDettaglio.Columns[(int)colonneDettaglio.ValoreRicarico].Width = 80;
            dgvGruppiDettaglio.Columns[(int)colonneDettaglio.ValoreCalcolato].Width = 80;
            dgvGruppiDettaglio.Columns[(int)colonneDettaglio.ValoreManuale].Width = 80;
            dgvGruppiDettaglio.Columns[(int)colonneDettaglio.ValoreManualeTotale].Width = 80;
            dgvGruppiDettaglio.Columns[(int)colonneDettaglio.Codice].Width = 120;
            dgvGruppiDettaglio.Columns[(int)colonneDettaglio.Sequenza].Width = 80;
            dgvGruppiDettaglio.Columns[(int)colonneDettaglio.ValoreConRicarico].Width = 80;
            dgvGruppiDettaglio.Columns[(int)colonneDettaglio.ValoreConRicarico].DefaultCellStyle.ForeColor = Color.Red;
        }

        private void CreaGrigliaGruppi()
        {
            dgvGruppi.DataSource = _dsGrigliaDettaglio;
            dgvGruppi.DataMember = _tabellaGrigliaGruppi;

            dgvGruppi.Columns[(int)colonneGruppo.IDVENDITEGRUPPOT].Visible = false;
            dgvGruppi.Columns[(int)colonneGruppo.IDVENDITEPF].Visible = false;
            dgvGruppi.Columns[(int)colonneGruppo.IDVENDITEPD].Visible = false;
            dgvGruppi.Columns[(int)colonneGruppo.IDVENDITEPFDIBA].Visible = false;
            dgvGruppi.Columns[(int)colonneGruppo.IDPREVGRUPPO].Visible = false;
            dgvGruppi.Columns[(int)colonneGruppo.SEQUENZA].Width = 80;
            dgvGruppi.Columns[(int)colonneGruppo.GRUPPO].Width = 80;
            dgvGruppi.Columns[(int)colonneGruppo.DESCRIZIONEGRUPPO].Width = 80;
            dgvGruppi.Columns[(int)colonneGruppo.TOTALECOSTI].Width = 80;
            dgvGruppi.Columns[(int)colonneGruppo.TOTALERICARICO].Width = 80;
            dgvGruppi.Columns[(int)colonneGruppo.TOTALEVENDITACALCOLATO].Width = 80;
            dgvGruppi.Columns[(int)colonneGruppo.TOTALEVENDITAMANUALETOTALE].Width = 80;
            dgvGruppi.Columns[(int)colonneGruppo.TOTALEVENDITAMANUALEGRUPPO].Width = 80;
            dgvGruppi.Columns[(int)colonneGruppo.TOTALECONRICARICO].Width = 80;
            dgvGruppi.Columns[(int)colonneGruppo.TOTALECONRICARICO].DefaultCellStyle.ForeColor = Color.Red;
        }
        private void PopolaDSGrigliaDettaglio(string IDVENDITEPFGRUPPOT)
        {
            DataTable dtGriglia = _dsGrigliaDettaglio.Tables[_tabellaGrigliaDettaglio];
            dtGriglia.Clear();
            foreach (PreventiviDS.USR_VENDITEPF_GRUPPODRow dettaglio in _dsPreventivi.USR_VENDITEPF_GRUPPOD.Where(x => x.IDVENDITEPFGRUPPOT == IDVENDITEPFGRUPPOT))
            {
                DataRow riga = dtGriglia.NewRow();

                riga[(int)colonneDettaglio.IDVENDITEPFGRUPPOD] = dettaglio.IDVENDITEPFGRUPPOD;

                if (!dettaglio.IsIDORIGINENull())
                {
                    PreventiviDS.USR_VENDITEPF_DIBATREERow diba = _dsPreventivi.USR_VENDITEPF_DIBATREE.Where(x => x.IDVENDITEPFDIBATREE == dettaglio.IDORIGINE).FirstOrDefault();
                    if (diba != null)
                    {
                        riga[(int)colonneDettaglio.Codice] = diba.IsMODELLONull() ? string.Empty : diba.MODELLO;
                        riga[(int)colonneDettaglio.Descrizione] = diba.IsDESMAGAZZNull() ? string.Empty : diba.DESMAGAZZ;
                    }
                }

                riga[(int)colonneDettaglio.ValoreCostoDistinta] = dettaglio.VALORECOSTODIBA;
                riga[(int)colonneDettaglio.ValoreCostoFisso] = dettaglio.VALORECOSTOFISSO;
                riga[(int)colonneDettaglio.ValoreCosto] = dettaglio.VALORECOSTO;
                riga[(int)colonneDettaglio.Ricarico] = dettaglio.PERCRICARICO;
                riga[(int)colonneDettaglio.ValoreRicarico] = dettaglio.VALORERICARICO;
                riga[(int)colonneDettaglio.ValoreCalcolato] = dettaglio.VALORECALCOLATO;
                riga[(int)colonneDettaglio.ValoreManuale] = dettaglio.VALOREMANUALE;
                riga[(int)colonneDettaglio.ValoreManualeTotale] = dettaglio.VALOREMANUALET;
                riga[(int)colonneDettaglio.Sequenza] = dettaglio.SEQUENZA;
                decimal ricaricato = dettaglio.VALOREMANUALET * (1 + (nRicarico.Value / 100));
                riga[(int)colonneDettaglio.ValoreConRicarico] = Math.Round(ricaricato, 3);
                dtGriglia.Rows.Add(riga);
            }
        }

        private void PopolaDSGrigliaGruppi()
        {
            DataTable dtGriglia = _dsGrigliaDettaglio.Tables[_tabellaGrigliaGruppi];
            dtGriglia.Clear();
            foreach (PreventiviDS.USR_VENDITEPF_GRUPPOTRow gruppo in _dsPreventivi.USR_VENDITEPF_GRUPPOT)
            {
                DataRow riga = dtGriglia.NewRow();

                riga[(int)colonneGruppo.IDVENDITEGRUPPOT] = gruppo.IDVENDITEPFGRUPPOT;
                riga[(int)colonneGruppo.IDVENDITEPF] = gruppo.IDVENDITEPF;
                riga[(int)colonneGruppo.IDVENDITEPD] = gruppo.IDVENDITEPD;
                riga[(int)colonneGruppo.IDVENDITEPFDIBA] = gruppo.IDVENDITEPFDIBA;
                riga[(int)colonneGruppo.IDPREVGRUPPO] = gruppo.IDPREVGRUPPO;
                riga[(int)colonneGruppo.GRUPPO] = gruppo.CODPREVGRUPPO;
                riga[(int)colonneGruppo.DESCRIZIONEGRUPPO] = gruppo.DESPREVGRUPPO;
                riga[(int)colonneGruppo.SEQUENZA] = gruppo.SEQUENZA;
                riga[(int)colonneGruppo.TOTALECOSTI] = gruppo.TOTALECOSTI;
                riga[(int)colonneGruppo.TOTALERICARICO] = gruppo.TOTALERICARICO;
                riga[(int)colonneGruppo.TOTALEVENDITACALCOLATO] = gruppo.TOTALEVENDITACALCOLATO;
                riga[(int)colonneGruppo.TOTALEVENDITAMANUALETOTALE] = gruppo.TOTALEVENDITAMANUALET;
                riga[(int)colonneGruppo.TOTALEVENDITAMANUALEGRUPPO] = gruppo.TOTALEVENDITAMANUALEG;
                decimal ricaricato = gruppo.TOTALEVENDITAMANUALEG * (1 + (nRicarico.Value / 100));
                riga[(int)colonneGruppo.TOTALECONRICARICO] = Math.Round(ricaricato, 3);

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

        private void nRicarico_ValueChanged(object sender, EventArgs e)
        {
            DataTable dtGrigliaDettaglio = _dsGrigliaDettaglio.Tables[_tabellaGrigliaDettaglio];
            foreach (DataRow dr in dtGrigliaDettaglio.Rows)
            {
                decimal valore = (decimal)dr[(int)colonneDettaglio.ValoreManualeTotale];
                decimal ricaricato = valore * (1 + (nRicarico.Value / 100));
                dr[(int)colonneDettaglio.ValoreConRicarico] = Math.Round(ricaricato, 3);
            }

            DataTable dtGrigliaGruppi = _dsGrigliaDettaglio.Tables[_tabellaGrigliaGruppi];
            foreach (DataRow dr in dtGrigliaGruppi.Rows)
            {
                decimal valore = (decimal)dr[(int)colonneGruppo.TOTALEVENDITAMANUALEGRUPPO];
                decimal ricaricato = valore * (1 + (nRicarico.Value / 100));
                dr[(int)colonneGruppo.TOTALECONRICARICO] = Math.Round(ricaricato, 3);
            }

            lblPrezzo.Text= CalcolaPrezzoUnitario().ToString();
        }

        private decimal CalcolaPrezzoUnitario()
        {
            decimal prezzo = 0;
            decimal scaglione = _IDVENDITEPF.QTA;

            DataTable dtGrigliaGruppi = _dsGrigliaDettaglio.Tables[_tabellaGrigliaGruppi];
            foreach (DataRow dr in dtGrigliaGruppi.Rows)
                prezzo += (decimal)dr[(int)colonneGruppo.TOTALECONRICARICO];

            prezzo += _dsPreventivi.USR_VENDITEPF_DIBACOS.Sum(x => x.VALOREFISSO) / (_IDVENDITEPF.QTA == 0 ? 1 : _IDVENDITEPF.QTA);

            return prezzo;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

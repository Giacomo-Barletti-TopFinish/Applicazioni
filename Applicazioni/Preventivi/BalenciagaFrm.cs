using Applicazioni.BLL;
using Applicazioni.Data.Anagrafica;
using Applicazioni.Data.Preventivi;
using Applicazioni.Entities;
using Applicazioni.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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
        private string _tabellaGrigliaCostiFissi = "grigliaCostiFissi";

        private string _fornitore = "METALPLUS";

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
            CreaDSGrigliaGruppi();
            CreaDSGrigliaCosti();
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

                AggiungiDatiStorici();

            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "ERRORE IN TROVA PREVENTIVO");
            }
        }

        private void AggiungiDatiStorici()
        {


            int colonneCostiFissi = Enum.GetValues(typeof(colonneCostiFissi)).Length;

            while (dgvCostiFissi.Columns.Count > colonneCostiFissi)
            {
                dgvCostiFissi.Columns.RemoveAt(colonneCostiFissi);
            }

            List<DateTime> dateInserite = _dsPreventivi.AP_PREVENTIVIC.Select(x => x.DATA).Distinct().OrderByDescending(x => x.Date).ToList();
            if (dateInserite.Count >= 2)
            {
                int indiceColonna = colonneCostiFissi - 1;

                for (int i = 1; i < dateInserite.Count; i++)
                {
                    indiceColonna++;
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.Width = 80;
                    col.HeaderText = dateInserite[i].ToShortDateString();
                    col.DefaultCellStyle.BackColor = Color.LightYellow;
                    dgvCostiFissi.Columns.Add(col);

                    List<PreventiviDS.AP_PREVENTIVICRow> preventivi = _dsPreventivi.AP_PREVENTIVIC.Where(x => x.DATA == dateInserite[i]).ToList();
                    foreach (DataGridViewRow dr in dgvCostiFissi.Rows)
                    {
                        if (dr.IsNewRow) continue;
                        string IDVENDITEPFDIBACOS = dr.Cells[(int)BalenciagaFrm.colonneCostiFissi.IDVENDITEPFDIBACOS].Value.ToString();
                        string IDVENDITEPFDIBA = dr.Cells[(int)BalenciagaFrm.colonneCostiFissi.IDVENDITEPFDIBA].Value.ToString();

                        PreventiviDS.AP_PREVENTIVICRow prevc = preventivi.Where(x => x.IDVENDITEPFDIBA == IDVENDITEPFDIBA && x.IDVENDITEPFDIBACOS == IDVENDITEPFDIBACOS).FirstOrDefault();
                        if (prevc != null)
                        {
                            decimal valoreFisso = prevc.VALOREFISSO;
                            dr.Cells[indiceColonna].Value = valoreFisso.ToString();
                        }
                    }
                }

            }

            int colonneGruppi = Enum.GetValues(typeof(colonneGruppo)).Length;

            while (dgvGruppi.Columns.Count > colonneGruppi)
            {
                dgvGruppi.Columns.RemoveAt(colonneGruppi);
            }

            dateInserite = _dsPreventivi.AP_PREVENTIVIG.Select(x => x.DATA).Distinct().OrderByDescending(x => x.Date).ToList();
            if (dateInserite.Count >= 2)
            {
                int indiceColonna = colonneGruppi - 1;

                for (int i = 1; i < dateInserite.Count; i++)
                {
                    indiceColonna++;
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.Width = 80;
                    col.HeaderText = dateInserite[i].ToShortDateString();
                    col.DefaultCellStyle.BackColor = Color.LightYellow;
                    dgvGruppi.Columns.Add(col);

                    List<PreventiviDS.AP_PREVENTIVIGRow> preventivi = _dsPreventivi.AP_PREVENTIVIG.Where(x => x.DATA == dateInserite[i]).ToList();
                    foreach (DataGridViewRow dr in dgvGruppi.Rows)
                    {
                        if (dr.IsNewRow) continue;
                        string IDVENDITEGRUPPOT = dr.Cells[(int)BalenciagaFrm.colonneGruppo.IDVENDITEGRUPPOT].Value.ToString();

                        PreventiviDS.AP_PREVENTIVIGRow prevc = preventivi.Where(x => x.IDVENDITEPFGRUPPOT == IDVENDITEGRUPPOT).FirstOrDefault();
                        if (prevc != null)
                        {
                            decimal valoreFisso = prevc.TOTALECONRICARICO;
                            dr.Cells[indiceColonna].Value = valoreFisso.ToString();
                        }
                    }
                }

            }
        }

        private void caricaPreventivo()
        {
            _dsPreventivi = new PreventiviDS();
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
                bPreventivi.FillAP_PREVENTIVIT(_dsPreventivi, _IDVENDITEPF.IDVENDITEPF);
                bPreventivi.FillAP_PREVENTIVIC(_dsPreventivi, _IDVENDITEPF.IDVENDITEPF);
                bPreventivi.FillAP_PREVENTIVIG(_dsPreventivi, _IDVENDITEPF.IDVENDITEPF);
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
            PopolaCampiTestataPreventivo();
            PopolaDSGrigliaGruppi();
            CreaGrigliaGruppi();

            PopolaDSGrigliaCostiFissi();
            CreaGrigliaCosti();
            AggiornaPrezzi();
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
            TOTALECONRICARICO,
            STAMPA,
            DESCRIZIONE,
            FORNITORE,
            QUANTITA
        }

        private enum colonneCostiFissi
        {
            IDVENDITEPFDIBACOS,
            IDVENDITEPFDIBA,
            SEQUENZA,
            QTAFISSA,
            VALORENETTO,
            VOCECOSTO,
            DESCVOCECOSTO,
            VALOREFISSO,
            ATTREZZAGGIO,
            TIPOCOSTO
        }

        private void CreaDSGrigliaGruppi()
        {
            DataTable dtGriglia = _dsGrigliaDettaglio.Tables.Add();
            dtGriglia.TableName = _tabellaGrigliaGruppi;
            dtGriglia.Columns.Add("IDVENDITEGRUPPOT", Type.GetType("System.String"));
            dtGriglia.Columns.Add("Gruppo", Type.GetType("System.String"));
            dtGriglia.Columns.Add("Descrizione gruppo", Type.GetType("System.String"));
            dtGriglia.Columns.Add("IDVENTITEPF", Type.GetType("System.String"));
            dtGriglia.Columns.Add("IDVENTITEPD", Type.GetType("System.String"));
            dtGriglia.Columns.Add("IDVENTITEPFDIBA", Type.GetType("System.String"));
            dtGriglia.Columns.Add("IDPREVGRUPPO", Type.GetType("System.String"));
            dtGriglia.Columns.Add("Sequenza", Type.GetType("System.Decimal"));
            dtGriglia.Columns.Add("Totale costi", Type.GetType("System.Decimal"));
            dtGriglia.Columns.Add("Totale ricarico", Type.GetType("System.Decimal"));
            dtGriglia.Columns.Add("Totale vendita calcolato", Type.GetType("System.Decimal"));
            dtGriglia.Columns.Add("Totale vendita manuale totale", Type.GetType("System.Decimal"));
            dtGriglia.Columns.Add("Totale vendita manuale gruppo", Type.GetType("System.Decimal"));
            dtGriglia.Columns.Add("Totale con ricarico", Type.GetType("System.Decimal"));
            dtGriglia.Columns.Add("STAMPA", Type.GetType("System.String"));
            dtGriglia.Columns.Add("Descrizione", Type.GetType("System.String"));
            dtGriglia.Columns.Add("Fornitore", Type.GetType("System.String"));
            dtGriglia.Columns.Add("Quantità", Type.GetType("System.Decimal"));
        }

        private void CreaDSGrigliaCosti()
        {
            DataTable dtGriglia = _dsGrigliaDettaglio.Tables.Add();
            dtGriglia.TableName = _tabellaGrigliaCostiFissi;
            dtGriglia.Columns.Add("IDVENDITEPFDIBACOS", Type.GetType("System.String"));
            dtGriglia.Columns.Add("IDVENDITEPFDIBA", Type.GetType("System.String"));
            dtGriglia.Columns.Add("Sequenza", Type.GetType("System.String"));
            dtGriglia.Columns.Add("Quantità", Type.GetType("System.Decimal"));
            dtGriglia.Columns.Add("Valore netto", Type.GetType("System.Decimal"));
            dtGriglia.Columns.Add("Voce costo", Type.GetType("System.String"));
            dtGriglia.Columns.Add("Costo", Type.GetType("System.String"));
            dtGriglia.Columns.Add("Valore fisso", Type.GetType("System.Decimal"));
            dtGriglia.Columns.Add("Attrezzaggio", Type.GetType("System.String"));
            dtGriglia.Columns.Add("TIPOCOSTO", Type.GetType("System.String"));
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
            dgvGruppi.Columns[(int)colonneGruppo.TOTALEVENDITAMANUALEGRUPPO].DefaultCellStyle.ForeColor = Color.Blue;
            dgvGruppi.Columns[(int)colonneGruppo.TOTALECONRICARICO].Width = 80;
            dgvGruppi.Columns[(int)colonneGruppo.TOTALECONRICARICO].DefaultCellStyle.ForeColor = Color.Red;

            dgvGruppi.Columns.RemoveAt((int)colonneGruppo.STAMPA);
            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
            {
                col.DataPropertyName = "STAMPA";
                col.HeaderText = "Stampe";
                col.DropDownWidth = 130;
                col.Width = 130;
                col.MaxDropDownItems = 4;
                col.FlatStyle = FlatStyle.Flat;
                col.Items.AddRange(EtichetteGruppiReport.DISTINTABASE, EtichetteGruppiReport.INTERNE, EtichetteGruppiReport.ESTERNE, "Ignora");
            }
            dgvGruppi.Columns.Insert((int)colonneGruppo.STAMPA, col);
        }

        private void CreaGrigliaCosti()
        {
            dgvCostiFissi.DataSource = _dsGrigliaDettaglio;
            dgvCostiFissi.DataMember = _tabellaGrigliaCostiFissi;

            dgvCostiFissi.Columns[(int)colonneCostiFissi.IDVENDITEPFDIBACOS].Visible = false;
            dgvCostiFissi.Columns[(int)colonneCostiFissi.IDVENDITEPFDIBA].Visible = false;
            dgvCostiFissi.Columns[(int)colonneCostiFissi.SEQUENZA].Width = 80;
            dgvCostiFissi.Columns[(int)colonneCostiFissi.VALOREFISSO].Width = 80;
            dgvCostiFissi.Columns[(int)colonneCostiFissi.VALOREFISSO].DefaultCellStyle.ForeColor = Color.Red;
            dgvCostiFissi.Columns[(int)colonneCostiFissi.QTAFISSA].Width = 80;
            dgvCostiFissi.Columns[(int)colonneCostiFissi.VALORENETTO].Width = 80;
            dgvCostiFissi.Columns[(int)colonneCostiFissi.VOCECOSTO].Width = 80;
            dgvCostiFissi.Columns[(int)colonneCostiFissi.DESCVOCECOSTO].Width = 80;

            dgvCostiFissi.Columns.RemoveAt((int)colonneCostiFissi.ATTREZZAGGIO);

            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
            {
                col.DataPropertyName = "ATTREZZAGGIO";
                col.HeaderText = "Attrezzaggio";
                col.DropDownWidth = 90;
                col.Width = 90;
                col.MaxDropDownItems = 3;
                col.FlatStyle = FlatStyle.Flat;
                col.Items.AddRange(EtichetteGruppiReport.PROTOTIPIA, EtichetteGruppiReport.PRODUZIONE, EtichetteGruppiReport.IGNORA);
            }
            dgvCostiFissi.Columns.Insert((int)colonneCostiFissi.ATTREZZAGGIO, col);


            dgvCostiFissi.Columns.RemoveAt((int)colonneCostiFissi.TIPOCOSTO);
            DataGridViewComboBoxColumn col2 = new DataGridViewComboBoxColumn();
            {
                col2.DataPropertyName = "TIPOCOSTO";
                col2.HeaderText = "Etichetta stampa";
                col2.DropDownWidth = 100;
                col2.Width = 100;
                col2.MaxDropDownItems = 6;
                col2.FlatStyle = FlatStyle.Flat;
                col2.Items.AddRange(VOCECOSTODIBA.GOMMA, VOCECOSTODIBA.PRESSOFUSIONE, VOCECOSTODIBA.STAMPA3D, VOCECOSTODIBA.STAMPAGGIOCALDO, VOCECOSTODIBA.STAMPAGGIOFREDDO, VOCECOSTODIBA.IGNORA);
            }
            dgvCostiFissi.Columns.Insert((int)colonneCostiFissi.TIPOCOSTO, col2);
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
            if (_dsPreventivi.AP_PREVENTIVIG.Count == 0)
            {
                foreach (PreventiviDS.USR_VENDITEPF_GRUPPOTRow gruppo in _dsPreventivi.USR_VENDITEPF_GRUPPOT)
                {
                    DataRow riga = dtGriglia.NewRow();

                    riga[(int)colonneGruppo.IDVENDITEGRUPPOT] = gruppo.IDVENDITEPFGRUPPOT;
                    riga[(int)colonneGruppo.IDVENDITEPF] = gruppo.IDVENDITEPF;
                    riga[(int)colonneGruppo.IDVENDITEPD] = gruppo.IDVENDITEPD;
                    riga[(int)colonneGruppo.IDVENDITEPFDIBA] = gruppo.IDVENDITEPFDIBA;
                    riga[(int)colonneGruppo.IDPREVGRUPPO] = gruppo.IsIDPREVGRUPPONull() ? string.Empty : gruppo.IDPREVGRUPPO;
                    riga[(int)colonneGruppo.GRUPPO] = gruppo.IsCODPREVGRUPPONull() ? string.Empty : gruppo.CODPREVGRUPPO;
                    riga[(int)colonneGruppo.DESCRIZIONEGRUPPO] = gruppo.IsDESPREVGRUPPONull() ? string.Empty : gruppo.DESPREVGRUPPO;
                    riga[(int)colonneGruppo.SEQUENZA] = gruppo.SEQUENZA;
                    riga[(int)colonneGruppo.TOTALECOSTI] = gruppo.TOTALECOSTI;
                    riga[(int)colonneGruppo.TOTALERICARICO] = gruppo.TOTALERICARICO;
                    riga[(int)colonneGruppo.TOTALEVENDITACALCOLATO] = gruppo.TOTALEVENDITACALCOLATO;
                    riga[(int)colonneGruppo.TOTALEVENDITAMANUALETOTALE] = gruppo.TOTALEVENDITAMANUALET;
                    riga[(int)colonneGruppo.TOTALEVENDITAMANUALEGRUPPO] = gruppo.TOTALEVENDITAMANUALEG;
                    decimal ricaricato = gruppo.TOTALEVENDITAMANUALEG * (1 + (nRicarico.Value / 100));
                    riga[(int)colonneGruppo.TOTALECONRICARICO] = Math.Round(ricaricato, 3);
                    riga[(int)colonneGruppo.FORNITORE] = "METALPLUS";
                    riga[(int)colonneGruppo.QUANTITA] = 1;
                    dtGriglia.Rows.Add(riga);
                }
            }
            else
            {
                DateTime ultimaData = _dsPreventivi.AP_PREVENTIVIG.Max(x => x.DATA);
                foreach (PreventiviDS.AP_PREVENTIVIGRow gruppo in _dsPreventivi.AP_PREVENTIVIG.Where(x => x.DATA == ultimaData))
                {
                    DataRow riga = dtGriglia.NewRow();

                    riga[(int)colonneGruppo.IDVENDITEGRUPPOT] = gruppo.IDVENDITEPFGRUPPOT;
                    riga[(int)colonneGruppo.IDVENDITEPF] = gruppo.IDVENDITEPF;
                    riga[(int)colonneGruppo.IDVENDITEPD] = gruppo.IDVENDITEPD;
                    riga[(int)colonneGruppo.IDVENDITEPFDIBA] = gruppo.IDVENDITEPFDIBA;
                    riga[(int)colonneGruppo.IDPREVGRUPPO] = gruppo.IsIDPREVGRUPPONull() ? string.Empty : gruppo.IDPREVGRUPPO;
                    riga[(int)colonneGruppo.GRUPPO] = gruppo.IsCODVOCECOSTONull() ? string.Empty : gruppo.CODVOCECOSTO;
                    riga[(int)colonneGruppo.DESCRIZIONEGRUPPO] = gruppo.IsDESVOCECOSTONull() ? string.Empty : gruppo.DESVOCECOSTO;
                    riga[(int)colonneGruppo.SEQUENZA] = gruppo.IsSEQUENZANull() ? 0 : decimal.Parse(gruppo.SEQUENZA);
                    riga[(int)colonneGruppo.TOTALECOSTI] = gruppo.TOTALECOSTI;
                    riga[(int)colonneGruppo.TOTALERICARICO] = gruppo.TOTALERICARICO;
                    riga[(int)colonneGruppo.TOTALEVENDITACALCOLATO] = gruppo.TOTALEVENDITACALCOLATO;
                    riga[(int)colonneGruppo.TOTALEVENDITAMANUALETOTALE] = gruppo.TOTALEVENDITAMANUALET;
                    riga[(int)colonneGruppo.TOTALEVENDITAMANUALEGRUPPO] = gruppo.TOTALEVENDITAMANUALEG;
                    decimal ricaricato = gruppo.TOTALEVENDITAMANUALEG * (1 + (nRicarico.Value / 100));
                    riga[(int)colonneGruppo.TOTALECONRICARICO] = Math.Round(ricaricato, 3);
                    riga[(int)colonneGruppo.STAMPA] = gruppo.IsSTAMPENull() ? string.Empty : gruppo.STAMPE;
                    riga[(int)colonneGruppo.FORNITORE] = gruppo.IsFORNITORENull() ? string.Empty : gruppo.FORNITORE;
                    riga[(int)colonneGruppo.DESCRIZIONE] = gruppo.IsDESCRIZIONENull() ? string.Empty : gruppo.DESCRIZIONE;
                    riga[(int)colonneGruppo.QUANTITA] = gruppo.IsQUANTITANull() ? 1 : gruppo.QUANTITA;

                    dtGriglia.Rows.Add(riga);
                }
            }


        }

        private void PopolaDSGrigliaCostiFissi()
        {
            DataTable dtGriglia = _dsGrigliaDettaglio.Tables[_tabellaGrigliaCostiFissi];
            dtGriglia.Clear();
            if (_dsPreventivi.AP_PREVENTIVIC.Count == 0)
            {
                foreach (PreventiviDS.USR_VENDITEPF_DIBACOSRow gruppo in _dsPreventivi.USR_VENDITEPF_DIBACOS)
                {
                    DataRow riga = dtGriglia.NewRow();

                    riga[(int)colonneCostiFissi.IDVENDITEPFDIBACOS] = gruppo.IDVENDITEPFDIBACOS;
                    riga[(int)colonneCostiFissi.IDVENDITEPFDIBA] = gruppo.IDVENDITEPFDIBA;
                    riga[(int)colonneCostiFissi.SEQUENZA] = gruppo.SEQUENZA;
                    riga[(int)colonneCostiFissi.QTAFISSA] = gruppo.QTAFISSA;
                    riga[(int)colonneCostiFissi.ATTREZZAGGIO] = string.Empty;
                    riga[(int)colonneCostiFissi.DESCVOCECOSTO] = gruppo.DESVOCECOSTO;
                    riga[(int)colonneCostiFissi.VOCECOSTO] = gruppo.CODVOCECOSTO;
                    riga[(int)colonneCostiFissi.VALOREFISSO] = gruppo.VALOREFISSO;
                    riga[(int)colonneCostiFissi.VALORENETTO] = gruppo.VALORENETTO;
                    riga[(int)colonneCostiFissi.TIPOCOSTO] = string.Empty;

                    dtGriglia.Rows.Add(riga);
                }
            }
            else
            {
                DateTime ultimaDat = _dsPreventivi.AP_PREVENTIVIC.Max(x => x.DATA);
                foreach (PreventiviDS.AP_PREVENTIVICRow gruppo in _dsPreventivi.AP_PREVENTIVIC.Where(x => x.DATA == ultimaDat))
                {
                    DataRow riga = dtGriglia.NewRow();

                    riga[(int)colonneCostiFissi.IDVENDITEPFDIBACOS] = gruppo.IDVENDITEPFDIBACOS;
                    riga[(int)colonneCostiFissi.IDVENDITEPFDIBA] = gruppo.IDVENDITEPFDIBA;
                    riga[(int)colonneCostiFissi.SEQUENZA] = gruppo.IsSEQUENZANull() ? 0 : decimal.Parse(gruppo.SEQUENZA);
                    riga[(int)colonneCostiFissi.QTAFISSA] = gruppo.QTAFISSA;
                    riga[(int)colonneCostiFissi.DESCVOCECOSTO] = gruppo.IsDESVOCECOSTONull() ? string.Empty : gruppo.DESVOCECOSTO;
                    riga[(int)colonneCostiFissi.VOCECOSTO] = gruppo.IsCODVOCECOSTONull() ? string.Empty : gruppo.CODVOCECOSTO;
                    riga[(int)colonneCostiFissi.VALOREFISSO] = gruppo.VALOREFISSO;
                    riga[(int)colonneCostiFissi.VALORENETTO] = gruppo.VALORENETTO;
                    riga[(int)colonneCostiFissi.ATTREZZAGGIO] = gruppo.IsATTREZZAGGIONull() ? string.Empty : gruppo.ATTREZZAGGIO;
                    riga[(int)colonneCostiFissi.TIPOCOSTO] = gruppo.IsTIPOCOSTONull() ? string.Empty : gruppo.TIPOCOSTO;

                    dtGriglia.Rows.Add(riga);
                }
            }

        }

        private void dgvGruppi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (e.RowIndex >= dgvGruppi.RowCount) return;
            if (dgvGruppi.Rows[e.RowIndex].Cells[0].Value == DBNull.Value) return;

            string IDVENDITEPF_GRUPPOT = (string)dgvGruppi.Rows[e.RowIndex].Cells[0].Value;
            int aux;
            if (Int32.TryParse(IDVENDITEPF_GRUPPOT, out aux) && aux > 0)
            {
                PopolaDSGrigliaDettaglio(IDVENDITEPF_GRUPPOT);
                CreaGrigliaDettaglio();
            }
            else
            {
                DataTable dtGriglia = _dsGrigliaDettaglio.Tables[_tabellaGrigliaDettaglio];
                dtGriglia.Clear();
                CreaGrigliaDettaglio();
            }
        }

        private void nRicarico_ValueChanged(object sender, EventArgs e)
        {
            AggiornaValoriConRicarico();
        }

        private void AggiornaValoriConRicarico()
        {
            DataTable dtGrigliaDettaglio = _dsGrigliaDettaglio.Tables[_tabellaGrigliaDettaglio];
            foreach (DataRow dr in dtGrigliaDettaglio.Rows)
            {
                if (dr[(int)colonneDettaglio.ValoreManualeTotale] == DBNull.Value) continue;
                decimal valore = (decimal)dr[(int)colonneDettaglio.ValoreManualeTotale];
                decimal ricaricato = valore * (1 + (nRicarico.Value / 100));
                dr[(int)colonneDettaglio.ValoreConRicarico] = Math.Round(ricaricato, 3);
            }

            DataTable dtGrigliaGruppi = _dsGrigliaDettaglio.Tables[_tabellaGrigliaGruppi];
            foreach (DataRow dr in dtGrigliaGruppi.Rows)
            {
                if (dr[(int)colonneGruppo.TOTALEVENDITAMANUALEGRUPPO] == DBNull.Value) continue;
                decimal valore = (decimal)dr[(int)colonneGruppo.TOTALEVENDITAMANUALEGRUPPO];
                decimal ricaricato = valore * (1 + (nRicarico.Value / 100));
                dr[(int)colonneGruppo.TOTALECONRICARICO] = Math.Round(ricaricato, 3);
            }

            AggiornaPrezzi();
        }

        private void AggiornaPrezzi()
        {
            decimal prezzoGrezzo = 0;
            decimal prezzoLavorazioneInterna = 0;
            decimal prezzoLavorazioneEsterna = 0;
            decimal prezzoPrototipo = 0;
            decimal prezzoProduzione = 0;

            DataTable dtGrigliaGruppi = _dsGrigliaDettaglio.Tables[_tabellaGrigliaGruppi];
            foreach (DataRow dr in dtGrigliaGruppi.Rows)
            {
                string str = dr[(int)colonneGruppo.STAMPA].ToString();
                if (str == EtichetteGruppiReport.ESTERNE)
                    prezzoGrezzo += (decimal)dr[(int)colonneGruppo.TOTALECONRICARICO];
                else if (str == EtichetteGruppiReport.INTERNE)
                    prezzoLavorazioneInterna += (decimal)dr[(int)colonneGruppo.TOTALECONRICARICO];
                else if (str == EtichetteGruppiReport.DISTINTABASE)
                    prezzoLavorazioneEsterna += (decimal)dr[(int)colonneGruppo.TOTALECONRICARICO];
            }

            DataTable dtGrigliaCosti = _dsGrigliaDettaglio.Tables[_tabellaGrigliaCostiFissi];
            foreach (DataRow dr in dtGrigliaCosti.Rows)
            {
                decimal qta = 1;
                if (dr[(int)colonneCostiFissi.QTAFISSA] != DBNull.Value)
                    qta = (decimal)dr[(int)colonneCostiFissi.QTAFISSA];
                string str = dr[(int)colonneCostiFissi.ATTREZZAGGIO].ToString();
                string TIPOCOSTO = dr[(int)colonneCostiFissi.TIPOCOSTO].ToString();
                if (str == EtichetteGruppiReport.PRODUZIONE && TIPOCOSTO != VOCECOSTODIBA.IGNORA)
                    prezzoProduzione += qta * ((decimal)dr[(int)colonneCostiFissi.VALOREFISSO]);
                else if (str == EtichetteGruppiReport.PROTOTIPIA && TIPOCOSTO != VOCECOSTODIBA.IGNORA)
                    prezzoPrototipo += qta * ((decimal)dr[(int)colonneCostiFissi.VALOREFISSO]);
            }

            txtPrezzoPrototipo.Text = prezzoPrototipo.ToString();
            txtPrezzoProduzione.Text = prezzoProduzione.ToString();
            txtPrezzoGrezzo.Text = prezzoGrezzo.ToString();
            txtPrezzoLavorazioneInterna.Text = prezzoLavorazioneInterna.ToString();
            txtPrezzoLavorazioneesterna.Text = prezzoLavorazioneEsterna.ToString();

            txtPrezzoTotale.Text = (prezzoGrezzo + prezzoLavorazioneEsterna + prezzoLavorazioneInterna).ToString();
        }


        private void salvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decimal IDPREVENTIVOT;
            using (PreventiviBusiness bPreventivi = new PreventiviBusiness())
            {
                PreventiviDS.AP_PREVENTIVITRow testata = _dsPreventivi.AP_PREVENTIVIT.FirstOrDefault();
                if (testata == null)
                {
                    IDPREVENTIVOT = bPreventivi.GetID();
                    testata = _dsPreventivi.AP_PREVENTIVIT.NewAP_PREVENTIVITRow();
                    testata.IDPREVENTIVOT = IDPREVENTIVOT;
                    testata.IDVENDITEPF = _IDVENDITEPF.IDVENDITEPF;
                    AggiornaAP_PREVENTIVOT(testata);
                    _dsPreventivi.AP_PREVENTIVIT.AddAP_PREVENTIVITRow(testata);
                }
                else
                {
                    IDPREVENTIVOT = testata.IDPREVENTIVOT;
                    AggiornaAP_PREVENTIVOT(testata);
                }

                PreparaAP_PREVENTIVOC(IDPREVENTIVOT);
                PreparaAP_PREVENTIVOG(IDPREVENTIVOT);

                bPreventivi.UpdateTable(_dsPreventivi.AP_PREVENTIVIT.TableName, _dsPreventivi);
                bPreventivi.UpdateTable(_dsPreventivi.AP_PREVENTIVIC.TableName, _dsPreventivi);
                bPreventivi.UpdateTable(_dsPreventivi.AP_PREVENTIVIG.TableName, _dsPreventivi);

            }
        }

        private void PreparaAP_PREVENTIVOC(decimal IDPREVENTIVOT)
        {
            DateTime dtOra = DateTime.Now;
            using (PreventiviBusiness bPreventivi = new PreventiviBusiness())
            {
                DataTable dtGriglia = _dsGrigliaDettaglio.Tables[_tabellaGrigliaCostiFissi];

                foreach (DataRow riga in dtGriglia.Rows)
                {

                    string IDVENDITEPFDIBACOS = string.Empty;
                    if (riga[(int)colonneCostiFissi.IDVENDITEPFDIBACOS] == DBNull.Value)
                    {
                        IDVENDITEPFDIBACOS = (-1 * bPreventivi.GetID()).ToString();
                        riga[(int)colonneCostiFissi.IDVENDITEPFDIBACOS] = IDVENDITEPFDIBACOS;
                    }
                    else
                        IDVENDITEPFDIBACOS = (string)riga[(int)colonneCostiFissi.IDVENDITEPFDIBACOS];

                    string IDVENDITEPFDIBA = string.Empty; ;
                    if (riga[(int)colonneCostiFissi.IDVENDITEPFDIBA] == DBNull.Value)
                    {
                        IDVENDITEPFDIBA = _IDVENDITEPFDIBA;
                        riga[(int)colonneCostiFissi.IDVENDITEPFDIBA] = _IDVENDITEPFDIBA;
                    }
                    else
                        IDVENDITEPFDIBA = (string)riga[(int)colonneCostiFissi.IDVENDITEPFDIBA];

                    PreventiviDS.AP_PREVENTIVICRow costo = _dsPreventivi.AP_PREVENTIVIC.NewAP_PREVENTIVICRow();
                    costo.IDPREVENTIVOC = bPreventivi.GetID();

                    costo.IDVENDITEPF = _IDVENDITEPF.IDVENDITEPF;
                    costo.IDVENDITEPFDIBA = _IDVENDITEPFDIBA;
                    costo.IDVENDITEPFDIBACOS = IDVENDITEPFDIBACOS;

                    if (!string.IsNullOrEmpty(riga[(int)colonneCostiFissi.SEQUENZA].ToString()))
                        costo.SEQUENZA = riga[(int)colonneCostiFissi.SEQUENZA].ToString().Length > 15 ? riga[(int)colonneCostiFissi.SEQUENZA].ToString().Substring(0, 15) : riga[(int)colonneCostiFissi.SEQUENZA].ToString();

                    costo.DATA = dtOra;
                    if (riga[(int)colonneCostiFissi.VALOREFISSO] != DBNull.Value)
                        costo.VALOREFISSO = (decimal)riga[(int)colonneCostiFissi.VALOREFISSO];
                    else
                        costo.VALOREFISSO = 0;

                    if (riga[(int)colonneCostiFissi.VALORENETTO] != DBNull.Value)
                        costo.VALORENETTO = (decimal)riga[(int)colonneCostiFissi.VALORENETTO];
                    else
                        costo.VALORENETTO = 0;

                    if (riga[(int)colonneCostiFissi.QTAFISSA] != DBNull.Value)
                        costo.QTAFISSA = (decimal)riga[(int)colonneCostiFissi.QTAFISSA];
                    else
                        costo.QTAFISSA = 1;

                    costo.ATTREZZAGGIO = riga[(int)colonneCostiFissi.ATTREZZAGGIO].ToString();
                    costo.DESVOCECOSTO = riga[(int)colonneCostiFissi.DESCVOCECOSTO].ToString();
                    costo.CODVOCECOSTO = riga[(int)colonneCostiFissi.VOCECOSTO].ToString();
                    costo.TIPOCOSTO = riga[(int)colonneCostiFissi.TIPOCOSTO].ToString();
                    _dsPreventivi.AP_PREVENTIVIC.AddAP_PREVENTIVICRow(costo);
                }
            }
        }

        private void PreparaAP_PREVENTIVOG(decimal IDPREVENTIVOT)
        {
            DateTime dtOra = DateTime.Now;
            using (PreventiviBusiness bPreventivi = new PreventiviBusiness())
            {
                DataTable dtGriglia = _dsGrigliaDettaglio.Tables[_tabellaGrigliaGruppi];

                foreach (DataRow riga in dtGriglia.Rows)
                {
                    string IDVENDITEPFGRUPPOT = string.Empty;
                    if (riga[(int)colonneGruppo.IDVENDITEGRUPPOT] == DBNull.Value)
                        IDVENDITEPFGRUPPOT = (-1 * bPreventivi.GetID()).ToString();
                    else
                        IDVENDITEPFGRUPPOT = riga[(int)colonneGruppo.IDVENDITEGRUPPOT].ToString();

                    PreventiviDS.AP_PREVENTIVIGRow gruppo = _dsPreventivi.AP_PREVENTIVIG.NewAP_PREVENTIVIGRow();
                    gruppo.IDPREVENTIVOG = bPreventivi.GetID();
                    gruppo.IDVENDITEPFGRUPPOT = IDVENDITEPFGRUPPOT;
                    gruppo.IDPREVENTIVOT = IDPREVENTIVOT;
                    gruppo.IDVENDITEPF = _IDVENDITEPF.IDVENDITEPF;
                    gruppo.IDVENDITEPT = _IDVENDITEPF.IDVENDITEPT;
                    gruppo.IDVENDITEPD = _IDVENDITEPF.IDVENDITEPD;
                    gruppo.IDVENDITEPFDIBA = _IDVENDITEPFDIBA;
                    gruppo.IDPREVGRUPPO = riga[(int)colonneGruppo.IDPREVGRUPPO].ToString();
                    if (!string.IsNullOrEmpty(riga[(int)colonneGruppo.SEQUENZA].ToString()))
                        gruppo.SEQUENZA = riga[(int)colonneGruppo.SEQUENZA].ToString().Length > 15 ? riga[(int)colonneGruppo.SEQUENZA].ToString().Substring(0, 15) : riga[(int)colonneGruppo.SEQUENZA].ToString();
                    if (riga[(int)colonneGruppo.TOTALECOSTI] != DBNull.Value)
                        gruppo.TOTALECOSTI = (decimal)riga[(int)colonneGruppo.TOTALECOSTI];
                    else
                        gruppo.TOTALECOSTI = 0;

                    if (riga[(int)colonneGruppo.TOTALERICARICO] != DBNull.Value)
                        gruppo.TOTALERICARICO = (decimal)riga[(int)colonneGruppo.TOTALERICARICO];
                    else
                        gruppo.TOTALERICARICO = 0;

                    if (riga[(int)colonneGruppo.TOTALEVENDITACALCOLATO] != DBNull.Value)
                        gruppo.TOTALEVENDITACALCOLATO = (decimal)riga[(int)colonneGruppo.TOTALEVENDITACALCOLATO];
                    else
                        gruppo.TOTALEVENDITACALCOLATO = 0;

                    if (riga[(int)colonneGruppo.TOTALEVENDITAMANUALETOTALE] != DBNull.Value)
                        gruppo.TOTALEVENDITAMANUALET = (decimal)riga[(int)colonneGruppo.TOTALEVENDITAMANUALETOTALE];
                    else
                        gruppo.TOTALEVENDITAMANUALET = 0;

                    if (riga[(int)colonneGruppo.TOTALEVENDITAMANUALEGRUPPO] != DBNull.Value)
                        gruppo.TOTALEVENDITAMANUALEG = (decimal)riga[(int)colonneGruppo.TOTALEVENDITAMANUALEGRUPPO];
                    else
                        gruppo.TOTALEVENDITAMANUALEG = 0;

                    if (riga[(int)colonneGruppo.TOTALECONRICARICO] != DBNull.Value)
                        gruppo.TOTALECONRICARICO = (decimal)riga[(int)colonneGruppo.TOTALECONRICARICO];
                    else
                        gruppo.TOTALECONRICARICO = 0;

                    gruppo.TOTALEVENDITA = 0;
                    gruppo.DATA = dtOra;
                    gruppo.STAMPE = riga[(int)colonneGruppo.STAMPA].ToString();
                    gruppo.CODVOCECOSTO = riga[(int)colonneGruppo.GRUPPO].ToString();
                    gruppo.DESVOCECOSTO = riga[(int)colonneGruppo.DESCRIZIONEGRUPPO].ToString();
                    gruppo.DESCRIZIONE = riga[(int)colonneGruppo.DESCRIZIONE].ToString();
                    gruppo.FORNITORE = riga[(int)colonneGruppo.FORNITORE].ToString();

                    if (riga[(int)colonneGruppo.QUANTITA] != DBNull.Value)
                        gruppo.QUANTITA = (decimal)riga[(int)colonneGruppo.QUANTITA];
                    else
                        gruppo.QUANTITA = 1;
                    _dsPreventivi.AP_PREVENTIVIG.AddAP_PREVENTIVIGRow(gruppo);

                }
            }
        }
        private void AggiornaAP_PREVENTIVOT(PreventiviDS.AP_PREVENTIVITRow testata)
        {
            testata.CODDEFINITIVO = txtCodiceDefinitivo.Text.ToUpper();
            testata.CODGALVANICA = txtCodiceGalvanica.Text.ToUpper();
            testata.CODPROVVISORIO = txtCodiceProvvisorio.Text.ToUpper();
            testata.COMPOSIZIONE = txtComposizioneMateriali.Text.ToUpper();
            testata.DATA = dtData.Value;
            testata.DESCRIZIONE = txtDescrizioneArticolo.Text.ToUpper();
            testata.EVENTO = txtEvento.Text.ToUpper();
            testata.FORNITORE = txtFornitore.Text.ToUpper();
            testata.PESO = txtPeso.Text.ToUpper();
            testata.SPESSOREAU = txtSpessoreAu.Text.ToUpper();
            testata.SPESSOREPD = txtSpessorePd.Text.ToUpper();
            testata.STAGIONE = txtStagione.Text.ToUpper();
            testata.SUPERFICIE = txtSuperficie.Text.ToUpper();
            testata.RICARICO = nRicarico.Value;
        }

        private void PopolaCampiTestataPreventivo()
        {
            PreventiviDS.AP_PREVENTIVITRow testata = _dsPreventivi.AP_PREVENTIVIT.FirstOrDefault();
            if (testata != null)
            {
                txtCodiceDefinitivo.Text = testata.IsCODDEFINITIVONull() ? string.Empty : testata.CODDEFINITIVO;
                txtCodiceGalvanica.Text = testata.IsCODGALVANICANull() ? string.Empty : testata.CODGALVANICA;
                txtCodiceProvvisorio.Text = testata.IsCODPROVVISORIONull() ? string.Empty : testata.CODPROVVISORIO;
                txtComposizioneMateriali.Text = testata.IsCOMPOSIZIONENull() ? string.Empty : testata.COMPOSIZIONE;
                dtData.Value = testata.DATA;
                txtDescrizioneArticolo.Text = testata.IsDESCRIZIONENull() ? string.Empty : testata.DESCRIZIONE;
                txtEvento.Text = testata.IsEVENTONull() ? string.Empty : testata.EVENTO;
                txtFornitore.Text = testata.IsFORNITORENull() ? "METALPLUS" : testata.FORNITORE;
                txtPeso.Text = testata.IsPESONull() ? string.Empty : testata.PESO;
                txtSpessoreAu.Text = testata.IsSPESSOREAUNull() ? string.Empty : testata.SPESSOREAU;
                txtSpessorePd.Text = testata.IsSPESSOREPDNull() ? string.Empty : testata.SPESSOREPD;
                txtStagione.Text = testata.IsSTAGIONENull() ? string.Empty : testata.STAGIONE;
                txtSuperficie.Text = testata.IsSUPERFICIENull() ? string.Empty : testata.SUPERFICIE;
                nRicarico.Value = testata.IsRICARICONull() ? 0 : testata.RICARICO;
            }
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void dgvCostiFissi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            AggiornaPrezzi();
        }

        private void dgvGruppi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            AggiornaValoriConRicarico();
        }


        private void dgvGruppi_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
            if (dgvGruppi.CurrentCell.ColumnIndex == (int)colonneGruppo.SEQUENZA ||
                dgvGruppi.CurrentCell.ColumnIndex == (int)colonneGruppo.TOTALECONRICARICO ||
                dgvGruppi.CurrentCell.ColumnIndex == (int)colonneGruppo.TOTALECOSTI ||
                dgvGruppi.CurrentCell.ColumnIndex == (int)colonneGruppo.TOTALERICARICO ||
                dgvGruppi.CurrentCell.ColumnIndex == (int)colonneGruppo.TOTALEVENDITACALCOLATO ||
                dgvGruppi.CurrentCell.ColumnIndex == (int)colonneGruppo.TOTALEVENDITAMANUALEGRUPPO ||
                dgvGruppi.CurrentCell.ColumnIndex == (int)colonneGruppo.TOTALEVENDITAMANUALETOTALE)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
        }

        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            AggiornaPrezzi();
        }

        private void dgvCostiFissi_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvGruppi.CurrentCell == null) return;
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
            if (dgvGruppi.CurrentCell.ColumnIndex == (int)colonneCostiFissi.QTAFISSA ||
                dgvGruppi.CurrentCell.ColumnIndex == (int)colonneCostiFissi.VALOREFISSO ||
                dgvGruppi.CurrentCell.ColumnIndex == (int)colonneCostiFissi.VALORENETTO)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
            sfd.DefaultExt = "xlsx";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.Cancel) return;
            try
            {
                string filename = sfd.FileName;
                //       string template = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "balenciaga.xlsx");

                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "Preventivi.Balenciaga.xlsx";

                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string result = reader.ReadToEnd();
                    using (var fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write))
                    {
                        stream.Position = 0;
                        stream.CopyTo(fileStream);
                        fileStream.Flush();
                        fileStream.Close();
                    }
                }

                //   File.Copy(template, filename, true);
                CreaFileExcel(filename);
                if (MessageBox.Show("Excel creato con successo. Vuoi aprire il file ?", "INFORMAZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(filename);
                }

            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in creazione excel");
            }
        }

        private void CreaFileExcel(string filename)
        {
            ExcelHelper.InsertText(filename, "A", 11, txtCodiceProvvisorio.Text, false);
            ExcelHelper.InsertText(filename, "C", 11, txtCodiceDefinitivo.Text, false);
            ExcelHelper.InsertText(filename, "E", 11, txtCodiceGalvanica.Text, false);
            ExcelHelper.InsertText(filename, "I", 11, txtFornitore.Text, false);
            ExcelHelper.InsertText(filename, "M", 11, txtDescrizioneArticolo.Text, false);
            ExcelHelper.InsertText(filename, "A", 16, txtStagione.Text, false);
            ExcelHelper.InsertText(filename, "C", 16, txtEvento.Text, false);
            ExcelHelper.InsertText(filename, "F", 16, dtData.Value.ToShortDateString(), false);
            ExcelHelper.InsertText(filename, "A", 21, txtSpessoreAu.Text, false);
            ExcelHelper.InsertText(filename, "C", 21, txtSpessorePd.Text, false);
            ExcelHelper.InsertText(filename, "E", 21, txtSuperficie.Text, false);
            ExcelHelper.InsertText(filename, "F", 22, txtPeso.Text, false);
            ExcelHelper.InsertText(filename, "A", 26, txtComposizioneMateriali.Text, false);

            DataTable dtGriglia = _dsGrigliaDettaglio.Tables[_tabellaGrigliaGruppi];
            int indiceRigaDiba = 0;
            int indiceRigaLavInterna = 0;
            int indiceRigaLavEsterna = 0;
            foreach (DataRow riga in dtGriglia.Rows)
            {
                string descrizione = riga[(int)colonneGruppo.DESCRIZIONE].ToString().ToUpper();
                string fornitore = riga[(int)colonneGruppo.FORNITORE].ToString().ToUpper();
                string quantita = riga[(int)colonneGruppo.QUANTITA].ToString();
                string prezzo = riga[(int)colonneGruppo.TOTALECONRICARICO].ToString();
                string stampa = riga[(int)colonneGruppo.STAMPA].ToString();

                int indiceRiga = 34;//distinta base
                if (stampa == EtichetteGruppiReport.DISTINTABASE)
                {
                    ExcelHelper.InsertText(filename, "A", indiceRiga + indiceRigaDiba, string.Empty, false);
                    ExcelHelper.InsertText(filename, "D", indiceRiga + indiceRigaDiba, descrizione, false);
                    ExcelHelper.InsertText(filename, "L", indiceRiga + indiceRigaDiba, fornitore, false);
                    ExcelHelper.InsertText(filename, "N", indiceRiga + indiceRigaDiba, prezzo, true);
                    ExcelHelper.InsertText(filename, "O", indiceRiga + indiceRigaDiba, "0", true);
                    ExcelHelper.InsertText(filename, "P", indiceRiga + indiceRigaDiba, quantita, true);
                    indiceRigaDiba++;
                }

                indiceRiga = 55;//lavorazioni interne
                if (stampa == EtichetteGruppiReport.INTERNE)
                {
                    ExcelHelper.InsertText(filename, "A", indiceRiga + indiceRigaLavInterna, string.Empty, false);
                    ExcelHelper.InsertText(filename, "D", indiceRiga + indiceRigaLavInterna, descrizione, false);
                    ExcelHelper.InsertText(filename, "L", indiceRiga + indiceRigaLavInterna, fornitore, false);
                    ExcelHelper.InsertText(filename, "O", indiceRiga + indiceRigaLavInterna, prezzo, true);
                    ExcelHelper.InsertText(filename, "P", indiceRiga + indiceRigaLavInterna, quantita, true);
                    indiceRigaLavInterna++;
                }

                indiceRiga = 77;//lavorazioni esterne
                if (stampa == EtichetteGruppiReport.ESTERNE)
                {
                    ExcelHelper.InsertText(filename, "A", indiceRiga + indiceRigaLavEsterna, string.Empty, false);
                    ExcelHelper.InsertText(filename, "D", indiceRiga + indiceRigaLavEsterna, descrizione, false);
                    ExcelHelper.InsertText(filename, "L", indiceRiga + indiceRigaLavEsterna, fornitore, false);
                    ExcelHelper.InsertText(filename, "N", indiceRiga + indiceRigaLavEsterna, prezzo, true);
                    ExcelHelper.InsertText(filename, "O", indiceRiga + indiceRigaLavEsterna, "0", true);
                    ExcelHelper.InsertText(filename, "P", indiceRiga + indiceRigaLavEsterna, quantita, true);
                    indiceRigaLavEsterna++;
                }
            }

            DataTable dtGrigliaCostiFissi = _dsGrigliaDettaglio.Tables[_tabellaGrigliaCostiFissi];

            foreach (DataRow riga in dtGrigliaCostiFissi.Rows)
            {
                string tipoCosto = riga[(int)colonneCostiFissi.TIPOCOSTO].ToString().ToUpper();
                string attrezzaggio = riga[(int)colonneCostiFissi.ATTREZZAGGIO].ToString();
                string prezzo = riga[(int)colonneCostiFissi.VALOREFISSO].ToString();

                int indiceRiga = 0;
                if (attrezzaggio == EtichetteGruppiReport.PROTOTIPIA)
                    indiceRiga = 100;

                if (attrezzaggio == EtichetteGruppiReport.PRODUZIONE)
                    indiceRiga = 107;

                if (attrezzaggio == EtichetteGruppiReport.IGNORA) continue;

                switch (tipoCosto)
                {
                    case VOCECOSTODIBA.GOMMA:
                        ExcelHelper.InsertText(filename, "C", indiceRiga, prezzo, true);
                        break;
                    case VOCECOSTODIBA.STAMPA3D:
                        ExcelHelper.InsertText(filename, "A", indiceRiga, prezzo, true);
                        break;
                    case VOCECOSTODIBA.STAMPAGGIOCALDO:
                        ExcelHelper.InsertText(filename, "E", indiceRiga, prezzo, true);
                        break;
                    case VOCECOSTODIBA.STAMPAGGIOFREDDO:
                        ExcelHelper.InsertText(filename, "G", indiceRiga, prezzo, true);
                        break;
                    case VOCECOSTODIBA.PRESSOFUSIONE:
                        ExcelHelper.InsertText(filename, "I", indiceRiga, prezzo, true);
                        break;
                }
            }
        }
    }

    public static class EtichetteGruppiReport
    {
        public const string DISTINTABASE = "Distinta Base";
        public const string INTERNE = "Lavorazioni interne";
        public const string ESTERNE = "Lavorazioni esterne";
        public const string PROTOTIPIA = "Prototipia";
        public const string PRODUZIONE = "Produzione";
        public const string IGNORA = "Ignora";
    }

    public static class VOCECOSTODIBA
    {
        public const string STAMPAGGIOCALDO = "STCALDO";
        public const string STAMPAGGIOFREDDO = "STFREDDO";
        public const string PRESSOFUSIONE = "STPRESS";
        public const string GOMMA = "GOMMA";
        public const string STAMPA3D = "ST3D";
        public const string IGNORA = "Ignora";
    }
}

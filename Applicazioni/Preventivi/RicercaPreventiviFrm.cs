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
    public partial class RicercaPreventiviFrm : BaseChildForm
    {
        private string _filtroCliente;
        private string _etichettaCliente;
        private string _riferimento;
        public PreventiviDS.USR_VENDITEPFRow USR_VENDITEPF { get; private set; }
        public PreventiviDS.USR_VENDITEPDRow USR_VENDITEPD { get; private set; }

        private PreventiviDS _ds = new PreventiviDS();
        private AnagraficaDS _dsAnagrafica = new AnagraficaDS();
        public RicercaPreventiviFrm(string FiltroCliente, string EtichettaCliente, string Riferimento)
        {
            _etichettaCliente = EtichettaCliente;
            _filtroCliente = FiltroCliente;
            _riferimento = Riferimento;

            InitializeComponent();
        }

        private void RicercaPreventiviFrm_Load(object sender, EventArgs e)
        {
            try
            {
                lblErrore.Text = string.Empty;
                this.Text = this.Text + " - " + _etichettaCliente + " - " + _riferimento;
                using (PreventiviBusiness bPreventivo = new PreventiviBusiness())
                {
                    bPreventivo.FillUSR_VENDITEPT(_ds, _riferimento, _filtroCliente);
                    if (_ds.USR_VENDITEPT.Rows.Count == 0)
                    {
                        lblErrore.Text = "Nessun elemento trovato";
                        return;
                    }
                    else
                    {
                        dgvArticoli.DataSource = _ds;
                        if (dgvArticoli.Rows.Count > 0)
                            caricaGrigliaArticoliDettaglio(0);
                    }
                }
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "ERRORE IN RICERCA PREVENTIVI");
            }
        }

        private void caricaGrigliaArticoliDettaglio(int indiceRiga)
        {
            try
            {
                string IDVENDITEPT = (string)dgvArticoli.Rows[indiceRiga].Cells[0].Value;
                if (IDVENDITEPT == string.Empty)
                {
                    throw new ArgumentException("Valore IDVENDITEPT non trovato. Impossibile trovare il preventivo richiesto.");
                }

                if (!_ds.USR_VENDITEPD.Any(x => x.IDVENDITEPT == IDVENDITEPT))
                {
                    using (PreventiviBusiness bPreventivi = new PreventiviBusiness())
                    {
                        bPreventivi.FillUSR_VENDITEPD(_ds, IDVENDITEPT);
                    }
                }
                dgvArticoliDettaglio.DataSource = _ds.USR_VENDITEPD.Where(x => x.IDVENDITEPT == IDVENDITEPT).ToArray();
                if (dgvArticoliDettaglio.Rows.Count > 0)
                    caricaGrigliaScaglioni(0);

            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "ERRORE IN RICERCA PREVENTIVI");
            }
        }

        private void dgvArticoli_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            caricaGrigliaArticoliDettaglio(e.RowIndex);
        }

        private void dgvArticoliDettaglio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            caricaGrigliaScaglioni(e.RowIndex);
        }

        private void caricaGrigliaScaglioni(int indiceRiga)
        {
            try
            {
                string IDVENDITEPD = (string)dgvArticoliDettaglio.Rows[indiceRiga].Cells[0].Value;
                if (IDVENDITEPD == string.Empty)
                {
                    throw new ArgumentException("Valore IDVENDITEPF non trovato. Impossibile trovare il preventivo richiesto.");
                }

                if (!_ds.USR_VENDITEPF.Any(x => x.IDVENDITEPD == IDVENDITEPD))
                {
                    using (PreventiviBusiness bPreventivi = new PreventiviBusiness())
                    {
                        bPreventivi.FillUSR_VENDITEPF(_ds, IDVENDITEPD);
                    }
                }
                dgvScaglioni.DataSource = _ds.USR_VENDITEPF.Where(x => x.IDVENDITEPD == IDVENDITEPD).ToArray();

            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "ERRORE IN RICERCA PREVENTIVI");
            }
        }

        private void dgvScaglioni_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            USR_VENDITEPF = null;
            if (e.RowIndex == -1) return;
            string IDVENDITEPF = (string)dgvScaglioni.Rows[e.RowIndex].Cells[0].Value;
            USR_VENDITEPF = _ds.USR_VENDITEPF.Where(x => x.IDVENDITEPF == IDVENDITEPF).FirstOrDefault();

            string IDVENDITEPD = (string)dgvScaglioni.Rows[e.RowIndex].Cells[1].Value;
            USR_VENDITEPD = _ds.USR_VENDITEPD.Where(x => x.IDVENDITEPD == IDVENDITEPD).FirstOrDefault();

            this.Close();
        }
    }
}

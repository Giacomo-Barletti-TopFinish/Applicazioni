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
                    }
                }
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "ERRORE IN RICERCA PREVENTIVI");
            }
        }

        private void dgvArticoli_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            try
            {
                string IDVENDITEPT = (string)dgvArticoli.Rows[e.RowIndex].Cells[0].Value;
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

            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "ERRORE IN RICERCA PREVENTIVI");
            }
        }
    }
}

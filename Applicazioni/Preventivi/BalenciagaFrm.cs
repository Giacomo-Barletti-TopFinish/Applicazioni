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
        public BalenciagaFrm()
        {
            InitializeComponent();
        }

        private void BalenciagaFrm_Load(object sender, EventArgs e)
        {

        }

        private void btnTrova_Click(object sender, EventArgs e)
        {
            try
            {
                string filtro = Properties.Settings.Default.FiltroBalenciaga;
                RicercaPreventiviFrm frm = new RicercaPreventiviFrm(filtro, "BALENCIAGA", txtRiferimento.Text);
//                frm.MdiParent= this.MdiParent;
                frm.ShowDialog();
            }
            catch(Exception ex)
            {
                MostraEccezione(ex, "ERRORE IN TROVA PREVENTIVO");
            }
        }
    }
}

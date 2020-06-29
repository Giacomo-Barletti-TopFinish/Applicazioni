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
using AnalisiOrdiniVendita;
using Applicazioni.BLL;

namespace AnalisiOrdiniVendita
{
    public partial class RicercaForm : Form
    {
        private AnalisiOrdiniVenditaDS _ds = new AnalisiOrdiniVenditaDS();
        public RicercaForm()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            caricaGrigliaOC();
        }

        private void caricaGrigliaOC()
        {

            dgvOC.DataSource = _ds;
            dgvOC.DataMember = _ds.OC_APERTI.TableName;

            dgvOC.Columns[10].Visible = false;
            dgvOC.Columns[11].Visible = false;
            dgvOC.Columns[12].Visible = false;
            dgvOC.Columns[13].Visible = false;
            dgvOC.Columns[14].Visible = false;
            for (int i = 16; i <= 40; i++)
                dgvOC.Columns[i].Visible = false;
            for (int i = 54; i <= 62; i++)
                dgvOC.Columns[i].Visible = false;
            for (int i = 64; i <= 81; i++)
                dgvOC.Columns[i].Visible = false;
            for (int i = 93; i <= 108; i++)
                dgvOC.Columns[i].Visible = false;
            dgvOC.Columns[111].Visible = false;
            dgvOC.Columns[112].Visible = false;
            dgvOC.Columns[113].Visible = false;

        }

     

        private void dgvOC_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (e.StateChanged != DataGridViewElementStates.Selected)
                    return;
                //            pannello.Controls.Clear();
                string idvendited = (string)e.Row.Cells[10].Value;
                AnalisiOrdiniVenditaDS.OC_APERTIRow dettaglio = _ds.OC_APERTI.Where(x => x.IDVENDITED == idvendited).FirstOrDefault();
                //        idvendited = "0000000000000000001403575";

                CommessaForm form = new CommessaForm();
                form.Dettaglio = dettaglio;
                form.MdiParent = this.MdiParent;
                form.Show();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void RicercaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
         //   e.Cancel = true;
        }

        private void btnCerca_Click(object sender, EventArgs e)
        {
            _ds.OC_APERTI.Clear();
            OrdiniVendita ov = new OrdiniVendita();
            ov.EstraiOC(_ds, txtRiferimento.Text, txtFullNumDoc.Text, txtModello.Text);

            caricaGrigliaOC();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtCommessa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

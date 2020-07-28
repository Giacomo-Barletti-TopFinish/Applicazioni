using Applicazioni.BLL;
using Applicazioni.Common;
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

namespace SpedizioniFrm
{

    public partial class SaldiFrm : ChildBaseForm
    {
        private SpedizioniDS _ds = new SpedizioniDS();
        private DataSet _dsGriglia = new DataSet();
        private string _tabellaGriglia = "Griglia";
        public SaldiFrm()
        {
            InitializeComponent();
        }

        private void SaldiFrm_Load(object sender, EventArgs e)
        {

            CreaGriglia();

        }

        enum colonneGriglia { UBICAZIONE, DESCRIZIONE, ARTICOLO, QUANTITA,PULSANTE,IDSALDO }

        private void CreaGriglia()
        {
            _ds.SPSALDI.Clear();

            dgvSaldi.AutoGenerateColumns = false;
            dgvSaldi.DataSource = _ds;
            dgvSaldi.DataMember = _ds.SPSALDIEXT.TableName;

            dgvSaldi.Refresh();
        }

        private void dgvSaldi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!Contesto.Utente.SpedizioniMovimenta) return;
            if (e.ColumnIndex != (int)colonneGriglia.PULSANTE) return;
            if (e.RowIndex < 0) return;

            Decimal idsaldo = (decimal)dgvSaldi.Rows[e.RowIndex].Cells[(int)colonneGriglia.IDSALDO].Value;
            SpedizioniDS.SPSALDIEXTRow saldo = _ds.SPSALDIEXT.Where(x => x.IDSALDO == idsaldo).FirstOrDefault();
            if(saldo==null)
            {
                MessageBox.Show("Errore nella selezione del saldo", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MovimentiFrm form = new MovimentiFrm(saldo,_utenteConnesso);

            if(form.ShowDialog()== DialogResult.OK)
            {
                btnCerca_Click(null, null);
            }
        }

        private void btnCerca_Click(object sender, EventArgs e)
        {
            this.Text = string.Format("SALDI {0} - {1}", txtubicazione.Text, txtarticolo.Text);
            Spedizioni spedizioni = new Spedizioni();
            spedizioni.FillSaldi(_ds, txtubicazione.Text, txtarticolo.Text);
            CreaGriglia();

        }
    }

}



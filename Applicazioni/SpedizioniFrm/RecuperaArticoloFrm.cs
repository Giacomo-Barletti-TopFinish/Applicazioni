using Applicazioni.BLL;
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
    public partial class RecuperaArticoloFrm : Form
    {
        private SpedizioniDS _ds = new SpedizioniDS();
        private string _filtro;
        public string IDMAGAZZ { get; private set; }
        public string Modello { get; private set; }

        public RecuperaArticoloFrm(string filtro)
        {
            _filtro = filtro;
            InitializeComponent();
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void RecuperaArticoloFrm_Load(object sender, EventArgs e)
        {
            Spedizioni spedizioni = new Spedizioni();
            spedizioni.FillMagazz(_ds, _filtro);
            creaGriglia();
        }

        private void creaGriglia()
        {
            dgvRisultati.AutoGenerateColumns = false;
            dgvRisultati.DataSource = _ds;
            dgvRisultati.DataMember = _ds.MAGAZZ.TableName;
        }

        private void dgvRisultati_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            IDMAGAZZ = (string)dgvRisultati.Rows[e.RowIndex].Cells[0].Value;
            Modello= (string)dgvRisultati.Rows[e.RowIndex].Cells[1].Value;
            DialogResult= DialogResult.OK;
            Close();
        }
    }
}

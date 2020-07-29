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
    public partial class ListamovimentiFrm : ChildBaseForm
    {
        private SpedizioniDS _ds = new SpedizioniDS();
        private DataSet _dsGriglia = new DataSet();
        private string _tabellaGriglia = "Griglia";
        public ListamovimentiFrm()
        {
            InitializeComponent();
        }

         private void ListamovimentiFrm_Load(object sender, EventArgs e)
        {
            dtFine.Value = DateTime.Today;
            dtInizio.Value = DateTime.Today.AddDays(-7);

            CreaGriglia();

        }

        enum colonneGriglia { IDUBICAZIONE_,UBICAZIONE_, ARTICOLO_, QUANTITA_, DATAMODIFICA }

        private void CreaGriglia()
        {
            _ds.SPMOVIMENTI.Clear();

            dgvlistamovimenti.AutoGenerateColumns = false;
            dgvlistamovimenti.DataSource = _ds;
            dgvlistamovimenti.DataMember = _ds.SPMOVIMENTIEXT.TableName;

            dgvlistamovimenti.Refresh();
        }

        private void btncerca_Click(object sender, EventArgs e)
        {
            DateTime inizio = new DateTime( dtInizio.Value.Year, dtInizio.Value.Month, dtInizio.Value.Day,0,0,0);

            DateTime fine = new DateTime(dtFine.Value.Year, dtFine.Value.Month, dtFine.Value.Day, 23, 59, 59);

            if (inizio > fine)
                return;

            CreaGriglia();

        }

    }
}

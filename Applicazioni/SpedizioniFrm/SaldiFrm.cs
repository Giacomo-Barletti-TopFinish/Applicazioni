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
            dgvSaldi.AutoGenerateColumns = false;
            CreaGriglia();

        }

        private void CreaGriglia()
        {
            _ds.SPUBICAZIONI.Clear();
            Spedizioni spedizioni = new Spedizioni();
            spedizioni.FillSaldi(_ds, true);

            dgvSaldi.DataSource = _ds;
            dgvSaldi.DataMember = _ds.SPSALDI.TableName;

            dgvSaldi.Refresh();
        }
    }
    
}

       

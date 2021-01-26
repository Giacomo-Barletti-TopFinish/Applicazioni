using Applicazioni.Data.FlussoFatture;
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

namespace FlussoFatture
{
    public partial class FrmModificaPrezziMAMI : Form
    {
        private FlussoFattureDS _ds = new FlussoFattureDS();

        public FrmModificaPrezziMAMI()
        {
            InitializeComponent();
        }

        private void FrmModificaPrezziMAMI_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void FrmModificaPrezziMAMI_Load(object sender, EventArgs e)
        {
            using (FlussoFattureBusiness bFlussoFatture = new FlussoFattureBusiness())
            {
                bFlussoFatture.FillMATERIALIMAMI(_ds);
            }

            dgvMateriali.AutoGenerateColumns = false;
            dgvMateriali.DataSource = _ds;
            dgvMateriali.DataMember = _ds.MATERIALIMAMI.TableName;
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            using (FlussoFattureBusiness bFlussoFatture = new FlussoFattureBusiness())
            {
                bFlussoFatture.UpdateTable(_ds.MATERIALIMAMI.TableName, _ds);
            }

        }
    }
}

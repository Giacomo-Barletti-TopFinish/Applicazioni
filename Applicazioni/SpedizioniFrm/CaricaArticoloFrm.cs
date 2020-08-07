using Applicazioni.BLL;
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
    public partial class CaricaArticoloFrm : Form
    {
        private string _idmagazz;

        public CaricaArticoloFrm()
        {
            InitializeComponent();
        }

        private void CaricaArticoloFrm_Load(object sender, EventArgs e)
        {
            lblEsito.Text = string.Empty;
        }

        private void btnricerca_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtarticolo.Text)) return;

            RecuperaArticoloFrm form = new RecuperaArticoloFrm(txtarticolo.Text.ToUpper());
            if(form.ShowDialog()==DialogResult.OK)
            {
                _idmagazz = form.IDMAGAZZ;
                txtarticolo.Text = form.Modello;
            }
        }
    }
}

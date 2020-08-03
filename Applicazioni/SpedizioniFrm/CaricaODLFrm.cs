using Applicazioni.BLL;
using Applicazioni.Common;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpedizioniFrm
{
    public partial class CaricaODLFrm : ChildBaseForm
    {
        private SpedizioniDS _ds = new SpedizioniDS();


        public CaricaODLFrm()
        {
            InitializeComponent();
        }


        private void txtubicazione_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblEsito.Text = string.Empty;
                lblUbicazione.Text = string.Empty;
                string barcode = txtubicazione.Text;
                Spedizioni spedizioni = new Spedizioni();
                lblUbicazione.Text = spedizioni.LeggiBarcode(barcode);
                btnesegui.Focus();
            }



        }

        private void CaricaODLFrm_Load(object sender, EventArgs e)
        {
            lblOdl.Text = string.Empty;
            lblUbicazione.Text = string.Empty;
            lblEsito.Text = string.Empty;

        }

        private void txtOdl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblEsito.Text = string.Empty;
                lblOdl.Text = string.Empty;
                string barcode = txtOdl.Text;
                Spedizioni spedizioni = new Spedizioni();
                lblOdl.Text = spedizioni.LeggiBarcode(barcode);
                txtubicazione.Focus();
            }
        }

        private void btnesegui_Click(object sender, EventArgs e)
        {
            Spedizioni spedizioni = new Spedizioni();
            string esito = spedizioni.UbicaDaODL(txtOdl.Text, txtubicazione.Text, _utenteConnesso);
            if(esito == "COMPLETATA")
            {
                txtOdl.Focus();
                txtOdl.Text = string.Empty;
                txtubicazione.Text = string.Empty;
                lblEsito.ForeColor = Color.Green;
            }
            else
                lblEsito.ForeColor = Color.Red;
            lblEsito.Text = esito;
        }
    }
}

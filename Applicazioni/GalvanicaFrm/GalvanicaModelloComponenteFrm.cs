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

namespace GalvanicaFrm
{
    public partial class GalvanicaModelloComponenteFrm : BaseForm
    {
        private GalvanicaDS.USR_PRD_MOVFASIRow _odl;

        public string Superficie;
        public string Brand;
        public string Galvanica;
        public string Materiale;
        public string Finitura;
        public decimal PezziBarra;
        public GalvanicaModelloComponenteFrm(GalvanicaDS.USR_PRD_MOVFASIRow odl)
        {
            _odl = odl;
            InitializeComponent();
        }

        private void PopolaDropDownListBrand()
        {
            List<string> elementi = new List<string>();
            elementi.Add("YSL");
            elementi.Add("CHANEL");
            elementi.Add("BALENCIAGA");
            elementi.Add("GUCCI");
            elementi.Add("LOUIS VUITTON");
            elementi.Add("BOTTEGA VENETA");
            elementi.Add("TOM FORD");
            elementi.Add("FENDI");
            elementi.Add("MONTBLANC");
            elementi.Add("CELINE");
            elementi.Add("ALCE");

            elementi.Sort();

            ddlBrand.Items.AddRange(elementi.ToArray());
        }

        private void PopolaDropDownListMateriale()
        {
            List<string> elementi = new List<string>();
            elementi.Add("OTTONE");
            elementi.Add("ZAMA");
            elementi.Add("Altro");

            elementi.Sort();

            ddlMateriale.Items.AddRange(elementi.ToArray());
        }

        private void PopolaDropDownListGalvanica()
        {
            List<string> elementi = new List<string>();
            elementi.Add("AUTOMATICA");
            elementi.Add("ROTO");
            elementi.Add("STATICA");

            elementi.Sort();

            ddlGalvanica.Items.AddRange(elementi.ToArray());
        }

        private void GalvanicaModelloComponenteFrm_Load(object sender, EventArgs e)
        {
            lblMessaggio.Text = string.Empty;
            lblModello.Text = string.Format("Modello: {0} - Componente: {1}", _odl.MODELLO_LANCIO, _odl.MODELLO_WIP);
            PopolaDropDownListBrand();
            PopolaDropDownListMateriale();
            PopolaDropDownListGalvanica();

            txtSuperficie.Text = Superficie;
            if (!string.IsNullOrEmpty(Brand))
                ddlBrand.SelectedItem = Brand;

            if (!string.IsNullOrEmpty(Galvanica))
                ddlGalvanica.SelectedItem = Galvanica;

            if (!string.IsNullOrEmpty(Materiale))
                ddlMateriale.SelectedItem = Materiale;
            txtFinitura.Text = Finitura;
            nPezziBarra.Value = PezziBarra;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            if (ddlMateriale.SelectedIndex == -1)
            {
                lblMessaggio.Text = "Materiale non valorizzato";
                return;
            }

            if (ddlBrand.SelectedIndex == -1)
            {
                lblMessaggio.Text = "Brand non valorizzato";
                return;
            }

            if (ddlGalvanica.SelectedIndex == -1)
            {
                lblMessaggio.Text = "Galvanica non valorizzato";
                return;
            }

            if (string.IsNullOrEmpty(txtSuperficie.Text))
            {
                lblMessaggio.Text = "Superficie non valorizzato";
                return;
            }

            if (string.IsNullOrEmpty(txtFinitura.Text))
            {
                lblMessaggio.Text = "Finitura non valorizzato";
                return;
            }

            if (nPezziBarra.Value == 0)
            {
                lblMessaggio.Text = "Pezzi barra non valorizzato";
                return;
            }

            Superficie = txtSuperficie.Text;
            Materiale = (string)ddlMateriale.SelectedItem;
            Brand = (string)ddlBrand.SelectedItem;
            Galvanica = (string)ddlGalvanica.SelectedItem;
            this.DialogResult = DialogResult.OK;
            Finitura = txtFinitura.Text;
            PezziBarra = nPezziBarra.Value;
        }
    }
}

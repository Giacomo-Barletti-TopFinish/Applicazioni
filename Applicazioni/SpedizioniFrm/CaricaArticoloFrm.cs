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
    public partial class CaricaArticoloFrm : ChildBaseForm
    {
        private SpedizioniDS _ds = new SpedizioniDS();

        public CaricaArticoloFrm()
        {
            InitializeComponent();
        }

        private void CaricaArticoloFrm_Load(object sender, EventArgs e)
        {
            lblEsito.Text = string.Empty;
            Spedizioni sp = new Spedizioni();
            sp.FillUbicazioni(_ds, true);
        }

        private void btnricerca_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtarticolo.Text)) return;

            RecuperaArticoloFrm form = new RecuperaArticoloFrm(txtarticolo.Text.ToUpper());
            if (form.ShowDialog() == DialogResult.OK)
            {
                txtarticolo.Text = form.Modello;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (nQuantita.Value == 0)
            {
                MessageBox.Show("Indicare LA QUANTITà", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Spedizioni sp = new Spedizioni();
            lblEsito.Text = String.Empty;

            if (string.IsNullOrEmpty(txtUbicazione.Text))
            {
                MessageBox.Show("Indicare l'ubicazione", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            txtUbicazione.Text = txtUbicazione.Text.ToUpper();
            txtarticolo.Text = txtarticolo.Text.ToUpper();
            txtCausale.Text = txtCausale.Text.ToUpper();

            SpedizioniDS.SPUBICAZIONIRow ubicazione = _ds.SPUBICAZIONI.Where(x => x.CODICE == txtUbicazione.Text).FirstOrDefault();
            if (ubicazione == null)
            {
                MessageBox.Show("Ubicazione inesistente", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtarticolo.Text))
            {
                MessageBox.Show("Indicare l'articolo", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sp.FillMagazz(_ds, txtarticolo.Text);
            if (_ds.MAGAZZ.Count == 0)
            {
                MessageBox.Show("Impossibile trovare l'articolo", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_ds.MAGAZZ.Count > 1)
            {
                MessageBox.Show("Più articoli trovati con questa descrizione. Filtrare i dati", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SpedizioniDS.MAGAZZRow articolo = _ds.MAGAZZ.Where(x => x.MODELLO == txtarticolo.Text).FirstOrDefault();
            Anagrafica anagrafica = new Anagrafica();
            AnagraficaDS.MAGAZZRow art = anagrafica.GetMAGAZZ(articolo.IDMAGAZZ);

            if (!sp.Inserimento(ubicazione, art, nQuantita.Value, txtCausale.Text, _utenteConnesso))
            {
                MessageBox.Show("OPERAZIONE FALLITA errore nel salvataggio", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblEsito.Text = "OPERAZIONE RIUSCITA";

            nQuantita.Value = 0;
        }


    }
}


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
    public partial class MovimentiFrm : Form
    {
        private SpedizioniDS.SPSALDIEXTRow _saldo;
        private string _utente;
        public MovimentiFrm(SpedizioniDS.SPSALDIEXTRow saldo, string utente)
        {
            _saldo = saldo;
            _utente = utente;
            InitializeComponent();
            TXTCODICE.Text = saldo.CODICE;
            TXTDESCRIZIONE.Text = saldo.DESCRIZIONE;
            TXTMODELLO.Text = saldo.MODELLO;
            TXTQUANTITASALDO.Text = saldo.QUANTITA.ToString();
            ddlTipoMovimento.SelectedIndex = -1;
            numQuta.Maximum = 1000000;

            this.Text = string.Format("MOVIMENTA {0}   ARTICOLO {1}",saldo.CODICE,saldo.MODELLO);
        }

        private void BTNANNULLA_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BTNOK_Click(object sender, EventArgs e)
        {
            if(ddlTipoMovimento.SelectedIndex==-1)
            {
                MessageBox.Show("Selezionare un tipo movimento", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(TXTCAUSALE.Text))
            {
                MessageBox.Show("Indicare la causale", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (numQuta.Value==0)
            {
                MessageBox.Show("Indicare una quantità", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Spedizioni spedizioni = new Spedizioni();
            string esito = spedizioni.Movimenta(_saldo.IDSALDO, numQuta.Value, TXTCAUSALE.Text, (string)ddlTipoMovimento.SelectedItem, _utente);
            if(esito == "COMPLETATA")
            {
                MessageBox.Show("Operazione eseguita con successo", "INFORMAZIONE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();

            }
            else
            {
                MessageBox.Show(esito, "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }

       
}

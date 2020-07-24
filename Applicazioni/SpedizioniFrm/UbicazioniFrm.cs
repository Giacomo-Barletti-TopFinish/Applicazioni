using Applicazioni.BLL;
using Applicazioni.Common;
using Applicazioni.Data.Spedizioni;
using Applicazioni.Entities;
using Applicazioni.Helpers;
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
    public partial class UbicazioniFrm : ChildBaseForm
    {
        private SpedizioniDS _ds = new SpedizioniDS();
        private DataSet _dsGriglia = new DataSet();
        private string _tabellaGriglia = "Griglia";
        public UbicazioniFrm()

        {
            InitializeComponent();
        }

        private void UbicazioniFrm_Load(object sender, EventArgs e)
        {
            dgvUbicazioni.AutoGenerateColumns = false;
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                ddlStampanti.Items.Add(printer);
            }
            if (ddlStampanti.Items.Count > 0)
                ddlStampanti.SelectedIndex = 0;

            CreaGriglia();
        }

     
        enum colonneGriglia { IDUBICAZIONE, CODICE, DESCRIZIONE, BARCODE }
        private void CreaDSGriglia()
        {
            DataTable dtGriglia = _dsGriglia.Tables.Add();
            dtGriglia.TableName = _tabellaGriglia;

            int numeroColonne = Enum.GetNames(typeof(colonneGriglia)).Length;
            for (int i = 0; i < numeroColonne; i++)
            {
                string colonna = Enum.GetName(typeof(colonneGriglia), i);
                switch (i)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        dtGriglia.Columns.Add(colonna, Type.GetType("System.String")).ReadOnly = true;
                        break;
                    case 4:
                        dtGriglia.Columns.Add(colonna, Type.GetType("System.Decimal")).ReadOnly = true;
                        break;
                    case 5:
                        dtGriglia.Columns.Add(colonna, Type.GetType("System.Decimal"));
                        break;
                }
            }
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodiceUbicazione.Text))
                {
                    MessageBox.Show("Inserire il codice dell'ubicazione", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(txtDescrizioneUbicazione.Text))
                {
                    MessageBox.Show("Inserire la descrizione dell'ubicazione", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string codice = txtCodiceUbicazione.Text.ToUpper();
                string descrizione = txtDescrizioneUbicazione.Text.ToUpper();

                Spedizioni spedizioni = new Spedizioni();

                SpedizioniDS ds = new SpedizioniDS();
                spedizioni.FillUbicazioni(ds, false);

                if (_ds.SPUBICAZIONI.Any(x => x.CODICE == codice))
                {
                    MessageBox.Show("Esiste già un'ubicazione con questo codice", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                spedizioni.SalvaUbicazione(codice, descrizione, _utenteConnesso);
                CreaGriglia();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore nel salvataggio dell'ubicazione", ex);
            }

        }



        private void CreaGriglia()
        {
            _ds.SPUBICAZIONI.Clear();
            Spedizioni spedizioni = new Spedizioni();
            spedizioni.FillUbicazioni(_ds,true);

            dgvUbicazioni.DataSource = _ds;
            dgvUbicazioni.DataMember = _ds.SPUBICAZIONI.TableName;

            dgvUbicazioni.Refresh();

        }

        private void dgvUbicazioni_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 4 || e.ColumnIndex > 5) return;
            if (e.RowIndex < 0) return;
            try
            {
                if (e.ColumnIndex == 4)
                {
                    decimal idUbicazione = (decimal)dgvUbicazioni.Rows[e.RowIndex].Cells[0].Value;
                    Spedizioni spedizioni = new Spedizioni();
                    spedizioni.CancellaUbicazione(idUbicazione, _utenteConnesso);
                }

                if (e.ColumnIndex == 5)
                {

                    if (ddlStampanti.SelectedIndex == -1)
                    {
                        MessageBox.Show("Selezionare una stampante", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string PrinterName = ddlStampanti.SelectedItem.ToString();
                    string codice = (string)dgvUbicazioni.Rows[e.RowIndex].Cells[1].Value;
                    string descrizione = (string)dgvUbicazioni.Rows[e.RowIndex].Cells[2].Value;
                    string barcode = (string)dgvUbicazioni.Rows[e.RowIndex].Cells[3].Value;

                    ZebraHelper.StampaEtichettaUbicazione(PrinterName,codice, descrizione, barcode);
                }

            }
            catch (Exception ex)
            {
                MostraEccezione("Impossibile eseguire l'operazione", ex);
            }
        }
    }
}

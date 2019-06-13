using Applicazioni.Common;
using Applicazioni.Data.Galvanica;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalvanicaFrm
{
    public partial class GalvanicaFrm : BaseForm
    {
        private GalvanicaDS _ds = new GalvanicaDS();
        private DataSet _dsGriglia = new DataSet();
        private string _tabellaGriglia = "Griglia";

        public GalvanicaFrm()
        {
            InitializeComponent();
            lblMessaggi.Text = string.Empty;
            dtGiorno.Value = DateTime.Today;
            txtBarcode.Focus();
        }

        private void dtGiorno_ValueChanged(object sender, EventArgs e)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            int settimana = cal.GetWeekOfYear(dtGiorno.Value, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            lblSettimana.Text = string.Format("Settimana {0}", settimana);
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblMessaggi.Text = string.Empty;
                string barcode = txtBarcode.Text;
                txtBarcode.Text = string.Empty;
                ElaboraBarcode(barcode);
            }
        }

        private void ElaboraBarcode(string barcode)
        {
            try
            {
                string tipoBarcode = barcode.Substring(0, 3);
                switch (tipoBarcode)
                {
                    case "ODP":
                    case "ODL":
                    case "ODU":
                    case "RRF":
                    case "ODM":
                    case "ODS":
                        using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
                        {
                            bGalvanica.FillUSR_PRD_MOVFASI(_ds, barcode);
                            GalvanicaDS.USR_PRD_MOVFASIRow odl = _ds.USR_PRD_MOVFASI.Where(x => x.BARCODE == barcode).FirstOrDefault();
                            if (odl != null)
                            {
                                GalvanicaModelloComponenteFrm form = new GalvanicaModelloComponenteFrm(odl);
                                form.ShowDialog();
                            }
                        }
                        break;
                }
                txtBarcode.Focus();
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in elabora barcode");
            }
        }



        enum colonneGriglia { IDMAGAZZ_LANCIO, IDMAGAZZ_WIP, BRAND, MODELLO, COMPONENTE, FINITURA, MATERIALE, PEZZIBARRA, SUPERFICIE, ORDINE, GALVANICA, QUANTITA, PIANIFICATA, BARRE }
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
                    case 4:
                    case 5:
                    case 6:
                    case 8:
                    case 10:
                        dtGriglia.Columns.Add(colonna, Type.GetType("System.String"));
                        break;
                    case 7:
                    case 9:
                    case 11:
                    case 12:
                    case 13:
                        dtGriglia.Columns.Add(colonna, Type.GetType("System.Decimal"));
                        break;
                }
            }
        }

        private void CreaGriglia()
        {
            dgvGriglia.DataSource = _dsGriglia;
            dgvGriglia.DataMember = _tabellaGriglia;

            dgvGriglia.Columns[(int)colonneGriglia.IDMAGAZZ_LANCIO].Visible = false;
            dgvGriglia.Columns[(int)colonneGriglia.IDMAGAZZ_WIP].Visible = false;
            dgvGriglia.Columns[(int)colonneGriglia.BRAND].Width = 80;
            dgvGriglia.Columns[(int)colonneGriglia.MODELLO].Width = 160;
            dgvGriglia.Columns[(int)colonneGriglia.COMPONENTE].Width = 160;
            dgvGriglia.Columns[(int)colonneGriglia.FINITURA].Width = 80;
            dgvGriglia.Columns[(int)colonneGriglia.MATERIALE].Width = 80;
            dgvGriglia.Columns[(int)colonneGriglia.PEZZIBARRA].Width = 80;
            dgvGriglia.Columns[(int)colonneGriglia.SUPERFICIE].Width = 80;
            dgvGriglia.Columns[(int)colonneGriglia.ORDINE].Width = 80;
            dgvGriglia.Columns[(int)colonneGriglia.GALVANICA].Width = 80;
            dgvGriglia.Columns[(int)colonneGriglia.QUANTITA].Width = 80;
            dgvGriglia.Columns[(int)colonneGriglia.PIANIFICATA].Width = 80;
        }

        private void GalvanicaFrm_Load(object sender, EventArgs e)
        {
            CreaDSGriglia();
            CreaGriglia();
            txtBarcode.Focus();
        }
    }
}

using Applicazioni.BLL;
using Applicazioni.Common;
using Applicazioni.Data.Galvanica;
using Applicazioni.Entities;
using Applicazioni.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalvanicaFrm
{
    public partial class GalvanicaFrm : BaseForm
    {
        private GalvanicaDS _ds = new GalvanicaDS();
        private Anagrafica _anagrafica = new Anagrafica();

        public GalvanicaFrm()
        {
            InitializeComponent();
            lblMessaggi.Text = string.Empty;
            dtGiorno.Value = DateTime.Today;
            txtBarcode.Focus();
        }

        private void dtGiorno_ValueChanged(object sender, EventArgs e)
        {
            ImpostaSettimana();
            txtBarcode.Focus();

        }
        private void ImpostaSettimana()
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
                                GalvanicaDS.AP_GALVANICA_MODELLORow modelloRow = bGalvanica.GetAP_GALVANICA_MODELLO(_ds, odl.IDMAGAZZ_LANCIO, odl.IDMAGAZZ_WIP);
                                if (modelloRow != null)
                                {
                                    form.Superficie = modelloRow.SUPERFICIE;
                                    form.Brand = modelloRow.BRAND;
                                    form.Finitura = modelloRow.FINITURA;
                                    form.Galvanica = modelloRow.GALVANICA;
                                    form.PezziBarra = modelloRow.PEZZIBARRA;
                                    form.Materiale = modelloRow.MATERIALE;
                                }
                                else
                                {
                                    AnagraficaDS.MAGAZZRow articolo = _anagrafica.GetMAGAZZ(odl.IDMAGAZZ_WIP);
                                    form.Superficie = articolo.SUPERFICIE.ToString();
                                }

                                if (form.ShowDialog() == DialogResult.Cancel)
                                {
                                    txtBarcode.Focus();
                                    return;
                                }

                                if (modelloRow == null)
                                {
                                    modelloRow = _ds.AP_GALVANICA_MODELLO.NewAP_GALVANICA_MODELLORow();
                                    modelloRow.IDGALVAMODEL = bGalvanica.GetID();
                                    modelloRow.IDMAGAZZ = odl.IDMAGAZZ_LANCIO;
                                    modelloRow.IDMAGAZZ_WIP = odl.IDMAGAZZ_WIP;
                                    modelloRow.SUPERFICIE = form.Superficie;
                                    modelloRow.BRAND = form.Brand;
                                    modelloRow.FINITURA = form.Finitura;
                                    modelloRow.GALVANICA = form.Galvanica;
                                    modelloRow.PEZZIBARRA = form.PezziBarra;
                                    modelloRow.MATERIALE = form.Materiale;
                                    modelloRow.MODELLO = odl.MODELLO_LANCIO;
                                    modelloRow.COMPONENTE = odl.MODELLO_WIP;
                                    _ds.AP_GALVANICA_MODELLO.AddAP_GALVANICA_MODELLORow(modelloRow);
                                }
                                else
                                {
                                    modelloRow.SUPERFICIE = form.Superficie;
                                    modelloRow.BRAND = form.Brand;
                                    modelloRow.FINITURA = form.Finitura;
                                    modelloRow.GALVANICA = form.Galvanica;
                                    modelloRow.PEZZIBARRA = form.PezziBarra;
                                    modelloRow.MATERIALE = form.Materiale;
                                }
                                bGalvanica.UpdateTable(_ds.AP_GALVANICA_MODELLO.TableName, _ds);

                                PopolaGriglia(modelloRow, odl);
                                bGalvanica.UpdateTable(_ds.AP_GALVANICA_PIANO.TableName, _ds);
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

        private void PopolaGriglia(GalvanicaDS.AP_GALVANICA_MODELLORow modelloRow, GalvanicaDS.USR_PRD_MOVFASIRow odl)
        {
            GalvanicaDS.AP_GALVANICA_PIANORow riga = _ds.AP_GALVANICA_PIANO.Where(x => x.IDMAGAZZ == odl.IDMAGAZZ_LANCIO && x.IDMAGAZZ_WIP == odl.IDMAGAZZ_WIP).FirstOrDefault();
            if (riga == null)
            {
                GalvanicaDS.FINITURA_ORDINERow ordine = _ds.FINITURA_ORDINE.Where(x => x.BRAND == modelloRow.BRAND && x.FINITURA == modelloRow.FINITURA).FirstOrDefault();
                riga = _ds.AP_GALVANICA_PIANO.NewAP_GALVANICA_PIANORow();
                using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
                    riga.IDGALVAPIANO = bGalvanica.GetID();

                riga.IDMAGAZZ = odl.IDMAGAZZ_LANCIO;
                riga.IDMAGAZZ_WIP = odl.IDMAGAZZ_WIP;
                riga.BRAND = modelloRow.BRAND;
                riga.MODELLO = odl.MODELLO_LANCIO;
                riga.COMPONENTE = odl.MODELLO_WIP;
                riga.FINITURA = modelloRow.FINITURA;
                riga.MATERIALE = modelloRow.MATERIALE;
                riga.PEZZIBARRA = modelloRow.PEZZIBARRA;
                riga.SUPERFICIE = modelloRow.SUPERFICIE;
                riga.ORDINE = GeneraOrdineGalvanica(ordine, modelloRow);
                riga.GALVANICA = modelloRow.GALVANICA;
                riga.QUANTITA = odl.QTA;
                PopolaQuantitaEBarre(riga);
                riga.DATAGALVANICA = dtGiorno.Value;
                _ds.AP_GALVANICA_PIANO.AddAP_GALVANICA_PIANORow(riga);
            }
            else
            {
                riga.QUANTITA = riga.QUANTITA + odl.QTA;
                PopolaQuantitaEBarre(riga);
            }

        }

        private decimal GeneraOrdineGalvanica(GalvanicaDS.FINITURA_ORDINERow ordine, GalvanicaDS.AP_GALVANICA_MODELLORow modelloRow)
        {
            if (ordine == null) return -1;
            decimal aux = ordine.IDGRUPPO * 1000 + ordine.ORDINE;

            if (modelloRow.MATERIALE == "OTTONE")
                return aux;

            if (modelloRow.MATERIALE == "ZAMA")
                return aux + 10000000;

            return -2;
        }

        private void PopolaQuantitaEBarre(GalvanicaDS.AP_GALVANICA_PIANORow riga)
        {
            decimal barre = 0;
            if (riga.PEZZIBARRA != 0)
                barre = Math.Round(riga.QUANTITA / riga.PEZZIBARRA, 1);
            riga.BARRE = barre;
        }

        enum colonneGriglia { IDGALVAPIANO, IDMAGAZZ_LANCIO, IDMAGAZZ_WIP, MODELLO, COMPONENTE, BRAND, FINITURA, MATERIALE, PEZZIBARRA, SUPERFICIE, ORDINE, GALVANICA, QUANTITA, PIANIFICATO, BARRE, DATAGALVANICA }

        private void CreaGriglia()
        {
            dgvGriglia.DataSource = _ds.AP_GALVANICA_PIANO;

            dgvGriglia.Columns[(int)colonneGriglia.IDGALVAPIANO].Visible = false;
            dgvGriglia.Columns[(int)colonneGriglia.IDMAGAZZ_LANCIO].Visible = false;
            dgvGriglia.Columns[(int)colonneGriglia.IDMAGAZZ_WIP].Visible = false;
            dgvGriglia.Columns[(int)colonneGriglia.PIANIFICATO].Visible = false;
            dgvGriglia.Columns[(int)colonneGriglia.DATAGALVANICA].Visible = false;
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
        }

        private void GalvanicaFrm_Load(object sender, EventArgs e)
        {
            CreaGriglia();
            txtBarcode.Focus();

            using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
            {
                bGalvanica.FillFINITURA_ORDINE(_ds);
            }
            CaricaPianificazione();
            ImpostaSettimana();
        }

        private void CaricaPianificazione()
        {
            using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
            {
                _ds.AP_GALVANICA_PIANO.Clear();
                bGalvanica.FillAP_GALVANICA_PIANO(_ds, dtGiorno.Value);
            }
        }

        private void btnGiornoSuccessivo_Click(object sender, EventArgs e)
        {
            AggiornaCalendario(+1);
            txtBarcode.Focus();
        }

        private void btnGiornoPrecedente_Click(object sender, EventArgs e)
        {
            AggiornaCalendario(-1);

            txtBarcode.Focus();
        }

        private void AggiornaCalendario(int aggiungiGiorno)
        {
            dtGiorno.Value = dtGiorno.Value.AddDays(aggiungiGiorno);
            CaricaPianificazione();
            ImpostaSettimana();
            txtBarcode.Focus();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            txtBarcode.Focus();
            FileStream fs = null;
            if (_ds.AP_GALVANICA_PIANO.Rows.Count == 0)
            {
                MessageBox.Show("Non ci sono dati esportare", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog d = new SaveFileDialog();
            d.Filter = "Excel Files (*.xlsx)|*.xlsx";
            d.DefaultExt = "xlsx";
            d.AddExtension = true;
            if (d.ShowDialog() == DialogResult.Cancel) return;
            try
            {
                ExcelHelper hExcel = new ExcelHelper();
                byte[] fileExcel = hExcel.CreaExcelPianificazioneGalvanica(_ds);

                if (File.Exists(d.FileName)) File.Delete(d.FileName);

                fs = new FileStream(d.FileName, FileMode.Create);
                fs.Write(fileExcel, 0, fileExcel.Length);
                fs.Flush();

                MessageBox.Show("Export to excel terminato con successo", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "ERRORE IN ESPORTA EXCEL");
            }
            finally
            {
                if (fs != null) fs.Close();
                txtBarcode.Focus();
            }
        }
    }
}

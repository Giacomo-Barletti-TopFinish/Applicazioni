﻿using Applicazioni.BLL;
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
        }

        private void dtGiorno_ValueChanged(object sender, EventArgs e)
        {
            ImpostaSettimana();
        }
        private void ImpostaSettimana()
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            int settimana = cal.GetWeekOfYear(dtGiorno.Value, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            lblSettimana.Text = string.Format("Settimana {0}", settimana);

        }

        private void AggiornaColoreRiga()
        {
            foreach (DataGridViewRow riga in dgvGriglia.Rows)
            {
                if (riga.Cells[3].Value != DBNull.Value)
                {
                    string reparto = (string)riga.Cells[3].Value;
                    if (reparto != "INTERNO")
                        riga.DefaultCellStyle.ForeColor = Color.Red;
                }
            }

            dgvGriglia.Refresh();
        }

        enum colonne { IDMAGAZZ_LANCIO, IDMAGAZZ_WIP, IDGALVAPIANO, REPARTO, MODELLO_LANCIO, MODELLO_WIP, BRAND, FINITURA, ORDINE, GALVANICA, SUPERFICIE, MATERIALE, PEZZIBARRA, QTA, QTADATER, PIANIFICATO, BARRE };

        private void CreaGriglia()
        {

            string[] selectedColumns = new[] {"IDMAGAZZ_LANCIO","IDMAGAZZ_WIP","IDGALVAPIANO", "REPARTO", "MODELLO_LANCIO", "MODELLO_WIP", "BRAND", "FINITURA", "ORDINE","GALVANICA", "SUPERFICIE", "MATERIALE",
                "PEZZIBARRA", "QTA", "QTADATER", "PIANIFICATO","BARRE" };

            DataTable dt = new DataView(_ds.GALVANICA_CARICO).ToTable(false, selectedColumns);

            dgvGriglia.DataSource = dt;

            dgvGriglia.Columns[(int)colonne.IDMAGAZZ_LANCIO].Visible = false;
            dgvGriglia.Columns[(int)colonne.IDMAGAZZ_WIP].Visible = false;
            dgvGriglia.Columns[(int)colonne.IDGALVAPIANO].Visible = false;
            dgvGriglia.Columns[(int)colonne.REPARTO].Width = 100;
            dgvGriglia.Columns[(int)colonne.MODELLO_LANCIO].Width = 200;
            dgvGriglia.Columns[(int)colonne.MODELLO_WIP].Width = 200;
            dgvGriglia.Columns[(int)colonne.BRAND].Width = 80;
            dgvGriglia.Columns[(int)colonne.FINITURA].Width = 80;
            dgvGriglia.Columns[(int)colonne.ORDINE].Width = 70;
            dgvGriglia.Columns[(int)colonne.GALVANICA].Width = 80;
            dgvGriglia.Columns[(int)colonne.SUPERFICIE].Width = 90;
            dgvGriglia.Columns[(int)colonne.MATERIALE].Width = 90;
            dgvGriglia.Columns[(int)colonne.PEZZIBARRA].Width = 80;
            dgvGriglia.Columns[(int)colonne.QTA].Width = 80;
            dgvGriglia.Columns[(int)colonne.QTADATER].Width = 80;
            dgvGriglia.Columns[(int)colonne.PIANIFICATO].Width = 80;
            dgvGriglia.Columns[(int)colonne.BARRE].Width = 80;


        }

        private void GalvanicaFrm_Load(object sender, EventArgs e)
        {
            try
            {
                using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
                {
                    bGalvanica.FillFINITURA_ORDINE(_ds);
                }
                CaricaPianificazione();
                ImpostaSettimana();
                CreaGriglia();
                AggiornaColoreRiga();
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in caricamento");
            }
        }

        private void CaricaPianificazione()
        {
            using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
            {
                _ds.GALVANICA_CARICO.Clear();
                bGalvanica.FillGALVANICA_CARICO(_ds, dtGiorno.Value);
                _ds.AP_GALVANICA_PIANO.Clear();
                bGalvanica.FillAP_GALVANICA_PIANO(_ds, dtGiorno.Value);
            }
        }

        private void btnGiornoSuccessivo_Click(object sender, EventArgs e)
        {
            AggiornaCalendario(+1);
        }

        private void btnGiornoPrecedente_Click(object sender, EventArgs e)
        {
            AggiornaCalendario(-1);
        }

        private void AggiornaCalendario(int aggiungiGiorno)
        {
            dtGiorno.Value = dtGiorno.Value.AddDays(aggiungiGiorno);
            CaricaPianificazione();
            ImpostaSettimana();
            CreaGriglia();
            AggiornaColoreRiga();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
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
            }
        }

        private void dgvGriglia_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvGriglia.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == DBNull.Value) return;
                DataGridViewRow riga = dgvGriglia.Rows[e.RowIndex];

                switch (e.ColumnIndex)
                {
                    case (int)colonne.PIANIFICATO:
                        ElaboraModifichePianificato(riga);
                        SalvaRigaAp_galva_piano(riga);
                        break;
                    case (int)colonne.MATERIALE:
                    case (int)colonne.BRAND:
                    case (int)colonne.FINITURA:
                    case (int)colonne.PEZZIBARRA:
                    case (int)colonne.SUPERFICIE:
                    case (int)colonne.GALVANICA:
                        SalvaRigaAp_galva_modello(riga);
                        SalvaRigaAp_galva_piano(riga);
                        break;
                    default:
                        return;
                }
                RiportaModificaInGriglia(e.ColumnIndex, riga);

            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in Cell change value");
            }
        }

        private void RiportaModificaInGriglia(int colonna, DataGridViewRow riga)
        {
            string IDMAGAZZ = (string)riga.Cells[(int)colonne.IDMAGAZZ_LANCIO].Value;
            string IDMAGAZZ_WIP = (string)riga.Cells[(int)colonne.IDMAGAZZ_WIP].Value;

            foreach (GalvanicaDS.GALVANICA_CARICORow row in _ds.GALVANICA_CARICO.Where(x => x.IDMAGAZZ_LANCIO == IDMAGAZZ && x.IDMAGAZZ_WIP == IDMAGAZZ_WIP))
            {
                switch (colonna)
                {
                    case (int)colonne.SUPERFICIE:
                        row.SUPERFICIE = (string)riga.Cells[colonna].Value;
                        break;
                    case (int)colonne.PEZZIBARRA:
                        row.PEZZIBARRA = (decimal)riga.Cells[colonna].Value;
                        break;
                    case (int)colonne.ORDINE:
                        row.ORDINE = (decimal)riga.Cells[colonna].Value;
                        break;
                    case (int)colonne.MATERIALE:
                        row.MATERIALE = (string)riga.Cells[colonna].Value;
                        break;
                    case (int)colonne.BRAND:
                        row.BRAND = (string)riga.Cells[colonna].Value;
                        break;
                    case (int)colonne.FINITURA:
                        row.FINITURA = (string)riga.Cells[colonna].Value;
                        break;
                }

            }
        }

        private void SalvaRigaAp_galva_modello(DataGridViewRow riga)
        {
            string IDMAGAZZ = (string)riga.Cells[(int)colonne.IDMAGAZZ_LANCIO].Value;
            string IDMAGAZZ_WIP = (string)riga.Cells[(int)colonne.IDMAGAZZ_WIP].Value;
            string modello = (string)riga.Cells[(int)colonne.MODELLO_LANCIO].Value;
            string componente = (string)riga.Cells[(int)colonne.MODELLO_WIP].Value;
            using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
            {
                GalvanicaDS.AP_GALVANICA_MODELLORow rigaModello = bGalvanica.GetAP_GALVANICA_MODELLO(_ds, IDMAGAZZ, IDMAGAZZ_WIP);
                if (rigaModello == null)
                {
                    rigaModello = _ds.AP_GALVANICA_MODELLO.NewAP_GALVANICA_MODELLORow();
                    rigaModello.IDGALVAMODEL = bGalvanica.GetID();
                    rigaModello.IDMAGAZZ = IDMAGAZZ;
                    rigaModello.IDMAGAZZ_WIP = IDMAGAZZ_WIP;
                    rigaModello.MODELLO = modello;
                    rigaModello.COMPONENTE = componente;
                    if (riga.Cells[(int)colonne.BRAND].Value != DBNull.Value)
                        rigaModello.BRAND = (string)riga.Cells[(int)colonne.BRAND].Value;
                    if (riga.Cells[(int)colonne.FINITURA].Value != DBNull.Value)
                        rigaModello.FINITURA = (string)riga.Cells[(int)colonne.FINITURA].Value;
                    if (riga.Cells[(int)colonne.MATERIALE].Value != DBNull.Value)
                        rigaModello.MATERIALE = (string)riga.Cells[(int)colonne.MATERIALE].Value;
                    if (riga.Cells[(int)colonne.PEZZIBARRA].Value != DBNull.Value)
                        rigaModello.PEZZIBARRA = (decimal)riga.Cells[(int)colonne.PEZZIBARRA].Value;
                    if (riga.Cells[(int)colonne.SUPERFICIE].Value != DBNull.Value)
                        rigaModello.SUPERFICIE = (string)riga.Cells[(int)colonne.SUPERFICIE].Value;
                    if (riga.Cells[(int)colonne.GALVANICA].Value != DBNull.Value)
                        rigaModello.GALVANICA = (string)riga.Cells[(int)colonne.GALVANICA].Value;
                    _ds.AP_GALVANICA_MODELLO.AddAP_GALVANICA_MODELLORow(rigaModello);
                }
                else
                {
                    if (riga.Cells[(int)colonne.BRAND].Value != DBNull.Value)
                        rigaModello.BRAND = (string)riga.Cells[(int)colonne.BRAND].Value;
                    if (riga.Cells[(int)colonne.FINITURA].Value != DBNull.Value)
                        rigaModello.FINITURA = (string)riga.Cells[(int)colonne.FINITURA].Value;
                    if (riga.Cells[(int)colonne.MATERIALE].Value != DBNull.Value)
                        rigaModello.MATERIALE = (string)riga.Cells[(int)colonne.MATERIALE].Value;
                    if (riga.Cells[(int)colonne.PEZZIBARRA].Value != DBNull.Value)
                        rigaModello.PEZZIBARRA = (decimal)riga.Cells[(int)colonne.PEZZIBARRA].Value;
                    if (riga.Cells[(int)colonne.SUPERFICIE].Value != DBNull.Value)
                        rigaModello.SUPERFICIE = (string)riga.Cells[(int)colonne.SUPERFICIE].Value;
                    if (riga.Cells[(int)colonne.GALVANICA].Value != DBNull.Value)
                        rigaModello.GALVANICA = (string)riga.Cells[(int)colonne.GALVANICA].Value;
                }
                bGalvanica.UpdateTable(_ds.AP_GALVANICA_MODELLO.TableName, _ds);
                _ds.AP_GALVANICA_MODELLO.AcceptChanges();
            }

        }
        private void ElaboraModifichePianificato(DataGridViewRow riga)
        {
            decimal pianificato = (decimal)riga.Cells[(int)colonne.PIANIFICATO].Value;
            if (riga.Cells[(int)colonne.PEZZIBARRA].Value == DBNull.Value) return;
            decimal pezziBarra = (decimal)riga.Cells[(int)colonne.PEZZIBARRA].Value;

            decimal barre = Math.Round(pianificato / pezziBarra, 1);
            riga.Cells[(int)colonne.BARRE].Value = barre;
        }

        private void SalvaRigaAp_galva_piano(DataGridViewRow riga)
        {
            if (riga.Cells[(int)colonne.PIANIFICATO].Value == DBNull.Value) return;

            using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
            {
                decimal IDGALVAPIANO;
                if (riga.Cells[(int)colonne.IDGALVAPIANO].Value == DBNull.Value)
                {
                    IDGALVAPIANO = bGalvanica.GetID();
                    riga.Cells[(int)colonne.IDGALVAPIANO].Value = IDGALVAPIANO;
                }
                else
                    IDGALVAPIANO = (decimal)riga.Cells[(int)colonne.IDGALVAPIANO].Value;

                GalvanicaDS.AP_GALVANICA_PIANORow rigaPiano = _ds.AP_GALVANICA_PIANO.Where(x => x.IDGALVAPIANO == IDGALVAPIANO).FirstOrDefault();
                if (rigaPiano == null)
                {
                    rigaPiano = _ds.AP_GALVANICA_PIANO.NewAP_GALVANICA_PIANORow();
                    rigaPiano.IDGALVAPIANO = IDGALVAPIANO;
                    rigaPiano.IDMAGAZZ = (string)riga.Cells[(int)colonne.IDMAGAZZ_LANCIO].Value;
                    rigaPiano.IDMAGAZZ_WIP = (string)riga.Cells[(int)colonne.IDMAGAZZ_WIP].Value;
                    rigaPiano.MODELLO = (string)riga.Cells[(int)colonne.MODELLO_LANCIO].Value;
                    rigaPiano.COMPONENTE = (string)riga.Cells[(int)colonne.MODELLO_WIP].Value;
                    if (riga.Cells[(int)colonne.BRAND].Value != DBNull.Value)
                        rigaPiano.BRAND = (string)riga.Cells[(int)colonne.BRAND].Value;
                    if (riga.Cells[(int)colonne.FINITURA].Value != DBNull.Value)
                        rigaPiano.FINITURA = (string)riga.Cells[(int)colonne.FINITURA].Value;
                    if (riga.Cells[(int)colonne.MATERIALE].Value != DBNull.Value)
                        rigaPiano.MATERIALE = (string)riga.Cells[(int)colonne.MATERIALE].Value;
                    if (riga.Cells[(int)colonne.PEZZIBARRA].Value != DBNull.Value)
                        rigaPiano.PEZZIBARRA = (decimal)riga.Cells[(int)colonne.PEZZIBARRA].Value;
                    if (riga.Cells[(int)colonne.SUPERFICIE].Value != DBNull.Value)
                        rigaPiano.SUPERFICIE = (string)riga.Cells[(int)colonne.SUPERFICIE].Value;
                    if (riga.Cells[(int)colonne.ORDINE].Value != DBNull.Value)
                        rigaPiano.ORDINE = (decimal)riga.Cells[(int)colonne.ORDINE].Value;
                    if (riga.Cells[(int)colonne.GALVANICA].Value != DBNull.Value)
                        rigaPiano.GALVANICA = (string)riga.Cells[(int)colonne.GALVANICA].Value;
                    if (riga.Cells[(int)colonne.PIANIFICATO].Value != DBNull.Value)
                        rigaPiano.PIANIFICATO = (decimal)riga.Cells[(int)colonne.PIANIFICATO].Value;
                    if (riga.Cells[(int)colonne.BARRE].Value != DBNull.Value)
                        rigaPiano.BARRE = (decimal)riga.Cells[(int)colonne.BARRE].Value;
                    if (riga.Cells[(int)colonne.REPARTO].Value != DBNull.Value)
                        rigaPiano.REPARTO = (string)riga.Cells[(int)colonne.REPARTO].Value;
                    rigaPiano.DATAGALVANICA = dtGiorno.Value;

                    _ds.AP_GALVANICA_PIANO.AddAP_GALVANICA_PIANORow(rigaPiano);
                }
                else
                {
                    rigaPiano.BRAND = (string)riga.Cells[(int)colonne.BRAND].Value;
                    rigaPiano.FINITURA = (string)riga.Cells[(int)colonne.FINITURA].Value;
                    rigaPiano.MATERIALE = (string)riga.Cells[(int)colonne.MATERIALE].Value;
                    rigaPiano.PEZZIBARRA = (decimal)riga.Cells[(int)colonne.PEZZIBARRA].Value;
                    rigaPiano.SUPERFICIE = (string)riga.Cells[(int)colonne.SUPERFICIE].Value;
                    rigaPiano.ORDINE = (decimal)riga.Cells[(int)colonne.ORDINE].Value;
                    rigaPiano.GALVANICA = (string)riga.Cells[(int)colonne.GALVANICA].Value;
                    rigaPiano.PIANIFICATO = (decimal)riga.Cells[(int)colonne.PIANIFICATO].Value;
                    rigaPiano.BARRE = (decimal)riga.Cells[(int)colonne.BARRE].Value;
                }
                bGalvanica.UpdateTable(_ds.AP_GALVANICA_PIANO.TableName, _ds);
                _ds.AP_GALVANICA_PIANO.AcceptChanges();
            }
        }
    }
}

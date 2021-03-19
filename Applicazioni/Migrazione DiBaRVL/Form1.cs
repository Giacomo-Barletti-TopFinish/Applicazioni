using Applicazioni.BLL;
using Applicazioni.Common;
using Applicazioni.Entities;
using Applicazioni.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migrazione_DiBaRVL
{
    public partial class MainForm : BaseForm
    {
        private MigrazioneDiBaDS _ds = new MigrazioneDiBaDS();
        public MainForm()
        {
            InitializeComponent();
        }

        private void CaricaMagazz()
        {
            _ds.MAGAZZ.Clear();
            MigrazioneDiBaBLL bll = new MigrazioneDiBaBLL();
            bll.FillMAGAZZ(_ds);
        }

        private void CaricaBC_Anagrafica()
        {
            _ds.BC_ANAGRAFICA.Clear();
            MigrazioneDiBaBLL bll = new MigrazioneDiBaBLL();
            bll.FillBC_ANAGRAFICA(_ds);
        }
        private void btnCercaFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";

                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFile.Text = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore nella ricerca file");
            }

        }

        private void btnApri_Click(object sender, EventArgs e)
        {
            TipoExcel tipoexcel = TipoExcel.Sconosciuto;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                btnApri.Enabled = false;

                txtRisultati.Text = string.Empty;
                if (string.IsNullOrEmpty(txtFile.Text))
                {
                    txtRisultati.Text = "Selezionare un file";
                    return;
                }

                if (!File.Exists(txtFile.Text))
                {
                    txtRisultati.Text = "Il file specificato non esiste";
                    return;
                }

                FileInfo fi = new FileInfo(txtFile.Text);
                string nomefile = fi.FullName.Replace(fi.Extension, string.Empty);
                nomefile = string.Format("{0} v1.0{1}", nomefile, fi.Extension);

                if (File.Exists(nomefile))
                    File.Delete(nomefile);
                File.Copy(txtFile.Text, nomefile);

                CaricaMagazz();
                CaricaBC_Anagrafica();
                string messaggioErrore;
                if (!LeggiExcel(_ds, nomefile, Contesto.Utente.FULLNAMEUSER, out messaggioErrore, out tipoexcel))
                {
                    string messaggio = string.Format("Errore nel caricamento del file excel. Errore: {0}", messaggioErrore);
                    MessageBox.Show(messaggio, "ERRORE LETTURA FILE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            }
            catch (Exception ex)
            {
                ScriviLogErrore("ERRORE");
                ExceptionFrm frm = new ExceptionFrm(ex);
                frm.ShowDialog();
            }
            finally
            {
                switch (tipoexcel)
                {
                    case TipoExcel.IdMagazz:
                        txtRisultati.Text = "FILE DI TIPO IDMAGAZZ";
                        break;
                    case TipoExcel.RVL:
                        txtRisultati.Text = "FILE DI TIPO RVL";
                        break;
                    case TipoExcel.Sconosciuto:
                        txtRisultati.Text = "FILE DI TIPO SCONOSCIUTO";
                        break;
                }
                btnApri.Enabled = true;
                Cursor.Current = Cursors.Default;

            }
        }

        private bool LeggiExcel(MigrazioneDiBaDS ds, string filePath, string utente, out string messaggioErrore, out TipoExcel tipoexcel)
        {
            tipoexcel = TipoExcel.Sconosciuto;
            messaggioErrore = string.Empty;
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
            {

                MemoryStream ms = new MemoryStream();
                byte[] dati = new byte[fs.Length];
                fs.Read(dati, 0, (int)fs.Length);

                ExcelHelper excel = new ExcelHelper();

                tipoexcel = excel.AggiungiColonIdentificaTipoFIleExcelneExcelDibaRVL(fs);
                switch (tipoexcel)
                {
                    case TipoExcel.IdMagazz:
                        break;
                    case TipoExcel.RVL:
                        if (!excel.AggiungiColonneExcelDibaRVL(_ds, fs, out messaggioErrore))
                        {
                            return false;
                        }
                        break;
                    default:
                        break;
                }

                fs.Flush();
                fs.Close();
            }
            return true;
        }
    }
}

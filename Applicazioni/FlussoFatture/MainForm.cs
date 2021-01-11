using Applicazioni.Common;
using Applicazioni.Data.FlussoFatture;
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

namespace FlussoFatture
{
    public partial class MainForm : BaseForm
    {
        private FlussoFattureDS _ds = new FlussoFattureDS();
        public MainForm()
        {
            InitializeComponent();
            rbEstero.Text = Etichette.ESTERO;
            rbSoloItalia.Text = Etichette.ITALIA;
            rbTutti.Text = Etichette.TUTTI;

            rbMetal.Text = Etichette.METAL;
            rbTop.Text = Etichette.TOP;
            rbMetalTop.Text = Etichette.METALTOP;

            dgvRisultati.AutoGenerateColumns = false;
        }

        private void btnTrova_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (dtDal.Value.Date > dtAl.Value.Date)
                {
                    MessageBox.Show("Attenzione la data DAL è successiva alla data AL", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string radioButtonEstero = string.Empty;
                foreach (Control control in grEstero.Controls)
                {
                    if (control is RadioButton)
                    {
                        RadioButton radio = control as RadioButton;
                        if (radio.Checked)
                        {
                            radioButtonEstero = radio.Text;
                        }
                    }
                }

                string radioButtonAzienda= string.Empty;
                foreach (Control control in grAzienda.Controls)
                {
                    if (control is RadioButton)
                    {
                        RadioButton radio = control as RadioButton;
                        if (radio.Checked)
                        {
                            radioButtonAzienda = radio.Text;
                        }
                    }
                }

                using (FlussoFattureBusiness bFlussoFatture = new FlussoFattureBusiness())
                {

                    _ds = new FlussoFattureDS();
                    bFlussoFatture.FillBOLLE_VENDITATESTATA(_ds, dtDal.Value, dtAl.Value, radioButtonEstero, radioButtonAzienda);

                    dgvRisultati.DataSource = _ds;
                    dgvRisultati.DataMember = _ds.BOLLE_VENDITA.TableName;
                }
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in trova bolle");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnCreaFiles_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> idTestate = new List<string>();
                foreach (DataGridViewRow riga in dgvRisultati.Rows)
                {
                    object selezione = riga.Cells[SELEZIONATA.Index].Value;
                    if (selezione != null)
                    {
                        bool valore = (bool)selezione;
                        if (valore)
                        {
                            string idTestata = (string)riga.Cells[DOCUMENTO.Index].Value;
                            idTestate.Add(idTestata);
                        }
                    }
                }

                if (idTestate.Count == 0)
                {
                    MessageBox.Show("Nessuna bolla selezionata", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                sfd.DefaultExt = "xlsx";
                sfd.AddExtension = true;
                sfd.FileName = string.Format("Flusso Fatture {0}.xlsx", DateTime.Today.ToString("dd.MM.yyyy"));
                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                FlussoFattureDS ds = new FlussoFattureDS();

                using (FlussoFattureBusiness bFlussoFatture = new FlussoFattureBusiness())
                {
                    bFlussoFatture.FillBC_FLUSSO_TESTATA(ds, dtDal.Value, dtAl.Value);
                    bFlussoFatture.FillBC_FLUSSO_DETTAGLIO(ds, dtDal.Value, dtAl.Value);
                }

                string errori;
                idTestate = idTestate.Distinct().ToList();

                ExcelHelper hExcel = new ExcelHelper();
                byte[] filedata = hExcel.CreaFlussoFatture(idTestate.Distinct().ToList(), ds, out errori);
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                fs.Write(filedata, 0, filedata.Length);
                fs.Flush();
                fs.Close();

                if (errori.Trim().Length > 0)
                    MessageBox.Show(errori.Trim(), "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                    MessageBox.Show("Operazione conclusa con successo", "OERAZIONE TERMINATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in fase di creazione dei file");
            }
        }

        private void chkSelezionaTutto_CheckedChanged(object sender, EventArgs e)
        {

            if (dgvRisultati.Rows.Count == 0) return;

            foreach (DataGridViewRow riga in dgvRisultati.Rows)
            {
                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                ch1 = (DataGridViewCheckBoxCell)riga.Cells[SELEZIONATA.Index];
                ch1.Value = chkSelezionaTutto.Checked;

            }
        }
    }
}

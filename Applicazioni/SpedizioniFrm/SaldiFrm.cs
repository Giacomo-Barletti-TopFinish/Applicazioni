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

namespace SpedizioniFrm
{

    public partial class SaldiFrm : ChildBaseForm
    {
        private SpedizioniDS _ds = new SpedizioniDS();
        private DataSet _dsGriglia = new DataSet();
        private string _tabellaGriglia = "Griglia";
        public SaldiFrm()
        {
            InitializeComponent();
        }

        private void SaldiFrm_Load(object sender, EventArgs e)
        {

            CreaGriglia();

        }

        enum colonneGriglia { UBICAZIONE, DESCRIZIONE, ARTICOLO, QUANTITA,PULSANTE,IDSALDO }

        private void CreaGriglia()
        {
            _ds.SPSALDI.Clear();

            dgvSaldi.AutoGenerateColumns = false;
            dgvSaldi.DataSource = _ds;
            dgvSaldi.DataMember = _ds.SPSALDIEXT.TableName;

            dgvSaldi.Refresh();
        }

        private void dgvSaldi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!Contesto.Utente.SpedizioniMovimenta) return;
            if (e.ColumnIndex != (int)colonneGriglia.PULSANTE) return;
            if (e.RowIndex < 0) return;

            Decimal idsaldo = (decimal)dgvSaldi.Rows[e.RowIndex].Cells[(int)colonneGriglia.IDSALDO].Value;
            SpedizioniDS.SPSALDIEXTRow saldo = _ds.SPSALDIEXT.Where(x => x.IDSALDO == idsaldo).FirstOrDefault();
            if(saldo==null)
            {
                MessageBox.Show("Errore nella selezione del saldo", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MovimentiFrm form = new MovimentiFrm(saldo,_utenteConnesso);

            if(form.ShowDialog()== DialogResult.OK)
            {
                btnCerca_Click(null, null);
            }
        }

        private void btnCerca_Click(object sender, EventArgs e)
        {
            this.Text = string.Format("SALDI {0} - {1}", txtubicazione.Text, txtarticolo.Text);
            Spedizioni spedizioni = new Spedizioni();
            spedizioni.FillSaldi(_ds, txtubicazione.Text, txtarticolo.Text,chkNascondiSaldiAZero.Checked);
            CreaGriglia();

        }

        private void btnexport_Click(object sender, EventArgs e)
        {
            FileStream fs = null;
            if (_ds.SPSALDIEXT.Count() < 0)
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
                byte[] fileExcel = hExcel.CreaExcelSpedizioni(_ds);

                if (File.Exists(d.FileName)) File.Delete(d.FileName);

                fs = new FileStream(d.FileName, FileMode.Create);
                fs.Write(fileExcel, 0, fileExcel.Length);
                fs.Flush();

                MessageBox.Show("Export to excel terminato con successo", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(d.FileName);
            }
            catch (Exception ex)
            {
                 MostraEccezione( "ERRORE IN ESPORTA EXCEL", ex);
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }
    }

}



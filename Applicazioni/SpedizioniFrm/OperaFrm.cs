using Applicazioni.BLL;
using Applicazioni.Common;
using Applicazioni.Entities;
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
    public partial class OperaFrm : ChildBaseForm
    {
        private string _brand;
        private SpedizioniDS _ds = new SpedizioniDS();

        public OperaFrm(string Brand)
        {
            _brand = Brand;
            InitializeComponent();

            this.Text = string.Format("OPERA {0}",_brand);
        }

        private void btnCerca_Click(object sender, EventArgs e)
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
                MostraEccezione("Errore nella ricerca file", ex);
            }
        }

        private void leggiFile_click(object sender, EventArgs e)
        {
            try
            {
                _ds = new SpedizioniDS();
                lblMessage.Text = string.Empty;
                if (string.IsNullOrEmpty(txtFile.Text))
                {
                    lblMessage.Text = "Selezionare un file";
                    return;
                }

                if (!File.Exists(txtFile.Text))
                {
                    lblMessage.Text = "Il file specificato non esiste";
                    return;
                }

                Spedizioni spedizioni = new Spedizioni();

                string messaggioErrore;
                if (!spedizioni.LeggiFileExcelOpera(_ds, txtFile.Text,_brand,out messaggioErrore))
                {
                    string messaggio = string.Format("Errore nel caricamento del file excel. Errore: {0}", messaggioErrore);
                    MessageBox.Show(messaggio, "ERRORE LETTURA FILE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_ds.SPOPERA.Count == 0)
                {
                    lblMessage.Text = "Il file è vuoto";
                    return;
                }

                dgvExcelCaricato.AutoGenerateColumns = true;
//                dgvExcelCaricato.DataSource = _ds;


                DataView dataview1;
                dataview1 = _ds.SPOPERA.DefaultView;
                dataview1.Sort = "[MODELLO_CODICE] ASC, [DATA_RICHIESTA] ASC";
                dgvExcelCaricato.DataSource = dataview1;

//                dgvExcelCaricato.DataMember = _ds.SPOPERA.TableName;
                dgvExcelCaricato.Columns[1].Visible = false;
                dgvExcelCaricato.Columns[3].Width= 200;
                dgvExcelCaricato.Columns[5].Width = 130;
                dgvExcelCaricato.Columns[7].Width = 200;
                dgvExcelCaricato.Columns[6].Visible = false;
                dgvExcelCaricato.Columns[10].Visible = false;
                dgvExcelCaricato.Columns[11].Visible = false;
                dgvExcelCaricato.Columns[12].Visible = false;
                dgvExcelCaricato.Columns[14].Visible = false;
                dgvExcelCaricato.Columns[15].Visible = false;
                dgvExcelCaricato.Columns[16].Visible = false;
                dgvExcelCaricato.Columns[17].Visible = false;

                

            }
            catch (Exception ex)
            {
                ExceptionFrm frm = new ExceptionFrm(ex);
                frm.ShowDialog();
            }
        }

        private void OperaFrm_Load(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
        }
    }
}

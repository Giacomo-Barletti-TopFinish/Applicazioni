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

            // creo le ubicazioni 
            //Spedizioni spedizioni = new Spedizioni();
            //for(int i = 70;i<=90;i++)
            //{
            //    for(int j=1;j<5;j++)
            //    {
            //        char c = Convert.ToChar(i);
            //        string codice = string.Format("{0}{1}",c, j);
            //        string descrizione = string.Format("UBICAZIONE {0}", codice);
            //        spedizioni.SalvaUbicazione(codice, descrizione, _utenteConnesso);
            //    }
            //}
     //       popolaSaldi();
        }


        private void popolaSaldi()
        {
            string[] idmagazzz = new string[]{"0000157776",
"0000103386",
"0000016109",
"0000103385",
"0000045338",
"0000011705",
"0000126789",
"0000045365",
"0000013395",
"0000113760",
"0000164734",
"0000113062",
"0000045640",
"0000013669",
"0000016582",
"0000013640",
"0000016588",
"0000164741",
"0000047401",
"0000080283",
"0000145413",
"0000157569",
"0000053119",
"0000046174",
"0000012785",
"0000061506",
"0000061518",
"0000012736",
"0000016370",
"0000092568",
"0000104587",
"0000118267",
"0000016296",
"0000047417",
"0000015279",
"0000016283",
"0000046892",
"0000016247",
"0000047822",
"0000121909",
"0000014517",
"0000118265",
"0000012692",
"0000013230",
"0000089614",
"0000113045",
"0000076922",
"0000075896",
"0000059950",
"0000013294",
"0000013120",
"0000161675",
"0000011977",
"0000168098",
"0000061382",
"0000047947",
"0000054827",
"0000168287",
"0000012108",
"0000013258",
"0000067819",
"0000067825",
"0000154492",
"0000161676",
"0000031451",
"0000075995",
"0000038289",
"0000038303",
"0000162600",
"0000035371",
"0000053079",
"0000053096",
"0000036423",
"0000103393",
"0000050180",
"0000047981",
"0000047994",
"0000169815",
"0000093648",
"0000167253",
"0000054708",
"0000074479",
"0000044243",
"0000044265",
"0000032166",
"0000169691",
"0000032173",
"0000034058",
"0000138072",
"0000147984",
"0000089019",
"0000111790",
"0000057116",
"0000168105",
"0000154501",
"0000168104",
"0000154502",
"0000168106",
"0000062123",
"0000098270",
"0000110689",
"0000081676",
"0000128605",
"0000081682",
"0000106132",
"0000098252",
"0000123147",
"0000103288",
"0000097409",
"0000121024",
"0000136665",
"0000125838",
"0000122546",
"0000121031",
"0000121882",
"0000129165",
"0000105491",
"0000154513",
"0000105500",
"0000152662",
"0000149980",
"0000110693",
"0000102245",
"0000161677",
"0000106119",
"0000156064",
"0000117183",
"0000123765",
"0000154517",
"0000158592",
"0000156084",
"0000156085",
"0000094811",
"0000044874",
"0000156086",
"0000126786",
"0000070007",
"0000156089",
"0000156090",
"0000156091" };
            Spedizioni spedizioni = new Spedizioni();
            Random rnd = new Random(DateTime.Now.Millisecond);
            foreach (string idmagazz in idmagazzz)
            {
                decimal ubicazione = (decimal)rnd.Next(21, 121);  // creates a number between 1 and 12
                decimal bas =(decimal)Math.Pow( 10, rnd.Next(1, 2));
                decimal quantita = (decimal)rnd.Next(1, 5) * bas;
                spedizioni.SalvaSaldo(ubicazione, idmagazz, quantita, _utenteConnesso);
            }
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
                txtCodiceUbicazione.Text = String.Empty;
                txtDescrizioneUbicazione.Text = string.Empty;
                txtCodiceUbicazione.Focus();
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

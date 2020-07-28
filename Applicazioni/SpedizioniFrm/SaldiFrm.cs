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

        enum colonneGriglia { IDSALDO, IDUBICAZIONE, IDMAGAZZ, QUANTITA }
        //private void CreaDSGriglia()
        //{
        //    DataTable dtGriglia = _dsGriglia.Tables.Add();
        //    dtGriglia.TableName = _tabellaGriglia;

        //    int numeroColonne = Enum.GetNames(typeof(colonneGriglia)).Length;
        //    for (int i = 0; i < numeroColonne; i++)
        //    {
        //        string colonna = Enum.GetName(typeof(colonneGriglia), i);
        //        switch (i)
        //        {
        //            case 0:
        //            case 1:
        //            case 2:
        //            case 3:
        //                dtGriglia.Columns.Add(colonna, Type.GetType("System.String")).ReadOnly = true;
        //                break;
        //            case 4:
        //                dtGriglia.Columns.Add(colonna, Type.GetType("System.Decimal")).ReadOnly = true;
        //                break;
        //            case 5:
        //                dtGriglia.Columns.Add(colonna, Type.GetType("System.Decimal"));
        //                break;
        //        }
        //    }
        //}

        private void btnMovimenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtubicazione.Text)&& string.IsNullOrEmpty(txtarticolo.Text))
                {
                    MessageBox.Show("Inserire almeno un campo", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                //decimal codiceubi = txtubicazione.Text.ToUpper();
                //string articolo = txtarticolo.Text.ToUpper();

                //Spedizioni spedizioni = new Spedizioni();

                //SpedizioniDS ds = new SpedizioniDS();
                //spedizioni.FillSaldi(ds, false);

                //if (_ds.SPUBICAZIONI.Any(x => x.CODICE == codice))
                //{
                //    MessageBox.Show("Esiste già un'ubicazione con questo codice", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                //spedizioni.SalvaSaldo(codiceubi ,articolo , _utenteConnesso);
                CreaGriglia();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore nel salvataggio del saldo", ex);
            }

        }

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

        }

        private void btnCerca_Click(object sender, EventArgs e)
        {
            this.Text = string.Format("SALDI {0} - {1}", txtubicazione.Text, txtarticolo.Text);
            Spedizioni spedizioni = new Spedizioni();
            spedizioni.FillSaldi(_ds, txtubicazione.Text,txtarticolo.Text);
            CreaGriglia();

        }
    }
    
}

       

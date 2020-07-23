using Applicazioni.BLL;
using Applicazioni.Common;
using Applicazioni.Data.Spedizioni;
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
    public partial class UbicazioniFrm : ChildBaseForm
    {
        private SpedizioniDS _ds;
        private DataSet _dsGriglia = new DataSet();
        private string _tabellaGriglia = "Griglia";
        public UbicazioniFrm()
        
        {
            InitializeComponent();
        }

        private void UbicazioniFrm_Load(object sender, EventArgs e)
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                ddlStampanti.Items.Add(printer);
            }
            if (ddlStampanti.Items.Count > 0)
                ddlStampanti.SelectedIndex = 0;
        }

        //private bool CaricaSpedizioni(string barcode, decimal IdUbicazione)
        //{
        //    if (string.IsNullOrEmpty(barcode)) return false;

        //    using (SpedizioniBusiness bSpedizioni = new SpedizioniBusiness())
        //    {
        //        if (!_ds.USR_PRD_MOVFASI.Any(x => x.BARCODE == barcode))
        //            bSpedizioni.SPUBICAZIONI(_ds, barcode);

        //        SpedizioniDS.USR_PRD_MOVFASIRow spedizioni = _ds.SPUBICAZIONI.Where(x => x.BARCODE == barcode).FirstOrDefault();

        //        //Spedizioni.MAGAZZRow articolo = _anagrafica.GetMAGAZZ(spedizioni.IDMAGAZZ);

        //        DataTable dtGriglia = _dsGriglia.Tables[_tabellaGriglia];

        //        DataRow riga = dtGriglia.NewRow();

        //        riga[(int)colonneGriglia.IDUBICAZIONE] = spedizioni.IsIDUBICAZIONENull() ? string.Empty : spedizioni.IDUBICAZIONE;
        //        riga[(int)colonneGriglia.CODICE] = spedizioni.IsCODICENull() ? string.Empty : spedizioni.CODICE;
        //        riga[(int)colonneGriglia.DESCRIZIONE] = spedizioni.IsDESCRIZIONENull() ? string.Empty : spedizioni.DESCRIZIONE;
        //        riga[(int)colonneGriglia.BARCODE] = spedizioni.ISBARCODENull() ? string.Empty : spedizioni.BARCODE;
                

        //        dtGriglia.Rows.Add(riga);

        //    }
        //    return true;
        //}

        enum colonneGriglia {IDUBICAZIONE,CODICE,DESCRIZIONE,BARCODE }
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

        //private void CreaGriglia()
        //{
        //    dgvTrasferimenti.DataSource = _dsGriglia;
        //    dgvTrasferimenti.DataMember = _tabellaGriglia;

        //    dgvTrasferimenti.Columns[(int)colonneGriglia.IDUBICAZIONE].Width = 150;
        //    dgvTrasferimenti.Columns[(int)colonneGriglia.CODICE].Width = 150;
        //    dgvTrasferimenti.Columns[(int)colonneGriglia.DESCRIZIONE].Width = 120;
        //    dgvTrasferimenti.Columns[(int)colonneGriglia.BARCODE].Width = 200;

        //}
    }
}

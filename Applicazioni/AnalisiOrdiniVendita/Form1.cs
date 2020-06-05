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
using AnalisiOrdiniVendita;
using Applicazioni.BLL;

namespace AnalisiOrdiniVendita
{
    public partial class Form1 : Form
    {
        private AnalisiOrdiniVenditaDS _ds = new AnalisiOrdiniVenditaDS();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            caricaGrigliaOC();
        }

        private void caricaGrigliaOC()
        {
            OrdiniVendita ov = new OrdiniVendita();
            ov.EstraiOC(_ds);

            dgvOC.DataSource = _ds;
            dgvOC.DataMember = _ds.OC_APERTI.TableName;

            dgvOC.Columns[10].Visible = false;
            dgvOC.Columns[11].Visible = false;
            dgvOC.Columns[12].Visible = false;
            dgvOC.Columns[13].Visible = false;
            dgvOC.Columns[14].Visible = false;
            for (int i = 16; i <= 40; i++)
                dgvOC.Columns[i].Visible = false;
            for (int i = 54; i <= 62; i++)
                dgvOC.Columns[i].Visible = false;
            for (int i = 64; i <= 81; i++)
                dgvOC.Columns[i].Visible = false;
            for (int i = 93; i <= 108; i++)
                dgvOC.Columns[i].Visible = false;
            dgvOC.Columns[111].Visible = false;
            dgvOC.Columns[112].Visible = false;
            dgvOC.Columns[113].Visible = false;

        }

        private void dgvOC_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected)
                return;
            pannello.Controls.Clear();
            string idvendited = (string)e.Row.Cells[10].Value;

            AnalisiOrdiniVenditaDS.OC_APERTIRow dettaglio = _ds.OC_APERTI.Where(x => x.IDVENDITED == idvendited).FirstOrDefault();
            if (dettaglio == null)
                MessageBox.Show("Impossibile trovare i dati di dettaglio", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);

            CommessaUC commessaUC = new CommessaUC();
            commessaUC.Commessa = dettaglio.FULLNUMDOC;
            commessaUC.Modello = dettaglio.MODELLO;
            commessaUC.Riga = dettaglio.NRRIGA;
            commessaUC.DataRichiesta = dettaglio.DATA_RICHIESTA.ToShortDateString();
            commessaUC.DataConcordata = dettaglio.DATA_CONFERMA.ToShortDateString();
            commessaUC.Quantita = dettaglio.QTATOT.ToString();
            commessaUC.QuantitaDaConsegnare = dettaglio.QTANOSPE.ToString();

            pannello.Controls.Add(commessaUC);

            OrdiniVendita ov = new OrdiniVendita();
            ov.FillAccantonatoEsistenzaPerOrigine(_ds, idvendited, (decimal)OrigineAccantonato.OrdineCliente);

            if (_ds.USR_ACCTO_ESI.Count > 0)
            {
                foreach (AnalisiOrdiniVenditaDS.USR_ACCTO_ESIRow esistenza in _ds.USR_ACCTO_ESI)
                {
                    AccantonatoEsistenzaUC uc = new AccantonatoEsistenzaUC();
                    uc.Modello = ov.GetModello(_ds, esistenza.IDMAGAZZ_ORI);
                    uc.Destinazione = string.Format("{0} {1}",ov.GetMagazzino(_ds, esistenza.IDMAGAZZ_DEST),esistenza.CODICECLIFO_DEST);
                    uc.QuantitaOrigine = esistenza.QUANTITA_ORI.ToString();
                    uc.QuantitaDestinazione = esistenza.QUANTITA_DEST.ToString();

                    pannello.Controls.Add(uc);
                }
            }


            ov.FillAccantonatoConsegnaPerOrigine(_ds, idvendited, (decimal)OrigineAccantonato.OrdineCliente);

            if (_ds.USR_ACCTO_CON.Count > 0)
            {
                foreach (AnalisiOrdiniVenditaDS.USR_ACCTO_CONRow esistenza in _ds.USR_ACCTO_CON)
                {
                    AccantonatoConsegnaUC uc = new AccantonatoConsegnaUC();
                    uc.Modello = ov.GetModello(_ds, esistenza.IDMAGAZZ_ORI);
                    uc.Destinazione = string.Format("{0} {1}", ov.GetMagazzino(_ds, esistenza.IDMAGAZZ_DEST), esistenza.IsCODICECLIFO_DESTNull()?string.Empty:esistenza.CODICECLIFO_DEST);
                    uc.QuantitaOrigine = esistenza.QUANTITA_ORI.ToString();
                    uc.QuantitaDestinazione = esistenza.QUANTITA_DEST.ToString();
                    uc.DataConsegna = esistenza.DATACONSEGNA_DEST.ToShortDateString();

                    foreach(AnalisiOrdiniVenditaDS.USR_ACCTO_CON_DOCRow documento in _ds.USR_ACCTO_CON_DOC.Where(x=>x.IDACCTOCON==esistenza.IDACCTOCON))
                    {
                     
                        uc.AggiungiDocumento(documento.DESTINAZIONE, ov.GetNumeroDocumento(_ds,documento.DESTINAZIONE,documento.IDDESTINAZIONE), documento.QUANTITA_DOC.ToString(), documento.QUANTITA_DOC_ARR.ToString());
                    }

                    pannello.Controls.Add(uc);

                    
                }
            }
        }
    }
}

using Applicazioni.BLL;
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

namespace AnalisiOrdiniVendita
{
    public partial class GrigliaForm : Form
    {
        public AnalisiOrdiniVenditaDS.OC_APERTIRow Dettaglio;
        private AnalisiOrdiniVenditaDS _ds = new AnalisiOrdiniVenditaDS();
        private BindingSource _source = new BindingSource();
        List<FaseModel> fasi = new List<FaseModel>();

        public GrigliaForm()
        {
            InitializeComponent();
        }

        private void GrigliaForm_Load(object sender, EventArgs e)
        {
            this.Text = string.Empty;
            if (Dettaglio == null) return;

            this.Text = string.Format("{0} {1} {2}", Dettaglio.RIFERIMENTO, Dettaglio.FULLNUMDOC, Dettaglio.MODELLO);
            caricaCommessa(chkNascondiAnnullate.Checked, chkNascandiCompletate.Checked);

            //dataGridView1.AutoGenerateColumns = false;

            _source.DataSource = fasi;
            dataGridView1.DataSource = _source;

            dataGridView1.Columns[1].Width = 230;
            dataGridView1.Columns[2].Width = 230;
            dataGridView1.Columns[3].Width = 230;

        }

        private void caricaCommessa(bool nascondiAnnullate, bool nascondiCompletate)
        {
            try
            {
                //            AnalisiOrdiniVenditaDS.OC_APERTIRow dettaglio = _ds.OC_APERTI.Where(x => x.IDVENDITED == idVendited).FirstOrDefault();
                if (Dettaglio == null)
                    MessageBox.Show("Impossibile trovare i dati di dettaglio", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);

                string idVendited = Dettaglio.IDVENDITED;

                //        aggiungiCommessa(Dettaglio);

                OrdiniVendita ov = new OrdiniVendita();
                ov.FillAccantonatoEsistenzaPerOrigine(_ds, idVendited, (decimal)OrigineAccantonato.OrdineCliente);

                if (_ds.USR_ACCTO_ESI.Count > 0)
                {
                    foreach (AnalisiOrdiniVenditaDS.USR_ACCTO_ESIRow esistenza in _ds.USR_ACCTO_ESI)
                        fasi.Add(aggiungiAccantonatoEsistenza(esistenza));
                }

                List<AnalisiOrdiniVenditaDS.USR_ACCTO_CON_DOCRow> documentiAccantonato = new List<AnalisiOrdiniVenditaDS.USR_ACCTO_CON_DOCRow>();

                ov.FillAccantonatoConsegnaPerOrigine(_ds, idVendited, (decimal)OrigineAccantonato.OrdineCliente);

                if (_ds.USR_ACCTO_CON.Count > 0)
                {
                    foreach (AnalisiOrdiniVenditaDS.USR_ACCTO_CONRow consegna in _ds.USR_ACCTO_CON)
                    {
                        FaseModel fase = new FaseModel();
                        fase.Livello1 = string.Empty;
                        fase.Livello2 = string.Format("{0} {1}", ov.GetMagazzino(_ds, consegna.IDTABMAG_DEST), consegna.IsCODICECLIFO_DESTNull() ? string.Empty : consegna.CODICECLIFO_DEST);
                        fase.Livello3 = string.Empty;
                        fase.Tipologia = Etichette.AccatonatoEsistenza;
                        fase.Modello = ov.GetModello(_ds, consegna.IDMAGAZZ_ORI);
                        fase.DataConsegna = consegna.DATACONSEGNA_DEST.ToShortDateString();
                        fase.Quantita = consegna.QUANTITA_ORI.ToString();
                        fase.QuantitaDaTerminare = consegna.QUANTITA_DEST.ToString();
                        fase.QuantitaOK = string.Empty;
                        fase.QuantitaDifettosa = string.Empty;
                        fase.QuantitaNonLavorata = string.Empty;
                        fase.QuantitaAnnullata = string.Empty;
                        fasi.Add(fase);

                        foreach (AnalisiOrdiniVenditaDS.USR_ACCTO_CON_DOCRow documento in _ds.USR_ACCTO_CON_DOC.Where(x => x.IDACCTOCON == consegna.IDACCTOCON))
                        {
                            FaseModel faseDocumento = new FaseModel();
                            faseDocumento.Livello1 = string.Empty;
                            faseDocumento.Livello2 = string.Empty;
                            faseDocumento.Livello3 = ov.GetNumeroDocumento(_ds, documento.DESTINAZIONE, documento.IDDESTINAZIONE);
                            faseDocumento.Tipologia = Etichette.AccatonatoDocumento;
                            faseDocumento.Modello = ov.GetModello(_ds, consegna.IDMAGAZZ_ORI);
                            faseDocumento.DataConsegna = string.Empty;
                            faseDocumento.Quantita = documento.QUANTITA_DOC.ToString();
                            faseDocumento.QuantitaDaTerminare = string.Empty;
                            faseDocumento.QuantitaOK = documento.QUANTITA_DOC_ARR.ToString();
                            faseDocumento.QuantitaDifettosa = string.Empty;
                            faseDocumento.QuantitaNonLavorata = string.Empty;
                            faseDocumento.QuantitaAnnullata = string.Empty;
                            fasi.Add(faseDocumento);
                            documentiAccantonato.Add(documento);
                        }

                    }
                }


                foreach (AnalisiOrdiniVenditaDS.USR_ACCTO_CON_DOCRow documento in documentiAccantonato)
                {

                    if (documento.DESTINAZIONE == (decimal)DestinazioneAccantonato.FaseDiCommessa)
                    {
                        AnalisiOrdiniVenditaDS.USR_PRD_FASIRow faseDestinazioneLancio = ov.GetFase(_ds, documento.IDDESTINAZIONE);
                        List<AnalisiOrdiniVenditaDS.USR_PRD_FASIRow> fasiLancio = ov.OrdinaFasiLancio(_ds, faseDestinazioneLancio.IDLANCIOD);
                        foreach (AnalisiOrdiniVenditaDS.USR_PRD_FASIRow fase in fasiLancio)
                        {
                            if (nascondiAnnullate && fase.QTA == fase.QTAANN && fase.QTATER == 0) continue;
                            if (nascondiCompletate && fase.QTA == fase.QTATER && fase.QTADATER == 0) continue;

                            FaseModel faseDestinazione = new FaseModel();
                            faseDestinazione.Livello1 = string.Format("{0} - {1}", fase.CODICECLIFO, ov.GetDescrizioneFase(_ds, fase.IDTABFAS));
                            faseDestinazione.Livello2 = string.Empty;
                            faseDestinazione.Livello3 = string.Empty;
                            faseDestinazione.Tipologia = Etichette.Fase;
                            faseDestinazione.Modello = ov.GetModello(_ds, fase.IDMAGAZZ);
                            faseDestinazione.DataConsegna = string.Empty;
                            faseDestinazione.Quantita = fase.QTA.ToString();
                            faseDestinazione.QuantitaDaTerminare = fase.QTADATER.ToString();
                            faseDestinazione.QuantitaOK = string.Empty;
                            faseDestinazione.QuantitaDifettosa = string.Empty;
                            faseDestinazione.QuantitaNonLavorata = string.Empty;
                            faseDestinazione.QuantitaAnnullata = fase.QTAANN.ToString();
                            fasi.Add(faseDestinazione);


                            foreach (AnalisiOrdiniVenditaDS.USR_PRD_MATERow materiale in _ds.USR_PRD_MATE.Where(x => x.IDPRDFASE == fase.IDPRDFASE))
                            {
                                FaseModel faseMateriale = new FaseModel();
                                faseMateriale.Livello1 = string.Empty;
                                faseMateriale.Livello2 = string.Empty;
                                faseMateriale.Livello3 = string.Empty;
                                faseMateriale.Tipologia = Etichette.Materiale;
                                faseMateriale.Modello = ov.GetModello(_ds, materiale.IDMAGAZZ);
                                faseMateriale.DataConsegna = string.Empty;
                                faseMateriale.Quantita = materiale.FABBIACCECOM.ToString();
                                faseMateriale.QuantitaDaTerminare = materiale.FABBIACCOCOM.ToString();
                                faseMateriale.QuantitaOK = materiale.FABBITOTCOM.ToString();
                                faseMateriale.QuantitaDifettosa = string.Empty;
                                faseMateriale.QuantitaNonLavorata = string.Empty;
                                faseMateriale.QuantitaAnnullata = string.Empty;
                                fasi.Add(faseMateriale);
                            }


                            if (fase.CODICECLIFO.Trim() == "02350")
                            {
                                inserisciInfragruppo(fase.IDPRDFASE, nascondiAnnullate, nascondiCompletate);
                            }
                            else
                            {
                                foreach (AnalisiOrdiniVenditaDS.USR_PRD_MOVFASIRow odl in _ds.USR_PRD_MOVFASI.Where(x => x.IDPRDFASE == fase.IDPRDFASE))
                                {
                                    string testata = string.Empty;
                                    AnalisiOrdiniVenditaDS.USR_CHECKQ_TRow cqt = _ds.USR_CHECKQ_T.Where(x => x.IDPRDMOVFASE == odl.IDPRDMOVFASE).FirstOrDefault();
                                    if (cqt != null)
                                    {
                                        testata = cqt.NUMCHECKQT;
                                    }
                                    FaseModel faseODL = new FaseModel();
                                    faseODL.Livello1 = string.Empty;
                                    faseODL.Livello2 = odl.NUMMOVFASE;
                                    faseODL.Livello3 = string.Empty;
                                    faseODL.Tipologia = Etichette.FaseODL;
                                    faseODL.Modello = ov.GetModello(_ds, fase.IDMAGAZZ);
                                    faseODL.DataConsegna = odl.DATAFINE.ToShortDateString();
                                    faseODL.Quantita = odl.QTA.ToString();
                                    faseODL.QuantitaDaTerminare = odl.QTADATER.ToString();
                                    faseODL.QuantitaOK = odl.QTATER_OK.ToString();
                                    faseODL.QuantitaDifettosa = odl.QTATER_DF.ToString();
                                    faseODL.QuantitaNonLavorata = odl.QTATER_NL.ToString();
                                    faseODL.QuantitaAnnullata = odl.QTAANN.ToString();
                                    faseODL.ControlloQualità = testata;
                                    fasi.Add(faseODL);

                                    if (cqt != null)
                                    {

                                    }
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
            }
        }
        //private void aggiungiCommessa(AnalisiOrdiniVenditaDS.OC_APERTIRow dettaglio)
        //{
        //    CommessaUC commessaUC = new CommessaUC();
        //    commessaUC.Commessa = dettaglio.FULLNUMDOC;
        //    commessaUC.Modello = dettaglio.MODELLO;
        //    commessaUC.Riga = dettaglio.NRRIGA;
        //    commessaUC.DataRichiesta = dettaglio.DATA_RICHIESTA.ToShortDateString();
        //    commessaUC.DataConcordata = dettaglio.DATA_CONFERMA.ToShortDateString();
        //    commessaUC.Quantita = dettaglio.QTATOT.ToString();
        //    commessaUC.QuantitaDaConsegnare = dettaglio.QTANOSPE.ToString();

        //    pannello.Controls.Add(commessaUC);
        //}

        private FaseModel aggiungiAccantonatoEsistenza(AnalisiOrdiniVenditaDS.USR_ACCTO_ESIRow esistenza)
        {
            OrdiniVendita ov = new OrdiniVendita();
            FaseModel fase = new FaseModel();
            fase.Livello1 = string.Format("{0} {1}", ov.GetMagazzino(_ds, esistenza.IDMAGAZZ_DEST), esistenza.CODICECLIFO_DEST);
            fase.Livello2 = string.Empty;
            fase.Livello3 = string.Empty;
            fase.Tipologia = Etichette.Accatonato;
            fase.Modello = ov.GetModello(_ds, esistenza.IDMAGAZZ_ORI);
            fase.DataConsegna = string.Empty;
            fase.Quantita = esistenza.QUANTITA_ORI.ToString();
            fase.QuantitaDaTerminare = esistenza.QUANTITA_DEST.ToString();
            fase.QuantitaOK = string.Empty;
            fase.QuantitaDifettosa = string.Empty;
            fase.QuantitaNonLavorata = string.Empty;
            fase.QuantitaAnnullata = string.Empty;

            return fase;

        }

        private void inserisciSeguiti(AnalisiOrdiniVenditaDS ds, AnalisiOrdiniVenditaDS.USR_CHECKQ_TRow cqt)
        {
            OrdiniVendita ov = new OrdiniVendita();
            AnalisiOrdiniVenditaDS dsSeguiti = new AnalisiOrdiniVenditaDS();
            List<AnalisiOrdiniVenditaDS.USR_CHECKQ_SRow> seguiti = ov.GetSeguito(ds, cqt.IDCHECKQT);
            foreach (AnalisiOrdiniVenditaDS.USR_CHECKQ_SRow seguito in seguiti)
            {
                FaseModel faseSeguito = new FaseModel();
                faseSeguito.Livello1 = string.Empty;
                faseSeguito.Livello2 = cqt.IsNUMCHECKQTNull() ? string.Empty : cqt.NUMCHECKQT;
                faseSeguito.Livello3 = ov.GetDescrizioneSeguito(_ds, seguito.IDSEGUITOCHECKQ);
                faseSeguito.Tipologia = Etichette.Seguito;
                faseSeguito.Modello = ov.GetModello(_ds, cqt.IDMAGAZZ);
                faseSeguito.DataConsegna = string.Empty;
                faseSeguito.Quantita = string.Empty;
                faseSeguito.QuantitaDaTerminare = string.Empty;
                faseSeguito.QuantitaOK = string.Empty;
                faseSeguito.QuantitaDifettosa = string.Empty;
                faseSeguito.QuantitaNonLavorata = string.Empty;
                faseSeguito.QuantitaAnnullata = string.Empty;
                fasi.Add(faseSeguito);

                if (!seguito.IsIDPRDMOVFASENull())
                {
                    AnalisiOrdiniVenditaDS.USR_PRD_MOVFASIRow odl = ov.GetODL(ds, seguito.IDPRDMOVFASE);
                    FaseModel faseODL = new FaseModel();
                    faseODL.Livello1 = string.Empty;
                    faseODL.Livello2 = odl.NUMMOVFASE;
                    faseODL.Livello3 = string.Empty;
                    faseODL.Tipologia = Etichette.SeguitoODL;
                    faseODL.Modello = ov.GetModello(_ds, odl.IDMAGAZZ);
                    faseODL.DataConsegna = odl.DATAFINE.ToShortDateString();
                    faseODL.Quantita = odl.QTA.ToString();
                    faseODL.QuantitaDaTerminare = odl.QTADATER.ToString();
                    faseODL.QuantitaOK = odl.QTATER_OK.ToString();
                    faseODL.QuantitaDifettosa = odl.QTATER_DF.ToString();
                    faseODL.QuantitaNonLavorata = odl.QTATER_NL.ToString();
                    faseODL.QuantitaAnnullata = odl.QTAANN.ToString();
                    faseODL.ControlloQualità = string.Empty;
                    fasi.Add(faseODL);
                }

                if (!seguito.IsIDLANCIODNull())
                {

                    ov.CaricaLancio(dsSeguiti, seguito.IDLANCIOD);
                    foreach (AnalisiOrdiniVenditaDS.USR_PRD_FASIRow fase in dsSeguiti.USR_PRD_FASI.Where(x => x.IDLANCIOD == seguito.IDLANCIOD).OrderBy(x => x.SEQFASE))
                    {

                        if (dsSeguiti.USR_PRD_MOVFASI.Where(x => x.IDPRDFASE == fase.IDPRDFASE).Count() > 0)
                        {
                            foreach (AnalisiOrdiniVenditaDS.USR_PRD_MOVFASIRow odl in dsSeguiti.USR_PRD_MOVFASI.Where(x => x.IDPRDFASE == fase.IDPRDFASE))
                            {
                                string faseStr = string.Format("{0} - {1} {2}", fase.CODICECLIFO, ov.GetDescrizioneFase(_ds, fase.IDTABFAS), odl.NUMMOVFASE);
                                FaseModel faseODL = new FaseModel();
                                faseODL.Livello1 = string.Empty;
                                faseODL.Livello3 = faseStr;
                                faseODL.Livello2 = string.Empty;
                                faseODL.Tipologia = Etichette.ControlloQualita;
                                faseODL.Modello = ov.GetModello(_ds, odl.IDMAGAZZ);
                                faseODL.DataConsegna = odl.DATAFINE.ToShortDateString();
                                faseODL.Quantita = odl.QTA.ToString();
                                faseODL.QuantitaDaTerminare = odl.QTADATER.ToString();
                                faseODL.QuantitaOK = odl.QTATER_OK.ToString();
                                faseODL.QuantitaDifettosa = odl.QTATER_DF.ToString();
                                faseODL.QuantitaNonLavorata = odl.QTATER_NL.ToString();
                                faseODL.QuantitaAnnullata = odl.QTAANN.ToString();
                                faseODL.ControlloQualità = string.Empty;
                                fasi.Add(faseODL);
                            }
                        }
                        else
                        {
                            string faseStr = string.Format("{0} - {1}", fase.CODICECLIFO, ov.GetDescrizioneFase(_ds, fase.IDTABFAS));
                            FaseModel faseODL = new FaseModel();
                            faseODL.Livello1 = string.Empty;
                            faseODL.Livello3 = faseStr;
                            faseODL.Livello2 = string.Empty;
                            faseODL.Tipologia = Etichette.ControlloQualita;
                            faseODL.Modello = ov.GetModello(_ds, fase.IDMAGAZZ);
                            faseODL.DataConsegna = string.Empty;
                            faseODL.Quantita = fase.QTA.ToString();
                            faseODL.QuantitaDaTerminare = fase.QTADATER.ToString();
                            faseODL.QuantitaOK = fase.QTATER.ToString();
                            faseODL.QuantitaDifettosa = string.Empty;
                            faseODL.QuantitaNonLavorata = string.Empty;
                            faseODL.QuantitaAnnullata = fase.QTAANN.ToString();
                            faseODL.ControlloQualità = string.Empty;
                            fasi.Add(faseODL);

                        }
                    }
                }
                //                pannello.Controls.Add(suc);
            }
        }

        private void inserisciInfragruppo(string idPrdFaseOrigine, bool nascondiAnnullate, bool nascondiCompletate)
        {
            AnalisiOrdiniVenditaDS dsInfragruppo = new AnalisiOrdiniVenditaDS();
            OrdiniVendita ov = new OrdiniVendita();

            string idLancioD = ov.CaricaFasiInfragruppo(dsInfragruppo, idPrdFaseOrigine);
            if (string.IsNullOrEmpty(idLancioD)) return;

            List<AnalisiOrdiniVenditaDS.USR_PRD_FASIRow> fasiLancio = ov.OrdinaFasiLancio(dsInfragruppo, idLancioD);

            foreach (AnalisiOrdiniVenditaDS.USR_PRD_FASIRow fase in fasiLancio)
            {
                if (nascondiAnnullate && fase.QTA == fase.QTAANN && fase.QTATER == 0) continue;
                if (nascondiCompletate && fase.QTA == fase.QTATER && fase.QTADATER == 0) continue;

                FaseModel faseInfragruppo = new FaseModel();
                faseInfragruppo.Livello1 = string.Empty;
                faseInfragruppo.Livello2 = string.Format("{0} - {1}", fase.CODICECLIFO, ov.GetDescrizioneFase(_ds, fase.IDTABFAS));
                faseInfragruppo.Livello3 = string.Empty;
                faseInfragruppo.Tipologia = Etichette.Infragruppo;
                faseInfragruppo.Modello = ov.GetModello(_ds, fase.IDMAGAZZ);
                faseInfragruppo.DataConsegna = string.Empty;
                faseInfragruppo.Quantita = fase.QTA.ToString();
                faseInfragruppo.QuantitaDaTerminare = fase.QTADATER.ToString();
                faseInfragruppo.QuantitaOK = fase.QTATER.ToString();
                faseInfragruppo.QuantitaDifettosa = string.Empty;
                faseInfragruppo.QuantitaNonLavorata = string.Empty;
                faseInfragruppo.QuantitaAnnullata = fase.QTAANN.ToString();
                fasi.Add(faseInfragruppo);

                foreach (AnalisiOrdiniVenditaDS.USR_PRD_MOVFASIRow odl in dsInfragruppo.USR_PRD_MOVFASI.Where(x => x.IDPRDFASE == fase.IDPRDFASE))
                {
                    string testata = string.Empty;
                    AnalisiOrdiniVenditaDS.USR_CHECKQ_TRow cqt = dsInfragruppo.USR_CHECKQ_T.Where(x => x.IDPRDMOVFASE == odl.IDPRDMOVFASE).FirstOrDefault();
                    if (cqt != null)
                    {
                        testata = cqt.NUMCHECKQT;
                    }

                    FaseModel faseODL = new FaseModel();
                    faseODL.Livello1 = string.Empty;
                    faseODL.Livello2 = odl.NUMMOVFASE;
                    faseODL.Livello3 = string.Empty;
                    faseODL.Tipologia = Etichette.InfragruppoODL;
                    faseODL.Modello = ov.GetModello(_ds, fase.IDMAGAZZ);
                    faseODL.DataConsegna = odl.DATAFINE.ToShortDateString();
                    faseODL.Quantita = odl.QTA.ToString();
                    faseODL.QuantitaDaTerminare = odl.QTADATER.ToString();
                    faseODL.QuantitaOK = odl.QTATER_OK.ToString();
                    faseODL.QuantitaDifettosa = odl.QTATER_DF.ToString();
                    faseODL.QuantitaNonLavorata = odl.QTATER_NL.ToString();
                    faseODL.QuantitaAnnullata = odl.QTAANN.ToString();
                    faseODL.ControlloQualità = testata;
                    fasi.Add(faseODL);

                    if (cqt != null)
                    {
                        inserisciSeguiti(dsInfragruppo, cqt);

                    }
                }



            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

            switch ((string)dataGridView1.Rows[e.RowIndex].Cells[0].Value)
            {
                case Etichette.Infragruppo:
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    break;
                //case Etichette.InfragruppoODL:
                //    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Coral;
                //    break;
                case Etichette.ControlloQualita:
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
                    break;
                case Etichette.Seguito:
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Azure;
                    break;
                //case Etichette.SeguitoODL:
                //    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Azure;
                //    break;
                case Etichette.Accatonato:
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                    break;
                case Etichette.AccatonatoEsistenza:
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                    break;
                case Etichette.AccatonatoDocumento:
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.YellowGreen;
                    break;
                case Etichette.Fase:
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Beige;
                    break;
                //case Etichette.FaseODL:
                //    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                //    break;
                    //                case Etichette.Materiale:
                    //                  dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gray;
                    //                break;
            }

          

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!string.IsNullOrEmpty((string)row.Cells[10].Value) && (string)row.Cells[10].Value != "0")
                {
                    row.Cells[10].Style.BackColor = Color.Yellow;
                }
                if (!string.IsNullOrEmpty((string)row.Cells[11].Value) && (string)row.Cells[11].Value != "0")
                {
                    row.Cells[11].Style.BackColor = Color.Yellow;
                }
            }
        }

        private void chkNascondiAnnullate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                caricaCommessa(chkNascondiAnnullate.Checked, chkNascandiCompletate.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}

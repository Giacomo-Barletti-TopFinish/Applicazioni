﻿using Applicazioni.BLL;
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
    public partial class CommessaForm : Form
    {

        public AnalisiOrdiniVenditaDS.OC_APERTIRow Dettaglio;
        private AnalisiOrdiniVenditaDS _ds = new AnalisiOrdiniVenditaDS();
        public CommessaForm()
        {
            InitializeComponent();
        }

        private void CommessaForm_Load(object sender, EventArgs e)
        {
            this.Text = string.Empty;
            if (Dettaglio == null) return;

            this.Text = string.Format("{0} {1} {2}", Dettaglio.RIFERIMENTO, Dettaglio.FULLNUMDOC, Dettaglio.MODELLO);
            caricaCommessa(chkNascondiAnnullate.Checked, chkNascandiCompletate.Checked);
        }

        private void aggiungiCommessa(AnalisiOrdiniVenditaDS.OC_APERTIRow dettaglio)
        {
            CommessaUC commessaUC = new CommessaUC();
            commessaUC.Commessa = dettaglio.FULLNUMDOC;
            commessaUC.Modello = dettaglio.MODELLO;
            commessaUC.Riga = dettaglio.NRRIGA;
            commessaUC.DataRichiesta = dettaglio.DATA_RICHIESTA.ToShortDateString();
            commessaUC.DataConcordata = dettaglio.DATA_CONFERMA.ToShortDateString();
            commessaUC.Quantita = dettaglio.QTATOT.ToString();
            commessaUC.QuantitaDaConsegnare = dettaglio.QTANOSPE.ToString();

            pannello.Controls.Add(commessaUC);
        }

        private void aggiungiAccantonatoEsistenza(AnalisiOrdiniVenditaDS.USR_ACCTO_ESIRow esistenza)
        {
            OrdiniVendita ov = new OrdiniVendita();
            AccantonatoEsistenzaUC uc = new AccantonatoEsistenzaUC();
            uc.Modello = ov.GetModello(_ds, esistenza.IDMAGAZZ_ORI);
            uc.Destinazione = string.Format("{0} {1}", ov.GetMagazzino(_ds, esistenza.IDMAGAZZ_DEST), esistenza.CODICECLIFO_DEST);
            uc.QuantitaOrigine = esistenza.QUANTITA_ORI.ToString();
            uc.QuantitaDestinazione = esistenza.QUANTITA_DEST.ToString();

            pannello.Controls.Add(uc);

        }

        private void caricaCommessa(bool nascondiAnnullate, bool nascondiCompletate)
        {
            try
            {
                SuspendLayout();
                pannello.Controls.Clear();
                //            AnalisiOrdiniVenditaDS.OC_APERTIRow dettaglio = _ds.OC_APERTI.Where(x => x.IDVENDITED == idVendited).FirstOrDefault();
                if (Dettaglio == null)
                    MessageBox.Show("Impossibile trovare i dati di dettaglio", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);

                string idVendited = Dettaglio.IDVENDITED;

                aggiungiCommessa(Dettaglio);

                OrdiniVendita ov = new OrdiniVendita();
                ov.FillAccantonatoEsistenzaPerOrigine(_ds, idVendited, (decimal)OrigineAccantonato.OrdineCliente);

                if (_ds.USR_ACCTO_ESI.Count > 0)
                {
                    foreach (AnalisiOrdiniVenditaDS.USR_ACCTO_ESIRow esistenza in _ds.USR_ACCTO_ESI)
                        aggiungiAccantonatoEsistenza(esistenza);
                }

                List<AnalisiOrdiniVenditaDS.USR_ACCTO_CON_DOCRow> documentiAccantonato = new List<AnalisiOrdiniVenditaDS.USR_ACCTO_CON_DOCRow>();

                ov.FillAccantonatoConsegnaPerOrigine(_ds, idVendited, (decimal)OrigineAccantonato.OrdineCliente);

                if (_ds.USR_ACCTO_CON.Count > 0)
                {
                    foreach (AnalisiOrdiniVenditaDS.USR_ACCTO_CONRow consegna in _ds.USR_ACCTO_CON)
                    {
                        AccantonatoConsegnaUC uc = new AccantonatoConsegnaUC();
                        uc.Modello = ov.GetModello(_ds, consegna.IDMAGAZZ_ORI);
                        uc.Destinazione = string.Format("{0} {1}", ov.GetMagazzino(_ds, consegna.IDMAGAZZ_DEST), consegna.IsCODICECLIFO_DESTNull() ? string.Empty : consegna.CODICECLIFO_DEST);
                        uc.QuantitaOrigine = consegna.QUANTITA_ORI.ToString();
                        uc.QuantitaDestinazione = consegna.QUANTITA_DEST.ToString();
                        uc.DataConsegna = consegna.DATACONSEGNA_DEST.ToShortDateString();
                        foreach (AnalisiOrdiniVenditaDS.USR_ACCTO_CON_DOCRow documento in _ds.USR_ACCTO_CON_DOC.Where(x => x.IDACCTOCON == consegna.IDACCTOCON))
                        {
                            uc.AggiungiDocumento(documento.DESTINAZIONE, ov.GetNumeroDocumento(_ds, documento.DESTINAZIONE, documento.IDDESTINAZIONE), documento.QUANTITA_DOC.ToString(), documento.QUANTITA_DOC_ARR.ToString());
                            documentiAccantonato.Add(documento);
                        }
                        pannello.Controls.Add(uc);


                    }
                }


                foreach (AnalisiOrdiniVenditaDS.USR_ACCTO_CON_DOCRow documento in documentiAccantonato)
                {

                    if (documento.DESTINAZIONE == (decimal)DestinazioneAccantonato.FaseDiCommessa)
                    {
                        AnalisiOrdiniVenditaDS.USR_PRD_FASIRow faseDestinazione = ov.GetFase(_ds, documento.IDDESTINAZIONE);
                        List<AnalisiOrdiniVenditaDS.USR_PRD_FASIRow> fasiLancio = ov.OrdinaFasiLancio(_ds, faseDestinazione.IDLANCIOD);
                        foreach (AnalisiOrdiniVenditaDS.USR_PRD_FASIRow fase in fasiLancio)
                        {
                            if (nascondiAnnullate && fase.QTA == fase.QTAANN && fase.QTATER == 0) continue;
                            if (nascondiCompletate && fase.QTA == fase.QTATER && fase.QTADATER == 0) continue;

                            BaseUC uc = new BaseUC(TipoControllo.Fase,
                                ov.GetModello(_ds, fase.IDMAGAZZ),
                                string.Format("{0} - {1}", fase.CODICECLIFO, ov.GetDescrizioneFase(_ds, fase.IDTABFAS)),
                                string.Empty,
                                fase.QTA,
                                fase.QTADATER,
                                fase.QTATER,
                                0,
                                0,
                                fase.QTAANN,
                                string.Empty);
                            pannello.Controls.Add(uc);

                            foreach (AnalisiOrdiniVenditaDS.USR_PRD_MATERow materiale in _ds.USR_PRD_MATE.Where(x => x.IDPRDFASE == fase.IDPRDFASE))
                            {
                                uc.AggiungiMateriale(ov.GetModello(_ds, materiale.IDMAGAZZ), materiale.FABBIACCECOM, materiale.FABBIACCOCOM, materiale.FABBITOTCOM);
                            }


                            if (fase.CODICECLIFO.Trim() == "02350")
                            {
                                inserisciInfragruppo(fase.IDPRDFASE, nascondiAnnullate, nascondiCompletate, uc);
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
                                    uc.AggiungiODL(TipoControllo.Fase, odl.NUMMOVFASE, odl.DATAFINE.ToShortDateString(), odl.QTA, odl.QTADATER, odl.QTATER_OK, odl.QTATER_DF, odl.QTATER_NL, odl.QTAANN, testata);

                                    if (cqt != null)
                                        inserisciSeguiti(_ds, cqt, uc);
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                ResumeLayout();
            }
        }

        private void inserisciSeguiti(AnalisiOrdiniVenditaDS ds, AnalisiOrdiniVenditaDS.USR_CHECKQ_TRow cqt, BaseUC uc)
        {
            OrdiniVendita ov = new OrdiniVendita();
            AnalisiOrdiniVenditaDS dsSeguiti = new AnalisiOrdiniVenditaDS();
            List<AnalisiOrdiniVenditaDS.USR_CHECKQ_SRow> seguiti = ov.GetSeguito(ds, cqt.IDCHECKQT);
            foreach (AnalisiOrdiniVenditaDS.USR_CHECKQ_SRow seguito in seguiti)
            {
                uc.AggiungiDescrizioneSeguito(cqt.IsNUMCHECKQTNull() ? string.Empty : cqt.NUMCHECKQT,
                    ov.GetDescrizioneSeguito(_ds, seguito.IDSEGUITOCHECKQ),
                    ov.GetModello(_ds, cqt.IDMAGAZZ),
                    seguito.DATASEGUITOCHECKQ.ToShortDateString(),
                    cqt.IsNUMCHECKQTNull() ? string.Empty : cqt.NUMCHECKQT);
                if (!seguito.IsIDPRDMOVFASENull())
                {
                    AnalisiOrdiniVenditaDS.USR_PRD_MOVFASIRow odl = ov.GetODL(ds, seguito.IDPRDMOVFASE);
                    uc.AggiungiODL(TipoControllo.Qualita,odl.NUMMOVFASE, odl.DATAFINE.ToShortDateString(), odl.QTA, odl.QTADATER, odl.QTATER_OK, odl.QTATER_DF, odl.QTATER_NL, odl.QTAANN,string.Empty);
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
                                uc.AggiungiODL(TipoControllo.Qualita, faseStr, odl.DATAFINE.ToShortDateString(), odl.QTA, odl.QTADATER, odl.QTATER_OK, odl.QTATER_DF, odl.QTATER_NL, odl.QTAANN,string.Empty);
                            }
                        }
                        else
                        {
                            string faseStr = string.Format("{0} - {1}", fase.CODICECLIFO, ov.GetDescrizioneFase(_ds, fase.IDTABFAS));
                            uc.AggiungiODL(TipoControllo.Qualita, faseStr, string.Empty, fase.QTA, fase.QTADATER, fase.QTATER, 0, 0, fase.QTAANN, string.Empty);

                        }
                    }
                }
//                pannello.Controls.Add(suc);
            }
        }

        private void inserisciInfragruppo(string idPrdFaseOrigine, bool nascondiAnnullate, bool nascondiCompletate,BaseUC ucPadre)
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

                BaseUC infragruppo = new BaseUC(TipoControllo.Infragruppo,
                     ov.GetModello(_ds, fase.IDMAGAZZ),
                            string.Format("{0} - {1}", fase.CODICECLIFO, ov.GetDescrizioneFase(_ds, fase.IDTABFAS)),
                            string.Empty,
                            fase.QTA,
                            fase.QTADATER,
                            fase.QTATER,
                            0,
                            0,
                            fase.QTAANN,
                            string.Empty);

                foreach (AnalisiOrdiniVenditaDS.USR_PRD_MOVFASIRow odl in dsInfragruppo.USR_PRD_MOVFASI.Where(x => x.IDPRDFASE == fase.IDPRDFASE))
                {
                    string testata = string.Empty;
                    AnalisiOrdiniVenditaDS.USR_CHECKQ_TRow cqt = dsInfragruppo.USR_CHECKQ_T.Where(x => x.IDPRDMOVFASE == odl.IDPRDMOVFASE).FirstOrDefault();
                    if (cqt != null)
                    {
                        testata = cqt.NUMCHECKQT;
                    }

                    ucPadre.AggiungiODL(TipoControllo.Infragruppo,odl.NUMMOVFASE, odl.DATAFINE.ToShortDateString(), odl.QTA, odl.QTADATER, odl.QTATER_OK, odl.QTATER_DF, odl.QTATER_NL, odl.QTAANN, testata);

                    if (cqt != null)
                    {
                        inserisciSeguiti(dsInfragruppo, cqt,ucPadre);

                    }
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

        private void chkNascandiCompletate_CheckedChanged(object sender, EventArgs e)
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

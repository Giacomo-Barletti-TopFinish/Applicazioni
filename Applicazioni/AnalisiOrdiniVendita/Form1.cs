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
                    uc.Destinazione = string.Format("{0} {1}", ov.GetMagazzino(_ds, esistenza.IDMAGAZZ_DEST), esistenza.CODICECLIFO_DEST);
                    uc.QuantitaOrigine = esistenza.QUANTITA_ORI.ToString();
                    uc.QuantitaDestinazione = esistenza.QUANTITA_DEST.ToString();

                    pannello.Controls.Add(uc);
                }
            }

            List<string> idcheckq_T = new List<string>();
            ov.FillAccantonatoConsegnaPerOrigine(_ds, idvendited, (decimal)OrigineAccantonato.OrdineCliente);

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

                    pannello.Controls.Add(uc);
                    foreach (AnalisiOrdiniVenditaDS.USR_ACCTO_CON_DOCRow documento in _ds.USR_ACCTO_CON_DOC.Where(x => x.IDACCTOCON == consegna.IDACCTOCON))
                    {

                        uc.AggiungiDocumento(documento.DESTINAZIONE, ov.GetNumeroDocumento(_ds, documento.DESTINAZIONE, documento.IDDESTINAZIONE), documento.QUANTITA_DOC.ToString(), documento.QUANTITA_DOC_ARR.ToString());
                        if (documento.DESTINAZIONE == (decimal)DestinazioneAccantonato.FaseDiCommessa)
                        {
                            AnalisiOrdiniVenditaDS.USR_PRD_FASIRow faseDestinazione = ov.GetFase(_ds, documento.IDDESTINAZIONE);
                            foreach (AnalisiOrdiniVenditaDS.USR_PRD_FASIRow fase in _ds.USR_PRD_FASI.Where(x => x.IDLANCIOD == faseDestinazione.IDLANCIOD).OrderBy(x => x.SEQFASE))
                            {
                                OrdineDiLavoroUC odlUC = new OrdineDiLavoroUC();
                                odlUC.Modello = ov.GetModello(_ds, fase.IDMAGAZZ);
                                odlUC.Quantita = fase.QTA.ToString();
                                odlUC.QuantitaDaTerminare = fase.QTADATER.ToString();
                                odlUC.QuantitaOK = fase.QTATER.ToString();
                                odlUC.QuantitaDifettosa = string.Empty;
                                odlUC.QuantitaNonLavorata = string.Empty;
                                odlUC.QuanatitaAnnullata = fase.QTAANN.ToString();
                                odlUC.Fase = string.Format("{0} - {1}", fase.CODICECLIFO, ov.GetDescrizioneFase(_ds, fase.IDTABFAS));
                                foreach (AnalisiOrdiniVenditaDS.USR_PRD_MOVFASIRow odl in _ds.USR_PRD_MOVFASI.Where(x => x.IDPRDFASE == fase.IDPRDFASE))
                                {
                                    string testata = string.Empty;
                                    AnalisiOrdiniVenditaDS.USR_CHECKQ_TRow cqt = _ds.USR_CHECKQ_T.Where(x => x.IDPRDMOVFASE == odl.IDPRDMOVFASE).FirstOrDefault();
                                    if (cqt != null)
                                    {
                                        idcheckq_T.Add(cqt.IDCHECKQT);
                                        testata = cqt.NUMCHECKQT;
                                    }
                                    odlUC.AggiungiDocumento(odl.NUMMOVFASE, odl.DATAFINE.ToShortDateString(), odl.QTA, odl.QTADATER, odl.QTATER_OK, odl.QTATER_DF, odl.QTATER_NL, odl.QTAANN, testata);
                                }
                                pannello.Controls.Add(odlUC);
                            }
                        }
                    }

                    foreach (string idcheckqT in idcheckq_T)
                    {
                        AnalisiOrdiniVenditaDS.USR_CHECKQ_TRow cqt = _ds.USR_CHECKQ_T.Where(x => x.IDCHECKQT == idcheckqT).FirstOrDefault();
                        if (cqt == null) continue;

                        List<AnalisiOrdiniVenditaDS.USR_CHECKQ_SRow> seguiti = ov.GetSeguito(_ds, cqt.IDCHECKQT);
                        foreach (AnalisiOrdiniVenditaDS.USR_CHECKQ_SRow seguito in seguiti)
                        {
                            SeguitoUC suc = new SeguitoUC();
                            suc.Modello = ov.GetModello(_ds, cqt.IDMAGAZZ);
                            suc.Seguito = ov.GetDescrizioneSeguito(_ds, seguito.IDSEGUITOCHECKQ);
                            suc.DataSeguito = seguito.DATASEGUITOCHECKQ.ToShortDateString();
                            suc.ControlloQualita = cqt.NOTECHECKQT;

                            if (!seguito.IsIDPRDMOVFASENull())
                            {
                                AnalisiOrdiniVenditaDS.USR_PRD_MOVFASIRow odl = ov.GetODL(_ds, seguito.IDPRDMOVFASE);
                                suc.AggiungiDocumento(odl.NUMMOVFASE, odl.DATAFINE.ToShortDateString(), odl.QTA, odl.QTADATER, odl.QTATER_OK, odl.QTATER_DF, odl.QTATER_NL, odl.QTAANN);
                            }

                            if (!seguito.IsIDLANCIODNull())
                            {
                                ov.CaricaLancio(_ds, seguito.IDLANCIOD);
                                foreach (AnalisiOrdiniVenditaDS.USR_PRD_FASIRow fase in _ds.USR_PRD_FASI.Where(x => x.IDLANCIOD == seguito.IDLANCIOD).OrderBy(x => x.SEQFASE))
                                {

                                    foreach (AnalisiOrdiniVenditaDS.USR_PRD_MOVFASIRow odl in _ds.USR_PRD_MOVFASI.Where(x => x.IDPRDFASE == fase.IDPRDFASE))
                                    {
                                        string faseStr = string.Format("{0} - {1} {2}", fase.CODICECLIFO, ov.GetDescrizioneFase(_ds, fase.IDTABFAS), odl.NUMMOVFASE);
                                        suc.AggiungiDocumento(faseStr, odl.DATAFINE.ToShortDateString(), odl.QTA, odl.QTADATER, odl.QTATER_OK, odl.QTATER_DF, odl.QTATER_NL, odl.QTAANN);
                                    }
                                }
                            }
                            pannello.Controls.Add(suc);
                        }

                    }

                }
            }
        }

    }
}

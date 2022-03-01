using Applicazioni.Data.EstraiProdottiFiniti;
using Applicazioni.Data.MigrazioneODL;
using Applicazioni.Entities;
using EstraiProdottiFiniti;
using NAV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MigrazioneODL
{
    public partial class Form1 : Form
    {
        private MigrazioneODLDS _ds = new MigrazioneODLDS();
        private const string etichettaStart = "Elabora";
        private const string etichettaStop = "Annulla";
        private BackgroundWorker _bgwMigraODL = new BackgroundWorker();

        string ubicazione = "MTP";
        //        string collocazione = "IMPORTAZIONE";
        string collocazione = "PROD";

        public Form1()
        {
            InitializeComponent();
        }
        private DateTime _start;


        private void inizializzaBackgroundWorker()
        {
            _bgwMigraODL.WorkerReportsProgress = true;
            _bgwMigraODL.WorkerSupportsCancellation = true;

            _bgwMigraODL.DoWork += _bgwMigraODL_DoWork;
            _bgwMigraODL.RunWorkerCompleted += _bgwMigraODL_RunWorkerCompleted;
            _bgwMigraODL.ProgressChanged += _bgwMigraODL_ProgressChanged;
        }
        private bool VerificaODLRiparazioni(MigrazioneODLDS.USR_PRD_MOVFASIRow odl, MigrazioneODLDS.MAGAZZRow articolo)
        {
            if (articolo != null)
            {
                return articolo.MODELLO.StartsWith("RIP");
            }
            return false;
        }
        private bool VerificaODLPreserie(MigrazioneODLDS.USR_PRD_MOVFASIRow odl, MigrazioneODLDS.MAGAZZRow articolo)
        {
            if (articolo != null)
            {
                return articolo.MODELLO.StartsWith("P-");
            }
            return false;
        }
        private bool VerificaODLCampionario(MigrazioneODLDS.USR_PRD_MOVFASIRow odl, MigrazioneODLDS.MAGAZZRow articolo)
        {
            if (articolo != null)
            {
                return articolo.MODELLO.StartsWith("K-");
            }
            return false;
        }
        private void _bgwMigraODL_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            pbAvanzamento.Value = e.ProgressPercentage;
            lblMetàAvanzamento.Text = e.ProgressPercentage.ToString();

        }
        private void _bgwMigraODL_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                AggiornaMessaggio("Terminato con errore");
            else if (e.Cancelled)
                AggiornaMessaggio("Operazione intterrotta dall utente");
            else
                AggiornaMessaggio("Operazione terminata correttamente");
            pbAvanzamento.Value = pbAvanzamento.Maximum;

            TimeSpan ts = DateTime.Now.Subtract(_start);
            string msd = string.Format("Durata Attività {0}:{1}", ts.Hours, ts.Minutes);
            AggiornaMessaggio(msd);
            btnEseguiMigrazione.Text = etichettaStart;

        }

        private void _bgwMigraODL_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            string numord = txtBarcodeODL.Text;

            ODLDTO dto = (ODLDTO)e.Argument;

            int progress = 1;

            foreach (string nummovfase in dto.odls)
            {
                decimal perc = progress;

                string distintaBC = string.Empty;
                worker.ReportProgress((int)perc);
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                try
                {
                    MigrazioneODLDS ds = new MigrazioneODLDS();

                    if (string.IsNullOrEmpty(nummovfase)) continue;
                    //string anagraficaBC = string.Empty;
                    MigrazioneODLDS.USR_PRD_MOVFASIRow odl = null;
                    MigrazioneODLDS.MAGAZZRow articolo = null;
                    string desvcrizione2odl = string.Empty;
                    string descrizioneVersioneODV = string.Empty;
                    string repartoRagSoc = string.Empty;
                    string faseCodice = string.Empty;


                    using (MigrazioneODLBusiness bMigrazioneODL = new MigrazioneODLBusiness())
                    {

                        bMigrazioneODL.InsertODL2ODPlog(nummovfase, "Migrazione iniziata", dto.esecuzione, dto.company, (int)Errori.Avvio);

                        bMigrazioneODL.GetUSR_PRD_MOVFASIByNumdoc(ds, nummovfase);
                        odl = ds.USR_PRD_MOVFASI.Where(x => x.NUMMOVFASE == nummovfase).FirstOrDefault();

                        if (odl == null)
                        {
                            bMigrazioneODL.InsertODL2ODPlog(nummovfase, "Non migrato : ODL non trovato", dto.esecuzione, dto.company, (int)Errori.NoODL);
                            continue;
                        }

                        bMigrazioneODL.GetCLIFO(ds, odl.CODICECLIFO);
                        MigrazioneODLDS.CLIFORow reparto = ds.CLIFO.Where(x => x.CODICE == odl.CODICECLIFO).FirstOrDefault();
                        repartoRagSoc = reparto.CODICE;

                        if (reparto.CODICE.Trim() == "02350")
                        {
                            bMigrazioneODL.InsertODL2ODPlog(nummovfase, "Non migrato: reparto TOPFINISH", dto.esecuzione, dto.company, (int)Errori.TopFinish, reparto.CODICE.Trim());
                            continue;
                        }

                        if (reparto.CODICE.Substring(0, 1) == "0")
                        {
                            bMigrazioneODL.InsertODL2ODPlog(nummovfase, "Non migrato: reparto terzista", dto.esecuzione, dto.company, (int)Errori.Terzista, reparto.CODICE.Trim());
                            continue;
                        }
                        bMigrazioneODL.GetTask(ds, odl.IDTABFAS);
                        MigrazioneODLDS.BC_TASKRow task = ds.BC_TASK.Where(x => x.IDTABFAS == odl.IDTABFAS).FirstOrDefault();

                        if (task != null && task.TASK == "***ESCLUDERE" && !(task.IDTABFAS == "0000000862" || task.IDTABFAS == "0000000856"))
                        {
                            bMigrazioneODL.InsertODL2ODPlog(nummovfase, "Non migrato: fase eliminata dalla distinta BC", dto.esecuzione, dto.company, (int)Errori.FaseEliminataDallaDistinta, task.CODICEFASE);
                            continue;
                        }

                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }

                        bMigrazioneODL.GetTABFAS(ds, odl.IDTABFAS);
                        MigrazioneODLDS.TABFASRow fase = ds.TABFAS.Where(x => x.IDTABFAS == odl.IDTABFAS).FirstOrDefault();
                        faseCodice = fase.CODICEFASE;

                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }

                        bMigrazioneODL.GetMAGAZZ(ds, odl.IDMAGAZZ);
                        articolo = ds.MAGAZZ.Where(x => x.IDMAGAZZ == odl.IDMAGAZZ).FirstOrDefault();

                        if (VerificaODLRiparazioni(odl, articolo))
                        {
                            bMigrazioneODL.InsertODL2ODPlog(nummovfase, "Non migrato perchè riparazione", dto.esecuzione, dto.company, (int)Errori.Riparazione, articolo.MODELLO);
                            continue;
                        }
                        if (VerificaODLPreserie(odl, articolo))
                        {
                            bMigrazioneODL.InsertODL2ODPlog(nummovfase, "Non migrato perchè preserie", dto.esecuzione, dto.company, (int)Errori.Preserie, articolo.MODELLO);
                            continue;
                        }
                        if (VerificaODLCampionario(odl, articolo))
                        {
                            bMigrazioneODL.InsertODL2ODPlog(nummovfase, "Non migrato perchè campionario", dto.esecuzione, dto.company, (int)Errori.Campionario, articolo.MODELLO);
                            continue;
                        }


                        bool continua = true;
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }
                        MigrazioneODLDS.BC_ANAGRAFICA_PRODUZIONERow anagrafica = bMigrazioneODL.GetANAGRAFICA(ds, odl.IDMAGAZZ);

                        MigrazioneODLDS.USR_PRD_FASIRow prdFase = bMigrazioneODL.GetUSR_PRD_FASI(ds, odl.IsIDPRDFASENull() ? string.Empty : odl.IDPRDFASE, odl.AZIENDA);
                        if (prdFase == null && anagrafica == null)
                        {
                            string str = string.Format("Non migrato: USR PRD FASE non trovata ");
                            bMigrazioneODL.InsertODL2ODPlog(nummovfase, str, dto.esecuzione, dto.company, (int)Errori.MancaUsRPRDFASE, articolo.MODELLO);
                            continue;
                        }
                        bool errore = false;
                        while (anagrafica == null && continua)
                        {
                            if (prdFase.IsIDPRDFASEPADRENull() || string.IsNullOrEmpty(prdFase.IDPRDFASEPADRE))
                            {
                                //                                string str = string.Format("Impossibile trovare una anagrafica di trasferimento idmagazz {0} odl {1}", odl.IDMAGAZZ, odl.IDPRDMOVFASE);
                                string str = "Non migrato: impossibile trovare una anagrafica di trasferimento dell distinta RVL";
                                bMigrazioneODL.InsertODL2ODPlog(nummovfase, str, dto.esecuzione, dto.company, (int)Errori.MancaAnagraficaTrasf, articolo.MODELLO);
                                continua = false;
                                errore = true;
                                continue;
                            }
                            prdFase = bMigrazioneODL.GetUSR_PRD_FASI(ds, prdFase.IDPRDFASEPADRE, prdFase.AZIENDA);
                            if (prdFase != null)
                            {
                                anagrafica = bMigrazioneODL.GetANAGRAFICA(ds, prdFase.IDMAGAZZ);
                            }
                            else
                            {
                                string str = string.Format("Non migrato: fase padre non trovata");
                                bMigrazioneODL.InsertODL2ODPlog(nummovfase, str, dto.esecuzione, dto.company, (int)Errori.MancaFasePadre, articolo.MODELLO);
                                continua = false;
                                errore = true;
                            }
                        }

                        if (errore) continue;

                        if (anagrafica == null)
                        {
                            string str = string.Format("Non migrato :anagrafica non trovata ");
                            bMigrazioneODL.InsertODL2ODPlog(nummovfase, str, dto.esecuzione, dto.company, (int)Errori.MancaAnagrafica, articolo.MODELLO);
                            continue;
                        }

                        distintaBC = anagrafica.BC;

                        descrizioneVersioneODV = string.Format("{0} {1}", odl.NUMMOVFASE, odl.DATAMOVFASE.ToShortDateString());
                        desvcrizione2odl = string.Format("{0} - {1}", reparto.CODICE.Trim(), fase.CODICEFASE.Trim());

                    }

                    if (odl == null) continue;
                    if (articolo == null) continue;

                    string IDPRDMOVFASE = odl.IDPRDMOVFASE;
                    string azienda = odl.AZIENDA;
                    string idmagazz = articolo.IDMAGAZZ.Trim();
                    string modello = articolo.MODELLO.Trim();
                    decimal quantita = odl.QTADATER;
                    //     decimal qtadater = odl.QTADATER;


                    using (MigrazioneODLSQLBusiness bMigrazioneODLSQL = new MigrazioneODLSQLBusiness())
                    {
                        bMigrazioneODLSQL.GetDistinteBCDettaglio(ds, distintaBC);
                    }
                    using (MigrazioneODLBusiness bMigrazioneODL = new MigrazioneODLBusiness())
                    {
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }


                        bMigrazioneODL.GetODL2ODP(ds, nummovfase);
                        bMigrazioneODL.GetODL2ODPCOMPONENTI(ds, nummovfase);

                        List<MigrazioneODLDS.ODL2ODPRow> odls = ds.ODL2ODP.Where(x => x.NUMMOVFASE == nummovfase && x.COMPANY == dto.company).ToList();
                        if (odls.Count > 0)
                        {
                            MigrazioneODLDS.ODL2ODPRow odp = odls[0];
                            string msg = String.Format("Non migrato: ODL già migrato per la company {0}", dto.company);
                            bMigrazioneODL.InsertODL2ODPlog(nummovfase, msg, dto.esecuzione, dto.company, (int)Errori.OrdinePrecMigrato, articolo.MODELLO);
                            continue;
                        }

                        List<MigrazioneODLDS.ODL2ODPCOMPONENTIRow> odlsComp = ds.ODL2ODPCOMPONENTI.Where(x => x.NUMMOVFASE == nummovfase && x.COMPANY == dto.company).ToList();
                        if (odlsComp.Count > 0)
                        {
                            string msg = String.Format("Non migrato: componenti dell'ODL già a sistema per la company {0}", dto.company);
                            bMigrazioneODL.InsertODL2ODPlog(nummovfase, msg, dto.esecuzione, dto.company, (int)Errori.CompGiàMigrati, articolo.MODELLO);
                            continue;
                        }
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }


                        if (dto.soloRVL)
                        {
                            bMigrazioneODL.InsertODL2ODPlog(nummovfase, "Migrazione completata correttamente SOLO RVL", dto.esecuzione, dto.company, (int)Errori.FinitoCorrettamenteRVL, articolo.MODELLO);
                            continue;
                        }
                        MPIntranet.WS.BCServices bc = new MPIntranet.WS.BCServices();
                        bc.CreaConnessione(dto.company);

                        //                        string codiceODP = bc.CreaOdDPConfermato(distintaBC, DateTime.Now, quantita, ubicazione, descrizioneVersioneODV, desvcrizione2odl);

                        int linenumber = 0;
                        if (odl.IDTABFAS == "0000000862" || odl.IDTABFAS == "0000000856")
                        {
                            bc.CreaRegistrazioneMagazzino(ubicazione, "SPED", linenumber, nummovfase, quantita, distintaBC);
                            bMigrazioneODL.InsertODL2ODPComponenti(azienda, nummovfase, repartoRagSoc.Trim(), faseCodice, distintaBC, distintaBC, quantita, quantita, "MAG3", ubicazione, collocazione, dto.company);
                            bMigrazioneODL.InsertODL2ODP(azienda, odl.IDPRDMOVFASE, nummovfase, repartoRagSoc.Trim(), faseCodice, idmagazz, distintaBC, quantita, "MAG3", descrizioneVersioneODV, desvcrizione2odl, dto.company);
                            bMigrazioneODL.InsertODL2ODPlog(nummovfase, "Migrazione completata correttamente (MAG 3)", dto.esecuzione, dto.company, (int)Errori.Spedizioni, articolo.MODELLO);
                            continue;
                        }

                        string codiceODP = string.Empty;
                        MPIntranet.WS.BCServices bcw = new MPIntranet.WS.BCServices();
                        bcw.CreaConnessione(dto.company);
                        try
                        {
                            bcw.MTPWS(distintaBC, quantita, odl.DATAFINE, ubicazione, ref codiceODP, descrizioneVersioneODV, desvcrizione2odl);
                            bMigrazioneODL.InsertODL2ODP(azienda, odl.IDPRDMOVFASE, nummovfase, repartoRagSoc.Trim(), faseCodice, idmagazz, distintaBC, quantita, codiceODP, descrizioneVersioneODV, desvcrizione2odl, dto.company);
                        }
                        catch (Exception ex)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("ECCEZIONE ");
                            while (ex != null)
                            {
                                sb.Append(ex.Message);
                                sb.Append(' ');
                                sb.Append(ex.Source);
                                sb.Append(' ');
                                ex = ex.InnerException;
                                sb.Append("**");
                            }
                            bMigrazioneODL.InsertODL2ODPlog(nummovfase, sb.ToString(), dto.esecuzione, dto.company, (int)Errori.Eccezione, codiceODP);
                        }

                        List<RegMesWS> magazzino = bc.EstraiRegMag();
                        if (magazzino.Count > 0)
                        {
                            magazzino = magazzino.Where(x => x.Journal_Batch_Name == "REGWS").ToList();
                            if (magazzino.Count > 0)
                                linenumber = magazzino.Max(x => x.Line_No);
                        }

                        foreach (MigrazioneODLDS.DistinteBCDettaglioRow dettaglio in ds.DistinteBCDettaglio.Where(x => x.Production_BOM_No_ == distintaBC))
                        {
                            decimal quantitaComponente = quantita * dettaglio.Quantity;
                            linenumber += 1000;
                            bc.CreaRegistrazioneMagazzino(ubicazione, collocazione, linenumber, nummovfase, quantitaComponente, dettaglio.No_);
                            bMigrazioneODL.InsertODL2ODPComponenti(azienda, nummovfase, repartoRagSoc.Trim(), faseCodice, distintaBC, dettaglio.No_, quantitaComponente, quantita, codiceODP, ubicazione, collocazione, dto.company);

                        }
                        if (dto.ChBoxRegMag)
                            bc.PostingRegMag();

                        bMigrazioneODL.InsertODL2ODPlog(nummovfase, "Migrazione completata correttamente", dto.esecuzione, dto.company, (int)Errori.FinitoCorrettamente, articolo.MODELLO);

                    }

                }
                catch (Exception ex)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("ECCEZIONE ");
                    while (ex != null)
                    {
                        sb.AppendLine(ex.Message);
                        sb.AppendLine(ex.Source);
                        ex = ex.InnerException;
                        sb.AppendLine("**");
                    }
                    using (MigrazioneODLBusiness bMigrazioneODL = new MigrazioneODLBusiness())
                    {
                        bMigrazioneODL.InsertODL2ODPlog(nummovfase, sb.ToString(), dto.esecuzione, dto.company, (int)Errori.Eccezione, string.Empty);
                    }
                }
                finally
                {
                    progress++;
                }
            }
        }

        private void btnCercaODL_Click(object sender, EventArgs e)
        {
            _ds = new MigrazioneODLDS();
            string barcode = txtBarcodeODL.Text;
            txtBarcodeODL.Text = string.Empty;

            txtIDPRDMOVFASE.Text = string.Empty;
            txtAZIENDA.Text = string.Empty;
            txtREPARTO.Text = string.Empty;
            txtFASE.Text = string.Empty;
            txtIDMAGAZZ.Text = string.Empty;
            txtArticolo.Text = string.Empty;
            txtQtaDaTer.Text = string.Empty;
            txtQuantita.Text = string.Empty;
            txtDescVersione.Text = string.Empty;
            txtAnagrafica.Text = string.Empty;
            txtNumOdl.Text = string.Empty;
            txtODP.Text = string.Empty;
            txtIDTABFAS.Text = string.Empty;
            txtDescrizioneODV.Text = string.Empty;
            txtDescrizione2ODV.Text = string.Empty;
            txtComponentiODV.Text = string.Empty;

            if (!string.IsNullOrEmpty(barcode))
            {
                MigrazioneODLDS.USR_PRD_MOVFASIRow odl = estraDatiODL(barcode);

                if (trovaAnagraficaPerMigrazione(odl))
                {
                    txtDescrizioneODV.Text = string.Format("{0} {1}", odl.NUMMOVFASE, odl.DATAMOVFASE.ToShortDateString());
                    txtDescrizione2ODV.Text = string.Format("{0} - {1}", txtREPARTO.Text, txtFASE.Text);
                    caricaComponenti();
                }
            }
        }

        private void caricaComponenti()
        {
            txtComponentiODV.Text = string.Empty;
            using (MigrazioneODLSQLBusiness bMigrazione = new MigrazioneODLSQLBusiness())
            {
                bMigrazione.GetDistinteBCDettaglio(_ds, txtAnagrafica.Text);
                StringBuilder sb = new StringBuilder();

                foreach (MigrazioneODLDS.DistinteBCDettaglioRow dettaglio in _ds.DistinteBCDettaglio.Where(x => x.Production_BOM_No_ == txtAnagrafica.Text))
                {
                    sb.AppendLine(string.Format("{0} - qta: {1}", dettaglio.No_, dettaglio.Quantity_per));
                }
                txtComponentiODV.Text = sb.ToString();
            }
        }

        private MigrazioneODLDS.USR_PRD_MOVFASIRow estraDatiODL(string barcode)
        {
            using (MigrazioneODLBusiness bMigrazioneODL = new MigrazioneODLBusiness())
            {
                bMigrazioneODL.GetUSR_PRD_MOVFASI(_ds, barcode);


                MigrazioneODLDS.USR_PRD_MOVFASIRow odl = _ds.USR_PRD_MOVFASI.Where(x => x.BARCODE == barcode).FirstOrDefault();
                if (odl != null)
                {

                    bMigrazioneODL.GetCLIFO(_ds, odl.CODICECLIFO);
                    MigrazioneODLDS.CLIFORow reparto = _ds.CLIFO.Where(x => x.CODICE == odl.CODICECLIFO).FirstOrDefault();

                    bMigrazioneODL.GetTABFAS(_ds, odl.IDTABFAS);
                    MigrazioneODLDS.TABFASRow fase = _ds.TABFAS.Where(x => x.IDTABFAS == odl.IDTABFAS).FirstOrDefault();

                    bMigrazioneODL.GetMAGAZZ(_ds, odl.IDMAGAZZ);
                    MigrazioneODLDS.MAGAZZRow articolo = _ds.MAGAZZ.Where(x => x.IDMAGAZZ == odl.IDMAGAZZ).FirstOrDefault();

                    txtIDPRDMOVFASE.Text = odl.IDPRDMOVFASE;
                    txtAZIENDA.Text = odl.AZIENDA;
                    txtREPARTO.Text = reparto.RAGIONESOC.Trim();
                    txtFASE.Text = fase.CODICEFASE.Trim();
                    txtIDMAGAZZ.Text = articolo.IDMAGAZZ.Trim();
                    txtArticolo.Text = articolo.MODELLO.Trim();
                    txtQuantita.Text = odl.QTA.ToString();
                    txtQtaDaTer.Text = odl.QTADATER.ToString();
                    txtMetodoDiba.Text = odl.IDDIBAMETHOD;
                    txtVersioneDiba.Text = odl.VERSION.ToString();
                    txtDescVersione.Text = odl.DESVERSION.Trim();
                    txtDescVersione.Text = odl.NUMMOVFASE;
                    txtNumOdl.Text = odl.NUMMOVFASE;

                }
                return odl;
            }
        }

        private MigrazioneODLDS.TRASFERIMENTIRVLRow estraDatiTrasferimento(string barcode)
        {
            using (MigrazioneODLBusiness bMigrazioneODL = new MigrazioneODLBusiness())
            {
                bMigrazioneODL.GetTrasferimenti(_ds, barcode);


                MigrazioneODLDS.TRASFERIMENTIRVLRow trasferimento = _ds.TRASFERIMENTIRVL.Where(x => x.BARCODE == barcode).FirstOrDefault();
                if (trasferimento != null)
                {

                    txtIdmagazzTR.Text = trasferimento.IDMAGAZZ;
                    txtArticoloTR.Text = trasferimento.MODELLO;
                    txtQuantitaTR.Text = trasferimento.QTA.ToString();
                    txtTrasferimento.Text = barcode;
                    tcxtAnagraficaBCTR.Text = (trasferimento.IsBCNull()) ? String.Empty : trasferimento.BC;

                }
                return trasferimento;
            }

        }
        private MigrazioneODLDS.USR_PRD_MOVFASIRow estraiDatiODLAuto(string ordine)
        {
            using (MigrazioneODLBusiness bMigrazioneODLAuto = new MigrazioneODLBusiness())
            {
                bMigrazioneODLAuto.GetUSR_PRD_MOVFASI(_ds, ordine);


                MigrazioneODLDS.USR_PRD_MOVFASIRow odls = _ds.USR_PRD_MOVFASI.Where(x => x.BARCODE == ordine).FirstOrDefault();
                if (odls != null)
                {

                    bMigrazioneODLAuto.GetCLIFO(_ds, odls.CODICECLIFO);
                    MigrazioneODLDS.CLIFORow reparto = _ds.CLIFO.Where(x => x.CODICE == odls.CODICECLIFO).FirstOrDefault();

                    bMigrazioneODLAuto.GetTABFAS(_ds, odls.IDTABFAS);
                    MigrazioneODLDS.TABFASRow fase = _ds.TABFAS.Where(x => x.IDTABFAS == odls.IDTABFAS).FirstOrDefault();

                    bMigrazioneODLAuto.GetMAGAZZ(_ds, odls.IDMAGAZZ);
                    MigrazioneODLDS.MAGAZZRow articolo = _ds.MAGAZZ.Where(x => x.IDMAGAZZ == odls.IDMAGAZZ).FirstOrDefault();

                    txtIDPRDMOVFASE.Text = odls.IDPRDMOVFASE;
                    txtAZIENDA.Text = odls.AZIENDA;
                    txtREPARTO.Text = reparto.RAGIONESOC.Trim();
                    txtFASE.Text = fase.CODICEFASE.Trim();
                    txtIDMAGAZZ.Text = articolo.IDMAGAZZ.Trim();
                    txtArticolo.Text = articolo.MODELLO.Trim();
                    txtQuantita.Text = odls.QTA.ToString();
                    txtQtaDaTer.Text = odls.QTADATER.ToString();
                    txtMetodoDiba.Text = odls.IDDIBAMETHOD;
                    txtVersioneDiba.Text = odls.VERSION.ToString();
                    txtDescVersione.Text = odls.DESVERSION.Trim();
                    txtDescVersione.Text = odls.NUMMOVFASE;
                    txtNumOdl.Text = odls.NUMMOVFASE;
                }
                return odls;
            }
        }

        private bool trovaAnagraficaPerMigrazione(MigrazioneODLDS.USR_PRD_MOVFASIRow odl)
        {
            txtAnagrafica.Text = string.Empty;
            if (odl.IsIDMAGAZZNull())
                return false;


            string idmagazz = odl.IDMAGAZZ;

            using (MigrazioneODLBusiness bMigrazioneODL = new MigrazioneODLBusiness())
            {




                bMigrazioneODL.GetCLIFO(_ds, odl.CODICECLIFO);
                MigrazioneODLDS.CLIFORow reparto = _ds.CLIFO.Where(x => x.CODICE == odl.CODICECLIFO).FirstOrDefault();

                if (reparto.CODICE.Trim() == "02350")
                {
                    txtMessaggi.Text = "Non migrato: reparto TOPFINISH";
                    return false;
                }

                if (reparto.CODICE.Substring(0, 1) == "0")
                {
                    txtMessaggi.Text = "Non migrato: reparto terzista";
                    return false;
                }
                bMigrazioneODL.GetTask(_ds, odl.IDTABFAS);
                MigrazioneODLDS.BC_TASKRow task = _ds.BC_TASK.Where(x => x.IDTABFAS == odl.IDTABFAS).FirstOrDefault();

                txtIDTABFAS.Text = task.IDTABFAS;
                if (task != null && task.TASK == "***ESCLUDERE" && !(task.IDTABFAS == "0000000862" || task.IDTABFAS == "0000000856"))
                {
                    txtMessaggi.Text = "Non migrato: fase eliminata dalla distinta BC";
                    return false;
                }

                bMigrazioneODL.GetMAGAZZ(_ds, odl.IDMAGAZZ);
                MigrazioneODLDS.MAGAZZRow articolo = _ds.MAGAZZ.Where(x => x.IDMAGAZZ == odl.IDMAGAZZ).FirstOrDefault();

                if (VerificaODLRiparazioni(odl, articolo))
                {
                    txtMessaggi.Text = "Non migrato perchè riparazione";
                    return false;
                }
                if (VerificaODLPreserie(odl, articolo))
                {
                    txtMessaggi.Text = "Non migrato perchè preserie";
                    return false;
                }
                if (VerificaODLCampionario(odl, articolo))
                {
                    txtMessaggi.Text = "Non migrato perchè campionario";
                    return false;
                }

                bool continua = true;
                MigrazioneODLDS.BC_ANAGRAFICA_PRODUZIONERow anagrafica = bMigrazioneODL.GetANAGRAFICA(_ds, idmagazz);

                if (anagrafica != null)
                {
                    txtAnagrafica.Text = (anagrafica == null) ? string.Empty : anagrafica.BC;
                    return true;
                }

                MigrazioneODLDS.USR_PRD_FASIRow prdFase = bMigrazioneODL.GetUSR_PRD_FASI(_ds, odl.IsIDPRDFASENull() ? string.Empty : odl.IDPRDFASE, odl.AZIENDA);
                if (prdFase == null && anagrafica == null)
                {
                    txtMessaggi.Text = "Non migrato perchè USR PRD FASE non trovata";
                    return false;
                }

                bMigrazioneODL.FillBC_MIGRAZIONE(_ds);
                MigrazioneODLDS.BC_MIGRAZIONERow riga = _ds.BC_MIGRAZIONE.Where(x => x.IDMAGAZZ == idmagazz).FirstOrDefault();
                if (riga == null) return false;
                decimal iddiba = riga.DIBA;
                decimal idnodo = riga.IDNODO;

                while (anagrafica == null && continua)
                {
                    if (prdFase.IsIDPRDFASEPADRENull() || string.IsNullOrEmpty(prdFase.IDPRDFASEPADRE))
                    {
                        //                                string str = string.Format("Impossibile trovare una anagrafica di trasferimento idmagazz {0} odl {1}", odl.IDMAGAZZ, odl.IDPRDMOVFASE);
                        txtMessaggi.Text = "Non migrato: impossibile trovare una anagrafica di trasferimento dell distinta RVL";
                        return false;
                    }
                    prdFase = bMigrazioneODL.GetUSR_PRD_FASI(_ds, prdFase.IDPRDFASEPADRE, prdFase.AZIENDA);
                    if (prdFase != null)
                    {
                        anagrafica = bMigrazioneODL.GetANAGRAFICA(_ds, prdFase.IDMAGAZZ);
                    }
                    else
                    {
                        txtMessaggi.Text = string.Format("Non migrato: fase padre non trovata");
                        return false;
                    }
                }



                if (anagrafica == null)
                {
                    txtMessaggi.Text = string.Format("Non migrato :anagrafica non trovata ");
                    return false;
                }


                txtPRODOTTOFINITO.Text = riga.PRODOTTOFINALE;
                txtAnagrafica.Text = (anagrafica == null) ? string.Empty : anagrafica.BC;

                return anagrafica != null;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            txtBarcodeODL.Focus();
            ActiveControl = txtBarcodeODL;
            lblCompany.Text = ConfigurationManager.AppSettings["Azienda"];
            lblMetàAvanzamento.Text = string.Empty;
            lblFineAvanzamento.Text = string.Empty;
            btnEseguiMigrazione.Text = etichettaStart;

            inizializzaBackgroundWorker();
        }

        private void btnSCaricaNodi_Click(object sender, EventArgs e)
        {
            txtMessaggi.Text = string.Empty;
            StringBuilder sb = new StringBuilder();
            _ds = new MigrazioneODLDS();
            using (MigrazioneODLBusiness bMigrazioneODL = new MigrazioneODLBusiness())
            {
                bMigrazioneODL.FillBC_MIGRAZIONE(_ds);
                foreach (MigrazioneODLDS.BC_MIGRAZIONERow r in _ds.BC_MIGRAZIONE)
                    r.Delete();

                bMigrazioneODL.UpdateTable(_ds.BC_MIGRAZIONE.TableName, _ds);
                _ds.AcceptChanges();
                bMigrazioneODL.GetPRODOTTIFINITI(_ds);
            }
            int idDiba = 0;
            EstraiProdottoFinito form = new EstraiProdottoFinito();
            foreach (MigrazioneODLDS.BC_ANAGRAFICA_PRODUZIONERow prodottoFinito in _ds.BC_ANAGRAFICA_PRODUZIONE)
            {
                try
                {
                    _ds.BC_MIGRAZIONE.Clear();
                    List<Nodo> Nodi = form.CreaListaNodi(prodottoFinito.MODELLO, false);
                    if (Nodi == null)
                    {
                        sb.AppendLine(string.Format("Articolo {0} distinta non trovata", prodottoFinito.MODELLO));
                    }
                    else
                    {

                        idDiba++;
                        Nodi.ForEach(x => caricaNodo(x, idDiba, prodottoFinito.MODELLO));

                        using (MigrazioneODLBusiness bMigrazioneODL = new MigrazioneODLBusiness())
                        {
                            bMigrazioneODL.UpdateTable(_ds.BC_MIGRAZIONE.TableName, _ds);
                        }
                    }
                }
                catch (Exception ex)
                {
                    sb.AppendLine(string.Format("Articolo {0} ECCEZIONE in CREA LISTA", prodottoFinito));
                    sb.AppendLine(ex.Message);
                }
            }
            form.Close();
            form.Dispose();
            form = null;
            txtMessaggi.Text = sb.ToString();
        }
        private void caricaNodo(Nodo nodo, int iddiba, string prodottoFinale)
        {
            MigrazioneODLDS.BC_MIGRAZIONERow bcMigrazione = _ds.BC_MIGRAZIONE.NewBC_MIGRAZIONERow();
            bcMigrazione.BC = nodo.Anagrafica;
            bcMigrazione.IDMAGAZZ = nodo.IDMAGAZZ;
            bcMigrazione.IDNODO = nodo.ID;
            bcMigrazione.PROFONDITA = nodo.Profondita;
            bcMigrazione.MODELLO = nodo.Modello;
            bcMigrazione.QUANTITA = nodo.Quantita;
            bcMigrazione.IDPADRE = nodo.IDPADRE;
            bcMigrazione.REPARTO = nodo.Reparto;
            bcMigrazione.FASE = nodo.Fase;
            bcMigrazione.DIBA = iddiba;
            bcMigrazione.PRODOTTOFINALE = prodottoFinale;
            _ds.BC_MIGRAZIONE.AddBC_MIGRAZIONERow(bcMigrazione);
        }

        private void btnMigraOrdineProduzione_Click(object sender, EventArgs e)
        {
            try
            {
                MigrazioneODLDS ds = new MigrazioneODLDS();
                Cursor.Current = Cursors.WaitCursor;
                txtBarcodeODL.Focus();
                txtMessaggi.Text = string.Empty;
                txtODP.Text = string.Empty;

                if (string.IsNullOrEmpty(txtNumOdl.Text))
                {
                    txtMessaggi.Text = "Prima selezionare in ODL";
                    return;
                }

                if (string.IsNullOrEmpty(txtAnagrafica.Text))
                {
                    txtMessaggi.Text = "Impossibile inserire un'anagrafica vuota";
                    return;
                }

                if (string.IsNullOrEmpty(txtQtaDaTer.Text))
                {
                    txtMessaggi.Text = "Quantità da terminare indefinita";
                    return;
                }

                string company = ConfigurationManager.AppSettings["Azienda"];

                decimal quantita = 0;
                if (!decimal.TryParse(txtQtaDaTer.Text, out quantita))
                {
                    txtMessaggi.Text = "Impossibile convertire quantità da terminare";
                    return;
                }

                MPIntranet.WS.BCServices bc = new MPIntranet.WS.BCServices();
                bc.CreaConnessione(company);
                using (MigrazioneODLBusiness bMigrazioneODL = new MigrazioneODLBusiness())
                {
                    bMigrazioneODL.GetODL2ODP(ds, txtNumOdl.Text);
                    bMigrazioneODL.GetODL2ODPCOMPONENTI(ds, txtNumOdl.Text);

                    List<MigrazioneODLDS.ODL2ODPRow> odls = ds.ODL2ODP.Where(x => x.NUMMOVFASE == txtNumOdl.Text && x.COMPANY == company).ToList();
                    if (odls.Count > 0)
                    {
                        MigrazioneODLDS.ODL2ODPRow odp = odls[0];
                        String ODV = odp.IsODVNull() ? String.Empty : odp.ODV;
                        txtMessaggi.Text = String.Format("ODL già migrato nell'ordine di produzione {0} per la company {1}", ODV, company);
                        return;
                    }

                    List<MigrazioneODLDS.ODL2ODPCOMPONENTIRow> odlsComp = ds.ODL2ODPCOMPONENTI.Where(x => x.NUMMOVFASE == txtNumOdl.Text && x.COMPANY == company).ToList();
                    if (odlsComp.Count > 0)
                    {
                        txtMessaggi.Text = String.Format("Componenti dell'ODL {0} già a sistema per la company {1}", txtNumOdl.Text, company);
                        return;
                    }

                    int linenumber = 0;
                    if (txtIDTABFAS.Text == "0000000862" || txtIDTABFAS.Text == "0000000856")
                    {
                        bc.CreaRegistrazioneMagazzino(ubicazione, "SPED", linenumber, txtNumOdl.Text, quantita, txtAnagrafica.Text);
                        bMigrazioneODL.InsertODL2ODPComponenti(txtAZIENDA.Text, txtNumOdl.Text, "", txtFASE.Text, txtAnagrafica.Text, txtAnagrafica.Text, quantita, quantita, "MAG3", ubicazione, collocazione, company);
                        bMigrazioneODL.InsertODL2ODP(txtAZIENDA.Text, txtIDPRDMOVFASE.Text, txtNumOdl.Text, "", txtFASE.Text, txtIDMAGAZZ.Text, txtAnagrafica.Text, quantita, "MAG3", txtDescrizioneODV.Text, txtDescrizione2ODV.Text, company);
                        bMigrazioneODL.InsertODL2ODPlog(txtNumOdl.Text, "Migrazione completata correttamente (MAG 3)", "", company, (int)Errori.Spedizioni, "");
                        txtMessaggi.Text = "Migrazione completata MAG 3";
                        return;
                    }

                    string codiceODP = string.Empty;
                    MPIntranet.WS.BCServices bcw = new MPIntranet.WS.BCServices();
                    bcw.CreaConnessione(company);
                    try
                    {
                        bcw.MTPWS(txtAnagrafica.Text, quantita, DateTime.Now.AddDays(2), ubicazione, ref codiceODP, txtDescrizioneODV.Text, txtDescrizione2ODV.Text);
                        bMigrazioneODL.InsertODL2ODP(company, txtIDPRDMOVFASE.Text, txtNumOdl.Text, string.Empty, txtFASE.Text, txtIDMAGAZZ.Text, txtAnagrafica.Text, quantita, codiceODP, txtDescrizioneODV.Text, txtDescrizione2ODV.Text, company);
                    }
                    catch (Exception ex)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("ECCEZIONE ");
                        while (ex != null)
                        {
                            sb.Append(ex.Message);
                            sb.Append(' ');
                            sb.Append(ex.Source);
                            sb.Append(' ');
                            ex = ex.InnerException;
                            sb.Append("**");
                        }
                        bMigrazioneODL.InsertODL2ODPlog(txtNumOdl.Text, sb.ToString(), "", company, (int)Errori.Eccezione, codiceODP);
                        txtMessaggi.Text += sb.ToString();
                    }

                    //string codiceODP = bc.CreaOdDPConfermato(txtAnagrafica.Text, DateTime.Now, quantita, ubicazione, txtDescrizioneODV.Text, txtDescrizione2ODV.Text);
                    bMigrazioneODL.InsertODL2ODP(txtAZIENDA.Text, txtIDPRDMOVFASE.Text, txtNumOdl.Text, string.Empty, txtFASE.Text, txtIDMAGAZZ.Text, txtAnagrafica.Text, quantita, codiceODP, txtDescrizioneODV.Text, txtDescrizione2ODV.Text, company);

                    txtODP.Text = codiceODP;

                    List<RegMesWS> magazzino = bc.EstraiRegMag();
                    if (magazzino.Count > 0)
                        linenumber = magazzino.Where(x => x.Journal_Batch_Name == "REGWS").Max(x => x.Line_No);

                    foreach (MigrazioneODLDS.DistinteBCDettaglioRow dettaglio in _ds.DistinteBCDettaglio.Where(x => x.Production_BOM_No_ == txtAnagrafica.Text))
                    {
                        decimal quantitaComponente = quantita * dettaglio.Quantity;
                        linenumber += 1000;
                        bc.CreaRegistrazioneMagazzino(ubicazione, collocazione, linenumber, txtNumOdl.Text, quantitaComponente, dettaglio.No_);
                        bMigrazioneODL.InsertODL2ODPComponenti(txtAZIENDA.Text, txtNumOdl.Text, "", txtFASE.Text, txtAnagrafica.Text, dettaglio.No_, quantitaComponente, quantita, codiceODP, ubicazione, collocazione, company);

                        txtMessaggi.Text = "Ordine Migrato Correttamente";
                    }
                    if (ChBoxRegMag.Checked)
                        bc.PostingRegMag();

                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("ERRORE IRREVERSIBILE");
                while (ex != null)
                {
                    sb.AppendLine(ex.Message);
                    ex = ex.InnerException;
                }
                txtMessaggi.Text = sb.ToString();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }


        }

        private void txtNumOdl_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIDPRDMOVFASE_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtComponentiODV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescrizioneODV_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtAnagrafica_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text Files (*.txt)|*.txt";
            openFile.AddExtension = true;
            openFile.Multiselect = false;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtRicercaFile.Text = openFile.FileName;
            }

        }

        private void btnEseguiMigrazione_Click(object sender, EventArgs e)
        {
            try
            {
                txtMessaggi.Text = string.Empty;

                if (btnEseguiMigrazione.Text == etichettaStart)
                {
                    if (string.IsNullOrEmpty(txtRicercaFile.Text))
                    {
                        txtMessaggi.Text = "Seleziona un file";
                        return;
                    }

                    if (!File.Exists(txtRicercaFile.Text))
                    {
                        txtMessaggi.Text = string.Format("Il file {0} non è stato trovato", txtRicercaFile.Text);
                        return;
                    }

                    List<string> odls = new List<string>();


                    using (FileStream fs = new FileStream(txtRicercaFile.Text, FileMode.Open, FileAccess.Read))
                    {
                        StreamReader sr = new StreamReader(fs);
                        while (!sr.EndOfStream)
                        {
                            string odl = sr.ReadLine();
                            odls.Add(odl);
                        }
                        sr.Close();
                    }

                    if (odls.Count == 0)
                    {
                        txtMessaggi.Text = string.Format("Il file {0} è vuoto", txtRicercaFile.Text);
                        return;
                    }

                    AggiornaMessaggio(string.Format(" ***********  File in elaborazione {0}", txtRicercaFile.Text));

                    AggiornaMessaggio(string.Format("Trovate {0} righe", odls.Count));

                    if (!_bgwMigraODL.IsBusy)
                    {
                        pbAvanzamento.Maximum = odls.Count + 1;
                        lblFineAvanzamento.Text = pbAvanzamento.Maximum.ToString();
                        ODLDTO dto = new ODLDTO();
                        dto.odls = odls;
                        dto.esecuzione = DateTime.Now.ToString("yyyyMMdd-HHmmss");
                        dto.company = lblCompany.Text;
                        dto.collocazione = collocazione;
                        dto.ubicazione = ubicazione;
                        dto.ChBoxRegMag = ChBoxRegMag.Checked;
                        dto.soloRVL = chkSoloRVL.Checked;


                        _bgwMigraODL.RunWorkerAsync(dto);
                        _start = DateTime.Now;
                        btnEseguiMigrazione.Text = etichettaStop;
                    }
                }
                else if (_bgwMigraODL.WorkerSupportsCancellation == true && _bgwMigraODL.IsBusy)
                {
                    _bgwMigraODL.CancelAsync();
                    btnEseguiMigrazione.Text = etichettaStart;
                }
            }
            catch (Exception ex)
            {
                txtMessaggi.Text = ex.Message;
            }
        }

        private void AggiornaMessaggio(string messaggio)
        {
            string str = string.Format("{0} - {1}", DateTime.Now.ToShortTimeString(), messaggio);
            txtMessaggi.Text = str + Environment.NewLine + txtMessaggi.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtIDPRDMOVFASE.Text = string.Empty;
            txtAZIENDA.Text = string.Empty;
            txtREPARTO.Text = string.Empty;
            txtFASE.Text = string.Empty;
            txtIDMAGAZZ.Text = string.Empty;
            txtArticolo.Text = string.Empty;
            txtQtaDaTer.Text = string.Empty;
            txtQuantita.Text = string.Empty;
            txtDescVersione.Text = string.Empty;
            txtAnagrafica.Text = string.Empty;
            txtNumOdl.Text = string.Empty;
            txtODP.Text = string.Empty;
            txtIDTABFAS.Text = string.Empty;
            txtDescrizioneODV.Text = string.Empty;
            txtDescrizione2ODV.Text = string.Empty;
            txtComponentiODV.Text = string.Empty;
            txtBarcodeODL.Focus();
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void btnCercaTrasferimenti_Click(object sender, EventArgs e)
        {
            _ds = new MigrazioneODLDS();
            string barcode = txtBarcodeTrasferimento.Text;
            txtBarcodeTrasferimento.Text = string.Empty;

            txtBarcodeTrasferimento.Text = string.Empty;
            txtIdmagazzTR.Text = string.Empty;
            txtArticoloTR.Text = string.Empty;
            txtQuantitaTR.Text = string.Empty;
            txtTrasferimento.Text = string.Empty;
            tcxtAnagraficaBCTR.Text = string.Empty;

            if (!string.IsNullOrEmpty(barcode))
            {
                MigrazioneODLDS.TRASFERIMENTIRVLRow trasferimento = estraDatiTrasferimento(barcode);
            }
        }

        private void btnCaricaTrasferimento_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tcxtAnagraficaBCTR.Text))
            {
                txtMessaggi.Text = "Impossibile procedere senza un'anagrafica BC!!";
                return;
            }

            try
            {
                string company = ConfigurationManager.AppSettings["Azienda"];

                decimal quantita = 0;
                if (!decimal.TryParse(txtQuantitaTR.Text, out quantita))
                {
                    txtMessaggi.Text = "Impossibile convertire quantità da terminare";
                    return;
                }


                MPIntranet.WS.BCServices bc = new MPIntranet.WS.BCServices();
                bc.CreaConnessione();
                bc.CreaRegistrazioneMagazzino(ubicazione, "ACC", 10, txtTrasferimento.Text, quantita, tcxtAnagraficaBCTR.Text);

                if (chkConsolidaTrasferimento.Checked)
                    bc.PostingRegMag();
                txtMessaggi.Text = "Operazione completata con successo";
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("ERRORE IRREVERSIBILE");
                while (ex != null)
                {
                    sb.AppendLine(ex.Message);
                    ex = ex.InnerException;
                }
                txtMessaggi.Text = sb.ToString();
            }
        }

        private void btnPulisciTrasferimenti_Click(object sender, EventArgs e)
        {
            txtBarcodeTrasferimento.Text = string.Empty;
            txtIdmagazzTR.Text = string.Empty;
            txtArticoloTR.Text = string.Empty;
            txtQuantitaTR.Text = string.Empty;
            txtTrasferimento.Text = string.Empty;
            txtBarcodeTrasferimento.Focus();
        }
    }

    public class ODLDTO
    {
        public List<string> odls { get; set; }
        public string esecuzione { get; set; }
        public string company { get; set; }

        public string ubicazione { get; set; }
        public string collocazione { get; set; }
        public bool ChBoxRegMag { get; set; }

        public bool soloRVL { get; set; }
    }

    public enum Errori
    {
        Avvio, EsitoOK, TopFinish, Riparazione, Preserie, Campionario, NoODL, Terzista, MancaUsRPRDFASE,
        MancaAnagraficaTrasf, MancaFasePadre, MancaAnagrafica, OrdinePrecMigrato, CompGiàMigrati, FinitoCorrettamenteRVL,
        FinitoCorrettamente, FaseEliminataDallaDistinta, Eccezione, Spedizioni
    }

}

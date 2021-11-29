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
        string collocazione = "IMPORTAZIONE";

        public Form1()
        {
            InitializeComponent();
        }

        private void inizializzaBackgroundWorker()
        {
            _bgwMigraODL.WorkerReportsProgress = true;
            _bgwMigraODL.WorkerSupportsCancellation = true;

            _bgwMigraODL.DoWork += _bgwMigraODL_DoWork;
            _bgwMigraODL.RunWorkerCompleted += _bgwMigraODL_RunWorkerCompleted;
            _bgwMigraODL.ProgressChanged += _bgwMigraODL_ProgressChanged;
        }

        private void _bgwMigraODL_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            pbAvanzamento.Value = e.ProgressPercentage;

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
        }

        private void _bgwMigraODL_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            string numord = txtBarcodeODL.Text;

            ODLDTO dto = (ODLDTO)e.Argument;



            int progress = 1;

            foreach (string nummovfase in dto.odls)
            {
                decimal perc = (progress * 100) / dto.odls.Count;

                worker.ReportProgress((int)perc);
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                try
                {
                    MigrazioneODLDS ds = new MigrazioneODLDS();

                    if (!string.IsNullOrEmpty(nummovfase)) continue;

                    using (MigrazioneODLBusiness bMigrazioneODL = new MigrazioneODLBusiness())
                    {

                        bMigrazioneODL.InsertODL2ODPlog(nummovfase, "Migrazione iniziata", dto.esecuzione, dto.company);

                        bMigrazioneODL.GetUSR_PRD_MOVFASIByNumdoc(_ds, nummovfase);
                        MigrazioneODLDS.USR_PRD_MOVFASIRow odl = _ds.USR_PRD_MOVFASI.Where(x => x.NUMMOVFASE == nummovfase).FirstOrDefault();

                        if (odl == null)
                        {
                            bMigrazioneODL.InsertODL2ODPlog(nummovfase, "ODL NON TROVATO", dto.esecuzione, dto.company);
                            continue;
                        }

                        bMigrazioneODL.GetCLIFO(_ds, odl.CODICECLIFO);
                        MigrazioneODLDS.CLIFORow reparto = _ds.CLIFO.Where(x => x.CODICE == odl.CODICECLIFO).FirstOrDefault();
                        worker.ReportProgress(0, "Carica clienti");
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }

                        bMigrazioneODL.GetTABFAS(_ds, odl.IDTABFAS);
                        MigrazioneODLDS.TABFASRow fase = _ds.TABFAS.Where(x => x.IDTABFAS == odl.IDTABFAS).FirstOrDefault();
                        worker.ReportProgress(0, "Carica fasi");
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }

                        bMigrazioneODL.GetMAGAZZ(_ds, odl.IDMAGAZZ);
                        MigrazioneODLDS.MAGAZZRow articolo = _ds.MAGAZZ.Where(x => x.IDMAGAZZ == odl.IDMAGAZZ).FirstOrDefault();


                        string IDPRDMOVFASE = odl.IDPRDMOVFASE;
                        string azienda = odl.AZIENDA;
                        string idmagazz = articolo.IDMAGAZZ.Trim();
                        string modello = articolo.MODELLO.Trim();
                        decimal quantita = odl.QTA;
                        decimal qtadater = odl.QTADATER;
                        string metododiba = odl.IDDIBAMETHOD;
                        string version = odl.VERSION.ToString();
                        string descrizioneVersione = odl.DESVERSION.Trim();

                        bool continua = true;
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }
                        MigrazioneODLDS.BC_ANAGRAFICA_PRODUZIONERow anagrafica = bMigrazioneODL.GetANAGRAFICA(_ds, idmagazz);

                        bMigrazioneODL.FillBC_MIGRAZIONE(_ds);
                        MigrazioneODLDS.BC_MIGRAZIONERow riga = _ds.BC_MIGRAZIONE.Where(x => x.IDMAGAZZ == idmagazz).FirstOrDefault();
                        if (riga == null)
                        {
                            bMigrazioneODL.InsertODL2ODPlog(nummovfase, "DISTINTA NON TROVATA IN BC_MIGRAZIONE", dto.esecuzione, dto.company);
                            continue;
                        }
                        decimal iddiba = riga.DIBA;
                        decimal idnodo = riga.IDNODO;
                        while (anagrafica == null && continua)
                        {
                            riga = ds.BC_MIGRAZIONE.Where(x => x.IDNODO == idnodo && x.DIBA == iddiba).FirstOrDefault();
                            if (riga == null)
                            {
                                continua = false;
                            }
                            else
                            {
                                if (riga.IDPADRE < 0)
                                {
                                    continua = false;
                                }
                                else
                                {
                                    MigrazioneODLDS.BC_MIGRAZIONERow rigaPadre = _ds.BC_MIGRAZIONE.Where(x => x.IDNODO == riga.IDPADRE && x.DIBA == iddiba).FirstOrDefault();
                                    idmagazz = rigaPadre.IDMAGAZZ;
                                    idnodo = rigaPadre.IDNODO;
                                    anagrafica = bMigrazioneODL.GetANAGRAFICA(_ds, idmagazz);
                                }
                            }
                        }

                        if (!continua)
                        {
                            string str = string.Format("Anagrafica non trovata per la distinta {0} e nodo {1}", iddiba, idnodo);
                            bMigrazioneODL.InsertODL2ODPlog(nummovfase, str, dto.esecuzione, dto.company);
                            continue;
                        }

                        string prodottofinale = riga.PRODOTTOFINALE;

                        string descrizioneVersioneODV = string.Format("{0} {1}", odl.NUMMOVFASE, odl.DATAMOVFASE.ToShortDateString());
                        string desvcrizione2odl = string.Format("{0} - {1}", txtREPARTO.Text, txtFASE.Text);
                        bMigrazioneODL.GetDistinteBCDettaglio(_ds, anagrafica.BC);

                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }

                        MPIntranet.WS.BCServices bc = new MPIntranet.WS.BCServices();
                        bc.CreaConnessione(dto.company);

                        bMigrazioneODL.GetODL2ODP(ds, nummovfase);
                        bMigrazioneODL.GetODL2ODPCOMPONENTI(ds, nummovfase);

                        List<MigrazioneODLDS.ODL2ODPRow> odls = ds.ODL2ODP.Where(x => x.NUMMOVFASE == nummovfase && x.COMPANY == dto.company).ToList();
                        if (odls.Count > 0)
                        {
                            MigrazioneODLDS.ODL2ODPRow odp = odls[0];
                            string msg = String.Format("ODL già migrato nell'ordine di produzione {0} per la company {1}", odp.ODV, dto.company);
                            bMigrazioneODL.InsertODL2ODPlog(nummovfase, msg, dto.esecuzione, dto.company);
                            continue;
                        }

                        List<MigrazioneODLDS.ODL2ODPCOMPONENTIRow> odlsComp = ds.ODL2ODPCOMPONENTI.Where(x => x.NUMMOVFASE == nummovfase && x.COMPANY == dto.company).ToList();
                        if (odlsComp.Count > 0)
                        {
                            string msg = String.Format("Componenti dell'ODL {0} già a sistema per la company {1}", txtNumOdl.Text, dto.company);
                            bMigrazioneODL.InsertODL2ODPlog(nummovfase, msg, dto.esecuzione, dto.company);
                            continue;
                        }
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }
                        string codiceODP = bc.CreaOdDPConfermato(anagrafica.BC, DateTime.Now, quantita, ubicazione, descrizioneVersioneODV, desvcrizione2odl);
                        bMigrazioneODL.InsertODL2ODP(azienda, odl.IDPRDMOVFASE, nummovfase, reparto.RAGIONESOC.Trim(), fase.CODICEFASE, idmagazz, anagrafica.BC, quantita, codiceODP, descrizioneVersioneODV, desvcrizione2odl, dto.company);

                        int linenumber = 0;
                        List<RegMesWS> magazzino = bc.EstraiRegMag();
                        if (magazzino.Count > 0)
                            linenumber = magazzino.Where(x => x.Journal_Batch_Name == "REGWS").Max(x => x.Line_No);

                        foreach (MigrazioneODLDS.DistinteBCDettaglioRow dettaglio in _ds.DistinteBCDettaglio.Where(x => x.Production_BOM_No_ == anagrafica.BC))
                        {
                            decimal quantitaComponente = quantita * dettaglio.Quantity;
                            linenumber += 1000;
                            bc.CreaRegistrazioneMagazzino(ubicazione, collocazione, linenumber, nummovfase, quantitaComponente, dettaglio.No_);
                            bMigrazioneODL.InsertODL2ODPComponenti(azienda, nummovfase, reparto.RAGIONESOC.Trim(), fase.CODICEFASE, anagrafica.BC, dettaglio.No_, quantitaComponente, quantita, codiceODP, ubicazione, collocazione, dto.company);

                        }
                        if (dto.ChBoxRegMag)
                            bc.PostingRegMag();

                        bMigrazioneODL.InsertODL2ODPlog(nummovfase, "Migrazione completata correttamente", dto.esecuzione, dto.company);

                    }

                }
                catch (Exception ex)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("ECCEZIONE");
                    while (ex != null)
                    {
                        sb.AppendLine(ex.Message);
                        sb.AppendLine(ex.Source);
                        ex = ex.InnerException;
                        sb.AppendLine("**");
                    }
                    using (MigrazioneODLBusiness bMigrazioneODL = new MigrazioneODLBusiness())
                    {
                        bMigrazioneODL.InsertODL2ODPlog(nummovfase, sb.ToString(), dto.esecuzione, dto.company);
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
            if (odl.IsIDMAGAZZNull()) return false;


            string idmagazz = odl.IDMAGAZZ;

            using (MigrazioneODLBusiness bMigrazioneODL = new MigrazioneODLBusiness())
            {
                bool continua = true;
                MigrazioneODLDS.BC_ANAGRAFICA_PRODUZIONERow anagrafica = bMigrazioneODL.GetANAGRAFICA(_ds, idmagazz);

                if (anagrafica != null)
                {
                    txtAnagrafica.Text = (anagrafica == null) ? string.Empty : anagrafica.BC;
                    return true;
                }
                bMigrazioneODL.FillBC_MIGRAZIONE(_ds);
                MigrazioneODLDS.BC_MIGRAZIONERow riga = _ds.BC_MIGRAZIONE.Where(x => x.IDMAGAZZ == idmagazz).FirstOrDefault();
                if (riga == null) return false;
                decimal iddiba = riga.DIBA;
                decimal idnodo = riga.IDNODO;
                while (anagrafica == null && continua)
                {
                    riga = _ds.BC_MIGRAZIONE.Where(x => x.IDNODO == idnodo && x.DIBA == iddiba).FirstOrDefault();
                    if (riga == null)
                    {
                        continua = false;
                    }
                    else
                    {
                        if (riga.IDPADRE < 0)
                        {
                            continua = false;
                        }
                        else
                        {
                            MigrazioneODLDS.BC_MIGRAZIONERow rigaPadre = _ds.BC_MIGRAZIONE.Where(x => x.IDNODO == riga.IDPADRE && x.DIBA == iddiba).FirstOrDefault();
                            idmagazz = rigaPadre.IDMAGAZZ;
                            idnodo = rigaPadre.IDNODO;
                            anagrafica = bMigrazioneODL.GetANAGRAFICA(_ds, idmagazz);
                        }
                    }

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
                if (!decimal.TryParse(txtQuantita.Text, out quantita))
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
                        txtMessaggi.Text = String.Format("ODL già migrato nell'ordine di produzione {0} per la company {1}", odp.ODV, company);
                        return;
                    }

                    List<MigrazioneODLDS.ODL2ODPCOMPONENTIRow> odlsComp = ds.ODL2ODPCOMPONENTI.Where(x => x.NUMMOVFASE == txtNumOdl.Text && x.COMPANY == company).ToList();
                    if (odlsComp.Count > 0)
                    {
                        txtMessaggi.Text = String.Format("Componenti dell'ODL {0} già a sistema per la company {1}", txtNumOdl.Text, company);
                        return;
                    }

                    string codiceODP = bc.CreaOdDPConfermato(txtAnagrafica.Text, DateTime.Now, quantita, ubicazione, txtDescrizioneODV.Text, txtDescrizione2ODV.Text);
                    bMigrazioneODL.InsertODL2ODP(txtAZIENDA.Text, txtIDPRDMOVFASE.Text, txtNumOdl.Text, txtREPARTO.Text, txtFASE.Text, txtIDMAGAZZ.Text, txtAnagrafica.Text, quantita, codiceODP, txtDescrizioneODV.Text, txtDescrizione2ODV.Text, company);

                    txtODP.Text = codiceODP;
                    int linenumber = 0;
                    List<RegMesWS> magazzino = bc.EstraiRegMag();
                    if (magazzino.Count > 0)
                        linenumber = magazzino.Where(x => x.Journal_Batch_Name == "REGWS").Max(x => x.Line_No);

                    foreach (MigrazioneODLDS.DistinteBCDettaglioRow dettaglio in _ds.DistinteBCDettaglio.Where(x => x.Production_BOM_No_ == txtAnagrafica.Text))
                    {
                        decimal quantitaComponente = quantita * dettaglio.Quantity;
                        linenumber += 1000;
                        bc.CreaRegistrazioneMagazzino(ubicazione, collocazione, linenumber, txtNumOdl.Text, quantitaComponente, dettaglio.No_);
                        bMigrazioneODL.InsertODL2ODPComponenti(txtAZIENDA.Text, txtNumOdl.Text, txtREPARTO.Text, txtFASE.Text, txtAnagrafica.Text, dettaglio.No_, quantitaComponente, quantita, codiceODP, ubicazione, collocazione, company);

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
                        ODLDTO dto = new ODLDTO();
                        dto.odls = odls;
                        dto.esecuzione = DateTime.Now.ToString("yyyyMMddhhmmss");
                        dto.company = lblCompany.Text;
                        dto.collocazione = collocazione;
                        dto.ubicazione = ubicazione;
                        dto.ChBoxRegMag = ChBoxRegMag.Checked;

                        _bgwMigraODL.RunWorkerAsync(dto);

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
    }

    public class ODLDTO
    {
        public List<string> odls { get; set; }
        public string esecuzione { get; set; }
        public string company { get; set; }

        public string ubicazione { get; set; }
        public string collocazione { get; set; }
        public bool ChBoxRegMag { get; set; }
    }

}

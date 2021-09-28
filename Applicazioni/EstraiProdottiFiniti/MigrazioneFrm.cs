using Applicazioni.Common;
using Applicazioni.Data.EstraiProdottiFiniti;
using Applicazioni.Entities;
using Applicazioni.Helpers;
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

namespace EstraiProdottiFiniti
{
    public partial class MigrazioneFrm : ChildBaseForm
    {
        private EstraiProdottiFinitiDS _ds = new EstraiProdottiFinitiDS();
        private List<Nodo> Nodi = new List<Nodo>();
        private List<Distinta> distinte = new List<Distinta>();
        private List<Ciclo> cicli = new List<Ciclo>();
        private List<string> Collegamenti;


        public MigrazioneFrm()
        {
            InitializeComponent();
            CreaListaCollegamenti();
        }

        private void CreaListaCollegamenti()
        {
            Collegamenti = new List<string>();
            Collegamenti.Add(string.Empty);
            Collegamenti.Add("APERT");
            Collegamenti.Add("AVV");
            Collegamenti.Add("CATAF");
            Collegamenti.Add("CONF");
            Collegamenti.Add("CONFGREZZO");
            Collegamenti.Add("DECA");
            Collegamenti.Add("FBV");
            Collegamenti.Add("FLOC");
            Collegamenti.Add("FOR+FIL");
            Collegamenti.Add("FRESATURA");
            Collegamenti.Add("GALVROTO");
            Collegamenti.Add("GALVSTAT");
            Collegamenti.Add("IMPORT");
            Collegamenti.Add("INCART");
            Collegamenti.Add("INSACC");
            Collegamenti.Add("LEGFILI");
            Collegamenti.Add("LEGTEL");
            Collegamenti.Add("LUCACQUA");
            Collegamenti.Add("LUCSECCO");
            Collegamenti.Add("MONTFIN");
            Collegamenti.Add("MONTGRE");
            Collegamenti.Add("PIEG");
            Collegamenti.Add("PREP SPED");
            Collegamenti.Add("PULLUC");
            Collegamenti.Add("RIFIL");
            Collegamenti.Add("RINCOT");
            Collegamenti.Add("RIPRESE");
            Collegamenti.Add("SALD");
            Collegamenti.Add("SCELTASA");
            Collegamenti.Add("SCHIA");
            Collegamenti.Add("SGRAS");
            Collegamenti.Add("SLEGFILI");
            Collegamenti.Add("SLEGTEL");
            Collegamenti.Add("SMETEST");
            Collegamenti.Add("STAC");
            Collegamenti.Add("SVIRG");
            Collegamenti.Add("TAGLIO");
            Collegamenti.Add("TAGLIOMAT");
            Collegamenti.Add("TORN");
            Collegamenti.Add("TRANC");
            Collegamenti.Add("VIBACQUA");
            Collegamenti.Add("VIBSECCO");
        }
   
        private void btnCercaDiBa_Click(object sender, EventArgs e)
        {
            txtArticolo.Text = txtArticolo.Text.Trim().ToUpper();
            using (EstraiProdottiFinitiBusiness bEstrai = new EstraiProdottiFinitiBusiness())
            {
                if (string.IsNullOrEmpty(txtArticolo.Text))
                {
                    MessageBox.Show("Inserisci il modello da cercare", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                _ds.USR_PRD_TDIBA.Clear();
               
                txtNoteStd.Text = string.Empty;
                txtVersioneDiBa.Text = string.Empty;
                this.Text = "Distinta RVL";
                string IDTDIBA = string.Empty;
                string modello = string.Empty;
                bEstrai.GetUSR_PRD_TDIBAByModello(_ds, txtArticolo.Text);
                if (_ds.USR_PRD_TDIBA.Rows.Count > 0)
                {
                    SelezionaDIbaFrm frm = new SelezionaDIbaFrm();
                    frm.estraiProdottiFinitiDS1 = _ds;
                    frm.ShowDialog();

                    IDTDIBA = frm.IDTDIBA;
                    if (string.IsNullOrEmpty(IDTDIBA)) return;
                    txtNoteStd.Text = frm.NotaStd;
                    txtVersioneDiBa.Text = frm.Versione;
                    modello = frm.Modello;
                }
                else
                {
                    EstraiProdottiFinitiDS.USR_PRD_TDIBARow riga = _ds.USR_PRD_TDIBA.FirstOrDefault();
                    if (riga == null)
                    {
                        MessageBox.Show("Articolo non trovato", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    IDTDIBA = riga.IDTDIBA;

                    txtNoteStd.Text = riga.IsNOTESTDNull() ? string.Empty : riga.NOTESTD;
                    txtVersioneDiBa.Text = riga.IsNOTETECHNull() ? string.Empty : riga.NOTETECH;
                    modello = riga.MODELLO;
                }
                this.Text = string.Format("{0} {1}", this.Text, modello);

                Nodi = new List<Nodo>();
                _ds.USR_PRD_TDIBA.Clear();
                _ds.USR_PRD_RDIBA.Clear();
                _ds.MAGAZZ.Clear();
                _ds.BC_ANAGRAFICA.Clear();
                _ds.TABFAS.Clear();
                _ds.BC_NODO.Clear();

                bEstrai.FillBC_ANAGRAFICA(_ds, chkTest.Checked);
                bEstrai.FillTABFAS(_ds);
                bEstrai.FillBC_TASK(_ds);
                bEstrai.FillBC_NODO(_ds, chkTest.Checked);
                bEstrai.fILLBC_NODO_Q(_ds, chkTest.Checked);
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    int idNodo = 1;
                    int profondita = 1;
                    EstraiDistintaBase(bEstrai, IDTDIBA, profondita, ref idNodo, -1, 1, 0, string.Empty, string.Empty, "N", string.Empty);

                    pulisciNodi();
                    riempiNodi();
                    caricaMagazzinoRVL();

                    CreaAlbero();
                    PopolaGrigliaNodi();

                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MostraEccezione("Errore nel caricamento della distinta", ex);
                }

            }
        }

        private void caricaMagazzinoRVL()
        {
            EstraiProdottiFinitiDS ds = new EstraiProdottiFinitiDS();
            using (EstraiProdottiFinitiBusiness bEstrai = new EstraiProdottiFinitiBusiness())
            {
                foreach (Nodo n in Nodi)
                {
                    bEstrai.GetMagazzinoRVL(ds, n.IDMAGAZZ);
                    n.MagazzinoRVL = new List<Magazzino>();
                    foreach(EstraiProdottiFinitiDS.MAGAZZINORVLRow r in ds.MAGAZZINORVL.Where(x=>x.IDMAGAZZ==n.IDMAGAZZ))
                    {
                        n.MagazzinoRVL.Add(Magazzino.CreaMagazzino(r));
                    }
                }
            }
        }
        private void riempiNodi()
        {
            foreach (Nodo n in Nodi)
            {
                string IDMAGAZZPADRE = "-1";

                if (n.IDPADRE > 0)
                {
                    Nodo nodoPadre = Nodi.Where(x => x.ID == n.IDPADRE).FirstOrDefault();
                    IDMAGAZZPADRE = nodoPadre.IDMAGAZZ;
                }

                EstraiProdottiFinitiDS.BC_NODORow datiNodo = _ds.BC_NODO.Where(x => x.IDMAGAZZ == n.IDMAGAZZ).FirstOrDefault();
                if (datiNodo != null)
                {
                    n.CodiceCiclo = datiNodo.IsCODICECICLONull() ? string.Empty : datiNodo.CODICECICLO;
                    n.CollegamentoCiclo = datiNodo.IsCOLLEGAMENTOCICLONull() ? string.Empty : datiNodo.COLLEGAMENTOCICLO;
                    n.CollegamentoDiba = datiNodo.IsCOLLEGAMENTODIBANull() ? string.Empty : datiNodo.COLLEGAMENTODIBA;
                    if (!datiNodo.IsPEZZIORARINull())
                        n.PezziOrari = datiNodo.PEZZIORARI;
                    if (!datiNodo.IsOREPERIODONull())
                        n.OrePeriodo = datiNodo.OREPERIODO;

                    if (!datiNodo.IsCODICECICLONull())
                        n.CodiceCiclo = datiNodo.CODICECICLO;
                    if (!datiNodo.IsCOLLEGAMENTOCICLONull())
                        n.CollegamentoCiclo = datiNodo.COLLEGAMENTOCICLO;
                    if (!datiNodo.IsCOLLEGAMENTODIBANull())
                        n.CollegamentoDiba = datiNodo.COLLEGAMENTODIBA;
                }

                EstraiProdottiFinitiDS.BC_NODO_QRow datiNodoQ = _ds.BC_NODO_Q.Where(x => x.IDMAGAZZ == n.IDMAGAZZ && !x.IsIDMAGAZZPADRENull() && x.IDMAGAZZPADRE == IDMAGAZZPADRE).FirstOrDefault();
                if (datiNodoQ != null)
                {
                    if (!datiNodoQ.IsQUANTITANull())
                        n.Quantita = datiNodoQ.QUANTITA;

                    if (!datiNodoQ.IsUMQUANTITANull())
                        n.UM = datiNodoQ.UMQUANTITA;
                }
            }
        }

        private void pulisciNodi()
        {
            if (chkControlliQualita.Checked)
            {
                List<Nodo> lista = new List<Nodo>();
                foreach (Nodo n in Nodi)
                {
                    EstraiProdottiFinitiDS.BC_TASKRow task = _ds.BC_TASK.Where(x => x.CODICEFASE == n.Fase).FirstOrDefault();
                    if ((task != null && task.TASK == "***ESCLUDERE") || (n.Modello.Contains("CQSL") || n.Modello.Contains("CTRL")))
                    {
                        if (Nodi.Any(x => x.IDPADRE == n.ID))
                        {
                            foreach (Nodo nodoFiglio in Nodi.Where(x => x.IDPADRE == n.ID))
                            {
                                nodoFiglio.IDPADRE = n.IDPADRE;
                                if (n.Quantita != 1 && n.Quantita > 0)
                                {
                                    nodoFiglio.Quantita = n.Quantita;
                                    nodoFiglio.QuantitaConsumo = n.QuantitaConsumo;
                                    nodoFiglio.QuantitaOccorrenza = n.QuantitaOccorrenza;
                                }

                            }
                        }
                        else
                            lista.Add(n);
                    }
                    else
                        lista.Add(n);
                }
                Nodi = lista;
            }
            Nodo radice = Nodi[0];
            aggiornaProfondita(radice, radice.Profondita);

        }

        private void aggiornaProfondita(Nodo nodoDaAggiornare, int profondita)
        {
            nodoDaAggiornare.Profondita = profondita;
            profondita++;
            foreach (Nodo nodoFiglio in Nodi.Where(x => x.IDPADRE == nodoDaAggiornare.ID))
                aggiornaProfondita(nodoFiglio, profondita);
        }

        private void PopolaGrigliaNodi()
        {
            dgvNodi.AutoGenerateColumns = false;
            var bindingList = new BindingList<Nodo>(Nodi);
            var source = new BindingSource(bindingList, null);
            dgvNodi.DataSource = source;
            dgvNodi.Update();
        }

        private void CreaAlbero()
        {
            tvDiBa.Nodes.Clear();
            Nodo radice = Nodi.Where(x => x.IDPADRE == -1).FirstOrDefault();
            TreeNode root = tvDiBa.Nodes.Add(radice.ToString());
            root.Tag = radice;
            AggiungiRamo(root, radice.ID);
            tvDiBa.ExpandAll();
        }

        private void AggiungiRamo(TreeNode root, int IDPADRE)
        {
            List<Nodo> rami = Nodi.Where(x => x.IDPADRE == IDPADRE).ToList();

            foreach (Nodo n in rami)
            {
                TreeNode nodoPadre = root.Nodes.Add(n.ToString());
                nodoPadre.Tag = n;
                AggiungiRamo(nodoPadre, n.ID);
            }
        }

        private Nodo CreaNodo(int idNodo, string idmagazz, int profondita, int idpadre, decimal quantitaConsumo, decimal quantitaOccorrenza, string IDTABFAS,
            string noteTecniche, string noteStandard, string fornitoDaCommittente, string metodo, string versione, string attiva, string controllata, string unitaMisura, string repartoDiBa)
        {
            EstraiProdottiFinitiDS.MAGAZZRow magazz = _ds.MAGAZZ.Where(x => x.IDMAGAZZ == idmagazz).FirstOrDefault();
            EstraiProdottiFinitiDS.TABFASRow fase = _ds.TABFAS.Where(x => x.IDTABFAS == IDTABFAS).FirstOrDefault();

            EstraiProdottiFinitiDS.BC_ANAGRAFICARow anagrafica = _ds.BC_ANAGRAFICA.Where(x => x.RowState != DataRowState.Deleted && x.IDMAGAZZ == idmagazz && x.CL == 0).FirstOrDefault();


            string reparto = fase.IsCODICECLIFOPREDFASENull() ? string.Empty : fase.CODICECLIFOPREDFASE;
            Nodo n = new Nodo();
            n.Anagrafica = (anagrafica != null) ? anagrafica.BC : string.Empty; ;
            n.ID = idNodo;
            n.Profondita = profondita;
            n.IDPADRE = idpadre;
            n.IDMAGAZZ = idmagazz;

            decimal quantita = 0;
            if (quantitaOccorrenza == 0) quantita = quantitaConsumo;
            else quantita = 1.0M / quantitaOccorrenza;

            n.QuantitaConsumo = quantitaConsumo;
            n.QuantitaOccorrenza = quantitaOccorrenza;
            n.Quantita = quantita;

            n.Reparto = string.IsNullOrEmpty(repartoDiBa) ? reparto : repartoDiBa;
            n.Fase = fase.CODICEFASE;
            n.Peso = magazz.PESO;
            n.Superficie = magazz.SUPERFICIE;
            n.FornitoDaCommittente = fornitoDaCommittente;
            n.OrePeriodo = 1;

            noteStandard = noteStandard.Replace("\n", String.Empty);
            noteStandard = noteStandard.Replace("\r", String.Empty);
            noteStandard = noteStandard.Replace("\t", String.Empty);

            noteTecniche = noteTecniche.Replace("\n", String.Empty);
            noteTecniche = noteTecniche.Replace("\r", String.Empty);
            noteTecniche = noteTecniche.Replace("\t", String.Empty);

            n.NoteStandard = noteStandard;
            n.NoteTecniche = noteTecniche;
            n.Modello = (magazz == null) ? string.Empty : magazz.MODELLO;
            n.DescrizioneArticolo = (magazz == null) ? string.Empty : magazz.DESMAGAZZ;
            n.Metodo = metodo;
            n.Versione = versione;
            n.Attiva = attiva;
            n.Controllata = controllata;
            n.UM = unitaMisura;
            n.ContoLavoro = false;
            return n;
        }
        private void EstraiDistintaBase(EstraiProdottiFinitiBusiness bEstrai, string IDTDIBA, int profondita, ref int idNodo, int idPadre, decimal quantitaConsumo,
            decimal quantitaOccorrenza, string noteTecniche, string noteStandard, string fornitoDaCommittente, string unitaMisura)
        {
            bEstrai.GetUSR_PRD_TDIBA(_ds, IDTDIBA);
            EstraiProdottiFinitiDS.USR_PRD_TDIBARow testata = _ds.USR_PRD_TDIBA.Where(x => x.IDTDIBA == IDTDIBA).FirstOrDefault();

            if (testata != null)
            {
                bool modelloCOntieneCTRL = false;
                if (!testata.IsCODICECLIFOPRDNull() && testata.CODICECLIFOPRD.Trim() == "02350" && chkInserisciTopFinish.Checked)
                {
                    int IDNodoPartenza = idNodo;
                    int idPadreNuovo = 0;
                    bEstrai.GetUSR_PRD_TDIBATopFinishByIDMAGAZZ(_ds, testata.IDMAGAZZ);

                    EstraiProdottiFinitiDS.USR_PRD_TDIBATOPFINISHRow rigaTopFinish = _ds.USR_PRD_TDIBATOPFINISH.Where(x => x.IDMAGAZZ == testata.IDMAGAZZ && x.DEBADEFAULT == "S").FirstOrDefault();
                    if (rigaTopFinish != null)
                        EstraiDistintaTopFinish(bEstrai, rigaTopFinish.IDTDIBA, profondita, ref idNodo, idPadre, quantitaConsumo, quantitaOccorrenza, string.Empty, string.Empty, "N", unitaMisura);
                    int profonditaRamo = TrovaProfonditaRamo(IDNodoPartenza, out idPadreNuovo);
                    profondita = profonditaRamo;
                    idPadre = idPadreNuovo;
                }
                else
                {
                    bEstrai.GetMAGAZZ(_ds, testata.IDMAGAZZ);
                    string reparto = testata.IsCODICECLIFOPRDNull() ? string.Empty : testata.CODICECLIFOPRD;

                    noteTecniche = testata.IsNOTETECHNull() ? string.Empty : testata.NOTETECH;
                    noteStandard = testata.IsNOTESTDNull() ? string.Empty : testata.NOTESTD;

                    Nodo n = CreaNodo(idNodo, testata.IDMAGAZZ, profondita, idPadre, quantitaConsumo, quantitaOccorrenza, testata.IDTABFAS, noteTecniche, noteStandard, fornitoDaCommittente,
                        testata.METODO, testata.VERSION.ToString(), testata.ACTIVESN, testata.CHECKSN, unitaMisura, reparto);

                    Nodi.Add(n);
                    idPadre = n.ID;
                    idNodo++;

                    //EstraiProdottiFinitiDS.BC_TASKRow task = _ds.BC_TASK.Where(x => x.IDTABFAS == testata.IDTABFAS).FirstOrDefault();
                    //if (task != null)
                    //{
                    //    if (task.TASK.Trim() == "***ESCLUDERE")
                    //        n.Reparto = "CTRL";
                    //}

                    //if (!chkControlliQualita.Checked || !n.Reparto.Contains("CTRL"))

                    //{

                    //    if (!n.Modello.Contains("CTRL"))
                    //    {
                    //        Nodi.Add(n);
                    //        idPadre = n.ID;
                    //        idNodo++;
                    //    }
                    //    else modelloCOntieneCTRL = true;
                    //}
                    //else
                    //{
                    //    if (n.Fase == "SKIC")
                    //    {
                    //        Nodi.Add(n);
                    //        idPadre = n.ID;
                    //        idNodo++;
                    //    }
                    //}
                }
                bEstrai.GetUSR_PRD_RDIBA(_ds, IDTDIBA);
                List<EstraiProdottiFinitiDS.USR_PRD_RDIBARow> componenti = _ds.USR_PRD_RDIBA.Where(x => x.IDTDIBA == IDTDIBA).ToList();
                if (componenti.Count > 0 && !modelloCOntieneCTRL)
                    profondita++;

                foreach (EstraiProdottiFinitiDS.USR_PRD_RDIBARow componente in componenti)
                {
                    string nTech = componente.IsNOTETECHNull() ? string.Empty : componente.NOTETECH;
                    string nStad = componente.IsNOTESTDNull() ? string.Empty : componente.NOTESTD;
                    if (!componente.IsIDTDIBAIFFASENull() && componente.STOCKSN == "N")
                        EstraiDistintaBase(bEstrai, componente.IDTDIBAIFFASE, profondita, ref idNodo, idPadre, componente.QTACONSUMO, componente.QTAOCCORRENZA, nTech, nStad, componente.CVENSN, componente.CODICEUNIMI);
                    else
                    {
                        string repartoDiba = testata.IsCODICECLIFOPRDNull() ? string.Empty : testata.CODICECLIFOPRD;
                        bEstrai.GetMAGAZZ(_ds, componente.IDMAGAZZ);
                        Nodo nodoFiglio = CreaNodo(idNodo, componente.IDMAGAZZ, profondita, idPadre, componente.QTACONSUMO, componente.QTAOCCORRENZA, testata.IDTABFAS, noteTecniche, noteStandard, componente.CVENSN,
                            testata.METODO, testata.VERSION.ToString(), testata.ACTIVESN, testata.CHECKSN, componente.CODICEUNIMI, repartoDiba);

                        Nodi.Add(nodoFiglio);
                        idNodo++;
                        //EstraiProdottiFinitiDS.BC_TASKRow task = _ds.BC_TASK.Where(x => x.IDTABFAS == testata.IDTABFAS).FirstOrDefault();
                        //if (task != null)
                        //{
                        //    if (task.TASK.Trim() == "***ESCLUDERE")
                        //        nodoFiglio.Reparto = "CTRL";
                        //}


                        //if (!chkControlliQualita.Checked || !nodoFiglio.Reparto.Contains("CTRL"))
                        //{
                        //    if (!nodoFiglio.Modello.Contains("CTRL"))
                        //    {
                        //        Nodi.Add(nodoFiglio);
                        //        idNodo++;
                        //    }
                        //}
                        //else
                        //{
                        //    if (nodoFiglio.Fase == "SKIC")
                        //    {
                        //        Nodi.Add(nodoFiglio);
                        //        idPadre = nodoFiglio.ID;
                        //        idNodo++;
                        //    }

                        //}

                    }
                }


            }

        }

        private int TrovaProfonditaRamo(int IDNodoPartenza, out int IDPadre)
        {
            IDPadre = IDNodoPartenza;
            int profonditaMassima = Nodi.Where(x => x.ID == IDNodoPartenza).Select(x => x.Profondita).FirstOrDefault();
            List<Nodo> nodiFigli = Nodi.Where(x => x.IDPADRE == IDNodoPartenza).ToList();
            foreach (Nodo nodoFiglio in nodiFigli)
            {
                if (profonditaMassima < nodoFiglio.Profondita)
                {
                    profonditaMassima = nodoFiglio.Profondita;
                    IDPadre = nodoFiglio.ID;
                }
                int auxIdPadre = 0;
                int profondidaFiglo = TrovaProfonditaRamo(nodoFiglio.ID, out auxIdPadre);
                if (profonditaMassima < profondidaFiglo)
                {
                    profonditaMassima = profondidaFiglo;
                    IDPadre = auxIdPadre;
                }
            }
            return profonditaMassima;
        }

        private void EstraiDistintaTopFinish(EstraiProdottiFinitiBusiness bEstrai, string IDTDIBA, int profondita, ref int idNodo, int idPadre, decimal quantitaConsumo,
           decimal quantitaOccorrenza, string noteTecniche, string noteStandard, string fornitoDaCommittente, string unitaMisura)
        {
            bEstrai.GetUSR_PRD_TDIBATopFinish(_ds, IDTDIBA);
            EstraiProdottiFinitiDS.USR_PRD_TDIBATOPFINISHRow testata = _ds.USR_PRD_TDIBATOPFINISH.Where(x => x.IDTDIBA == IDTDIBA).FirstOrDefault();
            if (testata != null)
            {
                bool modelloCOntieneCTRL = false;
                bEstrai.GetMAGAZZ(_ds, testata.IDMAGAZZ);
                string reparto = testata.IsCODICECLIFOPRDNull() ? string.Empty : testata.CODICECLIFOPRD;

                noteTecniche = testata.IsNOTETECHNull() ? string.Empty : testata.NOTETECH;
                noteStandard = testata.IsNOTESTDNull() ? string.Empty : testata.NOTESTD;

                Nodo n = CreaNodo(idNodo, testata.IDMAGAZZ, profondita, idPadre, quantitaConsumo, quantitaOccorrenza, testata.IDTABFAS, noteTecniche, noteStandard, fornitoDaCommittente,
                    testata.METODO, testata.VERSION.ToString(), testata.ACTIVESN, testata.CHECKSN, unitaMisura, reparto);

                //EstraiProdottiFinitiDS.BC_TASKRow task = _ds.BC_TASK.Where(x => x.IDTABFAS == testata.IDTABFAS).FirstOrDefault();
                //if (task != null)
                //{
                //    if (task.TASK.Trim() == "***ESCLUDERE")
                //        n.Reparto = "CTRL";
                //}


                //if (!chkControlliQualita.Checked || !n.Reparto.Contains("CTRL"))

                //{
                //    if (!n.Modello.Contains("CTRL"))
                //    {
                //        Nodi.Add(n);
                //        idNodo++;
                //    }
                //    else modelloCOntieneCTRL = true;

                //}
                //else
                //{
                //    if (n.Fase == "SKIC")
                //    {
                //        Nodi.Add(n);
                //        idPadre = n.ID;
                //        idNodo++;
                //    }

                //}

                Nodi.Add(n);
                idPadre = n.ID;
                idNodo++;

                bEstrai.GetUSR_PRD_RDIBATopFinish(_ds, IDTDIBA);
                List<EstraiProdottiFinitiDS.USR_PRD_RDIBATOPFINISHRow> componenti = _ds.USR_PRD_RDIBATOPFINISH.Where(x => x.IDTDIBA == IDTDIBA).ToList();
                if (componenti.Count > 0 && !modelloCOntieneCTRL) profondita++;

                foreach (EstraiProdottiFinitiDS.USR_PRD_RDIBATOPFINISHRow componente in componenti)
                {
                    string nTech = componente.IsNOTETECHNull() ? string.Empty : componente.NOTETECH;
                    string nStad = componente.IsNOTESTDNull() ? string.Empty : componente.NOTESTD;
                    if (!componente.IsIDTDIBAIFFASENull() && componente.STOCKSN == "N")
                        EstraiDistintaTopFinish(bEstrai, componente.IDTDIBAIFFASE, profondita, ref idNodo, n.ID, componente.QTACONSUMO, componente.QTAOCCORRENZA, nTech, nStad, componente.CVENSN, componente.CODICEUNIMI);
                    else
                    {
                        //      string repartoDiba = testata.IsCODICECLIFOPRDNull() ? string.Empty : testata.CODICECLIFOPRD;
                        //     bEstrai.GetMAGAZZ(_ds, componente.IDMAGAZZ);
                        //      Nodo nodoFiglio = CreaNodo(idNodo, componente.IDMAGAZZ, profondita, idPadre, componente.QTACONSUMO, componente.QTAOCCORRENZA, testata.IDTABFAS, noteTecniche, noteStandard, componente.CVENSN,
                        //          testata.METODO, testata.VERSION.ToString(), testata.ACTIVESN, testata.CHECKSN, componente.CODICEUNIMI, repartoDiba);

                        // task = _ds.BC_TASK.Where(x => x.IDTABFAS == testata.IDTABFAS).FirstOrDefault();
                        //if (task != null)
                        //{
                        //    if (task.TASK.Trim() == "***ESCLUDERE")
                        //        nodoFiglio.Reparto = "CTRL";
                        //}

                        //if (!chkControlliQualita.Checked || !nodoFiglio.Reparto.Contains("CTRL"))
                        //{
                        //    if (!nodoFiglio.Modello.Contains("CTRL"))
                        //    {
                        //        Nodi.Add(nodoFiglio);
                        //        idNodo++;
                        //    }
                        //}
                        //else
                        //{
                        //    if (n.Fase == "SKIC")
                        //    {
                        //        Nodi.Add(n);
                        //        idPadre = n.ID;
                        //        idNodo++;
                        //    }

                        //}
                        //       Nodi.Add(nodoFiglio);
                        //        idNodo++;

                    }
                }
            }
        }

        private void tvDiBa_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Nodo n = (Nodo)e.Node.Tag;
            int ID = n.ID;

            foreach (DataGridViewRow riga in dgvNodi.Rows)
            {


                int IDRiga = (int)riga.Cells[0].Value;
                if (IDRiga == ID)
                {
                    riga.DefaultCellStyle.BackColor = Color.Yellow;
                    dgvNodi.CurrentCell = riga.Cells[5];
                }
                else
                    riga.DefaultCellStyle.BackColor = Color.White;
            }

        }

        private void creaDistinta(Nodo riga, int indiceMinimo, int indiceMassimo, List<Distinta> distinte, List<Nodo> righeConAnagrafica, int avantiMassimo)
        {
            int indice = 0;

            List<Nodo> righeFiglie = new List<Nodo>();

            do
            {
                indice++;
                if (indice > avantiMassimo)
                    return;

                righeFiglie = righeConAnagrafica.Where(x => x.Profondita == riga.Profondita + indice && x.ID >= indiceMinimo && x.ID <= indiceMassimo).ToList();
            } while (righeFiglie.Count == 0);

            List<Componente> componenti = new List<Componente>();
            righeFiglie.ForEach(x => componenti.Add(new Componente(x.Anagrafica, x.Quantita, x.CollegamentoDiba, x.UM, x.ID, riga.Anagrafica)));

            distinte.Add(new Distinta(riga.Anagrafica, componenti));

            for (int i = 0; i < righeFiglie.Count; i++)
            {
                if (i < righeFiglie.Count - 1)
                    creaDistinta(righeFiglie[i], righeFiglie[i].ID, righeFiglie[i + 1].ID, distinte, righeConAnagrafica, avantiMassimo);
                else
                    creaDistinta(righeFiglie[i], righeFiglie[i].ID, indiceMassimo, distinte, righeConAnagrafica, avantiMassimo);
            }

        }
 
     

        private bool TrovaNodoContolavoroAlbero(Nodo nodoDaTrovare, TreeNode radice)
        {
            Nodo nodoPadre = (Nodo)radice.Tag;
            if (nodoPadre == nodoDaTrovare)
            {
                nodoPadre.ContoLavoro = true;
                return true;
            }

            if (nodoPadre.ID == nodoDaTrovare.ID)
            {
                nodoPadre.ContoLavoro = true;
                return true;
            }

            foreach (TreeNode nodoAlberoFiglio in radice.Nodes)
            {
                Nodo nodoFiglio = (Nodo)radice.Tag;
                bool esito = TrovaNodoContolavoroAlbero(nodoDaTrovare, nodoAlberoFiglio);
                if (!nodoFiglio.ContoLavoro)
                    nodoFiglio.ContoLavoro = esito;
                if (esito) return esito;
            }
            return false;
        }
  
        private void EstraiProdottoFinito_Load(object sender, EventArgs e)
        {
        }

        private void dgvNodi_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtMagazzino.Text = string.Empty;
            string m = (string)dgvNodi.Rows[e.RowIndex].Cells[MagazzinoClm.Index].Value;
            txtMagazzino.Text = m;
        }
    }
}

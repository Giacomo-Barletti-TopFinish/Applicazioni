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
    public partial class EstraiProdottoFinito : ChildBaseForm
    {
        private EstraiProdottiFinitiDS _ds = new EstraiProdottiFinitiDS();
        private List<Nodo> Nodi = new List<Nodo>();
        private List<Distinta> distinte = new List<Distinta>();
        private List<Ciclo> cicli = new List<Ciclo>();
        private List<string> Collegamenti;


        public EstraiProdottoFinito()
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

        private void DisabilitaPulsanti()
        {
            btnSalvaAnagrafiche.Enabled = false;
            btnSalvaCicli.Enabled = false;
            btnSalvaDistinte.Enabled = false;
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
                DisabilitaPulsanti();
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


        private void salvaNodi()
        {
            foreach (Nodo n in Nodi)
            {
                string codiceCiclo = (n.CodiceCiclo == null) ? string.Empty : n.CodiceCiclo.ToUpper();
                string CollegamentoCiclo = (n.CollegamentoCiclo == null) ? string.Empty : n.CollegamentoCiclo.ToUpper();
                string CollegamentoDiba = (n.CollegamentoDiba == null) ? string.Empty : n.CollegamentoDiba.ToUpper();
                string IDMAGAZZPADRE = "-1";

                if (n.IDPADRE > 0)
                {
                    Nodo nodoPadre = Nodi.Where(x => x.ID == n.IDPADRE).FirstOrDefault();
                    IDMAGAZZPADRE = nodoPadre.IDMAGAZZ;
                }

                if (n.IDMAGAZZ != null)
                {
                    EstraiProdottiFinitiDS.BC_NODORow datiNodo = _ds.BC_NODO.Where(x => x.IDMAGAZZ == n.IDMAGAZZ).FirstOrDefault();
                    if (datiNodo != null)
                    {
                        if (datiNodo.IsCODICECICLONull()) datiNodo.CODICECICLO = string.Empty;
                        if (datiNodo.IsCOLLEGAMENTOCICLONull()) datiNodo.COLLEGAMENTOCICLO = string.Empty;
                        if (datiNodo.IsCOLLEGAMENTODIBANull()) datiNodo.COLLEGAMENTODIBA = string.Empty;
                        datiNodo.CODICECICLO = codiceCiclo;
                        datiNodo.COLLEGAMENTOCICLO = CollegamentoCiclo;
                        datiNodo.COLLEGAMENTODIBA = CollegamentoDiba;
                        datiNodo.PEZZIORARI = n.PezziOrari;
                        datiNodo.OREPERIODO = n.OrePeriodo;
                    }
                    else
                    {
                        datiNodo = _ds.BC_NODO.NewBC_NODORow();
                        datiNodo.IDMAGAZZ = n.IDMAGAZZ;
                        datiNodo.CODICECICLO = codiceCiclo;
                        datiNodo.COLLEGAMENTOCICLO = CollegamentoCiclo;
                        datiNodo.COLLEGAMENTODIBA = CollegamentoDiba;
                        datiNodo.PEZZIORARI = n.PezziOrari;
                        datiNodo.OREPERIODO = n.OrePeriodo;
                        _ds.BC_NODO.AddBC_NODORow(datiNodo);
                    }

                    EstraiProdottiFinitiDS.BC_NODO_QRow datiNodoQ = _ds.BC_NODO_Q.Where(x => x.IDMAGAZZ == n.IDMAGAZZ && !x.IsIDMAGAZZPADRENull() && x.IDMAGAZZPADRE == IDMAGAZZPADRE).FirstOrDefault();
                    if (datiNodoQ != null)
                    {
                        datiNodoQ.QUANTITA = n.Quantita;
                        datiNodoQ.UMQUANTITA = n.UM;
                    }
                    else
                    {
                        datiNodoQ = _ds.BC_NODO_Q.NewBC_NODO_QRow();
                        datiNodoQ.IDMAGAZZ = n.IDMAGAZZ;
                        datiNodoQ.QUANTITA = n.Quantita;
                        datiNodoQ.IDMAGAZZPADRE = IDMAGAZZPADRE;
                        datiNodoQ.UMQUANTITA = n.UM;
                        _ds.BC_NODO_Q.AddBC_NODO_QRow(datiNodoQ);
                    }
                }

            }
            using (EstraiProdottiFinitiBusiness bEstrai = new EstraiProdottiFinitiBusiness())
            {
                if (chkTest.Checked)
                {
                    bEstrai.UpdateTable(_ds.BC_NODO.TableName, _ds, "BC_NODO");
                    bEstrai.UpdateTable(_ds.BC_NODO_Q.TableName, _ds, "BC_NODO_Q");
                }
                else
                {
                    bEstrai.UpdateTable(_ds.BC_NODO.TableName, _ds, "BC_NODO_PRODUZIONE");
                    bEstrai.UpdateTable(_ds.BC_NODO_Q.TableName, _ds, "BC_NODO_Q_PRODUZIONE");
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

        private void VerificaAnagrafiche()
        {
            try
            {

                Cursor.Current = Cursors.WaitCursor;

                string messaggioErrore = string.Empty;

                List<Nodo> nodiSenzaAnagrafiche = Nodi.Where(x => string.IsNullOrEmpty(x.Anagrafica)).ToList();
                foreach (Nodo nodo in nodiSenzaAnagrafiche.Where(x => !string.IsNullOrEmpty(x.IDMAGAZZ)))
                {
                    EstraiProdottiFinitiDS.BC_ANAGRAFICARow riga = _ds.BC_ANAGRAFICA.Where(x => x.RowState != DataRowState.Deleted && x.IDMAGAZZ == nodo.IDMAGAZZ).FirstOrDefault();
                    if (riga != null)
                        riga.Delete();
                }

                List<Nodo> nodiConAnagrafiche = Nodi.Where(x => !string.IsNullOrEmpty(x.Anagrafica)).ToList();

                List<string> anagraficheCensite = new List<string>();
                List<string> anagraficheModificate = new List<string>();
                List<string> anagraficheNuove = new List<string>();
                foreach (Nodo nodoConAnagrafica in nodiConAnagrafiche.Where(x => !string.IsNullOrEmpty(x.IDMAGAZZ)))
                {
                    nodoConAnagrafica.ToUpper();
                    EstraiProdottiFinitiDS.BC_ANAGRAFICARow riga = _ds.BC_ANAGRAFICA.Where(x => x.RowState != DataRowState.Deleted && x.IDMAGAZZ == nodoConAnagrafica.IDMAGAZZ && x.CL == (nodoConAnagrafica.ContoLavoro ? 1 : 0)).FirstOrDefault();
                    if (riga != null)
                    {
                        if (riga.BC != nodoConAnagrafica.Anagrafica.ToUpper())
                        {
                            anagraficheModificate.Add(string.Format("{2} associazione modificata {0} -> {1}", riga.BC, nodoConAnagrafica.Anagrafica, nodoConAnagrafica.Modello));
                            riga.BC = nodoConAnagrafica.Anagrafica;
                        }
                        else
                            anagraficheCensite.Add(riga.BC);
                    }
                    else
                    {
                        EstraiProdottiFinitiDS.BC_ANAGRAFICARow nuovaRiga = _ds.BC_ANAGRAFICA.NewBC_ANAGRAFICARow();
                        nuovaRiga.BC = nodoConAnagrafica.Anagrafica;
                        nuovaRiga.IDMAGAZZ = nodoConAnagrafica.IDMAGAZZ;
                        nuovaRiga.CL = nodoConAnagrafica.ContoLavoro ? 1 : 0;
                        _ds.BC_ANAGRAFICA.AddBC_ANAGRAFICARow(nuovaRiga);
                        anagraficheNuove.Add(string.Format("{0} associata a {1}", nodoConAnagrafica.Modello, nodoConAnagrafica.Anagrafica));
                    }
                }
                txtMsgAnagrafiche.Text = messaggioErrore;

                ImpaginaMessaggioAnagrafiche(anagraficheCensite, anagraficheModificate, anagraficheNuove);

                btnSalvaAnagrafiche.Enabled = true;

            }
            catch (Exception ex)
            {
                txtMsgAnagrafiche.Text = ex.Message;
                MostraEccezione("Errore in verifica anagrafica", ex);
                Cursor.Current = Cursors.Default;

            }

        }

        private void btnVerificaAnagrafiche_Click(object sender, EventArgs e)
        {
            VerificaAnagrafiche();
        }

        private void btnSalvaAnagrafiche_Click(object sender, EventArgs e)
        {
            salvaAnagrafiche();
        }

        private void salvaAnagrafiche()
        {
            using (EstraiProdottiFinitiBusiness bEstrai = new EstraiProdottiFinitiBusiness())
            {
                if (chkTest.Checked)
                    bEstrai.UpdateTable(_ds.BC_ANAGRAFICA.TableName, _ds, "BC_ANAGRAFICA");
                else
                    bEstrai.UpdateTable(_ds.BC_ANAGRAFICA.TableName, _ds, "BC_ANAGRAFICA_PRODUZIONE");
            }
        }
        private void ImpaginaMessaggioAnagrafiche(List<string> anagraficheCensite, List<string> anagraficheModificate, List<string> anagraficheNuove)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NUOVE ANAGRAFICHE");
            sb.AppendLine("-----------------");
            anagraficheNuove.ForEach(x => sb.AppendLine(x));
            sb.AppendLine(string.Empty);

            sb.AppendLine("ANAGRAFICHE MODIFICATE");
            sb.AppendLine("----------------------");
            anagraficheModificate.ForEach(x => sb.AppendLine(x));
            sb.AppendLine(string.Empty);

            sb.AppendLine("ANAGRAFICHE GIA' CENSITE");
            sb.AppendLine("------------------------");
            anagraficheCensite.ForEach(x => sb.AppendLine(x));
            sb.AppendLine(string.Empty);

            txtMsgAnagrafiche.Text += sb.ToString();
        }

        private void VerificaCicli(out string errori)
        {
            using (EstraiProdottiFinitiBusiness bEstrai = new EstraiProdottiFinitiBusiness())
            {
                _ds.BC_TASK.Clear();
                bEstrai.FillBC_TASK(_ds);
            }

            errori = string.Empty;
            cicli = new List<Ciclo>();

            try
            {
                string messaggioErrore = string.Empty;
                Cursor.Current = Cursors.WaitCursor;

                List<Nodo> righeConAnagrafica = Nodi.Where(x => !string.IsNullOrEmpty(x.Anagrafica)).OrderByDescending(x => x.ID).ToList();
                if (righeConAnagrafica.Count == 0)
                {
                    txtMsgCicli.Text = "Nessuna anagrafica trovata";
                    errori = txtMsgCicli.Text;
                    return;
                }

                int idInizioCiclo = 0;
                int profondita = 0;
                foreach (Nodo riga in righeConAnagrafica)
                {
                    if (idInizioCiclo == 0)
                    {
                        idInizioCiclo = riga.ID;
                        profondita = riga.Profondita;
                    }
                    else if (idInizioCiclo > 0)
                    {
                        if (riga.Profondita < profondita)
                        {
                            cicli.Add(new Ciclo(idInizioCiclo, riga.ID, riga.Anagrafica));
                        }
                        idInizioCiclo = riga.ID;
                        profondita = riga.Profondita;
                    }
                }

                foreach (Ciclo c in cicli)
                {
                    int operazione = 10;
                    for (int i = c.Inizio - 1; i >= c.Fine; i--)
                    {
                        Nodo riga = Nodi.Where(x => x.ID == i).FirstOrDefault();
                        if (riga != null)
                        {
                            Fase f = new Fase();
                            f.Operazione = operazione;
                            operazione += 10;
                            f.ID = riga.ID;

                            //if (riga.Reparto.Trim() == "MAG")
                            //    f.AreaProduzione = "TBD";
                            //else
                            f.AreaProduzione = riga.Reparto;
                            f.TempoLavorazione = riga.OrePeriodo;
                            f.Collegamento = riga.CollegamentoCiclo;
                            f.DimensioneLotto = (int)riga.PezziOrari;
                            EstraiProdottiFinitiDS.BC_TASKRow task = _ds.BC_TASK.Where(x => x.CODICEFASE == riga.Fase).FirstOrDefault();
                            if (task == null)
                            {
                                txtMsgCicli.Text = Environment.NewLine + string.Format("   La fase {0} non ha un task associato", riga.Fase);
                                errori += txtMsgCicli.Text;
                                f.Task = "INDEFINITO";
                            }
                            else
                            {
                                f.Task = task.IsTASKNull() ? string.Empty : task.TASK;
                            }
                            //if (!string.IsNullOrEmpty(riga.NoteStandard))
                            //    f.Commenti.Add(riga.NoteStandard);
                            if (!string.IsNullOrEmpty(riga.NoteTecniche))
                                f.Commenti.Add(riga.NoteTecniche);

                            if (task == null)
                                c.Fasi.Add(f);

                            if (task != null && task.TASK != "***ESCLUDERE")
                            {
                                c.Fasi.Add(f);
                            }
                        }
                    }
                }
                ImpaginaMessaggioCicli(cicli);
                btnSalvaCicli.Enabled = true;
            }
            catch (Exception ex)
            {
                txtMsgCicli.Text = ex.Message;
                errori = errori + Environment.NewLine + ex.Message;
                MostraEccezione("Errore in verifica cicli", ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void btnVerificaCicli_Click(object sender, EventArgs e)
        {
            string errori = string.Empty;
            VerificaCicli(out errori);

        }

        private void ImpaginaMessaggioCicli(List<Ciclo> cicli)
        {

            List<string> righe = new List<string>();

            foreach (Ciclo c in cicli)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(c.Codice);
                foreach (Fase f in c.Fasi)
                {
                    sb.AppendLine(string.Format("        {0} {1} {2} {3}", f.Operazione, f.AreaProduzione, f.Task, f.Collegamento));
                    foreach (string commento in f.Commenti)
                    {
                        sb.AppendLine(string.Format("                {0}", commento));

                    }

                }
                sb.AppendLine(string.Empty);
                righe.Add(sb.ToString());
            }

            StringBuilder sbd = new StringBuilder();
            sbd.AppendLine("CICLI");
            sbd.AppendLine("-----");
            for (int i = righe.Count - 1; i >= 0; i--)
                sbd.AppendLine(righe[i]);

            txtMsgCicli.Text = sbd.ToString();
        }

        private void VerificaDistinte(out string errori)
        {
            errori = string.Empty;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var Query = from p in Nodi.GroupBy(p => p.IDPADRE)
                            select new
                            {
                                count = p.Count(),
                                p.First().IDPADRE,
                            };

                var Montaggi = Query.Where(x => x.count > 1);
                List<int> idPadreMontaggi = Montaggi.Select(x => x.IDPADRE).ToList();
                List<Nodo> NodiSenzaAnagrafica = new List<Nodo>();

                foreach (int idpadreDaVerificare in idPadreMontaggi)
                {
                    NodiSenzaAnagrafica.AddRange(Nodi.Where(x => x.IDPADRE == idpadreDaVerificare && string.IsNullOrEmpty(x.Anagrafica)).ToList());
                }

                distinte = new List<Distinta>();

                List<Nodo> righeConAnagrafica = Nodi.Where(x => !string.IsNullOrEmpty(x.Anagrafica)).OrderBy(x => x.ID).ToList();
                if (righeConAnagrafica.Count == 0)
                {
                    txtMsgDistinte.Text = "Nessuna anagrafica trovata";
                    errori = "DISTINTE " + Environment.NewLine + "Nessuna anagrafica trovata";
                    return;
                }

                Nodo riga = righeConAnagrafica.FirstOrDefault();
                int idMax = Nodi.Max(x => x.ID);

                riga.ToUpper();
                int avantiMassimo = Nodi.Max(x => x.Profondita);
                creaDistinta(riga, 1, idMax/*Nodi.Count*/, distinte, righeConAnagrafica, avantiMassimo);

                ImpaginaMessaggioDistinte(distinte, NodiSenzaAnagrafica);
                errori = errori + Environment.NewLine + ImpaginaNodiSenzaAnagrafica(NodiSenzaAnagrafica);

                btnSalvaDistinte.Enabled = true;

            }
            catch (Exception ex)
            {
                txtMsgDistinte.Text = ex.Message;
                MostraEccezione("Errore in verifica distinte", ex);

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void btnVerificaDistinte_Click(object sender, EventArgs e)
        {
            string errori = string.Empty;
            VerificaDistinte(out errori);
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

        private string ImpaginaNodiSenzaAnagrafica(List<Nodo> nodiSenzaAnagrafica)
        {
            StringBuilder sb = new StringBuilder();
            if (nodiSenzaAnagrafica.Count > 0)
            {

                sb.AppendLine("DISTINTE: NODI SENZA ANAGRAFICA");
                sb.AppendLine("-------------------------------");
                foreach (Nodo n in nodiSenzaAnagrafica)
                {
                    sb.AppendLine(n.Modello);
                    sb.AppendLine(String.Empty);
                }
            }
            return sb.ToString();

        }

        private void ImpaginaMessaggioDistinte(List<Distinta> distinte, List<Nodo> nodiSenzaAnagrafica)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ImpaginaNodiSenzaAnagrafica(nodiSenzaAnagrafica));

            sb.AppendLine("DISTINTA");
            sb.AppendLine("--------");

            foreach (Distinta d in distinte)
            {
                sb.AppendLine(d.Codice);
                foreach (Componente c in d.Componenti)
                {
                    sb.AppendLine(string.Format("        {0} {1} {2}", c.Anagrafica, c.Quantita, c.CodiceUM));

                }
                sb.AppendLine(string.Empty);
            }

            txtMsgDistinte.Text = sb.ToString();
        }

        private void btnSalvaCicli_Click(object sender, EventArgs e)
        {
            salvaCicli();

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
            sfd.DefaultExt = "xlsx";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.Cancel) return;

            string pathCompleto = sfd.FileName;

            if (File.Exists(pathCompleto))
                File.Delete(pathCompleto);

            string errori = string.Empty;
            FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ExcelHelper hExcel = new ExcelHelper();
                byte[] filedata = hExcel.CreaFileFaseCicli(cicli, out errori);

                fs.Write(filedata, 0, filedata.Length);
                fs.Flush();
                fs.Close();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore nel creare il file", ex);
                Cursor.Current = Cursors.Default;

            }
            finally
            {
                fs.Close();
            }

        }

        private void salvaCicli()
        {
            using (EstraiProdottiFinitiBusiness bEstrai = new EstraiProdottiFinitiBusiness())
            {
                salvaNodi();
                foreach (Ciclo c in cicli)
                {
                    _ds.BC_COM_CICLO.Clear();
                    _ds.BC_DETTAGLIO_CICLO.Clear();

                    bEstrai.GetBC_COM_CICLO(_ds, c.Codice, chkTest.Checked);
                    bEstrai.GetBC_DETTAGLIO_CICLO(_ds, c.Codice, chkTest.Checked);

                    foreach (EstraiProdottiFinitiDS.BC_COM_CICLORow riga in _ds.BC_COM_CICLO)
                        riga.Delete();

                    foreach (EstraiProdottiFinitiDS.BC_DETTAGLIO_CICLORow riga in _ds.BC_DETTAGLIO_CICLO)
                        riga.Delete();

                    foreach (Fase f in c.Fasi)
                    {
                        EstraiProdottiFinitiDS.BC_DETTAGLIO_CICLORow dettaglioCiclo = _ds.BC_DETTAGLIO_CICLO.NewBC_DETTAGLIO_CICLORow();

                        dettaglioCiclo.NRCICLO = c.Codice;
                        dettaglioCiclo.VERSIONE = f.Versione;
                        dettaglioCiclo.OPERAZIONE = f.Operazione;
                        dettaglioCiclo.TIPO = f.Tipo;
                        dettaglioCiclo.NR = f.AreaProduzione;
                        dettaglioCiclo.TEMPO_DI_SETUP = f.TempoSetup;
                        dettaglioCiclo.TEMPO_LAVORAZIONE = f.TempoLavorazione;
                        dettaglioCiclo.TEMPO_ATTESA = f.TempoAttesa;
                        dettaglioCiclo.TEMPO_SPOSTAMENTO = f.TempoSpostamento;
                        dettaglioCiclo.DIMENSIONE_LOTTO = f.DimensioneLotto;
                        dettaglioCiclo.UM_SETUP = f.UMSetup;
                        dettaglioCiclo.UM_LAVORAZ = f.UMLavorazione;
                        dettaglioCiclo.UM_ATTESA = f.UMAttesa;
                        dettaglioCiclo.UM_SPOSTAMENTO = f.UMSpostamento;
                        dettaglioCiclo.COLLEGAMENTO = f.Collegamento;
                        dettaglioCiclo.TASK = f.Task;
                        dettaglioCiclo.CONDIZIONE = f.Condizione;
                        dettaglioCiclo.CARATTERISTICA = f.Caratteristica;
                        dettaglioCiclo.LOGICHE = f.LogicheLavorazione;
                        dettaglioCiclo.DATAINSERIMENTO = DateTime.Now;

                        _ds.BC_DETTAGLIO_CICLO.AddBC_DETTAGLIO_CICLORow(dettaglioCiclo);


                        int numeroRiga = 1000;
                        foreach (string commento in f.Commenti)
                        {
                            EstraiProdottiFinitiDS.BC_COM_CICLORow comCiclo = _ds.BC_COM_CICLO.NewBC_COM_CICLORow();
                            comCiclo.CICLO = c.Codice;
                            comCiclo.VERSIONE = string.Empty;
                            comCiclo.OPERAZIONE = f.Operazione;
                            comCiclo.RIGA = numeroRiga;
                            comCiclo.DATA = DateTime.Today.ToShortDateString();
                            comCiclo.COMMENTO = commento;
                            comCiclo.DATAINSERIMENTO = DateTime.Now;
                            _ds.BC_COM_CICLO.AddBC_COM_CICLORow(comCiclo);
                            numeroRiga += 1000;
                        }
                    }
                    if (chkTest.Checked)
                    {
                        bEstrai.UpdateTable(_ds.BC_COM_CICLO.TableName, _ds, "BC_COM_CICLO");
                        bEstrai.UpdateTable(_ds.BC_DETTAGLIO_CICLO.TableName, _ds, "BC_DETTAGLIO_CICLO");
                    }
                    else
                    {
                        bEstrai.UpdateTable(_ds.BC_COM_CICLO.TableName, _ds, "BC_COM_CICLO_PRODUZIONE");
                        bEstrai.UpdateTable(_ds.BC_DETTAGLIO_CICLO.TableName, _ds, "BC_DETTAGLIO_CICLO_PRODUZIONE");

                    }
                }

            }


        }

        private void salvaDistinte()
        {
            using (EstraiProdottiFinitiBusiness bEstrai = new EstraiProdottiFinitiBusiness())
            {
                salvaNodi();
                foreach (Distinta d in distinte)
                {
                    _ds.BC_DISTINTA.Clear();

                    bEstrai.GetBC_DISTINTA(_ds, d.Codice, chkTest.Checked);

                    foreach (EstraiProdottiFinitiDS.BC_DISTINTARow riga in _ds.BC_DISTINTA)
                        riga.Delete();

                    int numeroRiga = 1000;
                    foreach (Componente c in d.Componenti)
                    {
                        EstraiProdottiFinitiDS.BC_DISTINTARow distinta = _ds.BC_DISTINTA.NewBC_DISTINTARow();

                        distinta.DIBA = d.Codice;
                        distinta.VERSIONE = d.Versione;
                        distinta.RIGA = numeroRiga;
                        numeroRiga += 1000;
                        distinta.TIPO = c.Tipo;
                        distinta.NR = c.Anagrafica;
                        distinta.DESCRIZIONE = c.Descrizione;
                        distinta.UM = c.CodiceUM;
                        distinta.QUANTITA = c.Quantita;
                        distinta.COLLEGAMENTO = c.Collegamento;
                        distinta.SCARTO = c.Scarto;
                        distinta.QUANTITA_PER = c.Quantita;
                        distinta.PRECIOUS_QUANTITY = c.Arrotondamento;
                        distinta.FORMULA_QUANTITA = c.FormulaQuantita;
                        distinta.CODICE_CONDIZIONE = c.Condizione;
                        distinta.ARTICOLO_NEUTRO = c.ArticoloNeutro;
                        distinta.FORMULA = c.Formula;
                        distinta.DATAINSERIMENTO = DateTime.Now;


                        _ds.BC_DISTINTA.AddBC_DISTINTARow(distinta);
                    }

                    if (chkTest.Checked)
                        bEstrai.UpdateTable(_ds.BC_DISTINTA.TableName, _ds, "BC_DISTINTA");
                    else
                        bEstrai.UpdateTable(_ds.BC_DISTINTA.TableName, _ds, "BC_DISTINTA_PRODUZIONE");

                }

            }


        }
        private void btnSalvaDistinte_Click(object sender, EventArgs e)
        {
            salvaDistinte();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
            sfd.DefaultExt = "xlsx";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.Cancel) return;

            string pathCompleto = sfd.FileName;

            if (File.Exists(pathCompleto))
                File.Delete(pathCompleto);

            FileStream fs = new FileStream(pathCompleto, FileMode.Create);
            string errori = string.Empty;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ExcelHelper hExcel = new ExcelHelper();
                byte[] filedata = hExcel.CreaFileCompoentiDistinta(distinte, out errori);
                fs.Write(filedata, 0, filedata.Length);
                fs.Flush();
                fs.Close();

            }
            catch (Exception ex)
            {
                MostraEccezione("Errore nel creare il file", ex);
                Cursor.Current = Cursors.Default;

            }
            finally
            {
                fs.Close();
            }
        }

        private void dgvNodi_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridViewComboBoxCell boxCiclo = dgvNodi.Rows[e.RowIndex].Cells[COLLEGAMENTOCICLO.Name] as DataGridViewComboBoxCell;
            if (boxCiclo != null)
                boxCiclo.DataSource = Collegamenti;
            DataGridViewComboBoxCell boxDistinta = dgvNodi.Rows[e.RowIndex].Cells[COLLEGAMENTODIBA.Name] as DataGridViewComboBoxCell;
            if (boxDistinta != null)
                boxDistinta.DataSource = Collegamenti;
        }

        private void btnVerifica_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string errori = string.Empty;
                VerificaAnagrafiche();

                sb.AppendLine("**** VERIFICA CICLI ****");
                VerificaCicli(out errori);
                if (errori.Trim().Length > 0)
                    sb.AppendLine(errori);

                sb.AppendLine("**** VERIFICHE DISTINTE ****");
                VerificaDistinte(out errori);
                if (errori.Trim().Length > 0)
                    sb.AppendLine(errori);

                sb.AppendLine("**** VERIFICA ANAGRAFICHE ORFANE ****");
                sb.AppendLine(VerificaAnagraficheOrfane());


                sb.AppendLine("**** VERIFICHE COLLEGAMENTO ****");
                sb.AppendLine(InserisciCodiciCollegamento());
                txtNotifiche.Text = sb.ToString();

                tabControl1.SelectedTab = tabPage5;

                dgvNodi.Update();
                dgvNodi.Refresh();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore nel creare il file", ex);
                Cursor.Current = Cursors.Default;

            }
        }

        private string VerificaAnagraficheOrfane()
        {
            StringBuilder sb = new StringBuilder();
            List<Nodo> righeConAnagrafica = Nodi.Where(x => !string.IsNullOrEmpty(x.Anagrafica)).OrderBy(x => x.ID).ToList();

            List<Componente> componenti = EstraiComponenti();

            foreach (Nodo n in righeConAnagrafica)
            {
                if (!distinte.Any(x => x.Codice == n.Anagrafica))
                {
                    if (!componenti.Any(x => x.Anagrafica == n.Anagrafica))
                        sb.AppendLine(n.Anagrafica);
                }

            }
            return sb.ToString();
        }

        private List<Componente> EstraiComponenti()
        {
            List<Componente> componenti = new List<Componente>();
            foreach (Distinta d in distinte)
                componenti.AddRange(d.Componenti);
            return componenti;
        }

        private string InserisciCodiciCollegamento()
        {
            StringBuilder sb = new StringBuilder();

            List<Componente> componenti = EstraiComponenti();

            foreach (Distinta d in distinte)
            {
                Ciclo c = cicli.Where(x => x.Codice == d.Codice).FirstOrDefault();
                if (c == null && !componenti.Any(x => x.Anagrafica == d.Codice))
                {
                    sb.AppendLine(string.Format("ERRORE: impossibile trovare il ciclo per la seguente distinta {0}", d.Codice));
                    continue;
                }

                if (c == null) continue;

                if (c.Fasi.Count == 0)
                {
                    sb.AppendLine(string.Format("ERRORE: il ciclo {0} non ha alcuna fase", c.Codice));
                    continue;
                }

                Fase f = c.Fasi.OrderBy(x => x.Operazione).FirstOrDefault();
                foreach (Componente comp in d.Componenti)
                {
                    comp.Collegamento = Ciclo.CodiceStandard;
                    Nodo n = Nodi.Where(x => x.ID == comp.ID).FirstOrDefault();
                    if (n == null)
                    {
                        sb.AppendLine(string.Format("ERRORE: impossibile trovare il nodo associato al componente {0} ", comp.Anagrafica));
                        continue;
                    }
                    n.CollegamentoDiba = Ciclo.CodiceStandard;
                }
                f.Collegamento = Ciclo.CodiceStandard;

                Nodo nCiclo = Nodi.Where(x => x.ID == f.ID).FirstOrDefault();
                if (nCiclo == null)
                {
                    sb.AppendLine(string.Format("ERRORE: impossibile trovare il nodo associato alla fase {0} del ciclo {1}", f.AreaProduzione, c.Codice));
                    continue;
                }
                nCiclo.CollegamentoCiclo = Ciclo.CodiceStandard;
            }

            return sb.ToString();

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

        private void btnContoLavoro_Click(object sender, EventArgs e)
        {

            List<Nodo> nodiFornitiDaCommittente = Nodi.Where(x => x.FornitoDaCommittente == "S").ToList();

            TreeNode root = tvDiBa.Nodes[0];

            foreach (Nodo n in nodiFornitiDaCommittente)
            {
                bool esito = TrovaNodoContolavoroAlbero(n, root);
            }
            foreach (Nodo nodoContoLavoro in Nodi.Where(x => x.ContoLavoro))
            {
                string anagrafica = nodoContoLavoro.Anagrafica;
                if (!string.IsNullOrEmpty(anagrafica) && anagrafica.Length > 10)
                {
                    anagrafica = anagrafica.Insert(5, "7");
                    anagrafica = anagrafica.Remove(6, 1);
                    nodoContoLavoro.Anagrafica = anagrafica;
                }
                if (string.IsNullOrEmpty(anagrafica) && !string.IsNullOrEmpty(nodoContoLavoro.IDMAGAZZ))
                {
                    EstraiProdottiFinitiDS.BC_ANAGRAFICARow rigaAnagarficaContoLavoro = _ds.BC_ANAGRAFICA.Where(x => x.RowState != DataRowState.Deleted && x.IDMAGAZZ == nodoContoLavoro.IDMAGAZZ && x.CL == 1).FirstOrDefault();
                    if (rigaAnagarficaContoLavoro != null)
                        nodoContoLavoro.Anagrafica = rigaAnagarficaContoLavoro.BC;
                }

                //              nodoContoLavoro.Reparto = nodoContoLavoro.Reparto;

            }

            foreach (DataGridViewRow riga in dgvNodi.Rows)
            {
                if (riga.Cells[ContoLavoro.Name].Value is bool)
                {
                    bool contoLavoro = (bool)riga.Cells[ContoLavoro.Name].Value;
                    if (contoLavoro)
                    {
                        string idmagazz = riga.Cells[IDMAGAZZ.Name].Value.ToString();
                        if (_ds.BC_ANAGRAFICA.Any(x => x.RowState != DataRowState.Deleted && x.IDMAGAZZ == idmagazz && x.CL == 1))
                            riga.DefaultCellStyle.ForeColor = Color.ForestGreen;
                        else
                            riga.DefaultCellStyle.ForeColor = Color.Red;

                    }
                }

            }

            dgvNodi.Update();
            dgvNodi.Refresh();
        }

        private void EstraiProdottoFinito_Load(object sender, EventArgs e)
        {
        }

        private void btnSalvaTutto_Click(object sender, EventArgs e)
        {
            try
            {
                VerificaAnagrafiche();
                salvaAnagrafiche();
                salvaNodi();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in salva nodi e anagrafiche", ex);
            }
        }
    }
}

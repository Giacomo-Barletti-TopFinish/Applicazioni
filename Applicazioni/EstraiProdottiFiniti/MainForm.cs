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

        public EstraiProdottoFinito()
        {
            InitializeComponent();
        }

        private void DisabilitaPulsanti()
        {
            btnSalvaAnagrafiche.Enabled = false;
            btnSalvaCicli.Enabled = false;
            btnSalvaDistinte.Enabled = false;
        }

        private void btnCercaDiBa_Click(object sender, EventArgs e)
        {
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
                if (_ds.USR_PRD_TDIBA.Rows.Count > 1)
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
                    IDTDIBA = riga.IDTDIBA;

                    txtNoteStd.Text = riga.NOTESTD;
                    txtVersioneDiBa.Text = riga.NOTETECH;
                    modello = riga.MODELLO;
                }
                this.Text = string.Format("{0} {1}", this.Text, modello);

                Nodi = new List<Nodo>();
                _ds.USR_PRD_TDIBA.Clear();
                _ds.USR_PRD_RDIBA.Clear();
                _ds.MAGAZZ.Clear();
                _ds.BC_ANAGRAFICA.Clear();
                _ds.TABFAS.Clear();

                bEstrai.FillBC_ANAGRAFICA(_ds);
                bEstrai.FillTABFAS(_ds);

                int idNodo = 1;
                int profondita = 1;
                EstraiDistintaBase(bEstrai, IDTDIBA, profondita, ref idNodo, -1, 1, 0, string.Empty, string.Empty, "N");
                CreaAlbero();
                PopolaGrigliaNodi();

            }
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
            string noteTecniche, string noteStandard, string fornitoDaCommittente, string metodo, string versione, string attiva, string controllata)
        {
            EstraiProdottiFinitiDS.MAGAZZRow magazz = _ds.MAGAZZ.Where(x => x.IDMAGAZZ == idmagazz).FirstOrDefault();
            EstraiProdottiFinitiDS.TABFASRow fase = _ds.TABFAS.Where(x => x.IDTABFAS == IDTABFAS).FirstOrDefault();

            EstraiProdottiFinitiDS.BC_ANAGRAFICARow anagrafica = _ds.BC_ANAGRAFICA.Where(x => x.IDMAGAZZ == idmagazz).FirstOrDefault();


            string reparto = fase.IsCODICECLIFOPREDFASENull() ? string.Empty : fase.CODICECLIFOPREDFASE;
            Nodo n = new Nodo();
            n.Anagrafica = (anagrafica != null) ? anagrafica.BC : string.Empty; ;
            n.ID = idNodo;
            n.Profondita = profondita;
            n.IDPADRE = idpadre;
            n.IDMAGAZZ = idmagazz;

            decimal quantita = 0;
            if (quantitaOccorrenza == 0) quantita = quantitaConsumo;
            else quantita = 1 / quantitaOccorrenza;

            n.QuantitaConsumo = quantitaConsumo;
            n.QuantitaOccorrenza = quantitaOccorrenza;
            n.Quantita = quantita;

            n.Reparto = reparto;
            n.Fase = fase.CODICEFASE;
            n.Peso = magazz.PESO;
            n.Superficie = magazz.SUPERFICIE;
            n.FornitoDaCommittente = fornitoDaCommittente;
            n.NoteStandard = noteStandard;
            n.NoteTecniche = noteTecniche;
            n.Modello = (magazz == null) ? string.Empty : magazz.MODELLO;
            n.DescrizioneArticolo = (magazz == null) ? string.Empty : magazz.DESMAGAZZ;
            n.Metodo = metodo;
            n.Versione = versione;
            n.Attiva = attiva;
            n.Controllata = n.Controllata;
            return n;
        }
        private void EstraiDistintaBase(EstraiProdottiFinitiBusiness bEstrai, string IDTDIBA, int profondita, ref int idNodo, int idPadre, decimal quantitaConsumo,
            decimal quantitaOccorrenza, string noteTecniche, string noteStandard, string fornitoDaCommittente)
        {
            bEstrai.GetUSR_PRD_TDIBA(_ds, IDTDIBA);
            EstraiProdottiFinitiDS.USR_PRD_TDIBARow testata = _ds.USR_PRD_TDIBA.Where(x => x.IDTDIBA == IDTDIBA).FirstOrDefault();
            if (testata != null)
            {
                bEstrai.GetMAGAZZ(_ds, testata.IDMAGAZZ);
                string reparto = testata.IsCODICECLIFOPRDNull() ? string.Empty : testata.CODICECLIFOPRD;

                noteTecniche = testata.IsNOTETECHNull() ? string.Empty : testata.NOTETECH;
                noteStandard = testata.IsNOTESTDNull() ? string.Empty : testata.NOTESTD;

                Nodo n = CreaNodo(idNodo, testata.IDMAGAZZ, profondita, idPadre, quantitaConsumo, quantitaOccorrenza, testata.IDTABFAS, noteTecniche, noteStandard, fornitoDaCommittente,
                    testata.METODO, testata.VERSION.ToString(), testata.ACTIVESN, testata.CHECKSN);
                Nodi.Add(n);
                idNodo++;
                bEstrai.GetUSR_PRD_RDIBA(_ds, IDTDIBA);
                List<EstraiProdottiFinitiDS.USR_PRD_RDIBARow> componenti = _ds.USR_PRD_RDIBA.Where(x => x.IDTDIBA == IDTDIBA).ToList();
                if (componenti.Count > 0) profondita++;

                foreach (EstraiProdottiFinitiDS.USR_PRD_RDIBARow componente in componenti)
                {
                    string nTech = componente.IsNOTETECHNull() ? string.Empty : componente.NOTETECH;
                    string nStad = componente.IsNOTESTDNull() ? string.Empty : componente.NOTESTD;
                    if (!componente.IsIDTDIBAIFFASENull())
                        EstraiDistintaBase(bEstrai, componente.IDTDIBAIFFASE, profondita, ref idNodo, n.ID, componente.QTACONSUMO, componente.QTAOCCORRENZA, nTech, nStad, componente.CVENSN);
                    else
                    {
                        bEstrai.GetMAGAZZ(_ds, componente.IDMAGAZZ);
                        Nodi.Add(CreaNodo(idNodo, componente.IDMAGAZZ, profondita, n.ID, componente.QTACONSUMO, componente.QTAOCCORRENZA, testata.IDTABFAS, noteTecniche, noteStandard, componente.CVENSN,
                            testata.METODO, testata.VERSION.ToString(), testata.ACTIVESN, testata.CHECKSN));
                        idNodo++;
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

        private void btnVerificaAnagrafiche_Click(object sender, EventArgs e)
        {
            try
            {
                string messaggioErrore = string.Empty;

                List<Nodo> nodiConAnagrafiche = Nodi.Where(x => !string.IsNullOrEmpty(x.Anagrafica)).ToList();

                List<string> anagraficheCensite = new List<string>();
                List<string> anagraficheModificate = new List<string>();
                List<string> anagraficheNuove = new List<string>();
                foreach (Nodo nodoConAnagrafica in nodiConAnagrafiche.Where(x => !string.IsNullOrEmpty(x.IDMAGAZZ)))
                {
                    nodoConAnagrafica.ToUpper();
                    EstraiProdottiFinitiDS.BC_ANAGRAFICARow riga = _ds.BC_ANAGRAFICA.Where(x => x.IDMAGAZZ == nodoConAnagrafica.IDMAGAZZ).FirstOrDefault();
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
            }
        }

        private void btnSalvaAnagrafiche_Click(object sender, EventArgs e)
        {
            //foreach (Nodo n in Nodi)
            //    _ds.BC_ANAGRAFICA.AddBC_ANAGRAFICARow(n.CreaRigaTabella(_ds));
            using (EstraiProdottiFinitiBusiness bEstrai = new EstraiProdottiFinitiBusiness())
            {
                bEstrai.UpdateTable(_ds.BC_ANAGRAFICA.TableName, _ds);
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

        private void btnVerificaCicli_Click(object sender, EventArgs e)
        {
            cicli = new List<Ciclo>();

            try
            {
                string messaggioErrore = string.Empty;

                List<Nodo> righeConAnagrafica = Nodi.Where(x => !string.IsNullOrEmpty(x.Anagrafica)).OrderByDescending(x => x.ID).ToList();
                if (righeConAnagrafica.Count == 0)
                {
                    txtMsgCicli.Text = "Nessuna anagrafica trovata";
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

                            f.AreaProduzione = riga.Reparto;
                            f.TempoLavorazione = riga.PezziOrari > 0 ? 1 / riga.PezziOrari : 0;
                            f.Collegamento = riga.CollegamentoCiclo;
                            f.Task = riga.Fase;
                            if (!string.IsNullOrEmpty(riga.NoteStandard))
                                f.Commenti.Add(riga.NoteStandard);
                            if (!string.IsNullOrEmpty(riga.NoteTecniche))
                                f.Commenti.Add(riga.NoteTecniche);
                            c.Fasi.Add(f);
                        }
                    }
                }
                ImpaginaMessaggioCicli(cicli);
                btnSalvaCicli.Enabled = true;
            }
            catch (Exception ex)
            {
                txtMsgCicli.Text = ex.Message;

            }
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

        private void btnVerificaDistinte_Click(object sender, EventArgs e)
        {
            var Query = from p in Nodi.GroupBy(p => p.IDPADRE)
                        select new
                        {
                            count = p.Count(),
                            p.First().IDPADRE,
                        };

            var Montaggi = Query.Where(x => x.count > 1);
            List<int> idPadreMOntaggi = Montaggi.Select(x => x.IDPADRE).ToList();
            List<Nodo> NodiSenzaAnagrafica = new List<Nodo>();

            foreach (int idpadreDaVerificare in idPadreMOntaggi)
            {
                NodiSenzaAnagrafica.AddRange(Nodi.Where(x => x.IDPADRE == idpadreDaVerificare && string.IsNullOrEmpty(x.Anagrafica)).ToList());
            }


            distinte = new List<Distinta>();
            try
            {

                List<Nodo> righeConAnagrafica = Nodi.Where(x => !string.IsNullOrEmpty(x.Anagrafica)).OrderBy(x => x.ID).ToList();
                if (righeConAnagrafica.Count == 0)
                {
                    txtMsgDistinte.Text = "Nessuna anagrafica trovata";
                    return;
                }

                Nodo riga = righeConAnagrafica.FirstOrDefault();

                riga.ToUpper();
                int avantiMassimo = Nodi.Max(x => x.Profondita);
                creaDistinta(riga, 1, Nodi.Count, distinte, righeConAnagrafica, avantiMassimo);

                ImpaginaMessaggioDistinte(distinte, NodiSenzaAnagrafica);
                btnSalvaDistinte.Enabled = true;

            }
            catch (Exception ex)
            {
                txtMsgDistinte.Text = ex.Message;
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

                righeFiglie = righeConAnagrafica.Where(x => x.Profondita == riga.Profondita + indice && x.ID > indiceMinimo && x.ID < indiceMassimo).ToList();
            } while (righeFiglie.Count == 0);

            List<Componente> componenti = new List<Componente>();
            righeFiglie.ForEach(x => componenti.Add(new Componente(x.Anagrafica, x.Quantita, x.CollegamentoDiba)));

            distinte.Add(new Distinta(riga.Anagrafica, componenti));

            for (int i = 0; i < righeFiglie.Count; i++)
            {
                if (i < righeFiglie.Count - 1)
                    creaDistinta(righeFiglie[i], righeFiglie[i].ID, righeFiglie[i + 1].ID, distinte, righeConAnagrafica, avantiMassimo);
                else
                    creaDistinta(righeFiglie[i], righeFiglie[i].ID, indiceMassimo, distinte, righeConAnagrafica, avantiMassimo);
            }

        }

        private void ImpaginaMessaggioDistinte(List<Distinta> distinte, List<Nodo> nodiSenzaAnagrafica)
        {

            StringBuilder sb = new StringBuilder();
            if (nodiSenzaAnagrafica.Count > 0)
            {

                sb.AppendLine("NODI SENZA ANAGRAFICA");
                sb.AppendLine("---------------------");
                foreach (Nodo n in nodiSenzaAnagrafica)
                {
                    sb.AppendLine(n.Modello);
                    sb.AppendLine(String.Empty);
                }
            }

            sb.AppendLine("DISTINTA");
            sb.AppendLine("--------");

            foreach (Distinta d in distinte)
            {
                sb.AppendLine(d.Codice);
                foreach (Componente c in d.Componenti)
                {
                    sb.AppendLine(string.Format("        {0} {1} ", c.Anagrafica, c.Quantita));

                }
                sb.AppendLine(string.Empty);
            }

            txtMsgDistinte.Text = sb.ToString();
        }

        private void btnSalvaCicli_Click(object sender, EventArgs e)
        {
            foreach (Ciclo c in cicli)
            {
                // salva database

            }

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
                ExcelHelper hExcel = new ExcelHelper();
                byte[] filedata = hExcel.CreaFileFaseCicli(cicli, out errori);

                fs.Write(filedata, 0, filedata.Length);
                fs.Flush();
                fs.Close();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore nel creare il file", ex);
            }
            finally
            {
                fs.Close();
            }

        }

        private void btnSalvaDistinte_Click(object sender, EventArgs e)
        {

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
                ExcelHelper hExcel = new ExcelHelper();
                byte[] filedata = hExcel.CreaFileCompoentiDistinta(distinte, out errori);
                fs.Write(filedata, 0, filedata.Length);
                fs.Flush();
                fs.Close();

            }
            catch (Exception ex)
            {
                MostraEccezione("Errore nel creare il file", ex);
            }
            finally
            {
                fs.Close();
            }
        }
    }
}

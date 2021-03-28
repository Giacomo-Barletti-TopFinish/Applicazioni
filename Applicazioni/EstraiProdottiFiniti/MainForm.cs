using Applicazioni.Data.EstraiProdottiFiniti;
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

namespace EstraiProdottiFiniti
{
    public partial class EstraiProdottoFinito : Form
    {
        private EstraiProdottiFinitiDS _ds = new EstraiProdottiFinitiDS();
        private List<Nodo> Nodi = new List<Nodo>();
        public EstraiProdottoFinito()
        {
            InitializeComponent();
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
                bEstrai.GetUSR_PRD_TDIBAByModello(_ds, txtArticolo.Text);
                if (_ds.USR_PRD_TDIBA.Rows.Count > 1)
                {
                    SelezionaDIbaFrm frm = new SelezionaDIbaFrm();
                    frm.estraiProdottiFinitiDS1 = _ds;
                    frm.ShowDialog();

                    string IDTDIBA = frm.IDTDIBA;
                    if (string.IsNullOrEmpty(IDTDIBA)) return;

                    Nodi = new List<Nodo>();
                    _ds.USR_PRD_TDIBA.Clear();
                    _ds.USR_PRD_RDIBA.Clear();
                    _ds.MAGAZZ.Clear();
                    _ds.BC_ANAGRAFICA.Clear();

                    bEstrai.FillBC_ANAGRAFICA(_ds);
                    int idNodo = 1;
                    int profondita = 1;
                    EstraiDistintaBase(bEstrai, IDTDIBA, profondita, ref idNodo, -1);
                    CreaAlbero();
                    PopolaGrigliaNodi();
                }
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

        private void AggiungiRamo(TreeNode root,int IDPADRE)
        {
            List<Nodo> rami = Nodi.Where(x => x.IDPADRE == IDPADRE).ToList();

            foreach (Nodo n in rami)
            {
                TreeNode nodoPadre = root.Nodes.Add(n.ToString());
                nodoPadre.Tag = n;
                AggiungiRamo(nodoPadre, n.ID);
            }
        }

        private Nodo CreaNodo(int idNodo, string idmagazz, int profondita, int idpadre)
        {
            EstraiProdottiFinitiDS.MAGAZZRow magazz = _ds.MAGAZZ.Where(x => x.IDMAGAZZ == idmagazz).FirstOrDefault();
            Nodo n = new Nodo();
            n.Anagrafica = string.Empty;
            n.ID = idNodo;
            n.Profondita = profondita;
            n.IDPADRE = idpadre;
            n.IDMAGAZZ = idmagazz;
            n.Modello = (magazz == null) ? string.Empty : magazz.MODELLO;
            return n;
        }
        private void EstraiDistintaBase(EstraiProdottiFinitiBusiness bEstrai, string IDTDIBA, int profondita, ref int idNodo, int idPadre)
        {
            bEstrai.GetUSR_PRD_TDIBA(_ds, IDTDIBA);
            EstraiProdottiFinitiDS.USR_PRD_TDIBARow testata = _ds.USR_PRD_TDIBA.Where(x => x.IDTDIBA == IDTDIBA).FirstOrDefault();
            if (testata != null)
            {
                bEstrai.GetMAGAZZ(_ds, testata.IDMAGAZZ);
                Nodo n = CreaNodo(idNodo, testata.IDMAGAZZ, profondita, idPadre);
                Nodi.Add(n);
                idNodo++;
                bEstrai.GetUSR_PRD_RDIBA(_ds, IDTDIBA);
                List<EstraiProdottiFinitiDS.USR_PRD_RDIBARow> componenti = _ds.USR_PRD_RDIBA.Where(x => x.IDTDIBA == IDTDIBA).ToList();
                if (componenti.Count > 0) profondita++;

                foreach (EstraiProdottiFinitiDS.USR_PRD_RDIBARow componente in componenti)
                {
                    if (!componente.IsIDTDIBAIFFASENull())
                        EstraiDistintaBase(bEstrai, componente.IDTDIBAIFFASE, profondita, ref idNodo, n.ID);
                    else
                    {
                        bEstrai.GetMAGAZZ(_ds, componente.IDMAGAZZ);
                        Nodi.Add(CreaNodo(idNodo, componente.IDMAGAZZ, profondita, n.ID));
                        idNodo++;
                    }
                }
            }

        }

        private void tvDiBa_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Nodo n = (Nodo)e.Node.Tag;
            int ID = n.ID;

            foreach(DataGridViewRow riga in dgvNodi.Rows)
            {

                int IDRiga = (int)riga.Cells[0].Value;
                if(IDRiga==ID)
                    riga.DefaultCellStyle.BackColor = Color.Yellow;
                else
                    riga.DefaultCellStyle.BackColor = Color.White;
            }

        }
    }
}

using Applicazioni.Common;
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

    public partial class DiBaForm : BaseForm
    {
        public DiBaForm()
        {
            InitializeComponent();
        }

        private void cascataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void organizzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void apriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EstraiProdottoFinito form = new EstraiProdottoFinito();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                base.MostraEccezione(ex, "Errore in apertura finestra");
            }
        }

        private void DiBaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.MdiChildren.Count() > 0)
                {
                    foreach (Form f in MdiChildren)
                        f.Close();
                }

            }
            catch (Exception ex)
            {
                base.MostraEccezione(ex, "Errore in chiusura applicazione");
            }
        }

        private void mIgrazioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MigrazioneFrm form = new MigrazioneFrm();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                base.MostraEccezione(ex, "Errore in apertura finestra");
            }
        }
    }
}

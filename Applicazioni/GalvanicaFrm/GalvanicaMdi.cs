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

namespace GalvanicaFrm
{
    public partial class GalvanicaMdi : BaseForm
    {
        public GalvanicaMdi()
        {
            InitializeComponent();
        }

        private void odiernoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MdiChildren.Count() > 0)
            {
                foreach (Form f in MdiChildren)
                {
                    if (f is GalvanicaFrm) return;
                }
            }

            GalvanicaFrm form = new GalvanicaFrm();
            form.MdiParent = this;            
            form.Show();
        }

        private void GalvanicaMdi_Load(object sender, EventArgs e)
        {
        }

        private void storicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StoricoFrm form = new StoricoFrm();
            form.MdiParent = this;
 
           form.Show();
        }

        private void GalvanicaMdi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MdiChildren.Count() > 0)
            {
                foreach (Form f in MdiChildren)
                {
                    f.Close();
                }
            }
        }

        private void cascataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);

        }

        private void orizzontaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
    }
}

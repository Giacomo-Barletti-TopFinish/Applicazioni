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

namespace Preventivatore
{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();
            AbilitaMenu();
            stUser.Text = _contesto.Utente.DisplayName;
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

       

        private void AbilitaMenu()
        {
            DisabilitaElementiMenu(mainMenu.Items, true);
            loginToolStripMenuItem.Enabled = false;
            exitToolStripMenuItem.Enabled = true;
            fileToolStripMenuItem.Enabled = true;

            anagraficaToolStripMenuItem.Enabled = _contesto.Utente.PreventivatoreAnagrafiche;
            distintaBaseToolStripMenuItem.Enabled = _contesto.Utente.PreventivatoreDistinteBase;
            costiToolStripMenuItem.Enabled = _contesto.Utente.PreventivatoreCosti;

        }

        private void DisabilitaElementiMenu(ToolStripItemCollection elementi, bool abilita)
        {
            foreach (ToolStripItem elemento in elementi)
            {
                if (elemento is ToolStripMenuItem)
                {
                    (elemento as ToolStripMenuItem).Enabled = abilita;
                    if ((elemento as ToolStripMenuItem).DropDownItems.Count > 0)
                    {
                        DisabilitaElementiMenu((elemento as ToolStripMenuItem).DropDownItems, abilita);
                    }
                }

            }
        }

        private void materialiToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
    }
}

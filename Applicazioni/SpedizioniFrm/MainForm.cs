﻿using Applicazioni.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpedizioniFrm
{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();
            AbilitaMenu();
            stUser.Text = Contesto.Utente.DisplayName;
        }

        private void AbilitaMenu()
        {
            DisabilitaElementiMenu(menuStrip1.Items, true);
            fileToolStripMenuItem.Enabled = true;
            finestreToolStripMenuItem.Enabled = true;

            magazzinoToolStripMenuItem.Enabled = Contesto.Utente.SpedizioniMagazzino;
            saldiToolStripMenuItem.Enabled = Contesto.Utente.SpedizioniSaldi;

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
        private void cascataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void orizzontaleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MdiChildren.Count() > 0)
            {
                foreach (Form f in MdiChildren)
                {
                    f.Close();
                }
            }
        }

        private void cascataToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void orizzontaleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ubicazioniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form figlio in this.MdiChildren)
            {
                if (figlio is UbicazioniFrm)
                {
                    figlio.Focus();
                    return;
                }
            }

            UbicazioniFrm form = new UbicazioniFrm();
            form.MdiParent = this;
            form.Show();
        }

        private void saldiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //foreach (Form figlio in this.MdiChildren)
            //{
            //    if (figlio is SaldiFrm)
            //    {
            //        figlio.Focus();
            //        return;
            //    }
            //}

            SaldiFrm form = new SaldiFrm();
            form.MdiParent = this;
            form.Show();

        }

        private void movimentiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            ListamovimentiFrm form = new ListamovimentiFrm();
            form.MdiParent = this;
            form.Show();
        }

        
    }
}

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

namespace EtichetteMagazzinoBC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                ddlStampanti.Items.Add(printer);
            }
            if (ddlStampanti.Items.Count > 0)
                ddlStampanti.SelectedIndex = 0;

        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text Files (*.txt)|*.txt";
            openFile.AddExtension = true;
            openFile.Multiselect = false;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFile.FileName;
            }
        }

        private void btnStampa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFile.Text))
            {
                txtMessaggi.Text = "Seleziona un file";
                return;
            }

            if (!File.Exists(txtFile.Text))
            {
                txtMessaggi.Text = string.Format("Il file {0} non è stato trovato", txtFile.Text);
                return;
            }

            List<string> odls = new List<string>();


            using (FileStream fs = new FileStream(txtFile.Text, FileMode.Open, FileAccess.Read))
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
                txtMessaggi.Text = string.Format("Il file {0} è vuoto", txtFile.Text);
                return;
            }

            if (ddlStampanti.SelectedIndex == -1)
            {
                MessageBox.Show("Selezionare una stampante", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string PrinterName = ddlStampanti.SelectedItem.ToString();

            foreach (string collocazione in odls)
            {
                string[] elementi = collocazione.Split(';');

                if (elementi.Count() != 4) continue;

                ZebraHelper.StampaEtichettaMagazzino(PrinterName,elementi[0],elementi[1],elementi[3],elementi[2]);
            }
        }
    }
}

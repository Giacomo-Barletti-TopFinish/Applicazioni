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

namespace CollocazioniZebraFrm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

                string codice = collocazione.Replace("MTP.",string.Empty); 
                string descrizione = "";
                string barcode = collocazione.ToString();
                ZebraHelper.StampaEtichettaUbicazione(PrinterName, codice, descrizione, barcode);
            }

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
    }
}

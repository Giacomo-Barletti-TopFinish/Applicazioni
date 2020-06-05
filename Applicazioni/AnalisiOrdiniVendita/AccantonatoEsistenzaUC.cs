using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalisiOrdiniVendita
{
    public partial class AccantonatoEsistenzaUC : UserControl
    {
        public AccantonatoEsistenzaUC()
        {
            InitializeComponent();
        }
        public string Modello { set { txtModello.Text = value; } }
        public string Destinazione { set { txtDestinazione.Text = value; } }
        public string QuantitaDestinazione { set { txtQtaDestinazione.Text = value; } }
        public string QuantitaOrigine { set { txtQtaOrigine.Text = value; } }
        private void AccantonatoEsistenzaUC_Load(object sender, EventArgs e)
        {

        }
    }
}

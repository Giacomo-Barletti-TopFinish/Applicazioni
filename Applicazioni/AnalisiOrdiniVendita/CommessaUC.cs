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
    public partial class CommessaUC : UserControl
    {
        public CommessaUC()
        {
            InitializeComponent();
        }

        public string Commessa { set { txtCommessa.Text = value; } }
        public string Modello { set { txtModello.Text = value; } }
        public string Riga { set { txtRiga.Text = value; } }
        public string DataRichiesta { set { txtDataRichiesta.Text = value; } }
        public string DataConcordata { set { txtDataConcordata.Text = value; } }
        public string Quantita { set { txtQta.Text = value; } }
        public string QuantitaDaConsegnare { set { txtQtaDaCons.Text = value; } }

        private void CommessaUC_Load(object sender, EventArgs e)
        {

        }
    }
}

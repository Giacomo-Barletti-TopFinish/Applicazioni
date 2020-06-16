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
    public partial class SeguitoUC : UserControl
    {

        public string Modello { set { txtModello.Text = value; } }
        public string ControlloQualita { set { lblControlloQualita.Text = value; } }
        public string Seguito { set { txtSeguito.Text = value; } }
        public string DataSeguito { set { txtDataSeguito.Text = value; } }
        public string Quantita { set { txtQuantita.Text = value; } }
        private int documenti = 0;
        public SeguitoUC()
        {
            InitializeComponent();
        }

        public void AggiungiDocumento(string NumeroDocumento, string DataConsegna, decimal Quantita, decimal QuantitaDaTerminare, decimal QuantitaOK, decimal QuantitaDifettosa, decimal QuantitaNonLavorata, decimal QuanatitaAnnullata)
        {
            this.Height = this.Height + 22;
            documenti++;

            int x = txtModello.Location.X;
            int y = txtModello.Location.Y + documenti * (22);

            TextBox txt = new TextBox();
            x = txtSeguito.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtSeguito.Size;
            txt.Text = NumeroDocumento;

            Controls.Add(txt);

            x = txtDataSeguito.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtDataSeguito.Size;
            txt.Text = DataConsegna;
            this.Controls.Add(txt);

            x = txtQuantita.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtQtaDaTer.Size;
            txt.Text = Quantita.ToString();
            this.Controls.Add(txt);

            x = txtQtaDaTer.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtQtaDaTer.Size;
            txt.Text = QuantitaDaTerminare.ToString();
            this.Controls.Add(txt);

            x = txtQtaOK.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtQtaOK.Size;
            txt.Text = QuantitaOK.ToString();
            this.Controls.Add(txt);

            x = txtQtaDf.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtQtaDf.Size;
            txt.Text = QuantitaDifettosa.ToString();
            if (QuantitaDifettosa > 0) txt.BackColor = Color.Yellow;
            this.Controls.Add(txt);

            x = txtQtaNL.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtQtaNL.Size;
            txt.Text = QuantitaNonLavorata.ToString();
            if (QuantitaNonLavorata > 0) txt.BackColor = Color.Yellow;
            this.Controls.Add(txt);

            x = txtQtaAnn.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtQtaAnn.Size;
            txt.Text = QuanatitaAnnullata.ToString();
            if (QuanatitaAnnullata > 0) txt.BackColor = Color.Yellow;
            this.Controls.Add(txt);

        
        }
    }
}

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
    public partial class OrdineDiLavoroUC : UserControl
    {
        public string Modello { set { txtModello.Text = value; } }
        public string Fase { set { txtFase.Text = value; } }
        public string Quantita { set { txtQuantita.Text = value; } }
        public string QuantitaDaTerminare { set { txtQtaDaTer.Text = value; } }
        public string QuantitaOK { set { txtQtaOK.Text = value; } }
        public string QuantitaDifettosa { set { txtQtaDf.Text = value; } }
        public string QuantitaNonLavorata { set { txtQtaNL.Text = value; } }
        public string QuanatitaAnnullata { set { txtQtaAnn.Text = value; } }
        public string DataConsegna { set { txtDataConsegna.Text = value; } }
        private int documenti = 0;
        public OrdineDiLavoroUC()
        {
            InitializeComponent();
        }

        public void AggiungiDocumento(string NumeroDocumento, string DataConsegna, decimal Quantita, decimal QuantitaDaTerminare, decimal QuantitaOK, decimal QuantitaDifettosa, decimal QuantitaNonLavorata, decimal QuanatitaAnnullata, string Testata)
        {
            this.Height = this.Height + 22;
            documenti++;

            int x = txtModello.Location.X;
            int y = txtModello.Location.Y + documenti * (22);

            TextBox txt = new TextBox();
            x = txtFase.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtFase.Size;
            txt.Text = NumeroDocumento;

            Controls.Add(txt);



            x = txtDataConsegna.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtDataConsegna.Size;
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

            x = txtControlloQT.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtControlloQT.Size;
            txt.Text = Testata;
            this.Controls.Add(txt);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Applicazioni.BLL;

namespace AnalisiOrdiniVendita
{
    public partial class AccantonatoConsegnaUC : UserControl
    {
        public AccantonatoConsegnaUC()
        {
            InitializeComponent();
        }

        public string Modello { set { txtModello.Text = value; } }
        public string Destinazione { set { txtDestinazione.Text = value; } }
        public string QuantitaDestinazione { set { txtQtaDestinazione.Text = value; } }
        public string QuantitaOrigine { set { txtQtaOrigine.Text = value; } }
        public string DataConsegna { set { txtDataConsegna.Text = value; } }
        private int documenti = 0;
        public void AggiungiDocumento(decimal Tipo, string NumeroDocumento, string QuantitaDocumento, string QuantitaAccantonata)
        {
            this.Height = this.Height + 22;
            documenti++;

            int x = txtModello.Location.X;
            int y = txtModello.Location.Y + documenti * (22);

            TextBox txt = new TextBox();
            x = txtDestinazione.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtDestinazione.Size;

            switch (Tipo)
            {
                case (decimal)DestinazioneAccantonato.ControlloQualita:
                    txt.Text = string.Format("CQ {0}", NumeroDocumento);
                    break;
                case (decimal)DestinazioneAccantonato.FaseDiCommessa:
                    txt.Text = string.Format("Fase {0}", NumeroDocumento);
                    break;
                case (decimal)DestinazioneAccantonato.OrdineDiLavoro:
                    txt.Text = string.Format("ODL {0}", NumeroDocumento);
                    break;
                case (decimal)DestinazioneAccantonato.RichiestaTrasferimento:
                    txt.Text = string.Format("Trasf {0}", NumeroDocumento);
                    break;
                case (decimal)DestinazioneAccantonato.RigaOrdineFornitore:
                    txt.Text = string.Format("Ord. Forn. {0}", NumeroDocumento);
                    break;
            }
            this.Controls.Add(txt);



            x = txtQtaOrigine.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtQtaOrigine.Size;
            txt.Text = QuantitaDocumento;
            this.Controls.Add(txt);

            x = txtQtaDestinazione.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtQtaDestinazione.Size;
            txt.Text = QuantitaAccantonata;
            this.Controls.Add(txt);


        }
    }
}

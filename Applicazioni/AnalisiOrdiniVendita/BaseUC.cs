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
    public partial class BaseUC : UserControl
    {
        public BaseUC(TipoControllo tipoControllo, string modello, string fase, string data, decimal quantita, decimal qtadater, decimal qtaok, decimal qtadif, decimal qtaNL, decimal qtaann, string cq)
        {
            InitializeComponent();
            switch (tipoControllo)
            {
                case TipoControllo.Fase:
                    lblTipoControllo.Text = "Fase";
                    pnlODL.BackColor = this.pnlContent.BackColor = this.BackColor = Color.LightGreen;
                    break;
                case TipoControllo.Infragruppo:
                    lblTipoControllo.Text = "Infragruppo";
                    pnlODL.BackColor = this.pnlContent.BackColor = this.BackColor = Color.Orange;
                    break;
                case TipoControllo.Qualita:
                    lblTipoControllo.Text = "CQ";
                    pnlODL.BackColor = this.pnlContent.BackColor = this.BackColor = Color.LightBlue;
                    break;
            }
            txtModello.Text = modello;
            txtFase.Text = fase;
            txtData.Text = data;
            txtQuantita.Text = quantita.ToString();
            txtQtaDaTer.Text = qtadater.ToString();
            txtQtaOK.Text = qtaok.ToString();
            txtQtaDif.Text = qtadif.ToString();
            txtQtaNL.Text = qtaNL.ToString();
            txtQtaAnn.Text = qtaann.ToString();
            txtControlloQT.Text = cq;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (btnShowHide.Text == "+")
            {
                pnlContent.Visible = true;
                btnShowHide.Text = "-";
                this.Height = this.Height + pnlContent.Height;
            }
            else
            {
                pnlContent.Visible = false;
                btnShowHide.Text = "+";
                this.Height = this.Height - pnlContent.Height;
            }
        }

        private void BaseUC_Load(object sender, EventArgs e)
        {

        }
        private int documenti = 0;
        private List<Materiale> materiale = new List<Materiale>();

        public void AggiungiMateriale(string Modello, decimal FabbisognoAccantonatoEsistenzaCommessa, decimal FabbisognoAccantonatoConsegnaCommessa, decimal FabbisognoTotaleCommessa)
        {
            materiale.Add(new Materiale(Modello, FabbisognoAccantonatoEsistenzaCommessa, FabbisognoAccantonatoConsegnaCommessa, FabbisognoTotaleCommessa));

            this.Height = this.Height + 22;
            pnlContent.Height = pnlContent.Height + 22;


            int x = txtModello.Location.X;
            int y = documenti * (22);
            documenti++;
            Label lbl = new Label();
            lbl.Location = new Point(x, y);
            lbl.Size = txtModello.Size;
            lbl.Text = "Materiale";
            pnlContent.Controls.Add(lbl);

            TextBox txt = new TextBox();
            x = txtFase.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtFase.Size;
            txt.Text = Modello;
            pnlContent.Controls.Add(txt);

            x = txtData.Location.X;
            lbl = new Label();
            lbl.Location = new Point(x, y);
            lbl.Size = txtData.Size;
            lbl.Text = "Fabb. Tot. Commessa";
            pnlContent.Controls.Add(lbl);

            x = txtQuantita.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtQtaDaTer.Size;
            txt.Text = FabbisognoTotaleCommessa.ToString();
            pnlContent.Controls.Add(txt);

            x = txtQtaDaTer.Location.X;
            lbl = new Label();
            lbl.Location = new Point(x, y);
            lbl.Size = txtQtaDaTer.Size;
            lbl.Text = "Acc.to Esi. Commessa";
            pnlContent.Controls.Add(lbl);

            x = txtQtaOK.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtQtaOK.Size;
            txt.Text = FabbisognoAccantonatoEsistenzaCommessa.ToString();
            pnlContent.Controls.Add(txt);

            x = txtQtaDif.Location.X;
            lbl = new Label();
            lbl.Location = new Point(x, y);
            lbl.Size = txtQtaDif.Size;
            lbl.Text = "Acc.to Con. Commessa";
            pnlContent.Controls.Add(lbl);

            x = txtQtaNL.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtQtaNL.Size;
            txt.Text = FabbisognoAccantonatoConsegnaCommessa.ToString();
            pnlContent.Controls.Add(txt);

        }

        private List<ODL> odl = new List<ODL>();
        private int odls = 0;
        public void AggiungiODL(TipoControllo tipoControllo, string NumeroDocumento, string DataConsegna, decimal Quantita, decimal QuantitaDaTerminare, decimal QuantitaOK, decimal QuantitaDifettosa, decimal QuantitaNonLavorata, decimal QuanatitaAnnullata, string Testata)
        {
            int locationY = pnlODL.Location.Y;
            odl.Add(new ODL(tipoControllo, NumeroDocumento, DataConsegna, Quantita, QuantitaDaTerminare, QuantitaOK, QuantitaDifettosa, QuantitaNonLavorata, QuanatitaAnnullata, Testata));
            this.Height = this.Height + 22;
            pnlODL.Height = pnlODL.Height + 22;
            pnlODL.Location = new Point(pnlODL.Location.X, locationY);

            int x = txtModello.Location.X;
            int y = odls * (22);
            odls++;

            Label lbl = new Label();
            lbl.Location = new Point(x, y);
            lbl.Size = txtModello.Size;

            switch (tipoControllo)
            {
                case TipoControllo.Infragruppo:
                    lbl.Text = "Infragruppo";
                    lbl.BackColor = Color.Orange;
                    break;
                case TipoControllo.Qualita:
                    lbl.Text = "CQ";
                    lbl.BackColor = Color.LightBlue;
                    break;
                default:
                case TipoControllo.Fase:
                    lbl.Text = "ODL";
                    break;
            }
            pnlODL.Controls.Add(lbl);

            TextBox txt = new TextBox();
            x = txtFase.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtFase.Size;
            txt.Text = NumeroDocumento;

            pnlODL.Controls.Add(txt);



            x = txtData.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtData.Size;
            txt.Text = DataConsegna;
            pnlODL.Controls.Add(txt);

            x = txtQuantita.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtQtaDaTer.Size;
            txt.Text = Quantita.ToString();
            pnlODL.Controls.Add(txt);

            x = txtQtaDaTer.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtQtaDaTer.Size;
            txt.Text = QuantitaDaTerminare.ToString();
            pnlODL.Controls.Add(txt);

            x = txtQtaOK.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtQtaOK.Size;
            txt.Text = QuantitaOK.ToString();
            pnlODL.Controls.Add(txt);

            x = txtQtaDif.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtQtaDif.Size;
            txt.Text = QuantitaDifettosa.ToString();
            if (QuantitaDifettosa > 0) txt.BackColor = Color.Yellow;
            pnlODL.Controls.Add(txt);

            x = txtQtaNL.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtQtaNL.Size;
            txt.Text = QuantitaNonLavorata.ToString();
            if (QuantitaNonLavorata > 0) txt.BackColor = Color.Yellow;
            pnlODL.Controls.Add(txt);

            x = txtQtaAnn.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtQtaAnn.Size;
            txt.Text = QuanatitaAnnullata.ToString();
            if (QuanatitaAnnullata > 0) txt.BackColor = Color.Yellow;
            pnlODL.Controls.Add(txt);

            x = txtControlloQT.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtControlloQT.Size;
            txt.Text = Testata;
            pnlODL.Controls.Add(txt);

        }

        public void AggiungiDescrizioneSeguito(string Testata,string DescrizioneSeguito, string Modello, string DataConsegna, string Quantita)
        {
            int locationY = pnlODL.Location.Y;
            this.Height = this.Height + 22;
            pnlODL.Height = pnlODL.Height + 22;
            pnlODL.Location = new Point(pnlODL.Location.X, locationY);

            int x = txtModello.Location.X;
            int y = odls * (22);
            odls++;

            Label lbl = new Label();
            lbl.Location = new Point(x, y);
            lbl.Size = txtModello.Size;
            lbl.BackColor = Color.LightBlue;
            lbl.Text = Testata;
            pnlODL.Controls.Add(lbl);

            TextBox txt = new TextBox();
            x = txtFase.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtFase.Size;
            txt.Text = DescrizioneSeguito;

            pnlODL.Controls.Add(txt);



            x = txtData.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtData.Size;
            txt.Text = DataConsegna;
            pnlODL.Controls.Add(txt);

            x = txtQuantita.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtQtaDaTer.Size;
            txt.Text = Quantita.ToString();
            pnlODL.Controls.Add(txt);

            x = txtQtaDaTer.Location.X;
            txt = new TextBox();
            txt.ReadOnly = true;
            txt.Location = new Point(x, y);
            txt.Size = txtQtaDaTer.Size;
            txt.Text = Modello;
            pnlODL.Controls.Add(txt);

        }


        private int elementiInfragruppo = 0;


        private void btnODL_Click(object sender, EventArgs e)
        {
            if (btnODL.Text == "+")
            {
                pnlODL.Visible = true;
                btnODL.Text = "-";
                this.Height = this.Height + pnlODL.Height;
            }
            else
            {
                pnlODL.Visible = false;
                btnODL.Text = "+";
                this.Height = this.Height - pnlODL.Height;
            }
        }
    }

    public enum TipoControllo { Fase, Infragruppo, Qualita }

    public class Materiale
    {
        public string Modello { get; set; }
        public decimal FabbisognoAccantonatoEsistenzaCommessa { get; set; }
        public decimal FabbisognoAccantonatoConsegnaCommessa { get; set; }
        public decimal FabbisognoTotaleCommessa { get; set; }

        public Materiale(string Modello, decimal FabbisognoAccantonatoEsistenzaCommessa, decimal FabbisognoAccantonatoConsegnaCommessa, decimal FabbisognoTotaleCommessa)
        {
            this.Modello = Modello;
            this.FabbisognoAccantonatoEsistenzaCommessa = FabbisognoAccantonatoEsistenzaCommessa;
            this.FabbisognoAccantonatoConsegnaCommessa = FabbisognoAccantonatoConsegnaCommessa;
            this.FabbisognoTotaleCommessa = FabbisognoTotaleCommessa;
        }
    }

    public class ODL
    {
        public string NumeroDocumento { get; set; }
        public string DataConsegna { get; set; }
        public string Testata { get; set; }
        public decimal Quantita { get; set; }
        public decimal QuantitaDaTerminare { get; set; }
        public decimal QuantitaOK { get; set; }
        public decimal QuantitaDifettosa { get; set; }
        public decimal QuantitaNonLavorata { get; set; }
        public decimal QuantitaAnnullata { get; set; }
        public TipoControllo TipoControllo { get; set; }
        public ODL(TipoControllo TipoControllo, string NumeroDocumento, string DataConsegna, decimal Quantita, decimal QuantitaDaTerminare, decimal QuantitaOK, decimal QuantitaDifettosa, decimal QuantitaNonLavorata, decimal QuantitaAnnullata, string Testata)
        {
            this.NumeroDocumento = NumeroDocumento;
            this.DataConsegna = DataConsegna;
            this.Quantita = Quantita;
            this.QuantitaDaTerminare = QuantitaDaTerminare;
            this.QuantitaOK = QuantitaOK;
            this.QuantitaDifettosa = QuantitaDifettosa;
            this.QuantitaNonLavorata = QuantitaNonLavorata;
            this.QuantitaAnnullata = QuantitaAnnullata;
            this.Testata = Testata;
            this.TipoControllo = TipoControllo;
        }
    }
}
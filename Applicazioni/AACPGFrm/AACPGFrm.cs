using Applicazioni.BLL;
using Applicazioni.Common;
using Applicazioni.Entities;
using Applicazioni.Models;
using Applicazioni.Proxies.Temera;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AACPGFrm
{
    public partial class AACPGFrm : BaseForm
    {
        private Anagrafica _anagrafica = new Anagrafica();

        private Produzione _produzione = new Produzione();

        public AACPGFrm()
        {
            InitializeComponent();
            ScriviLogInfo("avvio");
        }

        public override void MostraEccezione( Exception ex, string messaggioLog)
        {
            ScriviLogErrore(messaggioLog, ex);
            base.MostraEccezione(ex, messaggioLog);
        }
        private void btnCancella_Click(object sender, EventArgs e)
        {
            try
            {
                CancellaTutto();
                txtTelaio.Focus();
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Erroe in cancella tutto");
            }
        }

        private void CancellaTutto()
        {
            txtODL.Text = string.Empty;
            txtTelaio.Text = string.Empty;
            txtToken.Text = string.Empty;
            txtMessage.Text = string.Empty;
        }

        private void txtODL_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    lblMessaggi.Text = string.Empty;
                    string barcode = txtODL.Text;
                    txtODL.Text = string.Empty;
                    ProduzioneDS.USR_PRD_MOVFASIRow movFase = VerificaBarcodeODL(barcode);
                    if (movFase == null) return;

                    ProduzioneDS.USR_PRD_FASIRow faseGalvanica = EstraiFaseGalvanicaDaODL(movFase);
                    if (faseGalvanica == null) return;
                    if (faseGalvanica.IsIDMAGAZZNull())
                    {
                        lblMessaggi.Text = "Nessun articolo associato alla fase galvanica";
                        return;
                    }
                    Articolo articolo = _anagrafica.GetArticolo(faseGalvanica.IDMAGAZZ);
                    if (articolo == null)
                    {
                        lblMessaggi.Text = "Errore nell'estrazione dei dati dell'articolo galvanica";
                        return;
                    }
                    txtDescrizione.Text = articolo.Descrizione;
                    txtModello.Text = articolo.Modello;
                    txtSuperficie.Text = articolo.Superficie.ToString();

                    txtOrdineLavoro.Text = movFase.IsNUMMOVFASENull() ? string.Empty : movFase.NUMMOVFASE;
                    pbArticolo.ImageLocation = articolo.Immagine;
                    btnAvvia.Focus();
                }
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in elabora barcode ODL");
            }
            finally
            {
                Cursor.Current = Cursors.Default;

            }
        }

        private void AACPGFrm_Load(object sender, EventArgs e)
        {
            lblMessaggi.Text = string.Empty;
        }

        private ProduzioneDS.USR_PRD_MOVFASIRow VerificaBarcodeODL(string barcode)
        {
            lblMessaggi.Text = "";
            ProduzioneDS.USR_PRD_MOVFASIRow movFase = _produzione.GetUSR_PRD_MOVFASIByBarcode(barcode);
            if (movFase == null)
            {
                lblMessaggi.Text = "Nessun ODL trovato per questo barcode";
                return null;
            }
            return movFase;
        }


        private ProduzioneDS.USR_PRD_FASIRow EstraiFaseGalvanicaDaODL(ProduzioneDS.USR_PRD_MOVFASIRow movFase)
        {
            ProduzioneDS.USR_PRD_FASIRow fase = _produzione.GetUSR_PRD_FASI(movFase.IDPRDFASE);
            if (fase == null)
            {
                lblMessaggi.Text = "Nessuna fase trovata per questo barcode";
                return null;
            }
            if (fase.IsIDPRDFASEPADRENull())
            {
                lblMessaggi.Text = "Impossibile risalire alla fase di galvanica";
                return null;
            }
            ProduzioneDS.USR_PRD_FASIRow faseGalvanica = _produzione.GetUSR_PRD_FASI(fase.IDPRDFASEPADRE);
            if (faseGalvanica == null)
            {
                lblMessaggi.Text = "Nessuna fase galvanica non trovata per questo barcode";
                return null;
            }
            return faseGalvanica;
        }

        private void VerificaCodiceTelaio(string barcode)
        {

        }
        private void txtTelaio_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.KeyCode == Keys.Enter)
                {
                    lblMessaggi.Text = string.Empty;
                    string barcode = txtTelaio.Text;
                    txtTelaio.Text = string.Empty;
                    VerificaCodiceTelaio(barcode);
                    txtODL.Focus();
                }
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in elabora barcode telaio");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private string GetTokenConnessione()
        {
            if (string.IsNullOrEmpty(txtToken.Text))
            {
                try
                {

                    using (TemeraTmr proxy = new TemeraTmr())
                    {
                        ScriviLogInfo("Richiesta token .....");
                        txtMessage.InserisciRichiesta("Richiesta token .....");
                        string token = proxy.GetToken(Properties.Settings.Default.User, Properties.Settings.Default.Password, Properties.Settings.Default.Server);
                        txtToken.Text = token;
                        txtMessage.InserisciRisposta("Token: " + token);
                    }
                }
                catch (Exception ex)
                {
                    MostraEccezione(ex, "Errore in get token");
                }

            }

            return txtToken.Text;
        }

        private void btnAvvia_Click(object sender, EventArgs e)
        {
            lblMessaggi.Text = string.Empty;
            if (string.IsNullOrEmpty(txtTelaio.Text))
            {
                lblMessaggi.Text += "Specificare il telaio";
            }

            if (string.IsNullOrEmpty(txtOrdineLavoro.Text))
            {
                lblMessaggi.Text += " Specificare l'ODL";
            }

            if (string.IsNullOrEmpty(txtModello.Text))
            {
                lblMessaggi.Text += " Specificare il modello";
            }

            int quantita = 0;
            if (string.IsNullOrEmpty(txtQuantita.Text))
            {
                lblMessaggi.Text += " Specificare la quantità";
            }
            else
            {
                if (!int.TryParse(txtQuantita.Text, out quantita))
                    lblMessaggi.Text += " La quantità no sembra essere un numero";
            }


            if (!string.IsNullOrEmpty(lblMessaggi.Text)) return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string token = GetTokenConnessione();

                txtMessage.InserisciRichiesta("Invio dati .....");

                using (TemeraTmr proxy = new TemeraTmr())
                {
                    string json = proxy.AssociazioneTelaio(txtODL.Text, txtModello.Text, txtTelaio.Text, quantita, 1, Properties.Settings.Default.Server, token);
                    txtMessage.InserisciRisposta(json);
                }
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in avvia galvanica");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }
    }

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            text = Environment.NewLine + text;
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        public static void InserisciRichiesta(this RichTextBox box, string messaggio)
        {
            box.AppendText(messaggio, Color.Blue);
        }

        public static void InserisciRisposta(this RichTextBox box, string messaggio)
        {
            box.AppendText(messaggio, Color.Red);
        }
    }
}

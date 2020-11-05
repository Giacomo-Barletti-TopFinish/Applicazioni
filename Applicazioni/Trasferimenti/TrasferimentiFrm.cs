using Applicazioni.BLL;
using Applicazioni.Common;
using Applicazioni.Data.Trasferimenti;
using Applicazioni.Entities;
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

namespace Trasferimenti
{
    public partial class TrasferimentiFrm : BaseForm
    {
        private List<string> _daStampare = new List<string>();
        private bool _inRicezione;
        private System.Drawing.Printing.PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument();
        private Font printFont = new Font("Arial", 11);

        private string _filter = "Text Files (*.txt)|*.txt";
        private string _defaultExt = "txt";
        private TrasferimentiDS _ds;
        private DataSet _dsGriglia = new DataSet();
        private string _tabellaGriglia = "Griglia";
        TrasferimentiDS.AP_TTRASFERIMENTIRow _trasferimentoInCorso;
        private Anagrafica _anagrafica = new Anagrafica();
        private int _index = 0;

        private void ImpostaInRicezione(bool valore)
        {
            _inRicezione = valore;
            if (valore)
                txtLedInTrasferimento.BackColor = Color.Green;
            else
                txtLedInTrasferimento.BackColor = SystemColors.Control;

        }

        public TrasferimentiFrm()
        {
            InitializeComponent();
        }

        private void TrasferimentiFrm_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                lblMessaggi.Text = string.Empty;
                _ds = new TrasferimentiDS();
                using (TrasferimentiBusiness bTrasferimenti = new TrasferimentiBusiness())
                {
                    bTrasferimenti.FillUSR_PRD_TIPOMOVFASI(_ds);
                }

                CreaDSGriglia();
                CreaGriglia();
                ImpostaInRicezione(false);
                docToPrint.PrintPage += DocToPrint_PrintPage;
                txtBarcode.Focus();
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in caricamento applicazione");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void DocToPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Bitmap bm = new Bitmap(this.dgvTrasferimenti.Width, this.dgvTrasferimenti.Height);
            //dgvTrasferimenti.DrawToBitmap(bm, new Rectangle(0, 0, this.dgvTrasferimenti.Width, this.dgvTrasferimenti.Height));
            //e.Graphics.DrawImage(bm, 0, 0);

            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            String line = null;
           
            // Calculate the number of lines per page.
            linesPerPage = e.MarginBounds.Height /
               printFont.GetHeight(e.Graphics);
            
            // Iterate over the file, printing each line.
            while (count < linesPerPage && _index < _daStampare.Count)
            {
                line = _daStampare[_index];
                yPos = topMargin + (count * printFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(line, printFont, Brushes.Black,
                   leftMargin, yPos, new StringFormat());
                count++;
                _index++;
            }

            // If more lines exist, print another page.
            if (_index < _daStampare.Count)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblMessaggi.Text = string.Empty;
                string barcode = txtBarcode.Text;
                txtBarcode.Text = string.Empty;
                ElaboraBarcode(barcode);
            }

        }

        private void ElaboraBarcode(string barcode)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                lblMessaggi.Text = string.Empty;
                string tipoBarcode = barcode.Substring(0, 3);
                switch (tipoBarcode)
                {
                    case "RSF":
                        if (_dsGriglia.Tables[_tabellaGriglia].Rows.Count > 0)
                        {
                            if (!_inRicezione)
                            {
                                if (VerificaEsistenzaTrasferimento(barcode))
                                {
                                    string messaggio = string.Format("Assegno questi documenti all'operatore con barcode {0}", barcode);
                                    if (MessageBox.Show(messaggio, "ASSEGNAZIONE DOCUMENTI", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                    {
                                        CreaTrasferimento(barcode);
                                        lblMessaggi.Text = "TRASFERIMENTO REGISTRATO CON SUCCESSO";
                                        PulisciArchivi();
                                        ImpostaInRicezione(false);
                                    }
                                }
                                else
                                {
                                    lblMessaggi.Text = "ESISTE GIA' UN TRASFERIMENTO ATTIVO PER QUESTO OPERATORE";
                                }
                            }
                            else
                            {
                                if (_trasferimentoInCorso.BARCODE_PARTENZA == barcode)
                                {
                                    lblMessaggi.Text = "IL BARCODE DI DESTINAZIONE E' LO STESSO DI QUELLO DI PARTENZA";
                                    return;
                                }

                                if (VerificaEsistenzaTrasferimento(barcode))
                                {
                                    ChiudiTrasferimento(barcode);
                                    lblMessaggi.Text = "TRASFERIMENTO REGISTRATO CON SUCCESSO";
                                    PulisciArchivi();
                                    ImpostaInRicezione(false);
                                }
                                else
                                {
                                    lblMessaggi.Text = "ESISTE GIA' UN TRASFERIMENTO ATTIVO PER QUESTO OPERATORE";
                                }
                            }
                        }
                        else
                        {
                            PulisciArchivi();
                            CaricaTrasferimentoDaBarcodePartenza(barcode);
                        }
                        break;
                    case "ODP":
                    case "ODL":
                    case "ODU":
                    case "RRF":
                    case "ODM":
                    case "ODS":
                        if (_inRicezione)
                        {
                            lblMessaggi.Text = "IN RICEZIONE TRASFERIMENTO non è possibile aggiungere ODL";
                            return;
                        }
                        if (VerificaBarcode(barcode))
                            CaricaODL(barcode, 1);
                        break;
                    case "DRT":
                        if (_inRicezione)
                        {
                            lblMessaggi.Text = "IN RICEZIONE TRASFERIMENTO non è possibile aggiungere TRASFERIMENTI";
                            return;
                        }
                        if (VerificaBarcode(barcode))
                            CaricaTrasferimento(barcode, 1);
                        break;
                }
                txtBarcode.Focus();
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in elabora barcode");
            }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void ChiudiTrasferimento(string barcode)
        {
            _trasferimentoInCorso.BARCODE_ARRIVO = barcode;
            _trasferimentoInCorso.DATA_ARRIVO = DateTime.Now;
            using (TrasferimentiBusiness bTrasferimenti = new TrasferimentiBusiness())
                bTrasferimenti.SalvaTrasferimenti(_ds);
        }
        private bool VerificaEsistenzaTrasferimento(string barcode)
        {
            using (TrasferimentiBusiness bTrasferimenti = new TrasferimentiBusiness())
            {
                bTrasferimenti.FillAP_TTRASFERIMENTIDaBarcodePartenza(_ds, barcode);
                return !_ds.AP_TTRASFERIMENTI.Any(x => x.BARCODE_PARTENZA == barcode && x.IsBARCODE_ARRIVONull());
            }
        }
        private void CaricaTrasferimentoDaBarcodePartenza(string barcode)
        {
            using (TrasferimentiBusiness bTrasferimenti = new TrasferimentiBusiness())
            {
                bTrasferimenti.FillAP_TTRASFERIMENTIDaBarcodePartenza(_ds, barcode);
                List<TrasferimentiDS.AP_TTRASFERIMENTIRow> trasferimenti = _ds.AP_TTRASFERIMENTI.Where(x => x.BARCODE_PARTENZA == barcode && x.IsBARCODE_ARRIVONull()).ToList();
                if (trasferimenti.Count == 0)
                {
                    lblMessaggi.Text = "NESSUN TRASFERIMENTO ATTIVO ASSOCIATO A QUESTO OPERATORE";
                    ImpostaInRicezione(false);
                    return;
                }
                if (trasferimenti.Count > 1)
                {
                    lblMessaggi.Text = "CI SONO DUE O PIU' TRASFERIMENTI ASSICIATI A QUESTO OPERATORE";
                    ImpostaInRicezione(false);
                    return;
                }
                _trasferimentoInCorso = trasferimenti[0];
                bTrasferimenti.FillAP_DTRASFERIMENTIDaIDTRASFERIMENTO(_ds, _trasferimentoInCorso.IDTRASFERIMENTO);

                List<string> barcodeOdl = _ds.AP_DTRASFERIMENTI.Where(x => x.IDTRASFERIMENTO == _trasferimentoInCorso.IDTRASFERIMENTO).Select(x => x.BARCODE_ODL).ToList();

                foreach (string odl in barcodeOdl)
                {
                    TrasferimentiDS.AP_DTRASFERIMENTIRow trasferimento = _ds.AP_DTRASFERIMENTI.Where(x => x.BARCODE_ODL == odl).FirstOrDefault();
                    decimal colli = trasferimento.IsCOLLINull() ? 1 : trasferimento.COLLI;
                    if (!CaricaODL(odl, colli))
                        CaricaTrasferimento(odl, colli);
                }

                ImpostaInRicezione(true);
            }
        }

        private void CreaTrasferimento(string barcode)
        {
            using (TrasferimentiBusiness bTrasferimenti = new TrasferimentiBusiness())
            {
                try
                {
                    TrasferimentiDS.AP_TTRASFERIMENTIRow trasferimento = _ds.AP_TTRASFERIMENTI.NewAP_TTRASFERIMENTIRow();
                    trasferimento.IDTRASFERIMENTO = bTrasferimenti.GetID();
                    trasferimento.BARCODE_PARTENZA = barcode;
                    trasferimento.DATA_PARTENZA = DateTime.Now;
                    trasferimento.ATTIVO = 1;
                    _ds.AP_TTRASFERIMENTI.AddAP_TTRASFERIMENTIRow(trasferimento);

                    foreach (DataGridViewRow riga in dgvTrasferimenti.Rows)
                    {
                        TrasferimentiDS.AP_DTRASFERIMENTIRow destinazione = _ds.AP_DTRASFERIMENTI.NewAP_DTRASFERIMENTIRow();
                        destinazione.IDDTRASFERIMENTO = bTrasferimenti.GetID();
                        destinazione.IDTRASFERIMENTO = trasferimento.IDTRASFERIMENTO;
                        destinazione.BARCODE_ODL = riga.Cells[(int)colonneGriglia.BARCODE].Value.ToString();
                        destinazione.NUMMOVFASE = riga.Cells[(int)colonneGriglia.NUMMOVFASE].Value.ToString();
                        destinazione.REPARTO = string.IsNullOrEmpty((string)riga.Cells[(int)colonneGriglia.REPARTO].Value) ? "N/D" : riga.Cells[(int)colonneGriglia.REPARTO].Value.ToString();
                        destinazione.MODELLO = riga.Cells[(int)colonneGriglia.MODELLO].Value.ToString();
                        destinazione.QTA = (decimal)riga.Cells[(int)colonneGriglia.QUANTITA].Value;
                        destinazione.COLLI = (decimal)riga.Cells[(int)colonneGriglia.COLLI].Value;
                        _ds.AP_DTRASFERIMENTI.AddAP_DTRASFERIMENTIRow(destinazione);
                    }
                    bTrasferimenti.SalvaTrasferimenti(_ds);
                }
                catch { bTrasferimenti.Rollback(); throw; }


            }
        }

        private bool VerificaBarcode(string barcode)
        {
            if (_ds.USR_PRD_MOVFASI.Any(x => x.BARCODE == barcode))
            {
                lblMessaggi.Text = "BARCODE GIA' INSERITO";
                return false;
            }
            if (_ds.USR_TRASF_RICH.Any(x => x.BARCODE == barcode))
            {
                lblMessaggi.Text = "BARCODE GIA' INSERITO";
                return false;
            }
            return true;
        }
        private bool CaricaODL(string barcode, decimal colli)
        {
            if (string.IsNullOrEmpty(barcode)) return false;

            using (TrasferimentiBusiness bTrasferimenti = new TrasferimentiBusiness())
            {
                if (!_ds.USR_PRD_MOVFASI.Any(x => x.BARCODE == barcode))
                    bTrasferimenti.FillUSR_PRD_MOVFASI(_ds, barcode);

                TrasferimentiDS.USR_PRD_MOVFASIRow odl = _ds.USR_PRD_MOVFASI.Where(x => x.BARCODE == barcode).FirstOrDefault();
                if (odl == null)
                {
                    lblMessaggi.Text = "BARCODE NON TROVATO";
                    return false;
                }
                AnagraficaDS.MAGAZZRow articolo = _anagrafica.GetMAGAZZ(odl.IDMAGAZZ);

                DataTable dtGriglia = _dsGriglia.Tables[_tabellaGriglia];

                DataRow riga = dtGriglia.NewRow();

                riga[(int)colonneGriglia.BARCODE] = odl.IsBARCODENull() ? string.Empty : odl.BARCODE;
                riga[(int)colonneGriglia.MODELLO] = articolo == null ? string.Empty : articolo.MODELLO;
                riga[(int)colonneGriglia.NUMMOVFASE] = odl.IsNUMMOVFASENull() ? string.Empty : odl.NUMMOVFASE;
                riga[(int)colonneGriglia.REPARTO] = odl.IsCODICECLIFODESTNull() ? string.Empty : odl.CODICECLIFODEST;
                riga[(int)colonneGriglia.QUANTITA] = odl.QTA;
                riga[(int)colonneGriglia.COLLI] = colli;

                dtGriglia.Rows.Add(riga);

            }
            return true;
        }

        private void CaricaTrasferimento(string barcode, decimal colli)
        {
            using (TrasferimentiBusiness bTrasferimenti = new TrasferimentiBusiness())
            {
                if (!_ds.USR_TRASF_RICH.Any(x => x.BARCODE == barcode))
                    bTrasferimenti.FillUSR_TRASF_RICH(_ds, barcode);

                TrasferimentiDS.USR_TRASF_RICHRow trasferimento = _ds.USR_TRASF_RICH.Where(x => x.BARCODE == barcode).FirstOrDefault();
                if (trasferimento == null)
                {
                    lblMessaggi.Text = "BARCODE NON TROVATO";
                    return;
                }
                AnagraficaDS.MAGAZZRow articolo = _anagrafica.GetMAGAZZ(trasferimento.IDMAGAZZ);

                DataTable dtGriglia = _dsGriglia.Tables[_tabellaGriglia];

                DataRow riga = dtGriglia.NewRow();

                riga[(int)colonneGriglia.BARCODE] = trasferimento.IsBARCODENull() ? string.Empty : trasferimento.BARCODE;
                riga[(int)colonneGriglia.MODELLO] = articolo == null ? string.Empty : articolo.MODELLO;
                riga[(int)colonneGriglia.NUMMOVFASE] = trasferimento.IsNUMRICHTRASFTNull() ? string.Empty : trasferimento.NUMRICHTRASFT;
                riga[(int)colonneGriglia.REPARTO] = "MAGAZZINO";
                riga[(int)colonneGriglia.QUANTITA] = trasferimento.QTA;
                riga[(int)colonneGriglia.COLLI] = colli;

                dtGriglia.Rows.Add(riga);

            }
        }

        enum colonneGriglia { BARCODE, NUMMOVFASE, REPARTO, MODELLO, QUANTITA, COLLI }
        private void CreaDSGriglia()
        {
            DataTable dtGriglia = _dsGriglia.Tables.Add();
            dtGriglia.TableName = _tabellaGriglia;

            int numeroColonne = Enum.GetNames(typeof(colonneGriglia)).Length;
            for (int i = 0; i < numeroColonne; i++)
            {
                string colonna = Enum.GetName(typeof(colonneGriglia), i);
                switch (i)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        dtGriglia.Columns.Add(colonna, Type.GetType("System.String")).ReadOnly = true;
                        break;
                    case 4:
                        dtGriglia.Columns.Add(colonna, Type.GetType("System.Decimal")).ReadOnly = true;
                        break;
                    case 5:
                        dtGriglia.Columns.Add(colonna, Type.GetType("System.Decimal"));
                        break;
                }
            }
        }

        private void CreaGriglia()
        {
            dgvTrasferimenti.DataSource = _dsGriglia;
            dgvTrasferimenti.DataMember = _tabellaGriglia;

            dgvTrasferimenti.Columns[(int)colonneGriglia.BARCODE].Width = 150;
            dgvTrasferimenti.Columns[(int)colonneGriglia.NUMMOVFASE].Width = 150;
            dgvTrasferimenti.Columns[(int)colonneGriglia.REPARTO].Width = 120;
            dgvTrasferimenti.Columns[(int)colonneGriglia.MODELLO].Width = 200;
            dgvTrasferimenti.Columns[(int)colonneGriglia.QUANTITA].Width = 100;
            dgvTrasferimenti.Columns[(int)colonneGriglia.COLLI].Width = 70;
        }

        private void btnPulisci_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                txtBarcode.Text = string.Empty;
                lblMessaggi.Text = string.Empty;
                PulisciArchivi();
                ImpostaInRicezione(false);
                txtBarcode.Focus();
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in elabora barcode");
            }
            finally { Cursor.Current = Cursors.Default; }

        }
        private void PulisciArchivi()
        {
            _dsGriglia.Tables[_tabellaGriglia].Clear();
            _ds.USR_PRD_MOVFASI.Clear();
            _ds.USR_TRASF_RICH.Clear();
            _ds.AP_TTRASFERIMENTI.Clear();
            _ds.AP_DTRASFERIMENTI.Clear();
        }

        private void dgvTrasferimenti_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                string barcode = (string)e.Row.Cells[(int)colonneGriglia.BARCODE].Value;

                TrasferimentiDS.USR_PRD_MOVFASIRow movfase = _ds.USR_PRD_MOVFASI.Where(x => x.BARCODE == barcode).FirstOrDefault();
                if (movfase != null) movfase.Delete();

                TrasferimentiDS.USR_TRASF_RICHRow rich = _ds.USR_TRASF_RICH.Where(x => x.BARCODE == barcode).FirstOrDefault();
                if (rich != null) rich.Delete();
                _ds.AcceptChanges();
                txtBarcode.Focus();

            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in elabora barcode");
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            btnPulisci_Click(null, null);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = _filter;
            ofd.DefaultExt = _defaultExt;
            ofd.AddExtension = true;
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.Cancel) return;

            StreamReader sr = new StreamReader(ofd.FileName);
            try
            {
                while (!sr.EndOfStream)
                {
                    string riga = sr.ReadLine().Trim();
                    if (riga.Contains("#"))
                    {
                        string[] elementi = riga.Split('#');
                        if (elementi.Length == 2)
                        {
                            decimal colli = decimal.Parse(elementi[1]);
                            if (!CaricaODL(elementi[0], colli))
                                CaricaTrasferimento(elementi[0], colli);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in carica dati da file");
            }
            finally
            {
                sr.Close();
                sr.Dispose();
                txtBarcode.Focus();
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            lblMessaggi.Text = string.Empty;
            if (dgvTrasferimenti.Rows.Count == 0)
            {
                lblMessaggi.Text = "Non ci sono dati da salvare";
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = _filter;
            sfd.DefaultExt = _defaultExt;
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.Cancel) return;

            if (File.Exists(sfd.FileName)) File.Delete(sfd.FileName);

            StreamWriter sw = new StreamWriter(sfd.FileName);

            try
            {
                foreach (DataGridViewRow riga in dgvTrasferimenti.Rows)
                {
                    string BARCODE_ODL = riga.Cells[(int)colonneGriglia.BARCODE].Value.ToString();
                    string colli = riga.Cells[(int)colonneGriglia.COLLI].Value.ToString();

                    sw.WriteLine(string.Format("{0}#{1}", BARCODE_ODL, colli));
                }

            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in salva dati in file");
            }
            finally
            {
                sw.Flush();
                sw.Close();
                sw.Dispose();
                txtBarcode.Focus();
            }

        }

        private bool PreparaStampa()
        {
            _daStampare = new List<string>();
            if (dgvTrasferimenti.Rows.Count == 0)
            {
                lblMessaggi.Text = "Non ci sono righe da stampare";
                return false;
            }

            foreach (DataGridViewRow riga in dgvTrasferimenti.Rows)
            {
                string BARCODE_ODL = riga.Cells[(int)colonneGriglia.BARCODE].Value.ToString();
                string NUMMOVFASE = riga.Cells[(int)colonneGriglia.NUMMOVFASE].Value.ToString();
                string REPARTO = riga.Cells[(int)colonneGriglia.REPARTO].Value.ToString();
                string MODELLO = riga.Cells[(int)colonneGriglia.MODELLO].Value.ToString();
                string QTA = riga.Cells[(int)colonneGriglia.QUANTITA].Value.ToString();
                string colli = riga.Cells[(int)colonneGriglia.COLLI].Value.ToString();

                _daStampare.Add(string.Format("{0} - {1} ( {2} )  Colli: {3}", NUMMOVFASE, MODELLO, QTA, colli));
            }
            return true;
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            lblMessaggi.Text = string.Empty;
            if (!PreparaStampa()) return;
            try
            {
                PrintDialog pd = new PrintDialog();
                pd.AllowSomePages = false;

                pd.ShowHelp = true;

                // Set the Document property to the PrintDocument for 
                // which the PrintPage Event has been handled. To display the
                // dialog, either this property or the PrinterSettings property 
                // must be set 
                pd.Document = docToPrint;

                if (pd.ShowDialog() == DialogResult.OK)
                {
                    _index = 0;
                    docToPrint.Print();
                }
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in salva dati in file");
            }
            finally
            {
                txtBarcode.Focus();

            }

        }
    }
}

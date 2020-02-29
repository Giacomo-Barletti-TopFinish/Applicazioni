using Applicazioni.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValorizzazioniFrm
{
    public partial class ValorizzazioneFrm : Form
    {
        private const string etichettaStart = "Elabora";
        private const string etichettaStop = "Annulla";

        private DateTime _start;

        private BackgroundWorker _bgwCosto = new BackgroundWorker();

        Inventario _inventario = new Inventario();
        public ValorizzazioneFrm()
        {
            InitializeComponent();
            List<Testata> testate = _inventario.CreaListaTestate();
            ddlInventario.Items.AddRange(testate.ToArray());
            InizializzaLabel();
            btnStart.Text = etichettaStart;

            InitializeCostoBackgroundWorker();
        }

        private void InitializeCostoBackgroundWorker()
        {
            _bgwCosto.WorkerReportsProgress = true;
            _bgwCosto.WorkerSupportsCancellation = true;

            _bgwCosto.DoWork += _bgwCosto_DoWork; ;
            _bgwCosto.RunWorkerCompleted += _bgwCosto_RunWorkerCompleted; ;
            _bgwCosto.ProgressChanged += _bgwCosto_ProgressChanged;
        }

        private void _bgwCosto_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblTempoCosto.Text = string.Format("{0}:{1}", (DateTime.Now - _start).Minutes, (DateTime.Now - _start).Seconds);
            if (e.UserState == null)
            {
                lblCostoCur.Text = e.ProgressPercentage.ToString();
                prgCosto.Value = e.ProgressPercentage;
                return;
            }

            string messaggio = (string)e.UserState;
            AggiornaMessaggio(messaggio);

            if (messaggio.Contains("Prodotti Finiti"))
            {
                lblCostoMax.Text = e.ProgressPercentage.ToString();
                _numeroElementi = e.ProgressPercentage;
                prgCosto.Maximum = e.ProgressPercentage;
                return;
            }
        }

        private void _bgwCosto_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                btnStart.Text = etichettaStart;
            }
            else if (e.Cancelled)
            {
                AggiornaMessaggio("*** CALCOLA COSTI CANCELLATA ***");
                btnStart.Text = etichettaStart;
            }
            else
            {
                lblTempoCosto.Text = string.Format("{0}:{1}", (DateTime.Now - _start).Minutes, (DateTime.Now - _start).Seconds);
                AggiornaMessaggio("*** CALCOLA COSTI COMPLETATA ***");
                prgCosto.Value = prgCosto.Maximum;
            }

            btnStart.Text = etichettaStart;
        }

        private void _bgwCosto_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            CostiDTO dto = (CostiDTO)e.Argument;
            Testata inventarioT = dto.testata;

            DiBa diba = new DiBa();
            worker.ReportProgress(0, string.Format("Cancella costi vecchi inventario {0} del {1}", inventarioT.Codice, inventarioT.DataFine.ToShortDateString()));
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            diba.DeleteCostiArticoli(inventarioT.IdInventarioT);

            worker.ReportProgress(0, "Carica anagrafica articoli");
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            diba.FillMAGAZZ();

            worker.ReportProgress(0, "Carica listini acquisto");
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            diba.FillUSR_LIS_ACQ();

            if (dto.consideraListiniTopFinish)
            {
                worker.ReportProgress(0, "Carica listini vendita");
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                diba.FillUSR_LIS_VEN();
            }

            worker.ReportProgress(0, "Carica fasi");
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            diba.FillTABFAS();

            worker.ReportProgress(0, "Carica listino fasi");
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            diba.FillUSR_LIS_FASE();

            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            worker.ReportProgress(0, "Carica TDIBA");
            diba.CaricaTDiba();

            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            worker.ReportProgress(0, "Carica TDIBA DEFAULT");
            diba.CaricaTDibaDefaut();

            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            worker.ReportProgress(0, "Carica RDIBA");
            diba.CaricaRDiba();

            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            worker.ReportProgress(0, string.Format("Carica INVENTARIOD PER L'INVENTARIO {0}", inventarioT.Codice));
            diba.FillUSR_INVENTARIOD(inventarioT.IdInventarioT);

            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            worker.ReportProgress(diba.CostiDaCalcolare, string.Format("Prodotti Finiti: {0}", diba.CostiDaCalcolare));

            worker.ReportProgress(0, "Inizio Calcolo Costi");
            diba.CalcolaCostiArticolo(inventarioT, worker, e, dto.consideraTutteLeFasi, dto.consideraListiniTopFinish);
            worker.ReportProgress(diba.CostiDaCalcolare, string.Format("Salvataggio dati in corso...", diba.CostiDaCalcolare));
            diba.SalvaCostiArticolo();

        }

        //private void _bgwDiba_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{

        //    if (e.Error != null)
        //    {
        //        MessageBox.Show(e.Error.Message);
        //        btnStart.Text = etichettaStart;
        //    }
        //    else if (e.Cancelled)
        //    {
        //        AggiornaMessaggio("*** ESPLODI DIBA CANCELLATA ***");
        //        btnStart.Text = etichettaStart;
        //    }
        //    else
        //    {
        //        lblTempoDiba.Text = string.Format("{0}:{1}", (DateTime.Now - _start).Minutes, (DateTime.Now - _start).Seconds);
        //        AggiornaMessaggio("*** ESPLODI DIBA COMPLETATA ***");
        //        prgDiba.Value = prgDiba.Maximum;
        //    }

        //    if (chkCosto.Checked && _bgwCosto.IsBusy != true)
        //    {
        //        Testata testata = (Testata)ddlInventario.SelectedItem;
        //        // Start the asynchronous operation.
        //        _bgwCosto.RunWorkerAsync(testata);
        //        return;
        //    }
        //}

        private int _numeroElementi = 1;
        //private void _bgwDiba_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    lblTempoDiba.Text = string.Format("{0}:{1}", (DateTime.Now - _start).Minutes, (DateTime.Now - _start).Seconds);
        //    if (e.UserState == null)
        //    {
        //        lblCurDiba.Text = e.ProgressPercentage.ToString();
        //        prgDiba.Value = e.ProgressPercentage;
        //        return;
        //    }

        //    string messaggio = (string)e.UserState;
        //    AggiornaMessaggio(messaggio);

        //    if (messaggio.Contains("Prodotti Finiti"))
        //    {
        //        lblMaxDiba.Text = e.ProgressPercentage.ToString();
        //        _numeroElementi = e.ProgressPercentage;
        //        prgDiba.Maximum = e.ProgressPercentage;
        //        return;
        //    }

        //}

        private void AggiornaMessaggio(string messaggio)
        {
            string str = string.Format("{0} - {1}", DateTime.Now.ToShortTimeString(), messaggio);
            txtNote.Text = str + Environment.NewLine + txtNote.Text;
        }

        //private void _bgwDiba_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    BackgroundWorker worker = sender as BackgroundWorker;
        //    string idInventarioT = (string)e.Argument;
        //    DiBa diba = new DiBa();

        //    diba.DeleteCostiArticoli(idInventarioT);

        //    if (worker.CancellationPending)
        //    {
        //        e.Cancel = true;
        //        return;
        //    }
        //    diba.FillTABFAS();
        //    worker.ReportProgress(0, "Caricate Fasi");

        //    if (worker.CancellationPending)
        //    {
        //        e.Cancel = true;
        //        return;
        //    }
        //    diba.CaricaTDiba();
        //    worker.ReportProgress(0, "Caricate TDIBA");

        //    if (worker.CancellationPending)
        //    {
        //        e.Cancel = true;
        //        return;
        //    }
        //    diba.CaricaRDiba();
        //    worker.ReportProgress(0, "Caricate RDIBA");

        //    if (worker.CancellationPending)
        //    {
        //        e.Cancel = true;
        //        return;
        //    }
        //    diba.CaricaTDibaDefault();
        //    worker.ReportProgress(0, "Caricate DEFAULTS");

        //    if (worker.CancellationPending)
        //    {
        //        e.Cancel = true;
        //        return;
        //    }
        //    int numeroProdottiFiniti = diba.PreparazioneElaborazione();
        //    worker.ReportProgress(numeroProdottiFiniti, string.Format("Prodotti Finiti: {0}", numeroProdottiFiniti));

        //    if (worker.CancellationPending)
        //    {
        //        e.Cancel = true;
        //        return;
        //    }
        //    diba.ElaboraDiba(idInventarioT, worker, e);
        //    worker.ReportProgress(numeroProdottiFiniti, string.Format("Salvataggio in dati corso...", numeroProdottiFiniti));
        //    diba.SalvaCostiArticolo();

        //    worker.ReportProgress(100);
        //}

        private void InizializzaLabel()
        {

            lblCostoCur.Text = string.Empty;
            lblCostoMax.Text = string.Empty;

            lblTempoCosto.Text = string.Empty;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == etichettaStart)
            {
                if (ddlInventario.SelectedIndex == -1)
                {
                    MessageBox.Show("Selezionare un inventario", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Testata testata = (Testata)ddlInventario.SelectedItem;
                _start = DateTime.Now;

                btnStart.Text = etichettaStop;

                if (_bgwCosto.IsBusy != true)
                {
                    // Start the asynchronous operation.
                    CostiDTO dto = new CostiDTO();
                    dto.testata = testata;
                    dto.consideraTutteLeFasi = chkConsideraTutteLeFasi.Checked;
                    dto.consideraListiniTopFinish = chkVenditaTopFinish.Checked;
                    _bgwCosto.RunWorkerAsync(dto);
                    return;
                }
            }
            else
            {
                if (_bgwCosto.WorkerSupportsCancellation == true && _bgwCosto.IsBusy)
                {
                    // Cancel the asynchronous operation.
                    _bgwCosto.CancelAsync();
                }
                btnStart.Text = etichettaStart;
            }
        }
    }

    public class CostiDTO
    {
        public bool consideraTutteLeFasi { get; set; }
        public Testata testata { get; set; }
        public bool consideraListiniTopFinish { get; set; }
    }
}

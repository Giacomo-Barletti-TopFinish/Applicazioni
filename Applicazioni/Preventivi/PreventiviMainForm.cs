using Applicazioni.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preventivi
{
    public partial class PreventiviMainForm : BaseForm
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public PreventiviMainForm()
        {
            InitializeComponent();
            LogScrivi("Applicazione Preventivi avviata");
        }
        public static void LogScriviErrore(string Messaggio, Exception ex)
        {
            _log.Error(Messaggio, ex);
        }

        public static void LogScrivi(string Messaggio)
        {
            _log.Info(Messaggio);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void balenciagaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BalenciagaFrm form = new BalenciagaFrm();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in apertura finestra balenciaga", ex);
            }
        }

        private void PreventiviMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                LogScrivi("Applicazione Preventivi fermata");
                if (this.MdiChildren.Count() > 0)
                {
                    foreach (Form f in MdiChildren)
                        f.Close();
                }

            }
            catch(Exception ex)
            {
                MostraEccezione("Errore in chiusura applicazione", ex);
            }
        }
        public void MostraEccezione(string messaggioLog, Exception ex)
        {
            LogScriviErrore(messaggioLog, ex);
            base.MostraEccezione(ex, messaggioLog);
        }

        private void cascataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void organizzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
    }
}

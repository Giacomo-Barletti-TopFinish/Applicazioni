using Applicazioni.Common;
using Applicazioni.Data.Galvanica;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalvanicaFrm
{
    public partial class StoricoFrm : BaseForm
    {
        GalvanicaDS _ds = new GalvanicaDS();
        public StoricoFrm()
        {
            InitializeComponent();
        }

        private void StoricoFrm_Load(object sender, EventArgs e)
        {
            dtGiorno.Value = DateTime.Today;
            CaricaStorico(dtGiorno.Value);
            lblMessaggi.Text = string.Empty;
            ImpostaSettimana(dtGiorno.Value);
        }
        private void ImpostaSettimana(DateTime dt)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            int settimana = cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            lblSettimana.Text = string.Format("Settimana {0}", settimana);

        }

        private void CaricaStorico(DateTime data)
        {
            this.Text = string.Format("Pianificazione del giorno {0}", data.ToShortDateString());
            using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
            {
                _ds = new GalvanicaDS();
                bGalvanica.FillAP_GALVANICA_PIANO(_ds, data);

                dgvGriglia.DataSource = _ds;
                dgvGriglia.DataMember = _ds.AP_GALVANICA_PIANO.TableName;
            }
        }

        private void dtGiorno_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                CaricaStorico(dtGiorno.Value);
                ImpostaSettimana(dtGiorno.Value);
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in elabora barcode");
            }

        }
    }
}

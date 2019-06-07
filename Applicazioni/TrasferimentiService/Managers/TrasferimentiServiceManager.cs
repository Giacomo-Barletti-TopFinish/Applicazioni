using Applicazioni.Data.Trasferimenti;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrasferimentiService.Helpers;

namespace TrasferimentiService.Managers
{
    public class TrasferimentiServiceManager : IDisposable
    {
        public void Dispose()
        {
        }
        public void DoIt()
        {
            using (TrasferimentiDS dsTrasferimenti = new TrasferimentiDS())
            using (TrasferimentiBusiness bTrasferimenti = new TrasferimentiBusiness())
            {
                bTrasferimenti.FillTRASFERIMENTIAttivi(dsTrasferimenti);
                LogHelper.LogInfo("Trasferimenti acquisiti");
                bTrasferimenti.FillUSR_PRD_FLUSSO_MOVFASIDaTrasferimentiAttivi(dsTrasferimenti);
                LogHelper.LogInfo("Flussi acquisiti");

                foreach (TrasferimentiDS.AP_TTRASFERIMENTIRow trasferimento in dsTrasferimenti.AP_TTRASFERIMENTI)
                {
                    bool attivo = false;
                    List<TrasferimentiDS.AP_DTRASFERIMENTIRow> dettagli = dsTrasferimenti.AP_DTRASFERIMENTI.Where(x => x.IDTRASFERIMENTO == trasferimento.IDTRASFERIMENTO).ToList();

                    foreach (TrasferimentiDS.AP_DTRASFERIMENTIRow dettaglio in dettagli)
                    {
                        if (!dsTrasferimenti.USR_PRD_FLUSSO_MOVFASI.Any(x => x.BARCODE_ODL == dettaglio.BARCODE_ODL))
                            attivo = true;
                    }
                    if (!attivo) trasferimento.ATTIVO = 0;
                }

                bTrasferimenti.SalvaTrasferimenti(dsTrasferimenti);
            }
        }
    }
}

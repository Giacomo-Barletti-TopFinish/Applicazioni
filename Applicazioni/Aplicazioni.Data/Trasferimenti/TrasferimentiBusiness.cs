using Applicazioni.Data.Core;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.Trasferimenti
{
    public class TrasferimentiBusiness : BusinessBase
    {
        [DataContext]
        public void FillUSR_PRD_TIPOMOVFASI(TrasferimentiDS ds)
        {
            TrasferimentiAdapter a = new TrasferimentiAdapter(DbConnection, DbTransaction);
            a.FillUSR_PRD_TIPOMOVFASI(ds);
        }
        [DataContext]
        public void FillUSR_PRD_MOVFASI(TrasferimentiDS ds, string barcode)
        {
            TrasferimentiAdapter a = new TrasferimentiAdapter(DbConnection, DbTransaction);
            a.FillUSR_PRD_MOVFASI(ds, barcode);
        }
        [DataContext]
        public void FillUSR_TRASF_RICH(TrasferimentiDS ds, string barcode)
        {
            TrasferimentiAdapter a = new TrasferimentiAdapter(DbConnection, DbTransaction);
            a.FillUSR_TRASF_RICH(ds, barcode);
        }
        [DataContext]
        public void FillAP_TTRASFERIMENTIDaBarcodePartenza(TrasferimentiDS ds, string barcode)
        {
            TrasferimentiAdapter a = new TrasferimentiAdapter(DbConnection, DbTransaction);
            a.FillAP_TTRASFERIMENTIDaBarcodePartenza(ds, barcode);
        }

        [DataContext]
        public void FillTRASFERIMENTIAttivi(TrasferimentiDS ds)
        {
            TrasferimentiAdapter a = new TrasferimentiAdapter(DbConnection, DbTransaction);
            a.FillAP_TTRASFERIMENTIAttivi(ds);
            a.FillAP_DTRASFERIMENTIAttivi(ds);
        }
        [DataContext]
        public void FillAP_DTRASFERIMENTIDaIDTRASFERIMENTO(TrasferimentiDS ds, decimal IDTRASFERIMENTO)
        {
            TrasferimentiAdapter a = new TrasferimentiAdapter(DbConnection, DbTransaction);
            a.FillAP_DTRASFERIMENTIDaIDTRASFERIMENTO(ds, IDTRASFERIMENTO);
        }

        [DataContext]
        public void FillUSR_PRD_FLUSSO_MOVFASIDaTrasferimentiAttivi(TrasferimentiDS ds)
        {
            TrasferimentiAdapter a = new TrasferimentiAdapter(DbConnection, DbTransaction);
            a.FillUSR_PRD_FLUSSO_MOVFASIDaTrasferimentiAttivi(ds);
        }

        [DataContext(true)]
        public void SalvaTrasferimenti(TrasferimentiDS ds)
        {
            TrasferimentiAdapter a = new TrasferimentiAdapter(DbConnection, DbTransaction);
            a.UpdateTable(ds.AP_TTRASFERIMENTI.TableName, ds);
            a.UpdateTable(ds.AP_DTRASFERIMENTI.TableName, ds);
        }

    }
}

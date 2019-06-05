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
        public void FillAP_TTRASFERIMENTI(TrasferimentiDS ds, string barcode)
        {
            TrasferimentiAdapter a = new TrasferimentiAdapter(DbConnection, DbTransaction);
            a.FillAP_TTRASFERIMENTI(ds, barcode);
        }
        [DataContext]
        public void FillAP_DTRASFERIMENTI(TrasferimentiDS ds, decimal IDTRASFERIMENTO)
        {
            TrasferimentiAdapter a = new TrasferimentiAdapter(DbConnection, DbTransaction);
            a.FillAP_DTRASFERIMENTI(ds, IDTRASFERIMENTO);
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

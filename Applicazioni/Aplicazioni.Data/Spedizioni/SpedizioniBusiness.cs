using Applicazioni.Data.Core;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.Spedizioni
{
    public class SpedizioniBusiness : BusinessBase
    {
        [DataContext]
        public void FillSPUBICAZIONI(SpedizioniDS ds, bool soloNonCancellati)
        {
            SpedizioniAdapter a = new SpedizioniAdapter(DbConnection, DbTransaction);
            a.FillSPUBICAZIONI(ds, soloNonCancellati);
        }
     
        [DataContext(true)]
        public void SalvaUbicazioni(SpedizioniDS ds)
        {
            SpedizioniAdapter a = new SpedizioniAdapter(DbConnection, DbTransaction);
            a.UpdateTable(ds.SPUBICAZIONI.TableName, ds);           
        }

        [DataContext]
        public void FillSPSALDI(SpedizioniDS ds, bool soloNonCancellati)
        {
            SpedizioniAdapter a = new SpedizioniAdapter(DbConnection, DbTransaction);
            a.FillSPSALDI(ds, soloNonCancellati);
        }

        [DataContext(true)]
        public void SalvaSaldi(SpedizioniDS ds)
        {
            SpedizioniAdapter a = new SpedizioniAdapter(DbConnection, DbTransaction);
            a.UpdateTable(ds.SPSALDI.TableName, ds);
        }

    }


}

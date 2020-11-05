using Applicazioni.Data.Core;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.FlussoFatture
{
    public class FlussoFattureBusiness: BusinessBase
    {
        [DataContext]
        public void FillBOLLE_VENDITATESTATA(FlussoFattureDS ds, DateTime Dal, DateTime Al)
        {
            FlussoFattureAdapter a = new FlussoFattureAdapter(DbConnection, DbTransaction);
            a.FillBOLLE_VENDITATESTATA(ds, Dal, Al);
        }
        [DataContext]
        public void FillBC_FLUSSO_TESTATA(FlussoFattureDS ds, DateTime Dal, DateTime Al)
        {
            FlussoFattureAdapter a = new FlussoFattureAdapter(DbConnection, DbTransaction);
            a.FillBC_FLUSSO_TESTATA(ds, Dal, Al);
        }
        [DataContext]
        public void FillBC_FLUSSO_DETTAGLIO(FlussoFattureDS ds, DateTime Dal, DateTime Al)
        {
            FlussoFattureAdapter a = new FlussoFattureAdapter(DbConnection, DbTransaction);
            a.FillBC_FLUSSO_DETTAGLIO(ds, Dal, Al);
        }
    }
}

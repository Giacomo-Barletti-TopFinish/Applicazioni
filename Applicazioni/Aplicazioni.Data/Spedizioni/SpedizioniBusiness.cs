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
<<<<<<< HEAD
        [DataContext]
        public void FillSPUBICAZIONI(SpedizioniDS ds, bool soloNonCancellati)
        {
            SpedizioniAdapter a = new SpedizioniAdapter(DbConnection, DbTransaction);
            a.FillSPUBICAZIONI(ds, soloNonCancellati);
        }
=======
     
        [DataContext(true)]
        public void SalvaUbicazioni(SpedizioniDS ds)
        {
            SpedizioniAdapter a = new SpedizioniAdapter(DbConnection, DbTransaction);
            a.UpdateTable(ds.SPUBICAZIONI.TableName, ds);           
        }

>>>>>>> 2f352375d0a953a41e42ba22743692fe4ed122d3
    }
}

using Applicazioni.Data.Core;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.Spedizioni
{
    public class SpedizioniBusiness: BusinessBase
    {
     
        [DataContext(true)]
        public void SalvaUbicazioni(SpedizioniDS ds)
        {
            SpedizioniAdapter a = new SpedizioniAdapter(DbConnection, DbTransaction);
            a.UpdateTable(ds.SPUBICAZIONI.TableName, ds);           
        }

    }
}

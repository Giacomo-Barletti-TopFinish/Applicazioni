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
    }
}

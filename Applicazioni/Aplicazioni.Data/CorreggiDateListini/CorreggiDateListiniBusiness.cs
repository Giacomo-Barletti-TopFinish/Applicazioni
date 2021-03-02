using Applicazioni.Data.Core;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.CorreggiDateListini
{
    public class CorreggiDateListiniBusiness : BusinessBase
    {
        [DataContext]
        public void FillUSR_LIS_ACQ_COR(CorreggiDateListiniDS ds)
        {
            CorreggiDateListiniAdapter a = new CorreggiDateListiniAdapter(DbConnection, DbTransaction);
            a.FillUSR_LIS_ACQ_COR(ds);
        }

        [DataContext(true)]
        public void UpdateTable(string tablename, CorreggiDateListiniDS ds)
        {
            CorreggiDateListiniAdapter a = new CorreggiDateListiniAdapter(DbConnection, DbTransaction);
            a.UpdateTable(tablename, ds);
        }
    }
}

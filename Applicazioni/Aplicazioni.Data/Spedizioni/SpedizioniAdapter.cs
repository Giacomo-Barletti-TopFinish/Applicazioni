using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.Spedizioni
{
    public class SpedizioniAdapter : AdapterBase
    {
        public SpedizioniAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
      base(connection, transaction)
        { }
        public void FillSPUBICAZIONI(SpedizioniDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM SPUBICAZIONI ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 'N'";

            select += "ORDER BY CODICE ";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.SPUBICAZIONI);
            }
        }
    }
}

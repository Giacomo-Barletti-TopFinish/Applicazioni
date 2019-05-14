using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.Anagrafica
{
    public class AnagraficaAdapter : AdapterBase
    {
        public AnagraficaAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
         base(connection, transaction)
        { }

        public void FillMAGAZZ(AnagraficaDS ds, List<string> IDMAGAZZ)
        {
            string inCOndition = ConvertToStringForInCondition(IDMAGAZZ);

            string select = @"SELECT DISTINCT * FROM GRUPPO.MAGAZZ WHERE IDMAGAZZ in ( {0} )";
            select = string.Format(select, inCOndition);

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.MAGAZZ);
            }
        }
    }
}

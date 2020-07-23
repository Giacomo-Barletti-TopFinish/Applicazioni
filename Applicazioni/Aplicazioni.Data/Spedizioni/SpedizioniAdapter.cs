using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.Spedizioni
{
    public class SpedizioniAdapter: AdapterBase
    {
        public SpedizioniAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
      base(connection, transaction)
        { }

    }
}

using Applicazioni.Data.Core;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.Preventivi
{
    public class PreventiviBusiness : BusinessBase
    {
        [DataContext]
        public void FillUSR_VENDITEPT(PreventiviDS ds, string Riferimento, string FiltroCliente)
        {
            PreventiviAdapter a = new PreventiviAdapter(DbConnection, DbTransaction);
            a.FillUSR_VENDITEPT(ds, Riferimento, FiltroCliente);
        }

        [DataContext]
        public void FillUSR_VENDITEPD(PreventiviDS ds, string IDVENDITEPT)
        {
            PreventiviAdapter a = new PreventiviAdapter(DbConnection, DbTransaction);
            a.FillUSR_VENDITEPD(ds, IDVENDITEPT);
        }
    }
}

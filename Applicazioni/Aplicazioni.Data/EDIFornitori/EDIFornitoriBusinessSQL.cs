using Applicazioni.Data.Core;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.EDIFornitori
{
    public class EDIFornitoriBusinessSQL : BusinessBaseSQL
    {
        [DataContext]
        public void FillBOLLE_VENDITATESTATA(EDIFornitoriDS ds, DateTime Dal, DateTime Al)
        {
            EDIFornitoriAdapter a = new EDIFornitoriAdapter(DbConnection, DbTransaction);
            a.FillBOLLE_VENDITATESTATASQL(ds, Dal, Al);
        }

        [DataContext]
        public void FillBOLLE_VENDITA(EDIFornitoriDS ds, DateTime Dal, DateTime Al, string CodiceFornitore)
        {
            EDIFornitoriAdapter a = new EDIFornitoriAdapter(DbConnection, DbTransaction);
            a.FillBOLLE_VENDITA(ds, Dal, Al, CodiceFornitore);
        }
        [DataContext]
        public void FillACCESSORISTI(EDIFornitoriDS ds)
        {
            EDIFornitoriAdapter a = new EDIFornitoriAdapter(DbConnection, DbTransaction);
            a.FillACCESSORISTI(ds);
        }
    }
}

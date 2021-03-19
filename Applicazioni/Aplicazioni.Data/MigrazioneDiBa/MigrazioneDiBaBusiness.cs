using Applicazioni.Data.Core;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.MigrazioneDiBa
{
    public class MigrazioneDiBaBusiness : BusinessBase
    {
        [DataContext]
        public void FillMAGAZZ(MigrazioneDiBaDS ds)
        {
            MigrazioneDiBaAdapter a = new MigrazioneDiBaAdapter(DbConnection, DbTransaction);
            a.FillMAGAZZ(ds);
        }
        [DataContext]
        public void FillBC_ANAGRAFICA(MigrazioneDiBaDS ds)
        {
            MigrazioneDiBaAdapter a = new MigrazioneDiBaAdapter(DbConnection, DbTransaction);
            a.FillBC_ANAGRAFICA(ds);
        }

        [DataContext(true)]
        public void UpdateTable(string tablename, MigrazioneDiBaDS ds)
        {
            MigrazioneDiBaAdapter a = new MigrazioneDiBaAdapter(DbConnection, DbTransaction);
            a.UpdateTable(tablename, ds);
        }
    }
}

using Applicazioni.Data.MigrazioneDiBa;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.BLL
{
    public class MigrazioneDiBaBLL
    {
        public void FillMAGAZZ(MigrazioneDiBaDS ds)
        {
            using (MigrazioneDiBaBusiness bMigrazione = new MigrazioneDiBaBusiness())
            {
                bMigrazione.FillMAGAZZ(ds);
            }
        }
        public void FillBC_ANAGRAFICA(MigrazioneDiBaDS ds)
        {
            using (MigrazioneDiBaBusiness bMigrazione = new MigrazioneDiBaBusiness())
            {
                bMigrazione.FillBC_ANAGRAFICA(ds);
            }
        }
    }
}

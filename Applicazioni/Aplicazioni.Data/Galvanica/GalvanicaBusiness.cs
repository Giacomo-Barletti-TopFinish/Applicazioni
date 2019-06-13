using Applicazioni.Data.Core;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.Galvanica
{
    public class GalvanicaBusiness : BusinessBase
    {
        [DataContext]
        public void FillUSR_PRD_MOVFASI(GalvanicaDS ds, string Barcode)
        {
            if (!ds.USR_PRD_MOVFASI.Any(x => x.BARCODE == Barcode))
            {
                GalvanicaAdapter a = new GalvanicaAdapter(DbConnection, DbTransaction);
                a.FillUSR_PRD_MOVFASI(ds, Barcode);
            }
        }

    }
}

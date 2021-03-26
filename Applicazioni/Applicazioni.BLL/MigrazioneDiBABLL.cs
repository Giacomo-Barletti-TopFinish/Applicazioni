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
        public string GetIDMAGAZZByDescrizione(MigrazioneDiBaDS ds, string descrizione)
        {
            MigrazioneDiBaDS.MAGAZZRow riga = ds.MAGAZZ.Where(x => x.DESMAGAZZ == descrizione).FirstOrDefault();
            if (riga != null)
                return riga.IDMAGAZZ;

            using (MigrazioneDiBaBusiness bMigrazione = new MigrazioneDiBaBusiness())
            {
                bMigrazione.GetMagazzByDescrizione(ds, descrizione);
            }
            riga = ds.MAGAZZ.Where(x => x.DESMAGAZZ == descrizione).FirstOrDefault();
            if (riga != null)
                return riga.IDMAGAZZ;

            return string.Empty;
        }
        public void FillBC_ANAGRAFICA(MigrazioneDiBaDS ds)
        {
            using (MigrazioneDiBaBusiness bMigrazione = new MigrazioneDiBaBusiness())
            {
                bMigrazione.FillBC_ANAGRAFICA(ds);
            }
        }

        public void SalvaBC_ANAGRAFICA(MigrazioneDiBaDS ds)
        {
            using (MigrazioneDiBaBusiness bMigrazione = new MigrazioneDiBaBusiness())
            {
                bMigrazione.UpdateTable(ds.BC_ANAGRAFICA.TableName, ds);
                ds.BC_ANAGRAFICA.AcceptChanges();
            }
        }
    }
}

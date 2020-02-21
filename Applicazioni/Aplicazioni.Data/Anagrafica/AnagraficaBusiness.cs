using Applicazioni.Data.Core;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.Anagrafica
{
    public class AnagraficaBusiness : BusinessBase
    {
        [DataContext]
        public void FillMAGAZZ(AnagraficaDS ds, List<string> IDMAGAZZ)
        {
            List<string> articoliPresenti = ds.MAGAZZ.Select(x => x.IDMAGAZZ).Distinct().ToList();
            List<string> articoliMancanti = IDMAGAZZ.Except(articoliPresenti).ToList();

            AnagraficaAdapter a = new AnagraficaAdapter(DbConnection, DbTransaction);
            while (articoliMancanti.Count > 0)
            {
                List<string> articoliDaCaricare;
                if (articoliMancanti.Count > 999)
                {
                    articoliDaCaricare = articoliMancanti.GetRange(0, 999);
                    articoliMancanti.RemoveRange(0, 999);
                }
                else
                {
                    articoliDaCaricare = articoliMancanti.GetRange(0, articoliMancanti.Count);
                    articoliMancanti.RemoveRange(0, articoliMancanti.Count);
                }
                a.FillMAGAZZ(ds, articoliDaCaricare);
                a.FillUSR_PDM_FILES(ds, articoliDaCaricare);
            }
        }

        [DataContext]
        public void FillUSR_PREV_GRUPPI(AnagraficaDS ds)
        {
            AnagraficaAdapter a = new AnagraficaAdapter(DbConnection, DbTransaction);
            a.FillUSR_PREV_GRUPPI(ds);
        }

        [DataContext]
        public void FillUSR_PRD_CDDIBA(AnagraficaDS ds)
        {
            AnagraficaAdapter a = new AnagraficaAdapter(DbConnection, DbTransaction);
            a.FillUSR_PRD_CDDIBA(ds);
        }

        [DataContext]
        public void FillUSR_TAB_VOCICOSTO(AnagraficaDS ds)
        {
            AnagraficaAdapter a = new AnagraficaAdapter(DbConnection, DbTransaction);
            a.FillUSR_TAB_VOCICOSTO(ds);
        }


        [DataContext]
        public void FillCLIFO(AnagraficaDS ds)
        {
            AnagraficaAdapter a = new AnagraficaAdapter(DbConnection, DbTransaction);
            a.FillCLIFO(ds);
        }
        [DataContext]
        public void FillTABFAS(AnagraficaDS ds)
        {
            AnagraficaAdapter a = new AnagraficaAdapter(DbConnection, DbTransaction);
            a.FillTABFAS(ds);
        }
        [DataContext]
        public void FillMAGAZZ(AnagraficaDS ds)
        {
            AnagraficaAdapter a = new AnagraficaAdapter(DbConnection, DbTransaction);
            a.FillMAGAZZ(ds);
        }
    }
}

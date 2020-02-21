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

        public void FillUSR_PREV_GRUPPI(AnagraficaDS ds)
        {
            string select = @"SELECT * FROM GRUPPO.USR_PREV_GRUPPI ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.USR_PREV_GRUPPI);
            }
        }

        public void FillUSR_TAB_VOCICOSTO(AnagraficaDS ds)
        {
            string select = @"SELECT * FROM GRUPPO.USR_TAB_VOCICOSTO ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.USR_TAB_VOCICOSTO);
            }
        }

        public void FillUSR_PRD_CDDIBA(AnagraficaDS ds)
        {
            string select = @"SELECT * FROM ditta1.USR_PRD_CDDIBA ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.USR_PRD_CDDIBA);
            }
        }

        public void FillUSR_PDM_FILES(AnagraficaDS ds, List<string> IDMAGAZZ)
        {
            string inCOndition = ConvertToStringForInCondition(IDMAGAZZ);

            string select = @"  select FI.*, IM.IDMAGAZZ,PA.PDMPATH  from gruppo.USR_PDM_FILES FI
            INNER JOIN GRUPPO.USR_PDM_IMG_MAGAZZ IM ON IM.IDPDMFILE = FI.IDPDMFILE
            INNER JOIN GRUPPO.USR_PDM_PATHS PA ON PA.IDPDMPATH = FI.IDPDMPATH
            where IM.idmagazz in ( {0} )";

            select = string.Format(select, inCOndition);

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.USR_PDM_FILES);
            }
        }

        public void FillCLIFO(AnagraficaDS ds)
        {
            string select = @"SELECT * FROM gruppo.CLIFO ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.CLIFO);
            }
        }

        public void FillTABFAS(AnagraficaDS ds)
        {
            string select = @"SELECT * FROM gruppo.tabfas ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.TABFAS);
            }
        }

        public void FillMAGAZZ(AnagraficaDS ds)
        {
            string select = @"SELECT * FROM gruppo.MAGAZZ ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.MAGAZZ);
            }
        }

    }
}

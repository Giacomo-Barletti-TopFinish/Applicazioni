using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.Valorizzazioni
{
    public class ValorizzazioneAdapter : AdapterBase
    {
        public ValorizzazioneAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
        { }

        public void FillUSR_INVENTARIOT(ValorizzazioneDS ds)
        {
            string select = @"SELECT * FROM ditta1.USR_INVENTARIOT  order by DATARIMFINALE desc,CODINVENTARIOT desc";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.USR_INVENTARIOT);
            }
        }

        public void FillUSR_INVENTARIOD(ValorizzazioneDS ds, string idInventarioT)
        {
            string select = @"SELECT * FROM ditta1.USR_INVENTARIOD  WHERE IDINVENTARIOT = $P<INVENTARIOT>";

            ParamSet ps = new ParamSet();
            ps.AddParam("INVENTARIOT", DbType.String, idInventarioT);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_INVENTARIOD);
            }
        }

        public void FillUSR_VENDITED(ValorizzazioneDS ds, string anno)
        {
            string select = @" SELECT vd.* FROM usr_vendited vd 
        inner join usr_venditet vt on vt.idvenditet = vd.idvenditet
        where vt.annodoc = $P<ANNO> and vt.IDTABTIPDOC = '0000000022'";

            ParamSet ps = new ParamSet();
            ps.AddParam("ANNO", DbType.String, anno);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_VENDITED);
            }
        }

        public void FillUSR_PRD_RDIBA(ValorizzazioneDS ds)
        {
            string select = @"SELECT 'METALPLUS'as AZIENDA,TD.* FROM DITTA1.USR_PRD_RDIBA TD 
                             --   UNION ALL 
                             --   SELECT 'TOPFINISH'as AZIENDA,TD.* FROM DITTA2.USR_PRD_RDIBA TD";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.USR_PRD_RDIBA);
            }
        }


        public void FillUSR_PRD_RDIBA(ValorizzazioneDS ds, List<string> idRdiba)
        {
            string inCOndition = ConvertToStringForInCondition(idRdiba);
            string select = @"SELECT 'METALPLUS'as AZIENDA,TD.* FROM DITTA1.USR_PRD_RDIBA TD where IDRDIBA in ( {0} )
                            --    UNION ALL 
                            --    SELECT 'TOPFINISH'as AZIENDA,TD.* FROM DITTA2.USR_PRD_RDIBA TD where IDRDIBA in ( {0} )";
            select = string.Format(select, inCOndition);

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.USR_PRD_RDIBA);
            }
        }

        public void FillUSR_PRD_TDIBA(ValorizzazioneDS ds, List<string> idTdiba)
        {
            string inCOndition = ConvertToStringForInCondition(idTdiba);
            string select = @"SELECT 'METALPLUS'as AZIENDA,TD.* FROM DITTA1.USR_PRD_TDIBA TD where IDTDIBA in ( {0} )
                              --  UNION ALL 
                             --   SELECT 'TOPFINISH'as AZIENDA,TD.* FROM DITTA2.USR_PRD_TDIBA TD where IDTDIBA in ( {0} )";
            select = string.Format(select, inCOndition);

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.USR_PRD_TDIBA);
            }
        }

        public void FillUSR_PRD_TDIBA(ValorizzazioneDS ds)
        {
            string select = @"select *from ditta1.usr_prd_tdiba td";
            //  string select = @"SELECT 'METALPLUS' as AZIENDA,TD.* FROM DITTA1.USR_PRD_TDIBA TD
            //  --INNER JOIN DITTA1.USR_PRD_TDIBA_DEFAULTS DF ON DF.IDTDIBA = TD.IDTDIBA
            //--  UNION ALL
            //                  --SELECT 'TOPFINISH' as AZIENDA,TD.* FROM DITTA2.USR_PRD_TDIBA TD
            //                   --INNER JOIN DITTA2.USR_PRD_TDIBA_DEFAULTS DF ON DF.IDTDIBA = TD.IDTDIBA";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.USR_PRD_TDIBA);
            }
        }

        public void FillUSR_PRD_TDIBA_DEFAULT(ValorizzazioneDS ds)
        {
            string select = @"select *from ditta1.usr_prd_tdiba td
                                    inner join ditta1.USR_PRD_TDIBA_DEFAULT tdd on tdd.idtdiba = td.idtdiba";
            //  string select = @"SELECT 'METALPLUS' as AZIENDA,TD.* FROM DITTA1.USR_PRD_TDIBA TD
            //  --INNER JOIN DITTA1.USR_PRD_TDIBA_DEFAULTS DF ON DF.IDTDIBA = TD.IDTDIBA
            //--  UNION ALL
            //                  --SELECT 'TOPFINISH' as AZIENDA,TD.* FROM DITTA2.USR_PRD_TDIBA TD
            //                   --INNER JOIN DITTA2.USR_PRD_TDIBA_DEFAULTS DF ON DF.IDTDIBA = TD.IDTDIBA";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.USR_PRD_TDIBA_DEFAULT);
            }
        }
        public void FillCOSTI_ARTICOLI(ValorizzazioneDS ds, String idInventarioT)
        {
            string select = @"SELECT * from COSTI_ARTICOLI WHERE IDINVENTARIOT = $T<IDINVENTARIOT>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDINVENTARIOT", DbType.String, idInventarioT);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.COSTI_ARTICOLI);
            }
        }

        public void FillUSR_PRD_TDIBA_DEFAULTS(ValorizzazioneDS ds)
        {
            string select = @"SELECT * FROM DITTA1.USR_PRD_TDIBA_DEFAULTS 
--UNION ALL 
--SELECT * FROM DITTA2.USR_PRD_TDIBA_DEFAULTS";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.USR_PRD_TDIBA_DEFAULTS);
            }
        }

        public void FillUSR_LIS_ACQ(ValorizzazioneDS ds)
        {
            string select = @"SELECT * FROM USR_LIS_ACQ ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.USR_LIS_ACQ);
            }
        }

        public void FillUSR_LIS_VEN(ValorizzazioneDS ds)
        {
            string select = @"SELECT * FROM USR_LIS_VEN ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.USR_LIS_VEN);
            }
        }

        public void FillUSR_LIS_FASE(ValorizzazioneDS ds)
        {
            string select = @"SELECT * FROM USR_LIS_FASE ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.USR_LIS_FASE);
            }
        }
        public long DeleteCostiArticoli(string IdInventarioT)
        {
            string select = @" DELETE FROM COSTI_ARTICOLI WHERE IDINVENTARIOT = '" + IdInventarioT + "'";
            using (IDbCommand da = BuildCommand(select))
            {
                long lnNextVal = Convert.ToInt64(da.ExecuteNonQuery());
                return lnNextVal;
            }
        }

        public long DeleteCostiGalvanica()
        {
            string select = @" DELETE FROM COSTI_GALVANICA ";
            using (IDbCommand da = BuildCommand(select))
            {
                long lnNextVal = Convert.ToInt64(da.ExecuteNonQuery());
                return lnNextVal;
            }
        }
        public void UpdateTable(string tablename, ValorizzazioneDS ds)
        {
            string query = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}", tablename);

            using (DbDataAdapter a = BuildDataAdapter(query))
            {
                a.ContinueUpdateOnError = false;
                DataTable dt = ds.Tables[tablename];
                DbCommandBuilder cmd = BuildCommandBuilder(a);
                a.UpdateCommand = cmd.GetUpdateCommand();
                a.DeleteCommand = cmd.GetDeleteCommand();
                a.InsertCommand = cmd.GetInsertCommand();
                a.Update(dt);
            }
        }
    }
}

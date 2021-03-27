using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applicazioni.Entities;

namespace Applicazioni.Data.EstraiProdottiFiniti
{
    public class EstraiProdottiFinitiAdapter : AdapterBase
    {
        public EstraiProdottiFinitiAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
   base(connection, transaction)
        { }

        public void GetUSR_PRD_TDIBAByModello(EstraiProdottiFinitiDS ds, string modello)
        {

            string select = string.Format(@"select MA.MODELLO,TB.* from ditta1.usr_prd_tdiba tb
                                inner join gruppo.magazz ma on ma.idmagazz = tb.idmagazz
                                where ma.modello like '{0}%'", modello);

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.USR_PRD_TDIBA);
            }
        }

        public void GetUSR_PRD_TDIBA(EstraiProdottiFinitiDS ds, string IDTDIBA)
        {

            string select = string.Format(@"select MA.MODELLO,TB.* from ditta1.usr_prd_tdiba tb
                                inner join gruppo.magazz ma on ma.idmagazz = tb.idmagazz
                                where tb.IDTDIBA =  $P<IDTDIBA>");
            ParamSet ps = new ParamSet();
            ps.AddParam("IDTDIBA", DbType.String, IDTDIBA);
            using (DbDataAdapter da = BuildDataAdapter(select,ps))
            {
                da.Fill(ds.USR_PRD_TDIBA);
            }
        }

        public void GetUSR_PRD_RDIBA(EstraiProdottiFinitiDS ds, string IDTDIBA)
        {

            string select = string.Format(@"select TB.* from ditta1.usr_prd_Rdiba tb
                                where tb.IDTDIBA =  $P<IDTDIBA>");
            ParamSet ps = new ParamSet();
            ps.AddParam("IDTDIBA", DbType.String, IDTDIBA);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_RDIBA);
            }
        }

        public void GetMAGAZZ(EstraiProdottiFinitiDS ds, string IDMAGAZZ)
        {

            string select = string.Format(@"select * from gruppo.magazz where IDMAGAZZ =  $P<IDMAGAZZ>");
            ParamSet ps = new ParamSet();
            ps.AddParam("IDMAGAZZ", DbType.String, IDMAGAZZ);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.MAGAZZ);
            }
        }

        public void FillBC_ANAGRAFICA(EstraiProdottiFinitiDS ds)
        {

            string select = string.Format(@"select * from BC_ANAGRAFICA");

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.BC_ANAGRAFICA);
            }
        }

        public void UpdateTable(string tablename, EstraiProdottiFinitiDS ds)
        {
            string query = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}", tablename);

            using (DbDataAdapter a = BuildDataAdapter(query))
            {
                try
                {
                    a.ContinueUpdateOnError = false;
                    DataTable dt = ds.Tables[tablename];
                    DbCommandBuilder cmd = BuildCommandBuilder(a);
                    a.UpdateCommand = cmd.GetUpdateCommand();
                    a.DeleteCommand = cmd.GetDeleteCommand();
                    a.InsertCommand = cmd.GetInsertCommand();
                    a.Update(dt);
                }
                catch (DBConcurrencyException ex)
                {

                }
                catch
                {
                    throw;
                }
            }
        }
    }
}

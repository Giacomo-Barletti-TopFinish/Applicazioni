using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.MigrazioneDiBa
{
    public class MigrazioneDiBaAdapter: AdapterBase
    {
        public MigrazioneDiBaAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
       base(connection, transaction)
        { }

        public void FillMAGAZZ(MigrazioneDiBaDS ds)
        {

            string select = @"SELECT DISTINCT * FROM GRUPPO.MAGAZZ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.MAGAZZ);
            }
        }
        public void GetMagazzByDescrizione(MigrazioneDiBaDS ds, string descrizione)
        {

            string select = @"SELECT DISTINCT * FROM GRUPPO.MAGAZZ where DESCRIZIONE = <DESCRIZIONE>";

            ParamSet ps = new ParamSet();
            ps.AddParam("DESCRIZIONE", DbType.String, descrizione);

            using (DbDataAdapter da = BuildDataAdapter(select,ps))
            {
                da.Fill(ds.MAGAZZ);
            }
        }
        public void FillBC_ANAGRAFICA(MigrazioneDiBaDS ds)
        {

            string select = @"SELECT DISTINCT * FROM BC_ANAGRAFICA";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.BC_ANAGRAFICA);
            }
        }

        public void UpdateTable(string tablename, MigrazioneDiBaDS ds)
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

using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.CorreggiDateListini
{
    public class CorreggiDateListiniAdapter: AdapterBase
    {
        public CorreggiDateListiniAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
        base(connection, transaction)
        { }

        public void FillUSR_LIS_ACQ_COR(CorreggiDateListiniDS ds)
        {
            string select = @"select * from USR_LIS_ACQ_COR";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.USR_LIS_ACQ_COR);
            }
        }

        public void UpdateTable(string tablename, CorreggiDateListiniDS ds)
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

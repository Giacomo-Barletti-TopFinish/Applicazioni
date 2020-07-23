using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
<<<<<<< HEAD
=======
using System.Globalization;
>>>>>>> 2f352375d0a953a41e42ba22743692fe4ed122d3
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.Spedizioni
{
    public class SpedizioniAdapter : AdapterBase
    {
        public SpedizioniAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
      base(connection, transaction)
        { }
        public void FillSPUBICAZIONI(SpedizioniDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM SPUBICAZIONI ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 'N'";

<<<<<<< HEAD
            select += "ORDER BY CODICE ";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.SPUBICAZIONI);
            }
        }
=======
        public void UpdateTable(string tablename, SpedizioniDS ds)
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

>>>>>>> 2f352375d0a953a41e42ba22743692fe4ed122d3
    }
}

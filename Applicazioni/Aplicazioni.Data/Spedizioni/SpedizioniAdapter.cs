using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
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

            select += "ORDER BY CODICE ";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.SPUBICAZIONI);
            }
        }

        public void FillSPSALDI(SpedizioniDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM SPSALDI ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 'N'";

            select += "ORDER BY CODICE ";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.SPSALDI);
            }
        }
        public void GetUSR_PRD_RESOURCESF(SpedizioniDS ds, string BARCODE)
        {
            string select = @"SELECT * FROM GRUPPO.USR_PRD_RESOURCESF WHERE BARCODE = $P<BARCODE> ";
            ParamSet ps = new ParamSet();
            ps.AddParam("BARCODE", DbType.String, BARCODE);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_RESOURCESF);
            }
        }

        public void GetSaldo(SpedizioniDS ds, decimal idUbicazione, string idmagazz)
        {
            string select = @"select * from spsaldi where idubicazione = $P<IDUBICAZIONE> and idmagazz = $P<IDMAGAZZ>";
            ParamSet ps = new ParamSet();
            ps.AddParam("IDUBICAZIONE", DbType.Decimal, idUbicazione);
            ps.AddParam("IDMAGAZZ", DbType.String, idmagazz);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.SPSALDI);
            }
        }
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

    }
}

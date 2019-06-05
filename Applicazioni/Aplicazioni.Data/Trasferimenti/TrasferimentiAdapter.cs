using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.Trasferimenti
{
    public class TrasferimentiAdapter: AdapterBase
    {
        public TrasferimentiAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
         base(connection, transaction)
        { }

        public void FillUSR_PRD_TIPOMOVFASI(TrasferimentiDS ds)
        {
            string select = @"SELECT * FROM GRUPPO.USR_PRD_TIPOMOVFASI";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.USR_PRD_TIPOMOVFASI);
            }
        }

        public void FillUSR_PRD_MOVFASI(TrasferimentiDS ds, string barcode)
        {
            string select = @"SELECT * FROM USR_PRD_MOVFASI WHERE BARCODE = $P{BARCODE}";

            ParamSet ps = new ParamSet();
            ps.AddParam("BARCODE", DbType.String, barcode);

            using (DbDataAdapter da = BuildDataAdapter(select,ps))
            {
                da.Fill(ds.USR_PRD_MOVFASI);
            }
        }

        public void FillAP_TTRASFERIMENTI(TrasferimentiDS ds, string barcode)
        {
            string select = @"SELECT * FROM AP_TTRASFERIMENTI WHERE BARCODE_PARTENZA = $P{BARCODE} ";

            ParamSet ps = new ParamSet();
            ps.AddParam("BARCODE", DbType.String, barcode);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.AP_TTRASFERIMENTI);
            }
        }

        public void FillAP_DTRASFERIMENTI(TrasferimentiDS ds, decimal IDTRASFERIMENTO)
        {
            string select = @"SELECT * FROM AP_DTRASFERIMENTI WHERE IDTRASFERIMENTO = $P{IDTRASFERIMENTO}";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDTRASFERIMENTO", DbType.Decimal, IDTRASFERIMENTO);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.AP_DTRASFERIMENTI);
            }
        }

        public void UpdateTable(string tablename, TrasferimentiDS ds)
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

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
    public class TrasferimentiAdapter : AdapterBase
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

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_MOVFASI);
            }
        }

        public void FillUSR_TRASF_RICH(TrasferimentiDS ds, string barcode)
        {
            string select = @"SELECT ri.*,RT.NUMRICHTRASFT FROM USR_TRASF_RICH ri 
                                    inner join USR_TRASF_RICHT RT ON RT.IDRICHTRASFT = RI.IDRICHTRASFT
                                    WHERE RI.BARCODE = $P{BARCODE}";

            ParamSet ps = new ParamSet();
            ps.AddParam("BARCODE", DbType.String, barcode);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_TRASF_RICH);
            }
        }

        public void FillAP_TTRASFERIMENTIDaBarcodePartenza(TrasferimentiDS ds, string barcode)
        {
            string select = @"SELECT * FROM AP_TTRASFERIMENTI WHERE BARCODE_PARTENZA = $P{BARCODE} ";

            ParamSet ps = new ParamSet();
            ps.AddParam("BARCODE", DbType.String, barcode);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.AP_TTRASFERIMENTI);
            }
        }

        public void FillGRUPPOModello(TrasferimentiDS ds, string barcode)
        {
            string select = @"select * from gruppo.clifo = $P{MODELLO} ";

            ParamSet ps = new ParamSet();
            ps.AddParam("BARCODE", DbType.String, barcode);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.CLIFO);
            }
        }

        public void FillGRUPPOReparto(TrasferimentiDS ds, string barcode)
        {
            string select = @"select * from gruppo.magazz  = $P{RAGIONESOC} ";

            ParamSet ps = new ParamSet();
            ps.AddParam("BARCODE", DbType.String, barcode);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.MAGAZZ);
            }
        }

        public void FillAP_TTRASFERIMENTIAttivi(TrasferimentiDS ds)
        {
            string select = @"SELECT * FROM AP_TTRASFERIMENTI WHERE attivo =1 ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.AP_TTRASFERIMENTI);
            }
        }

        public void FillAP_DTRASFERIMENTIDaIDTRASFERIMENTO(TrasferimentiDS ds, decimal IDTRASFERIMENTO)
        {
            string select = @"SELECT * FROM AP_DTRASFERIMENTI WHERE IDTRASFERIMENTO = $P{IDTRASFERIMENTO}";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDTRASFERIMENTO", DbType.Decimal, IDTRASFERIMENTO);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.AP_DTRASFERIMENTI);
            }
        }

        public void FillAP_DTRASFERIMENTIAttivi(TrasferimentiDS ds )
        {
            string select = @"SELECT AD.* FROM AP_DTRASFERIMENTI AD INNER JOIN AP_TTRASFERIMENTI AT ON AT.IDTRASFERIMENTO=AD.IDTRASFERIMENTO WHERE ATTIVO = 1";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.AP_DTRASFERIMENTI);
            }
        }

        public void FillUSR_PRD_FLUSSO_MOVFASIDaTrasferimentiAttivi(TrasferimentiDS ds)
        {
            string select = @"select fmf.*,ad.barcode_odl from usr_prd_flusso_movfasi fmf
                                inner join usr_prd_movfasi mf on mf.idprdmovfase = fmf.idprdmovfase
                                inner join AP_DTRASFERIMENTI ad on ad.barcode_odl = mf.barcode
                                inner join AP_TTRASFERIMENTI  at on at.idtrasferimento = ad.idtrasferimento
                                where at.attivo =1 and at.barcode_arrivo is not null";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.USR_PRD_FLUSSO_MOVFASI);
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

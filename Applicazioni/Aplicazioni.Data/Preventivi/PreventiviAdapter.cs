using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.Preventivi
{
    public class PreventiviAdapter : AdapterBase
    {
        public PreventiviAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
           base(connection, transaction)
        { }

        public void FillUSR_VENDITEPT(PreventiviDS ds, string Riferimento, string FiltroCliente)
        {
            string select = @"SELECT * FROM DITTA1.USR_VENDITEPT WHERE CODICECLIFO IN ({0}) AND RIFERIMENTO LIKE $P<RIFERIMENTO> ORDER BY DATADOCUMENTO DESC, NUMDOC";
            select = string.Format(select, FiltroCliente);

            ParamSet ps = new ParamSet();
            string riferimento = Riferimento + "%";
            ps.AddParam("RIFERIMENTO", DbType.String, riferimento);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_VENDITEPT);
            }
        }

        public void FillUSR_VENDITEPD(PreventiviDS ds, string IDVENDITEPT)
        {
            string select = @"SELECT VD.*,MA.MODELLO, MA.DESMAGAZZ FROM DITTA1.USR_VENDITEPD VD
                                INNER JOIN GRUPPO.MAGAZZ MA ON MA.IDMAGAZZ = VD.IDMAGAZZ 
                                WHERE IDVENDITEPT = $P<IDVENDITEPT> ORDER BY NRRIGA";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDVENDITEPT", DbType.String, IDVENDITEPT);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_VENDITEPD);
            }
        }

        public void FillUSR_VENDITEPF(PreventiviDS ds, string IDVENDITEPD)
        {
            string select = @"SELECT VF.* FROM DITTA1.USR_VENDITEPF VF
                                WHERE IDVENDITEPD = $P<IDVENDITEPD> ORDER BY QTA";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDVENDITEPD", DbType.String, IDVENDITEPD);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_VENDITEPF);
            }
        }

        public void FillUSR_VENDITEPF_DIBA(PreventiviDS ds, string IDVENDITEPF)
        {
            string select = @"SELECT VF.* FROM DITTA1.USR_VENDITEPF_DIBA VF
                                WHERE IDVENDITEPF = $P<IDVENDITEPF> ";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDVENDITEPF", DbType.String, IDVENDITEPF);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_VENDITEPF_DIBA);
            }
        }

        public void FillUSR_VENDITEPF_DIBATREE(PreventiviDS ds, string IDVENDITEPFDIBA)
        {
            string select = @"SELECT VF.* FROM DITTA1.USR_VENDITEPF_DIBATREE VF
                                WHERE IDVENDITEPFDIBA = $P<IDVENDITEPFDIBA> ";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDVENDITEPFDIBA", DbType.String, IDVENDITEPFDIBA);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_VENDITEPF_DIBATREE);
            }
        }

        public void FillUSR_VENDITEPF_DIBACOS(PreventiviDS ds, string IDVENDITEPFDIBA)
        {
            string select = @"SELECT COS.*, VC.CODVOCECOSTO, VC.DESVOCECOSTO 
                                FROM DITTA1.USR_VENDITEPF_DIBACOS COS 
                                INNER JOIN GRUPPO.USR_TAB_VOCICOSTO VC ON VC.IDVOCECOSTO = COS.IDVOCECOSTO
                                WHERE IDVENDITEPFDIBA = $P<IDVENDITEPFDIBA> ORDER BY COS.SEQUENZA";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDVENDITEPFDIBA", DbType.String, IDVENDITEPFDIBA);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_VENDITEPF_DIBACOS);
            }
        }

        public void FillUSR_VENDITEPF_GRUPPOT(PreventiviDS ds, string IDVENDITEPFDIBA)
        {
            string select = @"SELECT VT.*,GR.CODPREVGRUPPO, GR.DESPREVGRUPPO 
                                FROM DITTA1.USR_VENDITEPF_GRUPPOT VT 
                                INNER JOIN GRUPPO.USR_PREV_GRUPPI GR ON GR.IDPREVGRUPPO = VT.IDPREVGRUPPO 
                                WHERE IDVENDITEPFDIBA = $P<IDVENDITEPFDIBA> ";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDVENDITEPFDIBA", DbType.String, IDVENDITEPFDIBA);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_VENDITEPF_GRUPPOT);
            }
        }

        public void FillUSR_VENDITEPF_GRUPPOD(PreventiviDS ds, string IDVENDITEPFDIBA)
        {
            string select = @"SELECT VF.* FROM DITTA1.USR_VENDITEPF_GRUPPOD VF
                                WHERE IDVENDITEPFDIBA = $P<IDVENDITEPFDIBA> ";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDVENDITEPFDIBA", DbType.String, IDVENDITEPFDIBA);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_VENDITEPF_GRUPPOD);
            }
        }

        public void FillUSR_VENDITEPF_TOTPREV(PreventiviDS ds, string IDVENDITEPFDIBA)
        {
            string select = @"SELECT VF.* FROM DITTA1.USR_VENDITEPF_TOTPREV VF
                                WHERE IDVENDITEPFDIBA = $P<IDVENDITEPFDIBA> ";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDVENDITEPFDIBA", DbType.String, IDVENDITEPFDIBA);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_VENDITEPF_TOTPREV);
            }
        }

        public void FillAP_PREVENTIVIT(PreventiviDS ds, string IDVENDITEPF)
        {
            string select = @"SELECT VF.* FROM AP_PREVENTIVIT VF
                                WHERE IDVENDITEPF = $P<IDVENDITEPF> ";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDVENDITEPF", DbType.String, IDVENDITEPF);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.AP_PREVENTIVIT);
            }
        }

        public void FillAP_PREVENTIVIC(PreventiviDS ds, string IDVENDITEPF)
        {
            string select = @"SELECT VF.* FROM AP_PREVENTIVIC VF
                                WHERE IDVENDITEPF = $P<IDVENDITEPF> ";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDVENDITEPF", DbType.String, IDVENDITEPF);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.AP_PREVENTIVIC);
            }
        }

        public void FillAP_PREVENTIVIG(PreventiviDS ds, string IDVENDITEPF)
        {
            string select = @"SELECT VF.* FROM AP_PREVENTIVIG VF
                                WHERE IDVENDITEPF = $P<IDVENDITEPF> ";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDVENDITEPF", DbType.String, IDVENDITEPF);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.AP_PREVENTIVIG);
            }
        }

        public void UpdateTable(string tablename, PreventiviDS ds)
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

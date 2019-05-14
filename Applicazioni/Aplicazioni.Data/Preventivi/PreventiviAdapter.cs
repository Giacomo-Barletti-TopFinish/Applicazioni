using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
    }
}

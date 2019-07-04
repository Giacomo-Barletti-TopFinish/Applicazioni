using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.Produzione
{
    public class ProduzioneAdapter : AdapterBase
    {
        public ProduzioneAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
        base(connection, transaction)
        { }

        public void FillUSR_PRD_MOVFASI(ProduzioneDS ds, List<string> IDPRDMOVFASE)
        {
            string inCOndition = ConvertToStringForInCondition(IDPRDMOVFASE);

            string select = @"SELECT DISTINCT * FROM USR_PRD_MOVFASI WHERE IDPRDMOVFASE in ( {0} )";
            select = string.Format(select, inCOndition);

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.USR_PRD_MOVFASI);
            }
        }

        public void FillUSR_PRD_FASI(ProduzioneDS ds, List<string> IDPRDFASE)
        {
            string inCOndition = ConvertToStringForInCondition(IDPRDFASE);

            string select = @"SELECT DISTINCT * FROM USR_PRD_FASI WHERE IDPRDFASE in ( {0} )";
            select = string.Format(select, inCOndition);

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.USR_PRD_FASI);
            }
        }

        public void FillUSR_PRD_MOVFASIByBarcode(ProduzioneDS ds, string Barcode)
        {
            string select = @"SELECT * FROM USR_PRD_MOVFASI WHERE BARCODE = $P{Barcode}";

            ParamSet ps = new ParamSet();
            ps.AddParam("Barcode", DbType.String, Barcode);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_MOVFASI);
            }
        }
    }
}

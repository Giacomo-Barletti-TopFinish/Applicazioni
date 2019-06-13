using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.Galvanica
{
    public class GalvanicaAdapter : AdapterBase
    {
        public GalvanicaAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
           base(connection, transaction)
        { }

        public void FillUSR_PRD_MOVFASI(GalvanicaDS ds, string Barcode)
        {
            string select = @"  SELECT MF.*,
                                MODLAN.IDMAGAZZ AS IDMAGAZZ_LANCIO,
                                MODLAN.MODELLO AS MODELLO_LANCIO,
                                MOD.IDMAGAZZ AS IDMAGAZZ_WIP,
                                MOD.MODELLO AS MODELLO_WIP
                            FROM 
                            USR_PRD_MOVFASI MF
                            INNER JOIN USR_PRD_FASI FAS  ON  MF.IDPRDFASE = FAS.IDPRDFASE
                            INNER JOIN GRUPPO.MAGAZZ MOD ON MF.IDMAGAZZ = MOD.IDMAGAZZ 
                            INNER JOIN USR_PRD_LANCIOD LAN ON FAS.IDLANCIOD = LAN.IDLANCIOD 
                            INNER JOIN GRUPPO.MAGAZZ MODLAN ON LAN.IDMAGAZZ = MODLAN.IDMAGAZZ
                            WHERE MF.BARCODE = $P{BARCODE}";

            ParamSet ps = new ParamSet();
            ps.AddParam("BARCODE", DbType.String, Barcode);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_MOVFASI);
            }
        }
    }
}

using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
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

        public void FillAP_GALVANICA_MODELLO(GalvanicaDS ds, string IDMAGAZZ_Lancio, string IDMAGAZZ_WIP)
        {
            string select = @"  SELECT * FROM AP_GALVANICA_MODELLO WHERE IDMAGAZZ = $P{LANCIO} AND IDMAGAZZ_WIP = $P{IDMAGAZZ_WIP}";

            ParamSet ps = new ParamSet();
            ps.AddParam("LANCIO", DbType.String, IDMAGAZZ_Lancio);
            ps.AddParam("IDMAGAZZ_WIP", DbType.String, IDMAGAZZ_WIP);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.AP_GALVANICA_MODELLO);
            }
        }

        public void FillFINITURA_ORDINE(GalvanicaDS ds)
        {
            string select = @"  SELECT * FROM FINITURA_ORDINE";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.FINITURA_ORDINE);
            }
        }
        public void UpdateTable(string tablename, GalvanicaDS ds)
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

        public void FillAP_GALVANICA_PIANO(GalvanicaDS ds, DateTime data)
        {
            string select = @"  SELECT * FROM AP_GALVANICA_PIANO WHERE DATAGALVANICA >= to_date('{0}','DD/MM/YYYY HH24:MI:SS') AND DATAGALVANICA <= to_date('{1}','DD/MM/YYYY HH24:MI:SS')";

            string dtInizio = data.ToString("dd/MM/yyyy");
            dtInizio += " 00:00:00";
            string dtFine = data.ToString("dd/MM/yyyy");
            dtFine += " 23:59:59";
            select = string.Format(select, dtInizio, dtFine);

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.AP_GALVANICA_PIANO);
            }
        }
    }
}

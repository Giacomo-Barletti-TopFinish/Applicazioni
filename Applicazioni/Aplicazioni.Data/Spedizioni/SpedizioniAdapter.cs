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

        public void FillSPSALDI(SpedizioniDS ds, String UBICAZIONE, String  MODELLO)
        {
            ds.SPSALDIEXT.Clear();
            string select = @"select sa.*,ub.codice, ub.descrizione,ma.modello 
                                    from spsaldi sa
                                    inner join spubicazioni ub on ub.idubicazione = sa.idubicazione
                                    inner join gruppo.magazz ma on ma.idmagazz = sa.idmagazz
                                    where 1=1 ";


            if (!string.IsNullOrEmpty(UBICAZIONE))
                select += string.Format("and ub.codice like '%{0}%'", UBICAZIONE.ToUpper());

            if (!string.IsNullOrEmpty(MODELLO))
                select += string.Format("and ma.modello like '%{0}%'", MODELLO.ToUpper());

            select += "ORDER BY ub.codice,ma.modello ";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.SPSALDIEXT);
            }
        }
        
        public void FillMovimenti(SpedizioniDS ds, String UBICAZIONE, String MODELLO, DateTime dtInizo, DateTime dtFine)
        {
            string inizio = dtInizo.ToString("dd/MM/yyyy");
            string fine = dtFine.ToString("dd/MM/yyyy");
            ds.SPSALDIEXT.Clear();
            string select = @"select sm.*,ub.codice, ma.modello 
                                    from  spmovimenti sm
                                    inner join spsaldi sa on sa.idsaldo = sm.idsaldo
                                    inner join spubicazioni ub on ub.idubicazione = sa.idubicazione
                                    inner join gruppo.magazz ma on ma.idmagazz = sa.idmagazz
                                    where sm.datamodifica >= to_date('{0} 00:00:00','dd/mm/yyyy HH24:MI:ss') 
                                    and sm.datamodifica <= to_date('{1} 23:59:59','dd/mm/yyyy HH24:MI:ss')";

            select = string.Format(select, inizio,fine);

            if (!string.IsNullOrEmpty(UBICAZIONE))
                select += string.Format("and ub.codice like '%{0}%'", UBICAZIONE.ToUpper());

            if (!string.IsNullOrEmpty(MODELLO))
                select += string.Format("and ma.modello like '%{0}%'", MODELLO.ToUpper());

            select += " ORDER BY sm.datamodifica";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.SPMOVIMENTIEXT);
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

        public void GetSaldo(SpedizioniDS ds, decimal idSaldo)
        {
            string select = @"select * from spsaldi where idsaldo = $P<IDSALDO>";
            ParamSet ps = new ParamSet();
            ps.AddParam("IDSALDO", DbType.Decimal, idSaldo);
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

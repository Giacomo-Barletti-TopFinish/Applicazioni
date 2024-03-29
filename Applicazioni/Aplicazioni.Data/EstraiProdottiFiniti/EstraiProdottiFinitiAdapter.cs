﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applicazioni.Entities;

namespace Applicazioni.Data.EstraiProdottiFiniti
{
    public class EstraiProdottiFinitiAdapter : AdapterBase
    {
        public EstraiProdottiFinitiAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
   base(connection, transaction)
        { }

        public void GetUSR_PRD_TDIBAByModello(EstraiProdottiFinitiDS ds, string modello)
        {

            string select = string.Format(@"select MA.MODELLO,TB.*,MET.DESDIBAMETHOD METODO, 
                                 case 
                                when tdd.idtdibadefault is null then 'N'
                                else 'S'
                                end dEbaDefault

                                from ditta1.usr_prd_tdiba tb
                                inner join gruppo.magazz ma on ma.idmagazz = tb.idmagazz
                                inner join GRUPPO.USR_TAB_DIBAMETHODS MET ON MET.IDDIBAMETHOD = tb.IDDIBAMETHOD
                                left outer join ditta1.usr_prd_tdiba_default tdd on tdd.idtdiba = tb.idtdiba

                                where ma.modello like '{0}%'", modello);

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.USR_PRD_TDIBA);
            }
        }

        public void GetBC_DETTAGLIO_CICLO(EstraiProdottiFinitiDS ds, string codiceCiclo, bool test)
        {
            string select = string.Empty;
            if (test)
                select = @"select * from BC_DETTAGLIO_CICLO where NRCICLO = $P<NRCICLO>";
            else
                select = @"select * from BC_DETTAGLIO_CICLO_PRODUZIONE where NRCICLO = $P<NRCICLO>";

            ParamSet ps = new ParamSet();
            ps.AddParam("NRCICLO", DbType.String, codiceCiclo);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.BC_DETTAGLIO_CICLO);
            }
        }

        public void GetMagazzinoRVL(EstraiProdottiFinitiDS ds, string idmagazz)
        {
            string select = @"
                             select SG.IDMAGAZZ,tm.codicemag,cl.codice,trim(cl.ragionesoc) descrizione,sg.qesi 
                                  from saldi_gen sg
                                  inner join gruppo.tabmag tm on tm.idtabmag = sg.idtabmag
                                  inner join gruppo.clifo cl on cl.codice = sg.codiceclifo
                                  where 
                                  SG.IDMAGAZZ = $P<IDMAGAZZ>
                                  AND (tm.codicemag ='EXIT' 
                                      or tm.codicemag ='LAV' 
                                      OR tm.codicemag ='PLT%' 
                                      OR tm.codicemag ='ACQ_%' 
                                      OR tm.codicemag ='CONF-%' 
                                      OR tm.codicemag ='FINITO-%' 
                                      OR tm.codicemag ='GRE\SAL%' 
                                      OR DESTABMAG LIKE '%UBICAZIONE%')
                                  and sg.qesi <> 0";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDMAGAZZ", DbType.String, idmagazz);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.MAGAZZINORVL);
            }
        }

        public void GetODL(EstraiProdottiFinitiDS ds, string idmagazz)
        {
            string select = @"
                             select SG.IDMAGAZZ,tm.codicemag,cl.codice,trim(cl.ragionesoc) descrizione,sg.qesi 
                                  from saldi_gen sg
                                  inner join gruppo.tabmag tm on tm.idtabmag = sg.idtabmag
                                  inner join gruppo.clifo cl on cl.codice = sg.codiceclifo
                                  where 
                                  SG.IDMAGAZZ = $P<IDMAGAZZ>
                                  AND (tm.codicemag ='EXIT' 
                                      or tm.codicemag ='LAV' 
                                      OR tm.codicemag ='PLT%' 
                                      OR tm.codicemag ='ACQ_%' 
                                      OR tm.codicemag ='CONF-%' 
                                      OR tm.codicemag ='FINITO-%' 
                                      OR tm.codicemag ='GRE\SAL%' 
                                      OR DESTABMAG LIKE '%UBICAZIONE%')
                                  and sg.qesi <> 0";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDMAGAZZ", DbType.String, idmagazz);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.MAGAZZINORVL);
            }
        }
        public void GetBC_COM_CICLO(EstraiProdottiFinitiDS ds, string codiceCiclo, bool test)
        {
            string select = string.Empty;
            if (test)
                select = @"select * from BC_COM_CICLO where CICLO = $P<NRCICLO>";
            else
                select = @"select * from BC_COM_CICLO_PRODUZIONE where CICLO = $P<NRCICLO>";

            ParamSet ps = new ParamSet();
            ps.AddParam("NRCICLO", DbType.String, codiceCiclo);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.BC_COM_CICLO);
            }
        }

        public void GetBC_DISTINTA(EstraiProdottiFinitiDS ds, string distinta, bool test)
        {

            string select = string.Empty;
            if (test)
                select = @"select * from BC_DISTINTA where DIBA = $P<DIBA>";
            else
                select = @"select * from BC_DISTINTA_PRODUZIONE where DIBA = $P<DIBA>";

            ParamSet ps = new ParamSet();
            ps.AddParam("DIBA", DbType.String, distinta);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.BC_DISTINTA);
            }
        }

        public void FillBC_NODO(EstraiProdottiFinitiDS ds, bool test)
        {

            string select = string.Empty;
            if (test)
                select = @"select * from BC_NODO";
            else
                select = @"select * from BC_NODO_PRODUZIONE";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.BC_NODO);
            }
        }

        public void fILLBC_NODO_Q(EstraiProdottiFinitiDS ds, bool test)
        {

            string select = string.Empty;
            if (test)
                select = @"select * from BC_NODO_Q";
            else
                select = @"select * from BC_NODO_Q_PRODUZIONE";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.BC_NODO_Q);
            }
        }
        public void GetUSR_PRD_TDIBA(EstraiProdottiFinitiDS ds, string IDTDIBA)
        {

            string select = string.Format(@"select MA.MODELLO,MET.DESDIBAMETHOD METODO,TB.*,
                                case 
                                when tdd.idtdibadefault is null then 'N'
                                else 'S'
                                end dEbaDefault

                                from ditta1.usr_prd_tdiba tb
                                inner join gruppo.magazz ma on ma.idmagazz = tb.idmagazz
                                inner join GRUPPO.USR_TAB_DIBAMETHODS MET ON MET.IDDIBAMETHOD = tb.IDDIBAMETHOD
                                left outer join ditta1.usr_prd_tdiba_default tdd on tdd.idtdiba = tb.idtdiba
                                where tb.IDTDIBA =  $P<IDTDIBA>");
            ParamSet ps = new ParamSet();
            ps.AddParam("IDTDIBA", DbType.String, IDTDIBA);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_TDIBA);
            }
        }
        public void GetUSR_LIS_ACQ(EstraiProdottiFinitiDS ds, string idmagazz)
        {

            string select = string.Format(@"select *
                                from ditta1.USR_LIS_ACQ tb
                                where idmagazz =  $P<IDMAGAZZ>");
            ParamSet ps = new ParamSet();
            ps.AddParam("IDMAGAZZ", DbType.String, idmagazz);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_LIS_ACQ);
            }
        }
        public void fILLLISTINICONTOLAVORO(EstraiProdottiFinitiDS ds)
        {

            string select = string.Format(@"select *
                                from LISTINICONTOLAVORO");
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.LISTINICONTOLAVORO);
            }
        }
        public void GetUSR_PRD_RDIBA(EstraiProdottiFinitiDS ds, string IDTDIBA)
        {

            string select = string.Format(@"select TB.*, UN.CODICEUNIMI
                                from ditta1.usr_prd_Rdiba tb
                                INNER JOIN GRUPPO.TABUNIMI UN ON UN.IDTABUNIMI=TB.IDTABUNIMI
                                where tb.IDTDIBA =  $P<IDTDIBA>");
            ParamSet ps = new ParamSet();
            ps.AddParam("IDTDIBA", DbType.String, IDTDIBA);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_RDIBA);
            }
        }

        public void GetUSR_PRD_TDIBATopFinish(EstraiProdottiFinitiDS ds, string IDTDIBA)
        {

            string select = string.Format(@"select MA.MODELLO,MET.DESDIBAMETHOD METODO,TB.* from ditta2.usr_prd_tdiba tb
                                inner join gruppo.magazz ma on ma.idmagazz = tb.idmagazz
                                inner join GRUPPO.USR_TAB_DIBAMETHODS MET ON MET.IDDIBAMETHOD = tb.IDDIBAMETHOD
                                where tb.IDTDIBA =  $P<IDTDIBA>");
            ParamSet ps = new ParamSet();
            ps.AddParam("IDTDIBA", DbType.String, IDTDIBA);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_TDIBATOPFINISH);
            }
        }
        public void GetUSR_PRD_TDIBATopFinishByIDMAGAZZ(EstraiProdottiFinitiDS ds, string IDMAGAZZ)
        {

            string select = string.Format(@"select MA.MODELLO,MET.DESDIBAMETHOD METODO,TB.*,
                                case 
                                when tdd.idtdibadefault is null then 'N'
                                else 'S'
                                end dEbaDefault

                                from ditta2.usr_prd_tdiba tb
                                inner join gruppo.magazz ma on ma.idmagazz = tb.idmagazz
                                inner join GRUPPO.USR_TAB_DIBAMETHODS MET ON MET.IDDIBAMETHOD = tb.IDDIBAMETHOD
                                left outer join ditta2.usr_prd_tdiba_default tdd on tdd.idtdiba = tb.idtdiba
                                where tb.IDMAGAZZ =  $P<IDMAGAZZ>");
            ParamSet ps = new ParamSet();
            ps.AddParam("IDMAGAZZ", DbType.String, IDMAGAZZ);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_TDIBATOPFINISH);
            }
        }

        public void GetUSR_PRD_RDIBATopFinish(EstraiProdottiFinitiDS ds, string IDTDIBA)
        {

            string select = string.Format(@"select TB.*,UN.CODICEUNIMI 
                                from ditta2.usr_prd_Rdiba tb
                                INNER JOIN GRUPPO.TABUNIMI UN ON UN.IDTABUNIMI=TB.IDTABUNIMI
                                where tb.IDTDIBA =  $P<IDTDIBA>");
            ParamSet ps = new ParamSet();
            ps.AddParam("IDTDIBA", DbType.String, IDTDIBA);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_RDIBATOPFINISH);
            }
        }
        public void GetMAGAZZ(EstraiProdottiFinitiDS ds, string IDMAGAZZ)
        {

            string select = string.Format(@"select * from gruppo.magazz where IDMAGAZZ =  $P<IDMAGAZZ>");
            ParamSet ps = new ParamSet();
            ps.AddParam("IDMAGAZZ", DbType.String, IDMAGAZZ);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.MAGAZZ);
            }
        }

        public void FillBC_ANAGRAFICA(EstraiProdottiFinitiDS ds, bool test)
        {
            string select = string.Empty;
            if (test)
                select = string.Format(@"select * from BC_ANAGRAFICA");
            else
                select = string.Format(@"select * from BC_ANAGRAFICA_PRODUZIONE");

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.BC_ANAGRAFICA);
            }
        }

        public void FillTABFAS(EstraiProdottiFinitiDS ds)
        {

            string select = string.Format(@"select * from GRUPPO.TABFAS");

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.TABFAS);
            }
        }
        public void FillBC_TASK(EstraiProdottiFinitiDS ds)
        {

            string select = string.Format(@"select * from BC_TASK");

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.BC_TASK);
            }
        }

        public void UpdateTable(string tablename, EstraiProdottiFinitiDS ds, string tabellaFisica)
        {
            string query = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}", tabellaFisica);

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

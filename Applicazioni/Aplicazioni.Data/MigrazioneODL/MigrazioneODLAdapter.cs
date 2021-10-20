using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.MigrazioneODL
{
    public class MigrazioneODLAdapter : AdapterBase
    {
        public MigrazioneODLAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
       base(connection, transaction)
        { }

        public void GetUSR_PRD_MOVFASI(MigrazioneODLDS ds, String Barcode)
        {

            string select = @"SELECT * FROM USR_PRD_MOVFASI WHERE BARCODE = $P<BARCODE>";

            ParamSet ps = new ParamSet();
            ps.AddParam("BARCODE", DbType.String, Barcode);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_MOVFASI);
            }
        }

        public void GetANAGRAFICA(MigrazioneODLDS ds, String idmagazz)
        {

            string select = @"SELECT MA.MODELLO,BC.* from bc_anagrafica_produzione  BC
                                INNER JOIN GRUPPO.MAGAZZ MA ON MA.IDMAGAZZ = BC.IDMAGAZZ 
                                WHERE BC.IDMAGAZZ = $P<IDMAGAZZ>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDMAGAZZ", DbType.String, idmagazz);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.BC_ANAGRAFICA_PRODUZIONE);
            }
        }

        public void GetPRODOTTIFINITI(MigrazioneODLDS ds)
        {

            string select = @"select MA.MODELLO,BC.* from bc_anagrafica_produzione  BC
                                INNER JOIN GRUPPO.MAGAZZ MA ON MA.IDMAGAZZ = BC.IDMAGAZZ 
                                where bc like 'A-_________FI%' and CL=0
                                ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.BC_ANAGRAFICA_PRODUZIONE);
            }
        }
        public void GetCLIFO(MigrazioneODLDS ds, String codice)
        {

            string select = @"SELECT * FROM gruppo.clifo WHERE codice = $P<CODICE>";

            ParamSet ps = new ParamSet();
            ps.AddParam("CODICE", DbType.String, codice);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.CLIFO);
            }
        }
        public void GetTABFAS(MigrazioneODLDS ds, String IDTABFAS)
        {

            string select = @"SELECT * FROM gruppo.tabfas WHERE IDTABFAS = $P<IDTABFAS>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDTABFAS", DbType.String, IDTABFAS);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.TABFAS);
            }
        }
        public void GetMAGAZZ(MigrazioneODLDS ds, String idmagazz)
        {

            string select = @"SELECT * FROM gruppo.MAGAZZ WHERE IDMAGAZZ= $P<IDMAGAZZ>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDMAGAZZ", DbType.String, idmagazz);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.MAGAZZ);
            }
        }

        public void GetUSR_PRD_TDIBA(MigrazioneODLDS ds, String idmagazz, string dibaMethod, decimal version, string desVersion)
        {

            string select = @"select td.* 
                                    from usr_prd_tdiba td 
                                    WHERE td.IDMAGAZZ= $P<IDMAGAZZ>
                                    and td.iddibamethod = $P<DIBAMETHOD>
                                    and td.version = $P<VERSION>
                                    and td.desversion = $P<DESVERSION>
                                    ";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDMAGAZZ", DbType.String, idmagazz);
            ps.AddParam("DIBAMETHOD", DbType.String, dibaMethod);
            ps.AddParam("VERSION", DbType.Decimal, version);
            ps.AddParam("DESVERSION", DbType.String, desVersion);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_TDIBA);
            }
        }

        public void GetUSR_PRD_TDIBA1(MigrazioneODLDS ds, String idTdiba, string azienda)
        {

            string select = @"select td.*, RD.IDTDIBAIFFASE
                                    from usr_prd_tdiba td 
                                    inner join usr_prd_rdiba rd on rd.idtdiba = td.idtdiba and rd.azienda = td.azienda
                                    where rd.idtdibaiffase = $P<IDTDIBA> and rd.azienda = $P<AZIENDA> and td.activesn = 'S'
                                    ";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDTDIBA", DbType.String, idTdiba);
            ps.AddParam("AZIENDA", DbType.String, azienda);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_TDIBA1);
            }
        }
    }
}

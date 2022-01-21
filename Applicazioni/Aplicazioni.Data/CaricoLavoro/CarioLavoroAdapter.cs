using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.CaricoLavoro
{
    public class CaricoLavoroAdapter : AdapterBase
    {
        public CaricoLavoroAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
           base(connection, transaction)
        { }

        public void GetCaricoLavoro(CaricoLavoroDS ds)
        {
            string select = @"  select
    'MP' AS AZIENDA,
    TLAN.DESTIPOLANCIO,
    TRIM(TPO.CODICETIPOO) AS CODICETIPOO,
    TRIM(MF.CODICECLIFO) AS CODICECLIFO, 
    trim(CF.RAGIONESOC) as ragiosociale,
    MF.NUMMOVFASE,
    LAN.NOMECOMMESSA,
    trim(CLI.RAGIONESOC) AS SEGNALATORE,
    TMF.CODTIPOMOVFASE, TMF.DESTIPOMOVFASE,
    MODLAN.MODELLO AS MODELLO_LANCIO,
    MODLAN.DESMAGAZZ AS DESMODELLO_LANCIO,
    MOD.MODELLO AS MODELLO_WIP,
    MOD.DESMAGAZZ AS DESMODELLO_WIP, 
 


FAS.DATAFINE AS DATAFINE_FASECOMMESSA,
 

UM.CODICEUNIMI, MF.QTA, MF.QTADATER,
MF.PRIORITA,
fas.NOTEPARTFASE as NOTEPARTICOLARIFASE,
MF.NOTEPARTMOVFASE AS NOTAPARTICOLAREODL,
MF.IDPRDMOVFASE    ,MF.IDTABFAS
    
 

FROM 
(select * from DITTA1.USR_PRD_MOVFASI where QTADATER>0) MF, 
gruppo.CLIFO CF, 
DITTA1.USR_PRD_FASI FAS, 
GRUPPO.TABFAS TABFAS, 
GRUPPO.MAGAZZ MOD, 
GRUPPO.TABUNIMI UM, 
DITTA1.USR_PRD_LANCIOD LAN, 
gruppo.CLIFO CLI, 
GRUPPO.MAGAZZ MODLAN, 
GRUPPO.USR_PRD_TIPOLANCIO TLAN, 
GRUPPO.TABTIPOO TPO,
GRUPPO.USR_PRD_TIPOMOVFASI TMF

WHERE 1 = 1
AND MF.IDTIPOMOVFASE = TMF.IDTIPOMOVFASE
--AND MF.QTADATER > 0
AND MF.CODICECLIFO = CF.CODICE
AND MF.IDPRDFASE = FAS.IDPRDFASE
AND MF.IDTABFAS = TABFAS.IDTABFAS
AND MF.IDMAGAZZ = MOD.IDMAGAZZ
AND MF.IDTABUNIMI = UM.IDTABUNIMI
AND FAS.IDLANCIOD = LAN.IDLANCIOD(+)
AND LAN.SEGNALATORE = CLI.CODICE(+)
AND LAN.IDMAGAZZ = MODLAN.IDMAGAZZ(+)
AND LAN.IDTIPOLANCIO = TLAN.IDTIPOLANCIO(+)
AND LAN.IDTABTIPOO = TPO.IDTABTIPOO(+)

UNION ALL

select
'TF' AS AZIENDA,
TLAN.DESTIPOLANCIO,
    TRIM(TPO.CODICETIPOO) AS CODICETIPOO,
    TRIM(MF.CODICECLIFO) AS CODICECLIFO, 
trim(CF.RAGIONESOC),
MF.NUMMOVFASE,
LAN.NOMECOMMESSA,
trim(CLI.RAGIONESOC) AS SEGNALATORE,
TMF.CODTIPOMOVFASE, TMF.DESTIPOMOVFASE,
MODLAN.MODELLO AS MODELLO_LANCIO,
MODLAN.DESMAGAZZ AS DESMODELLO_LANCIO,
MOD.MODELLO AS MODELLO_WIP,
MOD.DESMAGAZZ AS DESMODELLO_WIP,
FAS.DATAFINE AS DATAFINE_FASECOMMESSA,
 

UM.CODICEUNIMI, MF.QTA, MF.QTADATER
,MF.PRIORITA,
fas.NOTEPARTFASE as NOTEPARTICOLARIFASE,
MF.NOTEPARTMOVFASE AS NOTAPARTICOLAREODL,
MF.IDPRDMOVFASE , MF.IDTABFAS   

FROM 
(select * from DITTA2.USR_PRD_MOVFASI where QTADATER>0) MF, 
gruppo.CLIFO CF, 
DITTA2.USR_PRD_FASI FAS, 
GRUPPO.TABFAS TABFAS, 
GRUPPO.MAGAZZ MOD, 
GRUPPO.TABUNIMI UM, 
DITTA2.USR_PRD_LANCIOD LAN, 
gruppo.CLIFO CLI, 
GRUPPO.MAGAZZ MODLAN, 
GRUPPO.USR_PRD_TIPOLANCIO TLAN, 
GRUPPO.TABTIPOO TPO,
GRUPPO.USR_PRD_TIPOMOVFASI TMF


WHERE 1 = 1


AND MF.IDTIPOMOVFASE = TMF.IDTIPOMOVFASE
--AND MF.QTADATER > 0
AND MF.CODICECLIFO = CF.CODICE
AND MF.IDPRDFASE = FAS.IDPRDFASE
AND MF.IDTABFAS = TABFAS.IDTABFAS
AND MF.IDMAGAZZ = MOD.IDMAGAZZ
AND MF.IDTABUNIMI = UM.IDTABUNIMI
AND FAS.IDLANCIOD = LAN.IDLANCIOD(+)
AND LAN.SEGNALATORE = CLI.CODICE(+)
AND LAN.IDMAGAZZ = MODLAN.IDMAGAZZ(+)
AND LAN.IDTIPOLANCIO = TLAN.IDTIPOLANCIO(+)
AND LAN.IDTABTIPOO = TPO.IDTABTIPOO(+)
";



            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.CARICOLAVORO);
            }
        }

        public void FillUSR_PRD_CAUMATE(CaricoLavoroDS ds)
        {
            string select = @"  SELECT * FROM gruppo.USR_PRD_CAUMATE ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.USR_PRD_CAUMATE);
            }
        }

        public void GetUSR_PRD_MOVMATE(CaricoLavoroDS ds, string IDPRDMOVFASE, string azienda)
        {
            string select = @"  SELECT * FROM USR_PRD_MOVMATE WHERE AZIENDA = $P<AZIENDA> AND IDPRDMOVFASE = $P<IDPRDMOVFASE>";
            ParamSet ps = new ParamSet();
            ps.AddParam("IDPRDMOVFASE", DbType.String, IDPRDMOVFASE);
            ps.AddParam("AZIENDA", DbType.String, azienda);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_MOVMATE);
            }
        }

        public void GetUSR_PRD_FLUSSO_MOVMATE(CaricoLavoroDS ds, string IDPRDMOVMATE, string azienda)
        {
            string select = @"  SELECT XMM.*,XCM.SEGNO FROM USR_PRD_FLUSSO_MOVMATE XMM
        INNER JOIN GRUPPO.USR_PRD_CAUMATE XCM ON XMM.IDPRDCAUMATE = XCM.IDPRDCAUMATE
        WHERE AZIENDA = $P<AZIENDA> AND IDPRDMOVMATE = $P<IDPRDMOVMATE>";
            ParamSet ps = new ParamSet();
            ps.AddParam("IDPRDMOVMATE", DbType.String, IDPRDMOVMATE);
            ps.AddParam("AZIENDA", DbType.String, azienda);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_FLUSSO_MOVMATE);
            }
        }

        public void FillTABFAS(CaricoLavoroDS ds)
        {
            string select = @"  SELECT * FROM gruppo.TABFAS";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.TABFAS);
            }
        }

        public void GetUSR_PRD_LEG_MULTILAV(CaricoLavoroDS ds, string IDPRDMOVFASE, string azienda)
        {
            string select = @"  SELECT * FROM USR_PRD_LEG_MULTILAV 
        WHERE AZIENDA = $P<AZIENDA> AND IDPRDMOVFASE_START = $P<IDPRDMOVFASE>";
            ParamSet ps = new ParamSet();
            ps.AddParam("IDPRDMOVFASE", DbType.String, IDPRDMOVFASE);
            ps.AddParam("AZIENDA", DbType.String, azienda);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_LEG_MULTILAV);
            }
        }
        public void GetUSR_PRD_FASI(CaricoLavoroDS ds, string IDPRDFASE, string azienda)
        {
            string select = @"  SELECT * FROM USR_PRD_FASI 
        WHERE AZIENDA = $P<AZIENDA> AND IDPRDFASE = $P<IDPRDFASE>";
            ParamSet ps = new ParamSet();
            ps.AddParam("IDPRDFASE", DbType.String, IDPRDFASE);
            ps.AddParam("AZIENDA", DbType.String, azienda);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_FASI);
            }
        }

        public void GetUSR_VENDITED(CaricoLavoroDS ds, string IDVENDITED, string azienda)
        {
            string select = @"  SELECT * FROM USR_VENDITED 
        WHERE AZIENDA = $P<AZIENDA> AND IDVENDITED = $P<IDVENDITED>";
            ParamSet ps = new ParamSet();
            ps.AddParam("IDVENDITED", DbType.String, IDVENDITED);
            ps.AddParam("AZIENDA", DbType.String, azienda);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_VENDITED);
            }
        }
        public void GetUSR_VENDITET(CaricoLavoroDS ds, string IDVENDITET, string azienda)
        {
            string select = @"  SELECT * FROM USR_VENDITET 
        WHERE AZIENDA = $P<AZIENDA> AND IDVENDITET = $P<IDVENDITET>";
            ParamSet ps = new ParamSet();
            ps.AddParam("IDVENDITET", DbType.String, IDVENDITET);
            ps.AddParam("AZIENDA", DbType.String, azienda);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_VENDITET);
            }
        }

        public void FillTABTIPDOC(CaricoLavoroDS ds)
        {
            string select = @"  SELECT * FROM TABTIPDOC ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.TABTIPDOC);
            }
        }
    }
}

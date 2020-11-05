using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.FlussoFatture
{
    public class FlussoFattureAdapter: AdapterBase
    {
        public FlussoFattureAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
          base(connection, transaction)
        { }

        public void FillBOLLE_VENDITATESTATA(FlussoFattureDS ds, DateTime Dal, DateTime Al)
        {
            string DalStr = Dal.ToString("dd/MM/yyyy");
            string AlStr = Al.ToString("dd/MM/yyyy");

            string select = @"  select DISTINCT AZIENDA, DESTABTIPDOC, CODICETIPDOC, CODICETIPOO, DESTABTIPOO, CODICECAUTR, DESTABCAUTR, 
                IDVENDITET, FATTURARE_SN, CONFERMATO_SN, DEFINITIVO_SN, FULLNUMDOC, DATDOC, ANNODOC, NUMDOC, CODICECLIFO, TRIM(RAGIONESOC) RAGIONESOC, CODINDSP, 
                FATTURAREA, FATTURAREALTER, SEGNALATORE, TRIM(SEGNALATORE_RS) SEGNALATORE_RS, NUMERORIGHE,RIFERIMENTO,trim(ind.ragsoc) DESTINAZIONE
                from bolle_vendita bv
                INNER JOIN GRUPPO.INDSPED IND ON IND.CODCF=BV.CODICECLIFO AND IND.CODIND=BV.CODINDSP                
                where 1=1

                and datdoc >=to_date('{0} 00:00:00','dd/mm/yyyy HH24:Mi:SS')
                and datdoc <to_date('{1} 23:59:59','dd/mm/yyyy HH24:Mi:SS')";

            select = string.Format(select, DalStr, AlStr);

           

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.BOLLE_VENDITA);
            }
        }

        public void FillBC_FLUSSO_TESTATA(FlussoFattureDS ds, DateTime Dal, DateTime Al)
        {
            string DalStr = Dal.ToString("dd/MM/yyyy");
            string AlStr = Al.ToString("dd/MM/yyyy");

            string select = @"  select csped.BC_CODE SPEDIZIONE,cfat.BC_CODE FATTURAZIONE,oo.codicetipoo,vt.fullnumdoc,vt.datdoc 
                                        from ditta1.usr_venditet vt
                                        left outer join v_converti_cliente csped on csped.codiceclifo=VT.codiceclifo 
                                        left outer join v_converti_cliente cfat on cfat.codiceclifo=VT.FATTURAREA 
                                        inner join gruppo.tabtipoo oo on oo.IDTABTIPOO = vt.IDTABTIPOO
                                        WHERE datdoc >=to_date('{0} 00:00:00','dd/mm/yyyy HH24:Mi:SS')
                                        AND datdoc <=to_date('{1} 23:59:59','dd/mm/yyyy HH24:Mi:SS')
                                       
                                        union all
                                        select csped.BC_CODE,cfat.BC_CODE,oo.codicetipoo,vt.fullnumdoc,vt.datdoc 
                                        from ditta2.usr_venditet vt
                                        left outer join v_converti_cliente csped on csped.codiceclifo=VT.codiceclifo 
                                        left outer join v_converti_cliente cfat on cfat.codiceclifo=VT.FATTURAREA 
                                        inner join gruppo.tabtipoo oo on oo.IDTABTIPOO = vt.IDTABTIPOO
                                        WHERE datdoc >=to_date('{2} 00:00:00','dd/mm/yyyy HH24:Mi:SS')
                                        AND datdoc <=to_date('{3} 23:59:59','dd/mm/yyyy HH24:Mi:SS')
                                       
                                        order by fullnumdoc ";

            select = string.Format(select, DalStr, AlStr, DalStr, AlStr);

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.BC_FLUSSO_TESTATA);
            }
        }

        public void FillBC_FLUSSO_DETTAGLIO(FlussoFattureDS ds, DateTime Dal, DateTime Al)
        {
            string DalStr = Dal.ToString("dd/MM/yyyy");
            string AlStr = Al.ToString("dd/MM/yyyy");

            string select = @"  select vt.fullnumdoc,vt.datdoc,PC.NUOVO AS CONTOCG,MA.MODELLO,VD.QTATOT,VD.PREZZOTOT,VD.CODIVARIGA,VD.PSCONTO1
                                    from ditta1.usr_venditet vt
                                    INNER JOIN DITTA1.USR_VENDITED VD ON VD.IDVENDITET = VT.IDVENDITET
                                    INNER JOIN GRUPPO.MAGAZZ MA ON MA.IDMAGAZZ = VD.IDMAGAZZ
                                    LEFT OUTER JOIN GRUPPO.TABTIPMOV TM ON TM.IDTABTIPMOV=MA.IDTABTIPMOVVEN
                                    LEFT OUTER JOIN BC_TRASCODIFICA_PIANO_CONTI PC ON PC.VECCHIO = TM.CODICETIPMOV AND PC.AZIENDA = 'MP'
                                        WHERE datdoc >=to_date('{0} 00:00:00','dd/mm/yyyy HH24:Mi:SS')
                                        AND datdoc <=to_date('{1} 23:59:59','dd/mm/yyyy HH24:Mi:SS')
                                   
                                    UNION ALL
                                    select vt.fullnumdoc,vt.datdoc,PC.NUOVO AS CONTOCG,MA.MODELLO,VD.QTATOT,VD.PREZZOTOT,VD.CODIVARIGA,VD.PSCONTO1
                                    from ditta2.usr_venditet vt
                                    INNER JOIN DITTA2.USR_VENDITED VD ON VD.IDVENDITET = VT.IDVENDITET
                                    INNER JOIN GRUPPO.MAGAZZ MA ON MA.IDMAGAZZ = VD.IDMAGAZZ
                                    LEFT OUTER JOIN GRUPPO.TABTIPMOV TM ON TM.IDTABTIPMOV=MA.IDTABTIPMOVVEN
                                    LEFT OUTER JOIN BC_TRASCODIFICA_PIANO_CONTI PC ON PC.VECCHIO = TM.CODICETIPMOV AND PC.AZIENDA = 'TP'
                                        WHERE datdoc >=to_date('{2} 00:00:00','dd/mm/yyyy HH24:Mi:SS')
                                        AND datdoc <=to_date('{3} 23:59:59','dd/mm/yyyy HH24:Mi:SS')

                                    order by fullnumdoc ";

            select = string.Format(select, DalStr, AlStr, DalStr, AlStr);

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.BC_FLUSSO_DETTAGLIO);
            }
        }
    }
}

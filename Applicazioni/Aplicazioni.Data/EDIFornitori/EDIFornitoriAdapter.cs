using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.EDIFornitori
{
    public class EDIFornitoriAdapter : AdapterBase
    {
        public EDIFornitoriAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
           base(connection, transaction)
        { }

        public void FillBOLLE_VENDITATESTATA(EDIFornitoriDS ds, DateTime Dal, DateTime Al, string CodiceFornitore)
        {
            string DalStr = Dal.ToString("dd/MM/yyyy");
            string AlStr = Al.ToString("dd/MM/yyyy");

            string select = @"  select DISTINCT AZIENDA, DESTABTIPDOC, CODICETIPDOC, CODICETIPOO, DESTABTIPOO, CODICECAUTR, DESTABCAUTR, 
                IDVENDITET, FATTURARE_SN, CONFERMATO_SN, DEFINITIVO_SN, FULLNUMDOC, DATDOC, ANNODOC, NUMDOC, CODICECLIFO, TRIM(RAGIONESOC) CODICECLIFO, CODINDSP, 
                FATTURAREA, FATTURAREALTER, SEGNALATORE, TRIM(SEGNALATORE_RS) SEGNALATORE_RS, NUMERORIGHE,RIFERIMENTO,trim(ind.ragsoc) DESTINAZIONE,
                AC.CODICE ACCESSORISTA
                from bolle_vendita bv
                INNER JOIN GRUPPO.INDSPED IND ON IND.CODCF=BV.CODICECLIFO AND IND.CODIND=BV.CODINDSP
                LEFT OUTER JOIN ACCESSORISTI AC ON IND.CODCF=AC.CODCF AND IND.CODIND=AC.CODIND
                where 1=1
                AND (segnalatore ='02575' OR SEGNALATORE IS NULL)

                and datdoc >=to_date('{0} 00:00:00','dd/mm/yyyy HH24:Mi:SS')
                and datdoc <to_date('{1} 23:59:59','dd/mm/yyyy HH24:Mi:SS')";

            select = string.Format(select, DalStr, AlStr);

            if (CodiceFornitore == ParametriEDIFornitori.MetalPlus)
                select = select + " AND AZIENDA = 'METALPLUS'";

            if (CodiceFornitore == ParametriEDIFornitori.TopFinish)
                select = select + " AND AZIENDA = 'TOP FINISH'";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.BOLLE_VENDITA);
            }
        }

        public void FillBOLLE_VENDITATESTATASQL(EDIFornitoriDS ds, DateTime Dal, DateTime Al)
        {
            string DalStr = Dal.ToString("yyyyMMdd");
            string AlStr = Al.ToString("yyyyMMdd");

            string select = @"  select DISTINCT AZIENDA, DESTABTIPDOC, CODICETIPDOC, CODICETIPOO, DESTABTIPOO, CODICECAUTR, DESTABCAUTR, 
                IDVENDITET, FATTURARE_SN, CONFERMATO_SN, DEFINITIVO_SN, FULLNUMDOC, DATDOC, ANNODOC, NUMDOC, CODICECLIFO, CODICECLIFO, CODINDSP, 
                FATTURAREA, FATTURAREALTER, SEGNALATORE, SEGNALATORE_RS, NUMERORIGHE,RIFERIMENTO, DESTINAZIONE,
                ACCESSORISTA
                from bolle_vendita bv
                where 1=1

                and datdoc >='{0}' 
                and datdoc <='{1}'";

            select = string.Format(select, DalStr, AlStr);

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.BOLLE_VENDITA);
            }
        }

        public void FillBOLLE_VENDITA(EDIFornitoriDS ds, DateTime Dal, DateTime Al, string CodiceFornitore)
        {
            string DalStr = Dal.ToString("dd/MM/yyyy");
            string AlStr = Al.ToString("dd/MM/yyyy");

            string select = @"  select * 
                from bolle_vendita
                where 1=1
                AND (segnalatore ='02575' OR SEGNALATORE IS NULL)
                and datdoc >=to_date('{0} 00:00:00','dd/mm/yyyy HH24:Mi:SS')
                and datdoc <to_date('{1} 23:59:59','dd/mm/yyyy HH24:Mi:SS')";

            select = string.Format(select, DalStr, AlStr);

            if (CodiceFornitore == ParametriEDIFornitori.MetalPlus)
                select = select + " AND AZIENDA = 'METALPLUS'";

            if (CodiceFornitore == ParametriEDIFornitori.TopFinish)
                select = select + " AND AZIENDA = 'TOP FINISH'";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.BOLLE_VENDITA);
            }
        }

        public void FillACCESSORISTI(EDIFornitoriDS ds)
        {

            string select = @"  select * from accessoristi";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.ACCESSORISTI);
            }
        }
    }
}

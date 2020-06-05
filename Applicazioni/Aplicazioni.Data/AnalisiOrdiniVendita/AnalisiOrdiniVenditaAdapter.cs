using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.AnalisiOrdiniVendita
{
    public class AnalisiOrdiniVenditaAdapter : AdapterBase
    {
        public AnalisiOrdiniVenditaAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
       base(connection, transaction)
        { }

        public void FillOC_APERTI(AnalisiOrdiniVenditaDS ds)
        {
            string select = @"    select trim(seg.ragionesoc) as segnalatore,td.destabtipdoc tipodocumento, vt.annodoc,vt.datdoc,vt.numdoc,trim(vt.riferimento)riferimento,
                                        vt.datarif,vt.fullnumdoc ,
                                        ma.modello,ma.DESMAGAZZ,
                                        vd.* 
                                        from ditta1.usr_vendited vd
                                        inner join ditta1.usr_venditet vt on vt.idvenditet = vd.idvenditet
                                        inner join gruppo.magazz ma on ma.idmagazz = vd.idmagazz
                                        inner join gruppo.clifo seg on seg.codice=vt.segnalatore
                                        inner join gruppo.tabtipdoc td on td.idtabtipdoc = vt.idtabtipdoc
                                        where qtanospe > 0";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.OC_APERTI);
            }
        }


        public void FillAccantonatoEsistenzaPerOrigine(AnalisiOrdiniVenditaDS ds, string idOrigine, decimal tipoOrigine)
        {
            string select = @"   select * from ditta1.USR_ACCTO_ESI WHERE IDORIGINE = $P<IDORIGINE> AND ORIGINE = $P<ORIGINE>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDORIGINE", DbType.String, idOrigine);
            ps.AddParam("ORIGINE", DbType.Decimal, tipoOrigine);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_ACCTO_ESI);
            }
        }

        public void FillAccantonatoConsegnaPerOrigine(AnalisiOrdiniVenditaDS ds, string idOrigine, decimal tipoOrigine)
        {
            string select = @"   select * from ditta1.USR_ACCTO_CON WHERE IDORIGINE = $P<IDORIGINE> AND ORIGINE = $P<ORIGINE>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDORIGINE", DbType.String, idOrigine);
            ps.AddParam("ORIGINE", DbType.Decimal, tipoOrigine);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_ACCTO_CON);
            }
        }
        public void FillAccantonatoConsegnaDocumento(AnalisiOrdiniVenditaDS ds, string IDACCTOCON)
        {
            string select = @"   select * from ditta1.USR_ACCTO_CON_DOC WHERE IDACCTOCON = $P<IDACCTOCON>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDACCTOCON", DbType.String, IDACCTOCON);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_ACCTO_CON_DOC);
            }
        }

        public void GetMagazz(AnalisiOrdiniVenditaDS ds, string idMagazz)
        {
            string select = @"   select * from gruppo.magazz WHERE idMagazz = $P<IDMAGAZZ>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDMAGAZZ", DbType.String, idMagazz);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.MAGAZZ);
            }
        }


        public void GetUSR_PRD_MOVFASI(AnalisiOrdiniVenditaDS ds, string IdPrdMovFase)
        {
            string select = @"   select * from DITTA1.USR_PRD_MOVFASI WHERE IDPRDMOVFASE = $P<IDPRDMOVFASE>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDPRDMOVFASE", DbType.String, IdPrdMovFase);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_MOVFASI);
            }
        }

        public void GetUSR_PRD_FASI(AnalisiOrdiniVenditaDS ds, string IdPrdFase)
        {
            string select = @"   select * from DITTA1.USR_PRD_FASI WHERE IDPRDFASE = $P<IDPRDFASE>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDPRDFASE", DbType.String, IdPrdFase);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_FASI);
            }
        }
        public void GetTabMag(AnalisiOrdiniVenditaDS ds, string idTabMag)
        {
            string select = @"   select * from gruppo.tabmag WHERE idtabmag = $P<IDTABMAG>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDTABMAG", DbType.String, idTabMag);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.TABMAG);
            }
        }

        public void FillTabFas(AnalisiOrdiniVenditaDS ds)
        {
            string select = @"   select * from gruppo.tabfas ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.TABFAS);
            }
        }
    }
}

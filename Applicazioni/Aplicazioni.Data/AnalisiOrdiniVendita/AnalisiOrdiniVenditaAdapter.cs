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

        public void GetUSR_PRD_MOVFASIAperte(AnalisiOrdiniVenditaDS ds, string IdPrdFase)
        {
            string select = @"   SELECT * FROM DITTA1.USR_PRD_movFASI mf
                                    inner join DITTA1.USR_PRD_FASI fa on fa.idprdfase = mf.idprdfase
                                    WHERE fa.idlanciod = (select idlanciod from DITTA1.USR_PRD_FASI where idprdfase =  $P<IDPRDFASE> ) 
                                    and mf.qtadater>0";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDPRDFASE", DbType.String, IdPrdFase);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_MOVFASI);
            }
        }

        public void GetUSR_PRD_MOVFASIDaLancio(AnalisiOrdiniVenditaDS ds, string idLancioD)
        {
            string select = @"   SELECT * FROM DITTA1.USR_PRD_movFASI mf
                                    inner join DITTA1.USR_PRD_FASI fa on fa.idprdfase = mf.idprdfase
                                    WHERE fa.idlanciod = $P<IDLANCIOD>  
                                    and mf.qtadater>0";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDLANCIOD", DbType.String, idLancioD);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_MOVFASI);
            }
        }
        public void GetUSR_PRD_FASI(AnalisiOrdiniVenditaDS ds, string IdPrdFase)
        {
            string select = @" SELECT * FROM DITTA1.USR_PRD_FASI WHERE idlanciod = (select idlanciod from DITTA1.USR_PRD_FASI where idprdfase =  $P<IDPRDFASE> ) ";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDPRDFASE", DbType.String, IdPrdFase);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_FASI);
            }
        }

        public void GetUSR_PRD_FASIDaLancio(AnalisiOrdiniVenditaDS ds, string idLancioD)
        {
            string select = @" SELECT * FROM DITTA1.USR_PRD_FASI WHERE idlanciod = $P<IDLANCIOD> ";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDLANCIOD", DbType.String, idLancioD);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_FASI);
            }
        }
        public void GetUSR_CHECKQ_T(AnalisiOrdiniVenditaDS ds, string IdPrdFase)
        {
            string select = @" SELECT mf.IDPRDMOVFASE, cq.* FROM ditta1.usr_checkq_t cq
                        inner join ditta1.usr_prd_flusso_movfasi fmf on fmf.idflussomovfase = cq.idorigine_ril and origine_ril = 2
                        inner join DITTA1.USR_PRD_movFASI mf on mf.idprdmovfase = fmf.idprdmovfase
                        inner join DITTA1.USR_PRD_FASI fa on fa.idprdfase = mf.idprdfase
                        WHERE fa.idlanciod = (select idlanciod from DITTA1.USR_PRD_FASI where idprdfase = $P<IDPRDFASE> ) 
                        and mf.qtadater>0   ";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDPRDFASE", DbType.String, IdPrdFase);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_CHECKQ_T);
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

        public void FillUSR_CHECKQ_S(AnalisiOrdiniVenditaDS ds, string idcheckqt)
        {
            string select = @" select * from ditta1.usr_checkq_s where IDCHECKQT = $P<IDCHECKQT>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDCHECKQT", DbType.String, idcheckqt);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_CHECKQ_S);
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

        public void FillUSR_TAB_SEGUITICHECKQ(AnalisiOrdiniVenditaDS ds)
        {
            string select = @"   select * from gruppo.USR_TAB_SEGUITICHECKQ ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.USR_TAB_SEGUITICHECKQ);
            }
        }
    }
}

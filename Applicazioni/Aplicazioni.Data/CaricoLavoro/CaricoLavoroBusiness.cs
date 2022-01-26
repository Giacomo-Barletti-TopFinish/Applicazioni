using Applicazioni.Data.Core;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.CaricoLavoro
{
    public class CaricoLavoroBusiness : BusinessBase
    {
        [DataContext]
        public void GetCaricoLavoro(CaricoLavoroDS ds)
        {
            CaricoLavoroAdapter a = new CaricoLavoroAdapter(DbConnection, DbTransaction);
            a.GetCaricoLavoro(ds);
        }

        [DataContext]
        public void FillUSR_PRD_CAUMATE(CaricoLavoroDS ds)
        {
            CaricoLavoroAdapter a = new CaricoLavoroAdapter(DbConnection, DbTransaction);
            a.FillUSR_PRD_CAUMATE(ds);
        }
        [DataContext]
        public CaricoLavoroDS.USR_PRD_MOVMATERow GetUSR_PRD_MOVMATE(CaricoLavoroDS ds, string IDPRDMOVFASE, string azienda)
        {
            CaricoLavoroDS.USR_PRD_MOVMATERow riga = ds.USR_PRD_MOVMATE.Where(x => x.AZIENDA == azienda && x.IDPRDMOVFASE == IDPRDMOVFASE).FirstOrDefault();
            if (riga == null)
            {
                CaricoLavoroAdapter a = new CaricoLavoroAdapter(DbConnection, DbTransaction);
                a.GetUSR_PRD_MOVMATE(ds, IDPRDMOVFASE, azienda);
                riga = ds.USR_PRD_MOVMATE.Where(x => x.AZIENDA == azienda && x.IDPRDMOVFASE == IDPRDMOVFASE).FirstOrDefault();
            }
            return riga;
        }

        [DataContext]
        public List<CaricoLavoroDS.USR_PRD_FLUSSO_MOVMATERow> FillUSR_PRD_FLUSSO_MOVMATE(CaricoLavoroDS ds, string IDPRDMOVMATE, string azienda)
        {
            List<CaricoLavoroDS.USR_PRD_FLUSSO_MOVMATERow> riga = ds.USR_PRD_FLUSSO_MOVMATE.Where(x => x.AZIENDA == azienda && x.IDPRDMOVMATE == IDPRDMOVMATE).ToList();
            if (riga.Count == 0)
            {
                CaricoLavoroAdapter a = new CaricoLavoroAdapter(DbConnection, DbTransaction);
                a.GetUSR_PRD_FLUSSO_MOVMATE(ds, IDPRDMOVMATE, azienda);
                riga = ds.USR_PRD_FLUSSO_MOVMATE.Where(x => x.AZIENDA == azienda && x.IDPRDMOVMATE == IDPRDMOVMATE).ToList();
            }
            return riga;
        }

        [DataContext]
        public CaricoLavoroDS.USR_PRD_FASIRow GetUSR_PRD_FASI(CaricoLavoroDS ds, string IDPRDFASE, string azienda)
        {
            CaricoLavoroDS.USR_PRD_FASIRow riga = ds.USR_PRD_FASI.Where(x => x.AZIENDA == azienda && x.IDPRDFASE == IDPRDFASE).FirstOrDefault();
            if (riga == null)
            {
                CaricoLavoroAdapter a = new CaricoLavoroAdapter(DbConnection, DbTransaction);
                a.GetUSR_PRD_FASI(ds, IDPRDFASE, azienda);
                riga = ds.USR_PRD_FASI.Where(x => x.AZIENDA == azienda && x.IDPRDFASE == IDPRDFASE).FirstOrDefault();
            }
            return riga;
        }
        [DataContext]
        public List<CaricoLavoroDS.USR_PRD_LEG_MULTILAVRow> GetUSR_PRD_LEG_MULTILAV(CaricoLavoroDS ds, string IDPRDMOVFASE, string azienda)
        {
            List<CaricoLavoroDS.USR_PRD_LEG_MULTILAVRow> riga = ds.USR_PRD_LEG_MULTILAV.Where(x => x.AZIENDA == azienda && x.IDPRDMOVFASE_START == IDPRDMOVFASE).ToList();
            if (riga.Count == 0)
            {
                CaricoLavoroAdapter a = new CaricoLavoroAdapter(DbConnection, DbTransaction);
                a.GetUSR_PRD_LEG_MULTILAV(ds, IDPRDMOVFASE, azienda);
                riga = ds.USR_PRD_LEG_MULTILAV.Where(x => x.AZIENDA == azienda && x.IDPRDMOVFASE_START == IDPRDMOVFASE).ToList();
            }
            return riga;
        }
        [DataContext]
        public CaricoLavoroDS.USR_VENDITETRow GetUSR_VENDITET(CaricoLavoroDS ds, string IDVENDITET, string azienda)
        {
            CaricoLavoroDS.USR_VENDITETRow riga = ds.USR_VENDITET.Where(x => x.AZIENDA == azienda && x.IDVENDITET == IDVENDITET).FirstOrDefault();
            if (riga==null)
            {
                CaricoLavoroAdapter a = new CaricoLavoroAdapter(DbConnection, DbTransaction);
                a.GetUSR_VENDITET(ds, IDVENDITET, azienda);
                riga = ds.USR_VENDITET.Where(x => x.AZIENDA == azienda && x.IDVENDITET == IDVENDITET).FirstOrDefault();
            }
            return riga;
        }
        [DataContext]
        public List<CaricoLavoroDS.USR_VENDITEDRow> GetUSR_VENDITED(CaricoLavoroDS ds, string IDVENDITED, string azienda)
        {
            List<CaricoLavoroDS.USR_VENDITEDRow> riga = ds.USR_VENDITED.Where(x => x.AZIENDA == azienda && x.IDVENDITED == IDVENDITED).ToList();
            if (riga.Count == 0)
            {
                CaricoLavoroAdapter a = new CaricoLavoroAdapter(DbConnection, DbTransaction);
                a.GetUSR_VENDITED(ds, IDVENDITED, azienda);
                riga = ds.USR_VENDITED.Where(x => x.AZIENDA == azienda && x.IDVENDITED == IDVENDITED).ToList();
            }
            return riga;
        }
        [DataContext]
        public void FillTABFAS(CaricoLavoroDS ds)
        {
            CaricoLavoroAdapter a = new CaricoLavoroAdapter(DbConnection, DbTransaction);
            a.FillTABFAS(ds);
        }

        [DataContext]
        public void FillTABTIPDOC(CaricoLavoroDS ds)
        {
            CaricoLavoroAdapter a = new CaricoLavoroAdapter(DbConnection, DbTransaction);
            a.FillTABTIPDOC(ds);
        }
    }
}

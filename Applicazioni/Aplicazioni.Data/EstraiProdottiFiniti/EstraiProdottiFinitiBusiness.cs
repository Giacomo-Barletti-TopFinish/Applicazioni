using Applicazioni.Data.Core;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.EstraiProdottiFiniti
{
    public class EstraiProdottiFinitiBusiness : BusinessBase
    {
        [DataContext]
        public void GetUSR_PRD_TDIBAByModello(EstraiProdottiFinitiDS ds, string modello)
        {
            EstraiProdottiFinitiAdapter a = new EstraiProdottiFinitiAdapter(DbConnection, DbTransaction);
            a.GetUSR_PRD_TDIBAByModello(ds, modello);
        }
        [DataContext]
        public void GetMagazzinoRVL(EstraiProdottiFinitiDS ds, string idmagazz)
        {
            if (!ds.MAGAZZINORVL.Any(x => x.IDMAGAZZ == idmagazz))
            {
                EstraiProdottiFinitiAdapter a = new EstraiProdottiFinitiAdapter(DbConnection, DbTransaction);
                a.GetMagazzinoRVL(ds, idmagazz);
            }
        }

        [DataContext]
        public void GetODL(EstraiProdottiFinitiDS ds, string idmagazz)
        {
            if (!ds.USR_PRD_MOVFASI.Any(x => x.IDMAGAZZ == idmagazz))
            {
                EstraiProdottiFinitiAdapter a = new EstraiProdottiFinitiAdapter(DbConnection, DbTransaction);
                a.GetMagazzinoRVL(ds, idmagazz);
            }
        }

        [DataContext]
        public void GetUSR_PRD_TDIBA(EstraiProdottiFinitiDS ds, string IDTDIBA)
        {
            EstraiProdottiFinitiAdapter a = new EstraiProdottiFinitiAdapter(DbConnection, DbTransaction);
            a.GetUSR_PRD_TDIBA(ds, IDTDIBA);
        }
        [DataContext]
        public void GetUSR_LIS_ACQ(EstraiProdottiFinitiDS ds, string idmagazz)
        {
            EstraiProdottiFinitiAdapter a = new EstraiProdottiFinitiAdapter(DbConnection, DbTransaction);
            a.GetUSR_LIS_ACQ(ds, idmagazz);
        }
        [DataContext]
        public void fILLLISTINICONTOLAVORO(EstraiProdottiFinitiDS ds)
        {
            EstraiProdottiFinitiAdapter a = new EstraiProdottiFinitiAdapter(DbConnection, DbTransaction);
            a.fILLLISTINICONTOLAVORO(ds);
        }
        [DataContext]
        public void GetBC_COM_CICLO(EstraiProdottiFinitiDS ds, string NRCICLO, bool test)
        {
            EstraiProdottiFinitiAdapter a = new EstraiProdottiFinitiAdapter(DbConnection, DbTransaction);
            a.GetBC_COM_CICLO(ds, NRCICLO, test);
        }

        [DataContext]
        public void GetBC_DETTAGLIO_CICLO(EstraiProdottiFinitiDS ds, string NRCICLO, bool test)
        {
            EstraiProdottiFinitiAdapter a = new EstraiProdottiFinitiAdapter(DbConnection, DbTransaction);
            a.GetBC_DETTAGLIO_CICLO(ds, NRCICLO, test);
        }
        [DataContext]
        public void FillBC_TASK(EstraiProdottiFinitiDS ds)
        {
            EstraiProdottiFinitiAdapter a = new EstraiProdottiFinitiAdapter(DbConnection, DbTransaction);
            a.FillBC_TASK(ds);
        }
        [DataContext]
        public void GetBC_DISTINTA(EstraiProdottiFinitiDS ds, string DIBA, bool test)
        {
            EstraiProdottiFinitiAdapter a = new EstraiProdottiFinitiAdapter(DbConnection, DbTransaction);
            a.GetBC_DISTINTA(ds, DIBA, test);
        }
        [DataContext]
        public void FillBC_NODO(EstraiProdottiFinitiDS ds, bool test)
        {
            EstraiProdottiFinitiAdapter a = new EstraiProdottiFinitiAdapter(DbConnection, DbTransaction);
            a.FillBC_NODO(ds, test);
        }
        [DataContext]
        public void fILLBC_NODO_Q(EstraiProdottiFinitiDS ds, bool test)
        {
            EstraiProdottiFinitiAdapter a = new EstraiProdottiFinitiAdapter(DbConnection, DbTransaction);
            a.fILLBC_NODO_Q(ds, test);
        }
        [DataContext]
        public void GetUSR_PRD_RDIBA(EstraiProdottiFinitiDS ds, string IDTDIBA)
        {
            if (!ds.USR_PRD_RDIBA.Any(x => x.IDTDIBA == IDTDIBA))
            {
                EstraiProdottiFinitiAdapter a = new EstraiProdottiFinitiAdapter(DbConnection, DbTransaction);
                a.GetUSR_PRD_RDIBA(ds, IDTDIBA);
            }
        }
        [DataContext]
        public void GetUSR_PRD_TDIBATopFinish(EstraiProdottiFinitiDS ds, string IDTDIBA)
        {
            EstraiProdottiFinitiAdapter a = new EstraiProdottiFinitiAdapter(DbConnection, DbTransaction);
            a.GetUSR_PRD_TDIBATopFinish(ds, IDTDIBA);
        }
        [DataContext]
        public void GetUSR_PRD_TDIBATopFinishByIDMAGAZZ(EstraiProdottiFinitiDS ds, string IDMAGAZZ)
        {
            EstraiProdottiFinitiAdapter a = new EstraiProdottiFinitiAdapter(DbConnection, DbTransaction);
            a.GetUSR_PRD_TDIBATopFinishByIDMAGAZZ(ds, IDMAGAZZ);
        }
        [DataContext]
        public void GetUSR_PRD_RDIBATopFinish(EstraiProdottiFinitiDS ds, string IDTDIBA)
        {
            EstraiProdottiFinitiAdapter a = new EstraiProdottiFinitiAdapter(DbConnection, DbTransaction);
            a.GetUSR_PRD_RDIBATopFinish(ds, IDTDIBA);
        }
        [DataContext]
        public void GetMAGAZZ(EstraiProdottiFinitiDS ds, string IDMAGAZZ)
        {
            EstraiProdottiFinitiAdapter a = new EstraiProdottiFinitiAdapter(DbConnection, DbTransaction);
            a.GetMAGAZZ(ds, IDMAGAZZ);
        }
        [DataContext]
        public void FillBC_ANAGRAFICA(EstraiProdottiFinitiDS ds, bool test)
        {
            EstraiProdottiFinitiAdapter a = new EstraiProdottiFinitiAdapter(DbConnection, DbTransaction);
            a.FillBC_ANAGRAFICA(ds, test);
        }
        [DataContext]
        public void FillTABFAS(EstraiProdottiFinitiDS ds)
        {
            EstraiProdottiFinitiAdapter a = new EstraiProdottiFinitiAdapter(DbConnection, DbTransaction);
            a.FillTABFAS(ds);
        }
        [DataContext(true)]
        public void UpdateTable(string tablename, EstraiProdottiFinitiDS ds, string tabellaFisica)
        {
            EstraiProdottiFinitiAdapter a = new EstraiProdottiFinitiAdapter(DbConnection, DbTransaction);
            a.UpdateTable(tablename, ds, tabellaFisica);
        }
    }
}

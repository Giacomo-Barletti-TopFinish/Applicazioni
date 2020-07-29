using Applicazioni.Data.Core;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.Spedizioni
{
    public class SpedizioniBusiness : BusinessBase
    {
        [DataContext]
        public void FillSPUBICAZIONI(SpedizioniDS ds, bool soloNonCancellati)
        {
            SpedizioniAdapter a = new SpedizioniAdapter(DbConnection, DbTransaction);
            a.FillSPUBICAZIONI(ds, soloNonCancellati);
        }

        [DataContext]
        public void GetUSR_PRD_RESOURCESF(SpedizioniDS ds, string BARCODE)
        {
            SpedizioniAdapter a = new SpedizioniAdapter(DbConnection, DbTransaction);
            a.GetUSR_PRD_RESOURCESF(ds, BARCODE);
        }
        [DataContext]
        public void GetSaldo(SpedizioniDS ds, decimal idSaldo)
        {
            SpedizioniAdapter a = new SpedizioniAdapter(DbConnection, DbTransaction);
            a.GetSaldo(ds, idSaldo);
        }

        [DataContext]
        public void GetSaldo(SpedizioniDS ds, decimal idUbicazione, string idmagazz)
        {
            SpedizioniAdapter a = new SpedizioniAdapter(DbConnection, DbTransaction);
            a.GetSaldo(ds, idUbicazione, idmagazz);
        }
        [DataContext(true)]
        public void SalvaUbicazioni(SpedizioniDS ds)
        {
            SpedizioniAdapter a = new SpedizioniAdapter(DbConnection, DbTransaction);
            a.UpdateTable(ds.SPUBICAZIONI.TableName, ds);
        }

        [DataContext(true)]
        public void SalvaInserimento(SpedizioniDS ds)
        {
            SpedizioniAdapter a = new SpedizioniAdapter(DbConnection, DbTransaction);
            a.UpdateTable(ds.SPSALDI.TableName, ds);
            a.UpdateTable(ds.SPMOVIMENTI.TableName, ds);
        }

        [DataContext]
        public void FillSPSALDI(SpedizioniDS ds, String UBICAZIONE, String MODELLO)
        {
            SpedizioniAdapter a = new SpedizioniAdapter(DbConnection, DbTransaction);
            a.FillSPSALDI(ds, UBICAZIONE, MODELLO);
        }

        [DataContext(true)]
        public void SalvaSaldi(SpedizioniDS ds)
        {
            SpedizioniAdapter a = new SpedizioniAdapter(DbConnection, DbTransaction);
            a.UpdateTable(ds.SPSALDI.TableName, ds);
        }

        [DataContext]
        public void FillMovimenti(SpedizioniDS ds, String UBICAZIONE, String MODELLO, DateTime dtInizo, DateTime dtFine)
        {
            SpedizioniAdapter a = new SpedizioniAdapter(DbConnection, DbTransaction);
            a.FillMovimenti(ds, UBICAZIONE, MODELLO, dtInizo, dtFine);
        }

    }


}

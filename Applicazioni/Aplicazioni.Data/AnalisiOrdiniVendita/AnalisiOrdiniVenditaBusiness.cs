using Applicazioni.Data.Core;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.AnalisiOrdiniVendita
{
    public class AnalisiOrdiniVenditaBusiness : BusinessBase
    {
        [DataContext]
        public void FillOC_APERTI(AnalisiOrdiniVenditaDS ds)
        {
            AnalisiOrdiniVenditaAdapter a = new AnalisiOrdiniVenditaAdapter(DbConnection, DbTransaction);
            a.FillOC_APERTI(ds);
        }

        [DataContext]
        public void FillAccantonatoEsistenzaPerOrigine(AnalisiOrdiniVenditaDS ds, string idOrigine, decimal tipoOrigine)
        {
            AnalisiOrdiniVenditaAdapter a = new AnalisiOrdiniVenditaAdapter(DbConnection, DbTransaction);
            a.FillAccantonatoEsistenzaPerOrigine(ds, idOrigine, tipoOrigine);
        }

        [DataContext]
        public void FillAccantonatoConsegnaDocumento(AnalisiOrdiniVenditaDS ds, string IDACCTOCON)
        {
            AnalisiOrdiniVenditaAdapter a = new AnalisiOrdiniVenditaAdapter(DbConnection, DbTransaction);
            a.FillAccantonatoConsegnaDocumento(ds, IDACCTOCON);
        }

        [DataContext]
        public void FillAccantonatoConsegnaPerOrigine(AnalisiOrdiniVenditaDS ds, string idOrigine, decimal tipoOrigine)
        {
            AnalisiOrdiniVenditaAdapter a = new AnalisiOrdiniVenditaAdapter(DbConnection, DbTransaction);
            a.FillAccantonatoConsegnaPerOrigine(ds, idOrigine, tipoOrigine);
        }

        [DataContext]
        public void GetMagazz(AnalisiOrdiniVenditaDS ds, string idMagazz)
        {
            AnalisiOrdiniVenditaAdapter a = new AnalisiOrdiniVenditaAdapter(DbConnection, DbTransaction);
            a.GetMagazz(ds, idMagazz);
        }
        [DataContext]
        public void GetTabMag(AnalisiOrdiniVenditaDS ds, string idTabMag)
        {
            AnalisiOrdiniVenditaAdapter a = new AnalisiOrdiniVenditaAdapter(DbConnection, DbTransaction);
            a.GetTabMag(ds, idTabMag);
        }
        [DataContext]
        public void GetUSR_PRD_MOVFASI(AnalisiOrdiniVenditaDS ds, string idPrdMovfase)
        {
            AnalisiOrdiniVenditaAdapter a = new AnalisiOrdiniVenditaAdapter(DbConnection, DbTransaction);
            a.GetUSR_PRD_MOVFASI(ds, idPrdMovfase);
        }

        [DataContext]
        public void GetUSR_PRD_FASI(AnalisiOrdiniVenditaDS ds, string idPrdfase)
        {
            AnalisiOrdiniVenditaAdapter a = new AnalisiOrdiniVenditaAdapter(DbConnection, DbTransaction);
            a.GetUSR_PRD_FASI(ds, idPrdfase);
        }
        [DataContext]
        public void FillTabFas(AnalisiOrdiniVenditaDS ds)
        {
            AnalisiOrdiniVenditaAdapter a = new AnalisiOrdiniVenditaAdapter(DbConnection, DbTransaction);
            a.FillTabFas(ds);
        }
    }
}

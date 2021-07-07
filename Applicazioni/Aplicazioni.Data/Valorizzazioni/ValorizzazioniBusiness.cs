using Applicazioni.Data.Core;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.Valorizzazioni
{
    public class ValorizzazioniBusiness : BusinessBase
    {
        [DataContext]
        public void FillUSR_INVENTARIOT(ValorizzazioneDS ds)
        {
            ValorizzazioneAdapter a = new ValorizzazioneAdapter(DbConnection, DbTransaction);
            a.FillUSR_INVENTARIOT(ds);
        }
        [DataContext]
        public void FillUSR_INVENTARIOD(ValorizzazioneDS ds, string idInventarioT)
        {
            ValorizzazioneAdapter a = new ValorizzazioneAdapter(DbConnection, DbTransaction);
            a.FillUSR_INVENTARIOD(ds, idInventarioT);
        }
        [DataContext]
        public void FillUSR_VENDITED(ValorizzazioneDS ds, string anno)
        {
            ValorizzazioneAdapter a = new ValorizzazioneAdapter(DbConnection, DbTransaction);
            a.FillUSR_VENDITED(ds, anno);
        }
        [DataContext]
        public void FillUSR_PRD_TDIBA(ValorizzazioneDS ds)
        {
            ValorizzazioneAdapter a = new ValorizzazioneAdapter(DbConnection, DbTransaction);
            a.FillUSR_PRD_TDIBA(ds);
        }
        [DataContext]
        public void FillUSR_PRD_TDIBA_DEFAULT(ValorizzazioneDS ds)
        {
            ValorizzazioneAdapter a = new ValorizzazioneAdapter(DbConnection, DbTransaction);
            a.FillUSR_PRD_TDIBA_DEFAULT(ds);
        }
        [DataContext]
        public void FillUSR_PRD_TDIBA_DEFAULTS(ValorizzazioneDS ds)
        {
            ValorizzazioneAdapter a = new ValorizzazioneAdapter(DbConnection, DbTransaction);
            a.FillUSR_PRD_TDIBA_DEFAULTS(ds);
        }
        [DataContext]
        public void FillUSR_PRD_RDIBA(ValorizzazioneDS ds)
        {
            ValorizzazioneAdapter a = new ValorizzazioneAdapter(DbConnection, DbTransaction);
            a.FillUSR_PRD_RDIBA(ds);
        }

        [DataContext]
        public void FillUSR_PRD_RDIBA(ValorizzazioneDS ds, List<string> idRdiba)
        {
            List<string> articoliPresenti = ds.USR_PRD_RDIBA.Select(x => x.IDRDIBA).Distinct().ToList();
            List<string> articoliMancanti = idRdiba.Except(articoliPresenti).ToList();

            ValorizzazioneAdapter a = new ValorizzazioneAdapter(DbConnection, DbTransaction);
            while (articoliMancanti.Count > 0)
            {
                List<string> articoliDaCaricare;
                if (articoliMancanti.Count > 999)
                {
                    articoliDaCaricare = articoliMancanti.GetRange(0, 999);
                    articoliMancanti.RemoveRange(0, 999);
                }
                else
                {
                    articoliDaCaricare = articoliMancanti.GetRange(0, articoliMancanti.Count);
                    articoliMancanti.RemoveRange(0, articoliMancanti.Count);
                }
                a.FillUSR_PRD_RDIBA(ds, articoliDaCaricare);

            }
        }

        [DataContext]
        public void FillUSR_PRD_TDIBA(ValorizzazioneDS ds, List<string> idTdiba)
        {
            List<string> articoliPresenti = ds.USR_PRD_TDIBA.Select(x => x.IDTDIBA).Distinct().ToList();
            List<string> articoliMancanti = idTdiba.Except(articoliPresenti).ToList();

            ValorizzazioneAdapter a = new ValorizzazioneAdapter(DbConnection, DbTransaction);
            while (articoliMancanti.Count > 0)
            {
                List<string> articoliDaCaricare;
                if (articoliMancanti.Count > 999)
                {
                    articoliDaCaricare = articoliMancanti.GetRange(0, 999);
                    articoliMancanti.RemoveRange(0, 999);
                }
                else
                {
                    articoliDaCaricare = articoliMancanti.GetRange(0, articoliMancanti.Count);
                    articoliMancanti.RemoveRange(0, articoliMancanti.Count);
                }
                a.FillUSR_PRD_TDIBA(ds, articoliDaCaricare);

            }
        }
        [DataContext]
        public long DeleteCostiArticoli(string IdInventarioT)
        {
            ValorizzazioneAdapter a = new ValorizzazioneAdapter(DbConnection, DbTransaction);
            return a.DeleteCostiArticoli(IdInventarioT);
        }

        [DataContext]
        public long DeleteCostiGalvanica()
        {
            ValorizzazioneAdapter a = new ValorizzazioneAdapter(DbConnection, DbTransaction);
            return a.DeleteCostiGalvanica();
        }

        [DataContext(true)]
        public void UpdateTable(string tablename, ValorizzazioneDS ds)
        {
            ValorizzazioneAdapter a = new ValorizzazioneAdapter(DbConnection, DbTransaction);
            a.UpdateTable(tablename, ds);
        }

        [DataContext]
        public void FillCOSTI_ARTICOLI(ValorizzazioneDS ds, String idInventarioT)
        {
            ValorizzazioneAdapter a = new ValorizzazioneAdapter(DbConnection, DbTransaction);
            a.FillCOSTI_ARTICOLI(ds, idInventarioT);
        }

        [DataContext]
        public void FillUSR_LIS_ACQ(ValorizzazioneDS ds)
        {
            ValorizzazioneAdapter a = new ValorizzazioneAdapter(DbConnection, DbTransaction);
            a.FillUSR_LIS_ACQ(ds);
        }

        [DataContext]
        public void FillUSR_LIS_VEN(ValorizzazioneDS ds)
        {
            ValorizzazioneAdapter a = new ValorizzazioneAdapter(DbConnection, DbTransaction);
            a.FillUSR_LIS_VEN(ds);
        }

        [DataContext]
        public void FillBILANCIO_2020(ValorizzazioneDS ds)
        {
            ValorizzazioneAdapter a = new ValorizzazioneAdapter(DbConnection, DbTransaction);
            a.FillBILANCIO_2020(ds);
        }
        [DataContext]
        public void FillUSR_LIS_FASE(ValorizzazioneDS ds)
        {
            ValorizzazioneAdapter a = new ValorizzazioneAdapter(DbConnection, DbTransaction);
            a.FillUSR_LIS_FASE(ds);
        }
    }
}

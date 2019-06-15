using Applicazioni.Data.Core;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.Galvanica
{
    public class GalvanicaBusiness : BusinessBase
    {
        [DataContext]
        public void FillUSR_PRD_MOVFASI(GalvanicaDS ds, string Barcode)
        {
            if (!ds.USR_PRD_MOVFASI.Any(x => x.BARCODE == Barcode))
            {
                GalvanicaAdapter a = new GalvanicaAdapter(DbConnection, DbTransaction);
                a.FillUSR_PRD_MOVFASI(ds, Barcode);
            }
        }

        [DataContext]
        public GalvanicaDS.AP_GALVANICA_MODELLORow GetAP_GALVANICA_MODELLO(GalvanicaDS ds, string IDMAGAZZ_Lancio, string IDMAGAZZ_WIP)
        {
            if (!ds.AP_GALVANICA_MODELLO.Any(x => x.IDMAGAZZ == IDMAGAZZ_Lancio && x.IDMAGAZZ_WIP == IDMAGAZZ_WIP))
            {
                GalvanicaAdapter a = new GalvanicaAdapter(DbConnection, DbTransaction);
                a.FillAP_GALVANICA_MODELLO(ds, IDMAGAZZ_Lancio, IDMAGAZZ_WIP);
            }
            return ds.AP_GALVANICA_MODELLO.Where(x => x.IDMAGAZZ == IDMAGAZZ_Lancio && x.IDMAGAZZ_WIP == IDMAGAZZ_WIP).FirstOrDefault();
        }

        [DataContext(true)]
        public void UpdateTable(string tablename, GalvanicaDS ds)
        {
            GalvanicaAdapter a = new GalvanicaAdapter(DbConnection, DbTransaction);
            a.UpdateTable(tablename, ds);
        }

        [DataContext]
        public void FillFINITURA_ORDINE(GalvanicaDS ds)
        {
            GalvanicaAdapter a = new GalvanicaAdapter(DbConnection, DbTransaction);
            a.FillFINITURA_ORDINE(ds);
        }

        [DataContext]
        public void FillAP_GALVANICA_PIANO(GalvanicaDS ds, DateTime data)
        {
            GalvanicaAdapter a = new GalvanicaAdapter(DbConnection, DbTransaction);
            a.FillAP_GALVANICA_PIANO(ds, data);
        }
        [DataContext]
        public void FillGALVANICA_CARICO(GalvanicaDS ds, DateTime data)
        {
            GalvanicaAdapter a = new GalvanicaAdapter(DbConnection, DbTransaction);
            a.FillGALVANICA_CARICO(ds, data);
        }
    }
}

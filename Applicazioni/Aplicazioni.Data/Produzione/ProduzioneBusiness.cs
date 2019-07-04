using Applicazioni.Data.Core;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.Produzione
{
    public class ProduzioneBusiness : BusinessBase
    {
        [DataContext]
        public void FillUSR_PRD_MOVFASI(ProduzioneDS ds, List<string> IDPRDMOVFASE)
        {
            List<string> Presenti = ds.USR_PRD_MOVFASI.Select(x => x.IDPRDMOVFASE).Distinct().ToList();
            List<string> Mancanti = IDPRDMOVFASE.Except(Presenti).ToList();

            ProduzioneAdapter a = new ProduzioneAdapter(DbConnection, DbTransaction);
            while (Mancanti.Count > 0)
            {
                List<string> daCaricare;
                if (Mancanti.Count > 999)
                {
                    daCaricare = Mancanti.GetRange(0, 999);
                    Mancanti.RemoveRange(0, 999);
                }
                else
                {
                    daCaricare = Mancanti.GetRange(0, Mancanti.Count);
                    Mancanti.RemoveRange(0, Mancanti.Count);
                }
                a.FillUSR_PRD_MOVFASI(ds, daCaricare);
            }
        }

        [DataContext]
        public void FillUSR_PRD_FASI(ProduzioneDS ds, List<string> IDPRDFASE)
        {
            List<string> Presenti = ds.USR_PRD_FASI.Select(x => x.IDPRDFASE).Distinct().ToList();
            List<string> Mancanti = IDPRDFASE.Except(Presenti).ToList();

            ProduzioneAdapter a = new ProduzioneAdapter(DbConnection, DbTransaction);
            while (Mancanti.Count > 0)
            {
                List<string> daCaricare;
                if (Mancanti.Count > 999)
                {
                    daCaricare = Mancanti.GetRange(0, 999);
                    Mancanti.RemoveRange(0, 999);
                }
                else
                {
                    daCaricare = Mancanti.GetRange(0, Mancanti.Count);
                    Mancanti.RemoveRange(0, Mancanti.Count);
                }
                a.FillUSR_PRD_FASI(ds, daCaricare);
            }
        }

        [DataContext]
        public void FillUSR_PRD_MOVFASIByBarcode(ProduzioneDS ds, string Barcode)
        {
            ProduzioneAdapter a = new ProduzioneAdapter(DbConnection, DbTransaction);
            a.FillUSR_PRD_MOVFASIByBarcode(ds, Barcode);
        }
    }
}


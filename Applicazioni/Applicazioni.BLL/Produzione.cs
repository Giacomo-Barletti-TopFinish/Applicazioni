using Applicazioni.Data.Produzione;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.BLL
{
    public class Produzione
    {
        private ProduzioneDS _ds = new ProduzioneDS();

        public ProduzioneDS.USR_PRD_FASIRow GetUSR_PRD_FASI(string IDPRDFASE)
        {
            if (!_ds.USR_PRD_FASI.Any(x => x.IDPRDFASE == IDPRDFASE))
            {
                using (ProduzioneBusiness bProduzione = new ProduzioneBusiness())
                {
                    bProduzione.FillUSR_PRD_FASI(_ds, new List<string>(new string[] { IDPRDFASE }));
                }
            }
            return _ds.USR_PRD_FASI.Where(x => x.IDPRDFASE == IDPRDFASE).FirstOrDefault();
        }

        public ProduzioneDS.USR_PRD_MOVFASIRow GetUSR_PRD_MOVFASI(string IDPRDMOVFASE)
        {
            if (!_ds.USR_PRD_MOVFASI.Any(x => x.IDPRDMOVFASE == IDPRDMOVFASE))
            {
                using (ProduzioneBusiness bProduzione = new ProduzioneBusiness())
                {
                    bProduzione.FillUSR_PRD_FASI(_ds, new List<string>(new string[] { IDPRDMOVFASE }));
                }
            }
            return _ds.USR_PRD_MOVFASI.Where(x => x.IDPRDMOVFASE == IDPRDMOVFASE).FirstOrDefault();
        }

        public ProduzioneDS.USR_PRD_MOVFASIRow GetUSR_PRD_MOVFASIByBarcode(string Barcode)
        {
            if (!_ds.USR_PRD_MOVFASI.Any(x => x.BARCODE == Barcode))
            {
                using (ProduzioneBusiness bProduzione = new ProduzioneBusiness())
                {
                    bProduzione.FillUSR_PRD_MOVFASIByBarcode(_ds, Barcode);
                }
            }
            return _ds.USR_PRD_MOVFASI.Where(x => x.BARCODE == Barcode).FirstOrDefault();
        }
    }
}

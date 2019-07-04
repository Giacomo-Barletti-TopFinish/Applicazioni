using Applicazioni.Data.Anagrafica;
using Applicazioni.Entities;
using Applicazioni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.BLL
{
    public class Anagrafica
    {
        private AnagraficaDS _ds = new AnagraficaDS();
        public AnagraficaDS.MAGAZZRow GetMAGAZZ(string IDMAGAZZ)
        {
            if (!_ds.MAGAZZ.Any(x => x.IDMAGAZZ == IDMAGAZZ))
            {
                using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
                {
                    bAnagrafica.FillMAGAZZ(_ds, new List<string>(new string[] { IDMAGAZZ }));
                }
            }
            return _ds.MAGAZZ.Where(x => x.IDMAGAZZ == IDMAGAZZ).FirstOrDefault();
        }

        public Articolo GetArticolo(string IDMAGAZZ)
        {

            AnagraficaDS.MAGAZZRow magazz = GetMAGAZZ(IDMAGAZZ);
            return CreaArticolo(magazz);
        }

        private Articolo CreaArticolo(AnagraficaDS.MAGAZZRow magazz)
        {
            if (magazz == null) return null;

            Articolo articolo = new Articolo();
            articolo.Modello = magazz.MODELLO;
            articolo.Descrizione = magazz.DESMAGAZZ;
            articolo.IdMagazz = magazz.IDMAGAZZ;
            articolo.Superficie = magazz.SUPERFICIE;

            AnagraficaDS.USR_PDM_FILESRow immagine = _ds.USR_PDM_FILES.Where(x => x.IDMAGAZZ == magazz.IDMAGAZZ).FirstOrDefault();
            if (immagine != null)
            {

                articolo.Immagine = immagine.PDMPATH + immagine.NOMEFILE;
            }

            return articolo;
        }
    }
}
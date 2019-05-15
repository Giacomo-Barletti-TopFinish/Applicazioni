using Applicazioni.Data.Anagrafica;
using Applicazioni.Entities;
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
    }
}
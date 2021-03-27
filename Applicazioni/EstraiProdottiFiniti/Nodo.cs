using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstraiProdottiFiniti
{
    public class Nodo
    {
        public int ID;
        public int Profondita;
        public string IDMAGAZZ;
        public string Modello;
        public string Anagrafica;
        public decimal Quantita;
        public int IDPADRE;

        public override string ToString()
        {
            return string.Format("{0} {1}", ID, Modello);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstraiProdottiFiniti
{
    public class Nodo
    {
        public int ID { get; set; }
        public int Profondita { get; set; }
        public string IDMAGAZZ { get; set; }
        public string Modello { get; set; }
        public string Anagrafica { get; set; }
        public decimal Quantita { get; set; }
        public int IDPADRE { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", ID, Modello);
        }
    }
}

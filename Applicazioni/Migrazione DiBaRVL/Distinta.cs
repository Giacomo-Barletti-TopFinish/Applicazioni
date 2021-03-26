using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrazione_DiBaRVL
{
    public class Distinta
    {
        public string Codice;
        public List<Componente> Componenti = new List<Componente>();

        public Distinta(string Codice, List<Componente> Componenti)
        {
            this.Codice = Codice;
            this.Componenti = Componenti;
        }
    }

    public class Componente
    {
        public string Anagrafica;
        public decimal Quantita;
        public Componente(string Anagrafica, decimal Quantita)
        {
            this.Anagrafica = Anagrafica;
            this.Quantita = Quantita;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Entities
{
    public class Distinta
    {
        public string Codice;
        public List<Componente> Componenti = new List<Componente>();
        public string Versione = string.Empty;



        public Distinta(string Codice, List<Componente> Componenti)
        {
            this.Codice = Codice;
            this.Componenti = Componenti;
        }
    }

    public class Componente
    {
        public string Tipo = "Articolo";
        public string Descrizione = string.Empty;
        public string CodiceUM = "KG";
        public string Anagrafica;
        public decimal Quantita;
        public string Collegamento;
        public decimal Scarto=0;
        public decimal Arrotondamento=1/1000;
        public decimal PrecisionQuantity=0;
        public string FormulaQuantita=string.Empty;
        public string Condizione=string.Empty;
        public string ArticoloNeutro=string.Empty;
        public string Formula=string.Empty;
        public Componente(string Anagrafica, decimal Quantita, string Collegamento, string UM)
        {
            this.Anagrafica = Anagrafica;
            this.Quantita = Quantita;
            this.Collegamento = Collegamento;
            this.CodiceUM = UM;
        }
    }
}

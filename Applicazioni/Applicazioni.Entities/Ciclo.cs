using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Entities
{
    public class Ciclo
    {
        public int Inizio;
        public int Fine;
        public string Codice;
        public List<Fase> Fasi;
        public Ciclo(int Inizio, int Fine, string Codice)
        {
            this.Codice = Codice;
            this.Inizio = Inizio;
            this.Fine = Fine;
            Fasi = new List<Fase>();
        }
    }

    public class Fase
    {
        public string Versione = string.Empty;
        public int Operazione;
        public string Tipo = "Area di produzione";
        public string AreaProduzione;
        public decimal TempoSetup = 0;
        public decimal TempoLavorazione;
        public decimal TempoAttesa = 0;
        public decimal TempoSpostamento = 0;
        public int DimensioneLotto = 0;
        public string UMSetup = "ORE";
        public string UMLavorazione = "ORE";
        public string UMAttesa = "ORE";
        public string UMSpostamento = "ORE";
        public string Collegamento;
        public string Task;
        public string Condizione = string.Empty;
        public string Caratteristica = string.Empty;
        public string LogicheLavorazione = string.Empty;
        public List<string> Commenti = new List<string>();
    }
}

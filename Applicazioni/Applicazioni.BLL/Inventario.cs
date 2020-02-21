using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applicazioni.Data.Valorizzazioni;
using Applicazioni.Entities;

namespace Applicazioni.BLL
{
    public class Inventario
    {
        private ValorizzazioneDS _ds = new ValorizzazioneDS();

        public List<Testata> CreaListaTestate()
        {
            List<Testata> lista = new List<Testata>();
            using (ValorizzazioniBusiness bValorizzazioni = new ValorizzazioniBusiness())
            {
                bValorizzazioni.FillUSR_INVENTARIOT(_ds);
                foreach (ValorizzazioneDS.USR_INVENTARIOTRow inventarioRow in _ds.USR_INVENTARIOT)
                {
                    lista.Add(CreaTestata(inventarioRow));
                }
            }
            return lista;
        }

        private Testata CreaTestata(ValorizzazioneDS.USR_INVENTARIOTRow inventarioRow)
        {
            return new Testata()
            {
                Codice = inventarioRow.CODINVENTARIOT,
                DataFine = inventarioRow.DATARIMFINALE,
                DataInizio = inventarioRow.DATARIMINIZIALE,
                Descrizione = inventarioRow.DESINVENTARIOT,
                IdInventarioT = inventarioRow.IDINVENTARIOT
            };
        }
    }

    public class Testata
    {
        public string IdInventarioT { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Codice, DataFine.ToShortDateString());
        }
    }
}

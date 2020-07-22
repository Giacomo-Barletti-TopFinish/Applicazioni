using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisiOrdiniVendita
{
    public class FaseModel
    {
        public string Tipologia { get; set; }

        public string Livello1 { get; set; }
        public string Livello2 { get; set; }
        public string Livello3{ get; set; }
        public string ControlloQualità { get; set; }
        public string Modello { get; set; }
        public string DataConsegna { get; set; }
        public string Quantita { get; set; }
        public string QuantitaDaTerminare { get; set; }
        public string QuantitaOK { get; set; }
        public string QuantitaDifettosa { get; set; }
        public string QuantitaNonLavorata { get; set; }
        public string QuantitaAnnullata { get; set; }
    }

    public class Etichette
    {
        public const string Infragruppo = "Infragruppo";
        public const string InfragruppoODL = "Infragruppo ODL";
        public const string ControlloQualita = "CQ";
        public const string SeguitoODL = "Seguito ODL";
        public const string Seguito = "Seguito";
        public const string Accatonato = "Accantonato";
        public const string AccatonatoDocumento = "AccantonatoDocumento";
        public const string AccatonatoEsistenza = "AccantonatoEsistenza";
        public const string FaseODL = "Fase ODL";
        public const string Fase = "Fase";
        public const string Materiale = "Materiale";

    }
}

using Applicazioni.Entities;
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
        public bool ContoLavoro { get; set; }
        public int Profondita { get; set; }
        public string IDMAGAZZ { get; set; }
        public string Modello { get; set; }
        public string Anagrafica { get; set; }
        public decimal Quantita { get; set; }
        public int IDPADRE { get; set; }
        private string _reparto;
        public string Reparto
        {
            get { return _reparto; }
            set
            {
                if (value.Trim() == "PUL TF") _reparto = "PULI";
                else _reparto = value;
            }
        }
        public string Fase { get; set; }
        public string NoteTecniche { get; set; }
        public string NoteStandard { get; set; }
        public string FornitoDaCommittente { get; set; }
        public string CollegamentoDiba { get; set; }
        public string CollegamentoCiclo { get; set; }
        public decimal PezziOrari { get; set; }
        public decimal OrePeriodo { get; set; }
        public string CodiceCiclo { get; set; }
        public decimal Peso { get; set; }
        public decimal Superficie { get; set; }
        public string UM { get; set; }


        public string DescrizioneArticolo { get; set; }
        public decimal QuantitaConsumo { get; set; }
        public decimal QuantitaOccorrenza { get; set; }
        public string Attiva { get; set; }
        public string Controllata { get; set; }
        public string CaricoReparto { get; set; }
        public string Metodo { get; set; }
        public string Versione { get; set; }



        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Anagrafica))
                return string.Format("{0} {1} ({2})", ID, Modello, Anagrafica);

            return string.Format("{0} {1}", ID, Modello);
        }

        public EstraiProdottiFinitiDS.BC_ANAGRAFICARow CreaRigaTabella(EstraiProdottiFinitiDS ds)
        {
            EstraiProdottiFinitiDS.BC_ANAGRAFICARow rigaTabella = ds.BC_ANAGRAFICA.NewBC_ANAGRAFICARow();
            rigaTabella.BC = Anagrafica;
            rigaTabella.IDMAGAZZ = IDMAGAZZ;
            return rigaTabella;
        }

        public void ToUpper()
        {

            if (Anagrafica != null) Anagrafica = Anagrafica.ToUpper();
            if (CodiceCiclo != null) CodiceCiclo = CodiceCiclo.ToUpper();
            if (CollegamentoCiclo != null) CollegamentoCiclo = CollegamentoCiclo.ToUpper();
            if (CollegamentoDiba != null) CollegamentoDiba = CollegamentoDiba.ToUpper();
            if (Reparto != null) Reparto = Reparto.ToUpper();
        }
    }
}

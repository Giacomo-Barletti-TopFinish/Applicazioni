using Applicazioni.Data.Spedizioni;
using Applicazioni.Data.Trasferimenti;
using Applicazioni.Entities;
using Applicazioni.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.BLL
{
    public class Spedizioni
    {
        private SpedizioniDS ds = new SpedizioniDS();
        public string LeggiBarcode(string barcode)
        {
            string tipo = barcode.Substring(0, 3);
            if (tipo == BarcodeHelper.TipoUbicazione)
            {
                using (SpedizioniBusiness bSpedizioni = new SpedizioniBusiness())
                {
                    bSpedizioni.FillSPUBICAZIONI(ds, true);
                }
                SpedizioniDS.SPUBICAZIONIRow ubicazione = ds.SPUBICAZIONI.Where(x => x.BARCODE == barcode).FirstOrDefault();
                if (ubicazione == null)
                    return "Ubicazione sconosciuta";

                return string.Format("{0} - {1}", ubicazione.CODICE, ubicazione.DESCRIZIONE);
            }

            TrasferimentiDS _ds = new TrasferimentiDS();
            using (TrasferimentiBusiness bTrasferimenti = new TrasferimentiBusiness())
            {
                if (!_ds.USR_PRD_MOVFASI.Any(x => x.BARCODE == barcode))
                    bTrasferimenti.FillUSR_PRD_MOVFASI(_ds, barcode);

                TrasferimentiDS.USR_PRD_MOVFASIRow odl = _ds.USR_PRD_MOVFASI.Where(x => x.BARCODE == barcode).FirstOrDefault();
                if (odl == null)
                    return "BARCODE NON TROVATO";

                Anagrafica _anagrafica = new Anagrafica();
                AnagraficaDS.MAGAZZRow articolo = _anagrafica.GetMAGAZZ(odl.IDMAGAZZ);

                return string.Format("{0} - {1}",odl.QTA,articolo.MODELLO);

            }
        }

        public void FillUbicazioni(SpedizioniDS ds, bool soloNonCancellati)
        {
            using(SpedizioniBusiness bSpedizioni = new SpedizioniBusiness())
            {
                bSpedizioni.FillSPUBICAZIONI(ds, soloNonCancellati);
            }
        }

        public void SalvaUbicazione(string codice, string descrizione, string utente)
        {
            using (SpedizioniBusiness bSpedizioni = new SpedizioniBusiness())
            {
                long id = bSpedizioni.GetID();
                string identificativo = id.ToString().PadLeft(10, '0');
                string barcode = string.Format("{0}{1}", BarcodeHelper.TipoUbicazione, identificativo);

                SpedizioniDS.SPUBICAZIONIRow ubicazione = ds.SPUBICAZIONI.NewSPUBICAZIONIRow();
                ubicazione.BARCODE = barcode;
                ubicazione.CODICE = codice;
                ubicazione.DESCRIZIONE = descrizione;
                ubicazione.CANCELLATO = "N";
                ubicazione.DATAMODIFICA = DateTime.Now;
                ubicazione.UTENTEMODIFICA = utente;

                ds.SPUBICAZIONI.AddSPUBICAZIONIRow(ubicazione);

                bSpedizioni.SalvaUbicazioni(ds);
            }
        }

        public void FillSaldi(SpedizioniDS ds, bool soloNonCancellati)
        {
            using (SpedizioniBusiness bSpedizioni = new SpedizioniBusiness())
            {
                bSpedizioni.FillSPSALDI(ds, soloNonCancellati);
            }
        }

        public void SalvaSaldo(decimal IdUbicazione, string IdMagazz, string utente)
        {
            using (SpedizioniBusiness bSpedizioni = new SpedizioniBusiness())
            {

                SpedizioniDS.SPSALDIRow saldo = ds.SPSALDI.NewSPSALDIRow();
                saldo.IDUBICAZIONE = IdUbicazione;
                saldo.IDMAGAZZ = IdMagazz;
                saldo.DATAMODIFICA = DateTime.Now;
                saldo.UTENTEMODIFICA = utente;

                ds.SPSALDI.AddSPSALDIRow(saldo);

                bSpedizioni.SalvaSaldi(ds);
            }
        }

    }
}

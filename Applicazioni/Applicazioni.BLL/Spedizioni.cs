using Applicazioni.Data.Spedizioni;
using Applicazioni.Data.Trasferimenti;
using Applicazioni.Entities;
using Applicazioni.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.BLL
{
    public class Spedizioni
    {
        private SpedizioniDS ds = new SpedizioniDS();

        public bool LeggiFileExcelOpera(SpedizioniDS ds, string filePath, string brand, out string messaggioErrore)
        {
            messaggioErrore = string.Empty;
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                ds.SPOPERA.Clear();


                ExcelHelper excel = new ExcelHelper();
                if (!excel.LeggiFileExcelOpera(fs, ds, out messaggioErrore))
                {
                    ds.SPOPERA.Clear();
                    return false;
                }

                if (ds.SPOPERA.Count == 0)
                {
                    messaggioErrore = "Il file excel risulta essere vuoto";
                    return false;
                }

                fs.Close();
            }
            return true;
        }


        public string Inserisci(string BarcodeODL, string BarcodeUbicazione, string BarcodeOperatore)
        {
            SpedizioniDS.SPUBICAZIONIRow ubicazione = LeggiUbicazione(BarcodeUbicazione);
            if (ubicazione == null) return "UBICAZIONE NON TROVATA";

            TrasferimentiDS.USR_PRD_MOVFASIRow odl = LeggiODL(BarcodeODL);
            if (odl == null)
                return "ARTICOLO NON TROVATO";

            Anagrafica _anagrafica = new Anagrafica();
            AnagraficaDS.MAGAZZRow articolo = _anagrafica.GetMAGAZZ(odl.IDMAGAZZ);
            if (articolo == null) return "ARTICOLO NON TROVATO";

            string utenza = LeggiUtenza(BarcodeOperatore);
            if (string.IsNullOrEmpty(utenza)) return "OPERATORE NON TROVATO";

            using (SpedizioniBusiness bSpedizioni = new SpedizioniBusiness())
            {
                try
                {
                    bSpedizioni.GetSaldo(ds, ubicazione.IDUBICAZIONE, articolo.IDMAGAZZ);
                    SpedizioniDS.SPSALDIRow saldo = ds.SPSALDI.Where(x => x.IDUBICAZIONE == ubicazione.IDUBICAZIONE && x.IDMAGAZZ == articolo.IDMAGAZZ).FirstOrDefault();
                    DateTime data = DateTime.Now;
                    decimal idsaldo = bSpedizioni.GetID(); ;
                    if (saldo == null)
                    {
                        saldo = ds.SPSALDI.NewSPSALDIRow();
                        saldo.IDSALDO = idsaldo;
                        saldo.IDMAGAZZ = articolo.IDMAGAZZ;
                        saldo.DATAMODIFICA = data;
                        saldo.IDUBICAZIONE = ubicazione.IDUBICAZIONE;
                        saldo.QUANTITA = odl.QTA;
                        saldo.UTENTEMODIFICA = utenza;
                        ds.SPSALDI.AddSPSALDIRow(saldo);
                    }
                    else
                    {
                        idsaldo = saldo.IDSALDO;
                        saldo.DATAMODIFICA = data;
                        decimal quantita = saldo.QUANTITA + odl.QTA;
                        saldo.QUANTITA = quantita;
                        saldo.UTENTEMODIFICA = utenza;

                    }

                    SpedizioniDS.SPMOVIMENTIRow movimento = ds.SPMOVIMENTI.NewSPMOVIMENTIRow();
                    movimento.CAUSALE = odl.IsNUMMOVFASENull() ? "ODL" : odl.NUMMOVFASE;
                    movimento.DATAMODIFICA = DateTime.Now;
                    movimento.IDSALDO = idsaldo;
                    movimento.QUANTITA = odl.QTA;
                    movimento.TIPOMOVIMENTO = "VERSAMENTO";
                    movimento.UTENTEMODIFICA = utenza;
                    ds.SPMOVIMENTI.AddSPMOVIMENTIRow(movimento);

                    bSpedizioni.SalvaInserimento(ds);

                }
                catch (Exception ex)
                {
                    bSpedizioni.Rollback();
                    return "ERRORE IMPOSSIBILE PROCEDERE";
                }
            }

            return "COMPLETATA";
        }

        public string UbicaDaODL(string BarcodeODL, string BarcodeUbicazione, string utenza)
        {
            SpedizioniDS.SPUBICAZIONIRow ubicazione = LeggiUbicazione(BarcodeUbicazione);
            if (ubicazione == null) return "UBICAZIONE NON TROVATA";

            TrasferimentiDS.USR_PRD_MOVFASIRow odl = LeggiODL(BarcodeODL);
            if (odl == null)
                return "ARTICOLO NON TROVATO";

            Anagrafica _anagrafica = new Anagrafica();
            AnagraficaDS.MAGAZZRow articolo = _anagrafica.GetMAGAZZ(odl.IDMAGAZZ);
            if (articolo == null) return "ARTICOLO NON TROVATO";

            using (SpedizioniBusiness bSpedizioni = new SpedizioniBusiness())
            {
                try
                {
                    bSpedizioni.GetSaldo(ds, ubicazione.IDUBICAZIONE, articolo.IDMAGAZZ);
                    SpedizioniDS.SPSALDIRow saldo = ds.SPSALDI.Where(x => x.IDUBICAZIONE == ubicazione.IDUBICAZIONE && x.IDMAGAZZ == articolo.IDMAGAZZ).FirstOrDefault();
                    DateTime data = DateTime.Now;
                    decimal idsaldo = bSpedizioni.GetID(); ;
                    if (saldo == null)
                    {
                        saldo = ds.SPSALDI.NewSPSALDIRow();
                        saldo.IDSALDO = idsaldo;
                        saldo.IDMAGAZZ = articolo.IDMAGAZZ;
                        saldo.DATAMODIFICA = data;
                        saldo.IDUBICAZIONE = ubicazione.IDUBICAZIONE;
                        saldo.QUANTITA = odl.QTA;
                        saldo.UTENTEMODIFICA = utenza;
                        ds.SPSALDI.AddSPSALDIRow(saldo);
                    }
                    else
                    {
                        idsaldo = saldo.IDSALDO;
                        saldo.DATAMODIFICA = data;
                        decimal quantita = saldo.QUANTITA + odl.QTA;
                        saldo.QUANTITA = quantita;
                        saldo.UTENTEMODIFICA = utenza;

                    }

                    SpedizioniDS.SPMOVIMENTIRow movimento = ds.SPMOVIMENTI.NewSPMOVIMENTIRow();
                    movimento.CAUSALE = odl.IsNUMMOVFASENull() ? "ODL" : odl.NUMMOVFASE;
                    movimento.DATAMODIFICA = DateTime.Now;
                    movimento.IDSALDO = idsaldo;
                    movimento.QUANTITA = odl.QTA;
                    movimento.TIPOMOVIMENTO = "VERSAMENTO";
                    movimento.UTENTEMODIFICA = utenza;
                    ds.SPMOVIMENTI.AddSPMOVIMENTIRow(movimento);

                    bSpedizioni.SalvaInserimento(ds);

                }
                catch (Exception ex)
                {
                    bSpedizioni.Rollback();
                    return "ERRORE IMPOSSIBILE PROCEDERE";
                }
            }

            return "COMPLETATA";
        }

        public string Movimenta(decimal idsaldo, decimal quantita, string causale, string tipoOperazione, string utenza)
        {

            using (SpedizioniBusiness bSpedizioni = new SpedizioniBusiness())
            {
                try
                {
                    bSpedizioni.GetSaldo(ds, idsaldo);
                    SpedizioniDS.SPSALDIRow saldo = ds.SPSALDI.Where(x => x.IDSALDO == idsaldo).FirstOrDefault();
                    DateTime data = DateTime.Now;
                    if (saldo == null)
                        return "Impossibile trovare il saldo";


                    saldo.DATAMODIFICA = data;
                    decimal quantitaSaldo = saldo.QUANTITA;
                    if (tipoOperazione == "VERSAMENTO")
                        quantitaSaldo = saldo.QUANTITA + quantita;
                    else
                    {
                        quantitaSaldo = saldo.QUANTITA - quantita;
                        if (quantitaSaldo < 0)
                            return "Saldo negativo operazione non ammessa";
                    }

                    saldo.QUANTITA = quantitaSaldo;
                    saldo.UTENTEMODIFICA = utenza;


                    SpedizioniDS.SPMOVIMENTIRow movimento = ds.SPMOVIMENTI.NewSPMOVIMENTIRow();
                    movimento.CAUSALE = causale;
                    movimento.DATAMODIFICA = data;
                    movimento.IDSALDO = idsaldo;
                    movimento.QUANTITA = quantita;
                    movimento.TIPOMOVIMENTO = tipoOperazione;
                    movimento.UTENTEMODIFICA = utenza;
                    ds.SPMOVIMENTI.AddSPMOVIMENTIRow(movimento);

                    bSpedizioni.SalvaInserimento(ds);

                }
                catch (Exception ex)
                {
                    bSpedizioni.Rollback();
                    return "ERRORE IMPOSSIBILE PROCEDERE";
                }
            }

            return "COMPLETATA";
        }
        private string LeggiUtenza(string barcodeOperatore)
        {
            using (SpedizioniBusiness bSpedizioni = new SpedizioniBusiness())
            {
                bSpedizioni.GetUSR_PRD_RESOURCESF(ds, barcodeOperatore);
            }
            SpedizioniDS.USR_PRD_RESOURCESFRow risorsa = ds.USR_PRD_RESOURCESF.Where(x => x.BARCODE == barcodeOperatore).FirstOrDefault();
            if (risorsa == null) return null;
            return risorsa.CODRESOURCEF;
        }
        private SpedizioniDS.SPUBICAZIONIRow LeggiUbicazione(string barcodeUbicazione)
        {
            using (SpedizioniBusiness bSpedizioni = new SpedizioniBusiness())
            {
                bSpedizioni.FillSPUBICAZIONI(ds, true);
            }
            SpedizioniDS.SPUBICAZIONIRow ubicazione = ds.SPUBICAZIONI.Where(x => x.BARCODE == barcodeUbicazione).FirstOrDefault();
            return ubicazione;
        }

        private TrasferimentiDS.USR_PRD_MOVFASIRow LeggiODL(string barcodeODL)
        {
            TrasferimentiDS _ds = new TrasferimentiDS();
            using (TrasferimentiBusiness bTrasferimenti = new TrasferimentiBusiness())
            {
                if (!_ds.USR_PRD_MOVFASI.Any(x => x.BARCODE == barcodeODL))
                    bTrasferimenti.FillUSR_PRD_MOVFASI(_ds, barcodeODL);

                return _ds.USR_PRD_MOVFASI.Where(x => x.BARCODE == barcodeODL).FirstOrDefault();
            }
        }

        public string LeggiBarcode(string barcode)
        {
            string tipo = barcode.Substring(0, 3);
            if (tipo == BarcodeHelper.TipoUbicazione)
            {
                SpedizioniDS.SPUBICAZIONIRow ubicazione = LeggiUbicazione(barcode);
                if (ubicazione == null)
                    return "Ubicazione sconosciuta";

                return string.Format("{0} - {1}", ubicazione.CODICE, ubicazione.DESCRIZIONE);
            }

            if (tipo == BarcodeHelper.RisorsaFisica)
            {
                string utenza = LeggiUtenza(barcode);
                if (string.IsNullOrEmpty(utenza))
                    return "Ubicazione sconosciuta";

                return utenza;
            }

            TrasferimentiDS.USR_PRD_MOVFASIRow odl = LeggiODL(barcode);
            if (odl == null)
                return "BARCODE NON TROVATO";

            Anagrafica _anagrafica = new Anagrafica();
            AnagraficaDS.MAGAZZRow articolo = _anagrafica.GetMAGAZZ(odl.IDMAGAZZ);

            return string.Format("{0} - {1}", odl.QTA, articolo.MODELLO);

        }

        public void FillUbicazioni(SpedizioniDS ds, bool soloNonCancellati)
        {
            using (SpedizioniBusiness bSpedizioni = new SpedizioniBusiness())
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

        public SpedizioniDS.MAGAZZRow GetMagazz(SpedizioniDS ds, string modello)
        {
            SpedizioniDS.MAGAZZRow magazz = ds.MAGAZZ.Where(x => x.MODELLO == modello).FirstOrDefault();
            if (magazz == null)
            {
                using (SpedizioniBusiness bSpedizioni = new SpedizioniBusiness())
                {
                    bSpedizioni.GetMagazz(ds, modello);
                    magazz = ds.MAGAZZ.Where(x => x.MODELLO == modello).FirstOrDefault();
                }
            }
            return magazz;
        }

        public void FillSaldi(SpedizioniDS ds, String UBICAZIONE, String MODELLO)
        {
            using (SpedizioniBusiness bSpedizioni = new SpedizioniBusiness())
            {
                bSpedizioni.FillSPSALDI(ds, UBICAZIONE, MODELLO);
            }
        }

        public void SalvaSaldo(decimal IdUbicazione, string IdMagazz, decimal quantita, string utente)
        {
            using (SpedizioniBusiness bSpedizioni = new SpedizioniBusiness())
            {

                SpedizioniDS.SPSALDIRow saldo = ds.SPSALDI.NewSPSALDIRow();
                saldo.IDUBICAZIONE = IdUbicazione;
                saldo.IDMAGAZZ = IdMagazz;
                saldo.DATAMODIFICA = DateTime.Now;
                saldo.UTENTEMODIFICA = utente;
                saldo.QUANTITA = quantita;

                ds.SPSALDI.AddSPSALDIRow(saldo);

                bSpedizioni.SalvaSaldi(ds);
            }
        }


        public void CancellaUbicazione(decimal idUbicazione, string utente)
        {
            using (SpedizioniBusiness bSpedizioni = new SpedizioniBusiness())
            {
                bSpedizioni.FillSPUBICAZIONI(ds, false);

                SpedizioniDS.SPUBICAZIONIRow ubicazione = ds.SPUBICAZIONI.Where(x => x.IDUBICAZIONE == idUbicazione).FirstOrDefault();
                if (ubicazione == null)
                    return;

                ubicazione.CANCELLATO = "S";
                ubicazione.DATAMODIFICA = DateTime.Now;
                ubicazione.UTENTEMODIFICA = utente;

                bSpedizioni.SalvaUbicazioni(ds);
            }
        }

        public void FillMovimenti(SpedizioniDS ds, String UBICAZIONE, String MODELLO, DateTime dtInizo, DateTime dtFine)
        {
            using (SpedizioniBusiness bSpedizioni = new SpedizioniBusiness())
            {
                bSpedizioni.FillMovimenti(ds, UBICAZIONE, MODELLO, dtInizo, dtFine);
            }
        }

    }
}

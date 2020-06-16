using Applicazioni.Data.Valorizzazioni;
using Applicazioni.Entities;
using Applicazioni.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.BLL
{
    public class DiBa
    {
        private Anagrafica _anagrafica = new Anagrafica();
        private ValorizzazioneDS _ds = new ValorizzazioneDS();
        private List<String> _idTDIBA_PRODOTTOFINITO = new List<string>();

        public void FillTABFAS()
        {
            _anagrafica.FillTABFAS();
        }
        public void FillCLIFO()
        {
            _anagrafica.FillCLIFO();
        }

        public void FillMAGAZZ()
        {
            _anagrafica.FillMAGAZZ();
        }

        public void CaricaRDiba()
        {
            using (ValorizzazioniBusiness bValorizzazioni = new ValorizzazioniBusiness())
            {
                bValorizzazioni.FillUSR_PRD_RDIBA(_ds);
            }
        }

        public ValorizzazioneDS.USR_PRD_RDIBARow GetRDiba(string idRdiba)
        {
            if (!_ds.USR_PRD_RDIBA.Any(x => x.IDRDIBA == idRdiba))
            {
                using (ValorizzazioniBusiness bValorizzazione = new ValorizzazioniBusiness())
                {
                    bValorizzazione.FillUSR_PRD_RDIBA(_ds, new List<string>(new string[] { idRdiba }));
                }
            }
            return _ds.USR_PRD_RDIBA.Where(x => x.IDRDIBA == idRdiba).FirstOrDefault();
        }

        public ValorizzazioneDS.USR_PRD_RDIBARow GetTDiba(string idTdiba)
        {
            if (!_ds.USR_PRD_TDIBA.Any(x => x.IDTDIBA == idTdiba))
            {
                using (ValorizzazioniBusiness bValorizzazione = new ValorizzazioniBusiness())
                {
                    bValorizzazione.FillUSR_PRD_TDIBA(_ds, new List<string>(new string[] { idTdiba }));
                }
            }
            return _ds.USR_PRD_RDIBA.Where(x => x.IDTDIBA == idTdiba).FirstOrDefault();
        }

        public void FillUSR_LIS_ACQ()
        {
            using (ValorizzazioniBusiness bValorizzazioni = new ValorizzazioniBusiness())
            {
                bValorizzazioni.FillUSR_LIS_ACQ(_ds);
            }
        }

        public void FillUSR_LIS_VEN()
        {
            using (ValorizzazioniBusiness bValorizzazioni = new ValorizzazioniBusiness())
            {
                bValorizzazioni.FillUSR_LIS_VEN(_ds);
            }
        }

        public void FillUSR_LIS_FASE()
        {
            using (ValorizzazioniBusiness bValorizzazioni = new ValorizzazioniBusiness())
            {
                bValorizzazioni.FillUSR_LIS_FASE(_ds);
            }
        }
        public void FillUSR_INVENTARIOD(string idInventarioT)
        {
            using (ValorizzazioniBusiness bValorizzazioni = new ValorizzazioniBusiness())
            {
                bValorizzazioni.FillUSR_INVENTARIOD(_ds, idInventarioT);
            }
        }

        public void FillUSR_VENDITED(string anno)
        {
            using (ValorizzazioniBusiness bValorizzazioni = new ValorizzazioniBusiness())
            {
                bValorizzazioni.FillUSR_VENDITED(_ds, anno);
            }
        }
        public int CostiDaCalcolare(bool tuttiProdotti)
        {
            if (tuttiProdotti)
                return _ds.USR_LIS_VEN.Where(x => !x.IsIDMAGAZZNull()).Select(x => x.IDMAGAZZ).Distinct().Count();
            else
                return _ds.USR_INVENTARIOD.Select(x => x.IDMAGAZZ).Distinct().Count();
        }
        public void DeleteCostiArticoli(string idInventarioT)
        {
            using (ValorizzazioniBusiness bValorizzazioni = new ValorizzazioniBusiness())
            {
                bValorizzazioni.DeleteCostiArticoli(idInventarioT);
            }
        }
        public void DeleteCostiGalvanica()
        {
            using (ValorizzazioniBusiness bValorizzazioni = new ValorizzazioniBusiness())
            {
                bValorizzazioni.DeleteCostiGalvanica();
            }
        }
        public void CaricaTDiba()
        {
            using (ValorizzazioniBusiness bValorizzazioni = new ValorizzazioniBusiness())
            {
                bValorizzazioni.FillUSR_PRD_TDIBA(_ds);
            }
        }
        public void CaricaTDibaDefaut()
        {
            using (ValorizzazioniBusiness bValorizzazioni = new ValorizzazioniBusiness())
            {
                bValorizzazioni.FillUSR_PRD_TDIBA_DEFAULT(_ds);
            }
        }
        public void CaricaTDibaDefaults()
        {
            using (ValorizzazioniBusiness bValorizzazioni = new ValorizzazioniBusiness())
            {
                bValorizzazioni.FillUSR_PRD_TDIBA_DEFAULTS(_ds);
            }
        }

        public int PreparazioneElaborazione()
        {
            List<String> idtdiba = _ds.USR_PRD_TDIBA.Where(x => x.ACTIVESN == "S").Select(x => x.IDTDIBA).Distinct().ToList();
            //idtdiba.Clear();
            //idtdiba.Add("0000058087");

            List<String> riferimento = _ds.USR_PRD_RDIBA.Where(x => !x.IsIDTDIBAIFFASENull()).Select(x => x.IDTDIBAIFFASE).Distinct().ToList();
            List<String> idtdibaDefault = _ds.USR_PRD_TDIBA_DEFAULTS.Select(x => x.IDTDIBA).Distinct().ToList();



            _idTDIBA_PRODOTTOFINITO = idtdiba.Where(x => !riferimento.Contains(x)).ToList();
            _idTDIBA_PRODOTTOFINITO = _idTDIBA_PRODOTTOFINITO.Where(x => idtdibaDefault.Contains(x)).ToList();

            return _idTDIBA_PRODOTTOFINITO.Count();
        }

        public void ElaboraDiba(string idInventarioT, BackgroundWorker worker, DoWorkEventArgs e)
        {
            int i = 1;
            int count = _idTDIBA_PRODOTTOFINITO.Count;
            foreach (ValorizzazioneDS.USR_PRD_TDIBARow tdiba in _ds.USR_PRD_TDIBA.Where(x => _idTDIBA_PRODOTTOFINITO.Contains(x.IDTDIBA)))
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                int livello = 0;
                worker.ReportProgress(i);
                string prodottoFinito = tdiba.IDMAGAZZ;
                //                if (prodottoFinito != "0000044581") continue;
                int ramo = 1;
                EstraiDiba(idInventarioT, _ds, tdiba, livello, prodottoFinito, 1, ref ramo);

                string articolo = tdiba.IDMAGAZZ;
                decimal qta = 1;

                ValorizzazioneDS.COSTI_ARTICOLIRow costiArticoloRow = _ds.COSTI_ARTICOLI.NewCOSTI_ARTICOLIRow();
                costiArticoloRow.IDMAGAZZ = articolo;
                if (!tdiba.IsIDTABFASNull())
                    costiArticoloRow.IDFASE = tdiba.IDTABFAS;
                costiArticoloRow.QTA = qta;

                costiArticoloRow.IDTDIBA = tdiba.IDTDIBA;
                costiArticoloRow.IDINVENTARIOT = idInventarioT;
                _ds.COSTI_ARTICOLI.AddCOSTI_ARTICOLIRow(costiArticoloRow);

                i++;

            }
        }

        public void SalvaCostiArticolo()
        {
            using (ValorizzazioniBusiness bValorizzazioni = new ValorizzazioniBusiness())
            {
                bValorizzazioni.UpdateTable(_ds.COSTI_ARTICOLI.TableName, _ds);
            }
        }

        public void SalvaCostiGalvanica()
        {
            using (ValorizzazioniBusiness bValorizzazioni = new ValorizzazioniBusiness())
            {
                bValorizzazioni.UpdateTable(_ds.COSTI_GALVANICA.TableName, _ds);
            }
        }
        public void CalcolaCostiArticolo(string IdInventarioT, DateTime DataFine, BackgroundWorker worker, DoWorkEventArgs e, bool consideraTutteLeFasi, bool consideraListiniVenditaTopFinish, bool usaDiBaNonDefault, bool tuttiProdottiFiniti)
        {
            List<string> idmagazz = new List<string>();
            int i = 1;
            if (tuttiProdottiFiniti)
                //                idmagazz = _ds.USR_LIS_VEN.Where(x => !x.IsIDMAGAZZNull()).Select(x => x.IDMAGAZZ).Distinct().ToList();
                idmagazz = _ds.USR_VENDITED.Where(x => !x.IsIDMAGAZZNull()).Select(x => x.IDMAGAZZ).Distinct().ToList();
            else
                idmagazz = _ds.USR_INVENTARIOD.Select(x => x.IDMAGAZZ).Distinct().ToList();
            //    bool m = idmagazz.Contains("0000096837");
            // idmagazz = new List<string>(new string[] { "0000085010" });


            foreach (string articolo in idmagazz)
            {

                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                worker.ReportProgress(i);
                ValorizzazioneDS.USR_PRD_TDIBA_DEFAULTRow tdibaArticolo = _ds.USR_PRD_TDIBA_DEFAULT.Where(x => x.IDMAGAZZ == articolo).FirstOrDefault();
                ValorizzazioneDS.USR_PRD_TDIBARow tdibaArticoloNonDefault = _ds.USR_PRD_TDIBA.Where(x => x.IDMAGAZZ == articolo).FirstOrDefault();
                if (tdibaArticolo != null)
                {
                    CalcolaCosto(tdibaArticolo.IDTDIBA, articolo, IdInventarioT, DataFine, consideraTutteLeFasi, consideraListiniVenditaTopFinish, "DiBa default", articolo);
                }
                else if (usaDiBaNonDefault && tdibaArticoloNonDefault != null)
                {
                    CalcolaCosto(tdibaArticoloNonDefault.IDTDIBA, articolo, IdInventarioT, DataFine, consideraTutteLeFasi, consideraListiniVenditaTopFinish, "DiBa non default", articolo);
                }
                else
                    CalcolaCosto(string.Empty, articolo, IdInventarioT, DataFine, consideraTutteLeFasi, consideraListiniVenditaTopFinish, string.Empty, articolo);
                //                RegistraCostoArticolo(0, 0, 0, tdibaArticolo, inventarioT.IdInventarioT, articolo, "TDIBA non definita", string.Empty);
                i++;
            }

        }

        public void CalcolaCostiGalvanica(DateTime DataFine, BackgroundWorker worker, DoWorkEventArgs e)
        {
            List<string> idmagazz = new List<string>();
            int i = 1;
            //            idmagazz = _ds.USR_VENDITED.Where(x => !x.IsIDMAGAZZNull()).Select(x => x.IDMAGAZZ).Distinct().ToList();
            idmagazz = _ds.USR_INVENTARIOD.Select(x => x.IDMAGAZZ).Distinct().ToList();
            //    bool m = idmagazz.Contains("0000096837");
    //        idmagazz = new List<string>(new string[] { "0000046402" });

            foreach (string articolo in idmagazz)
            {

                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                worker.ReportProgress(i);
                ValorizzazioneDS.USR_PRD_TDIBA_DEFAULTRow tdibaArticolo = _ds.USR_PRD_TDIBA_DEFAULT.Where(x => x.IDMAGAZZ == articolo).FirstOrDefault();
                ValorizzazioneDS.USR_PRD_TDIBARow tdibaArticoloNonDefault = _ds.USR_PRD_TDIBA.Where(x => x.IDMAGAZZ == articolo).FirstOrDefault();
                if (tdibaArticolo != null)
                {
                    CalcolaCostoGalvanica(tdibaArticolo.IDTDIBA, articolo, DataFine, "DiBa default", articolo);
                }
                else if (tdibaArticoloNonDefault != null)
                {
                    CalcolaCostoGalvanica(tdibaArticoloNonDefault.IDTDIBA, articolo, DataFine, "DiBa non default", articolo);
                }
                else
                    CalcolaCostoGalvanica(string.Empty, articolo, DataFine, string.Empty, articolo);
                i++;
            }

        }

        private decimal CalcolaCosto(string idtdiba, string idmagazz, string IdInventarioT, DateTime DataFine, bool consideraTutteLeFasi, bool consideraListiniVenditaTopFinish, string notaEsterna, string idProdottoFinito)
        {

            ValorizzazioneDS.COSTI_ARTICOLIRow costoArticolo = _ds.COSTI_ARTICOLI.Where(x => x.IDINVENTARIOT == IdInventarioT && x.IDMAGAZZ == idmagazz).FirstOrDefault();
            if (costoArticolo != null)
                return costoArticolo.COSTOFASE + costoArticolo.COSTOFIGLI + costoArticolo.COSTOMATERIALE;

            StringBuilder nota = new StringBuilder();
            nota.Append(notaEsterna);

            ValorizzazioneDS.USR_PRD_TDIBARow tdibaArticolo = _ds.USR_PRD_TDIBA.Where(x => x.IDTDIBA == idtdiba).FirstOrDefault();
            if (tdibaArticolo == null)
                nota.AppendLine("Diba non definita");

            decimal costoFigli = 0;
            decimal costoMateriale = 0;
            decimal costoFase = 0;
            //            decimal costoListino = 0;

            Articolo articolo = _anagrafica.GetArticolo(idmagazz);
            if (articolo == null)
            {
                nota.AppendLine("Articolo non trovato " + idmagazz);
                return 0;
            }
            string idListino = string.Empty;
            costoFase = CalcolaCostoListinoArticolo(articolo, IdInventarioT, DataFine, tdibaArticolo, out idListino);

            if (tdibaArticolo == null)
            {
                RegistraCostoArticolo(costoFase, costoFigli, costoMateriale, tdibaArticolo, IdInventarioT, idmagazz, nota.ToString(), idListino, idProdottoFinito);
                return costoFase;
            }

            if (costoFase == 0 && string.IsNullOrEmpty(idListino) && (_anagrafica.FaseDaCostificare(tdibaArticolo.IDTABFAS) || consideraTutteLeFasi))
                costoFase = EstraiCostoFase(tdibaArticolo.IDTABFAS, DataFine, articolo.Peso);

            foreach (ValorizzazioneDS.USR_PRD_RDIBARow rdiba in _ds.USR_PRD_RDIBA.Where(x => x.IDTDIBA == tdibaArticolo.IDTDIBA).OrderBy(x => x.SEQUENZA))
            {
                decimal costoFiglio = 0;
                if (!rdiba.IsIDTDIBAIFFASENull())
                    costoFiglio = CalcolaCosto(rdiba.IDTDIBAIFFASE, rdiba.IDMAGAZZ, IdInventarioT, DataFine, consideraTutteLeFasi, consideraListiniVenditaTopFinish, string.Empty, idProdottoFinito);
                else
                {
                    ValorizzazioneDS.COSTI_ARTICOLIRow costoArticoloMateriale = _ds.COSTI_ARTICOLI.Where(x => x.IDINVENTARIOT == IdInventarioT && x.IDMAGAZZ == rdiba.IDMAGAZZ).FirstOrDefault();
                    if (costoArticoloMateriale != null)
                        costoFiglio = costoArticoloMateriale.COSTOFASE + costoArticoloMateriale.COSTOFIGLI + costoArticoloMateriale.COSTOMATERIALE;
                    else
                    {
                        List<ValorizzazioneDS.USR_LIS_ACQRow> listiniMateriale = _ds.USR_LIS_ACQ.Where(x => !x.IsIDMAGAZZNull() && x.IDMAGAZZ == rdiba.IDMAGAZZ
                            && x.VALIDITA <= DataFine
                            //  && x.FINEVALIDITA >= InventarioT.DataInizio
                            && x.FINEVALIDITA >= DataFine
                            && x.AZIENDA == "MP").ToList();
                        if (listiniMateriale.Count > 0)
                        {
                            string idListinoMateriale;
                            costoFiglio = ValutaCostoListino(articolo.Peso, listiniMateriale, out idListinoMateriale);
                            RegistraCostoArticolo(costoFiglio, 0, 0, null, IdInventarioT, rdiba.IDMAGAZZ, string.Empty, idListinoMateriale, idProdottoFinito);
                            //return costoListino;
                        }
                    }

                }
                costoFigli = costoFigli + costoFiglio * rdiba.QTACONSUMO;
            }

            RegistraCostoArticolo(costoFase, costoFigli, costoMateriale, tdibaArticolo, IdInventarioT, idmagazz, nota.ToString(), idListino, idProdottoFinito);
            return costoFase + costoFigli + costoMateriale;
        }

        private decimal CalcolaCostoGalvanica(string idtdiba, string idmagazz, DateTime DataFine, string notaEsterna, string idProdottoFinito)
        {
            //if (idmagazz == "0000131250")
            //    System.Diagnostics.Debugger.Break();
            ValorizzazioneDS.COSTI_GALVANICARow costoGalvanica = _ds.COSTI_GALVANICA.Where(x => x.IDMAGAZZ == idmagazz).FirstOrDefault();
            if (costoGalvanica != null)
                return costoGalvanica.COSTOMATERIALE;

            ValorizzazioneDS.USR_PRD_TDIBARow tdibaArticolo = _ds.USR_PRD_TDIBA.Where(x => x.IDTDIBA == idtdiba).FirstOrDefault();

            decimal costoMateriale = 0;

            string idListino = string.Empty;

            List<ValorizzazioneDS.USR_LIS_VENRow> listini = _ds.USR_LIS_VEN.Where(x => !x.IsIDMAGAZZNull() && x.IDMAGAZZ == idmagazz
              && x.VALIDITA <= DataFine
              && x.FINEVALIDITA >= DataFine
              && !x.IsCODICECLIFONull()
              && x.CODICECLIFO.Trim() == "01631"
              && x.AZIENDA == "TF").ToList();

            if (listini.Count > 0)
            {
                costoMateriale = ValutaCostoListino(0, listini, out idListino);
            }else
            {
                List<ValorizzazioneDS.USR_LIS_ACQRow> listiniA = _ds.USR_LIS_ACQ.Where(x => !x.IsIDMAGAZZNull() && x.IDMAGAZZ == idmagazz
                  && x.VALIDITA <= DataFine
                  && x.FINEVALIDITA >= DataFine
                  && !x.IsCODICECLIFONull()
                  && x.CODICECLIFO.Trim() == "02350"
                  && x.AZIENDA == "MP").ToList();

                if (listiniA.Count > 0)
                {
                    costoMateriale = ValutaCostoListino(0, listiniA, out idListino);
                }
            }


            if (tdibaArticolo == null)
            {
                RegistraCostoGalvanica(costoMateriale, idmagazz, idListino);
                return costoMateriale;
            }
            decimal costoFigli = 0;
            foreach (ValorizzazioneDS.USR_PRD_RDIBARow rdiba in _ds.USR_PRD_RDIBA.Where(x => x.IDTDIBA == tdibaArticolo.IDTDIBA).OrderBy(x => x.SEQUENZA))
            {
                decimal costoFiglio = 0;
                if (!rdiba.IsIDTDIBAIFFASENull())
                    costoFiglio = CalcolaCostoGalvanica(rdiba.IDTDIBAIFFASE, rdiba.IDMAGAZZ, DataFine, string.Empty, idProdottoFinito);
                else
                {
                    ValorizzazioneDS.COSTI_GALVANICARow costoGalvanicaFiglio = _ds.COSTI_GALVANICA.Where(x => x.IDMAGAZZ == rdiba.IDMAGAZZ).FirstOrDefault();
                    if (costoGalvanicaFiglio != null)
                        costoFiglio = costoGalvanicaFiglio.COSTOMATERIALE;

                }
                costoFigli = costoFigli + costoFiglio * rdiba.QTACONSUMO;
            }

            RegistraCostoGalvanica(costoMateriale + costoFigli, idmagazz, idListino);
            return costoMateriale + costoFigli;
        }

        private decimal CalcolaCostoListinoArticolo(Articolo articolo, string IdInventarioT, DateTime DataFine, ValorizzazioneDS.USR_PRD_TDIBARow tdibaArticolo, out string idListino)
        {
            idListino = string.Empty;
            List<ValorizzazioneDS.USR_LIS_ACQRow> listiniAquistiInterni = _ds.USR_LIS_ACQ.Where(x => !x.IsIDMAGAZZNull() && x.IDMAGAZZ == articolo.IdMagazz
                && x.VALIDITA <= DataFine
                //&& x.FINEVALIDITA >= InventarioT.DataInizio
                && x.FINEVALIDITA >= DataFine
                && !x.IsCODICECLIFONull()
                && x.CODICECLIFO.Substring(0, 1) != "0"
                && x.AZIENDA == "MP").ToList();

            if (tdibaArticolo != null && !tdibaArticolo.IsIDDIBAMETHODNull())
            {
                List<ValorizzazioneDS.USR_LIS_ACQRow> listiniAquistiInterniPerVersioneDiba = listiniAquistiInterni.Where(x => !x.IsIDDIBAMETHODNull() && x.IDDIBAMETHOD == tdibaArticolo.IDDIBAMETHOD).ToList();
                if (listiniAquistiInterniPerVersioneDiba.Count > 0)
                    return ValutaCostoListino(articolo.Peso, listiniAquistiInterniPerVersioneDiba, out idListino);
            }

            if (listiniAquistiInterni.Count > 0)
                return ValutaCostoListino(articolo.Peso, listiniAquistiInterni, out idListino);

            List<ValorizzazioneDS.USR_LIS_ACQRow> listiniAquistiEsterni = _ds.USR_LIS_ACQ.Where(x => !x.IsIDMAGAZZNull() && x.IDMAGAZZ == articolo.IdMagazz
                && x.VALIDITA <= DataFine
                //&& x.FINEVALIDITA >= InventarioT.DataInizio
                && x.FINEVALIDITA >= DataFine
                && x.AZIENDA == "MP").ToList();

            if (tdibaArticolo != null && !tdibaArticolo.IsIDDIBAMETHODNull())
            {
                List<ValorizzazioneDS.USR_LIS_ACQRow> listiniAquistiEsterniPerVersioneDiba = listiniAquistiEsterni.Where(x => !x.IsIDDIBAMETHODNull() && x.IDDIBAMETHOD == tdibaArticolo.IDDIBAMETHOD).ToList();
                if (listiniAquistiEsterniPerVersioneDiba.Count > 0)
                    return ValutaCostoListino(articolo.Peso, listiniAquistiEsterniPerVersioneDiba, out idListino);
            }

            if (listiniAquistiEsterni.Count > 0)
                return ValutaCostoListino(articolo.Peso, listiniAquistiEsterni, out idListino);


            List<ValorizzazioneDS.USR_LIS_VENRow> listiniVendita = _ds.USR_LIS_VEN.Where(x => !x.IsIDMAGAZZNull() && x.IDMAGAZZ == articolo.IdMagazz
                   && x.VALIDITA <= DataFine
                   && x.FINEVALIDITA >= DataFine
                   //                    && x.FINEVALIDITA >= InventarioT.DataInizio
                   && x.AZIENDA == "TF").ToList();

            if (listiniVendita.Count > 0)
                return ValutaCostoListino(articolo.Peso, listiniVendita, out idListino);

            return 0;
        }

        private decimal EstraiCostoFase(string idtabfas, DateTime dataFine, decimal pesoInGrammi)
        {
            string idListino = string.Empty;

            List<ValorizzazioneDS.USR_LIS_FASERow> listiniFaseInterno = _ds.USR_LIS_FASE.Where(x => !x.IsIDTABFASNull()
                && x.IDTABFAS == idtabfas
                && x.VALIDITA <= dataFine
                && x.FINEVALIDITA >= dataFine
                ).ToList();

            if (listiniFaseInterno.Count > 0)
            {
                return ValutaCostoListino(pesoInGrammi, listiniFaseInterno, out idListino);
            }


            List<ValorizzazioneDS.USR_LIS_ACQRow> listiniFase = _ds.USR_LIS_ACQ.Where(x => x.IsIDMAGAZZNull()
                && !x.IsIDTABFASNull()
                && x.IDTABFAS == idtabfas
                && x.VALIDITA <= dataFine
                //                && x.FINEVALIDITA >= dataInizio
                && x.FINEVALIDITA >= dataFine
                //                && x.CODICECLIFO.Substring(0, 1) != "0"
                ).ToList();
            return ValutaCostoListino(pesoInGrammi, listiniFase, out idListino);
        }

        private decimal ValutaCostoListino(decimal pesoInGrammi, List<ValorizzazioneDS.USR_LIS_ACQRow> listini, out string idListino)
        {
            idListino = string.Empty;
            decimal costoListino = 0;
            DateTime dataInizioValidità = new DateTime(1980, 1, 1);

            if (listini.Count > 0)
            {
                costoListino = listini[0].COSTOUNI;
                dataInizioValidità = listini[0].VALIDITA;
            }
            foreach (ValorizzazioneDS.USR_LIS_ACQRow listino in listini)
            {
                switch (listino.IDTABUNIMI)
                {
                    default:
                    case "0000000011":  //numero
                                        //      if (costoListino > listino.COSTOUNI)
                        if (dataInizioValidità < listino.VALIDITA)
                        {
                            costoListino = listino.COSTOUNI;
                            idListino = listino.IDLISACQ;
                        }
                        break;
                        //case "0000000004":  //kg
                        //    {
                        //        decimal aux = pesoInGrammi * (listino.COSTOUNI) / 1000;
                        //        if (costoListino < aux)
                        //        {
                        //            costoListino = aux;
                        //            idListino = listino.IDLISACQ;
                        //        }
                        //    }
                        //    break;
                        //case "0000000012":  //gr
                        //    {
                        //        decimal aux = pesoInGrammi * listino.COSTOUNI;
                        //        if (costoListino < aux)
                        //        {
                        //            costoListino = aux;
                        //            idListino = listino.IDLISACQ;
                        //        }
                        //    }
                        //    break;
                }
            }
            return costoListino;
        }

        private decimal ValutaCostoListino(decimal pesoInGrammi, List<ValorizzazioneDS.USR_LIS_FASERow> listini, out string idListino)
        {
            idListino = string.Empty;
            decimal costoListino = 0;
            DateTime dataInizioValidità = new DateTime(1980, 1, 1);

            if (listini.Count > 0)
            {
                costoListino = listini[0].COSTOUNI;
                dataInizioValidità = listini[0].VALIDITA;
            }
            foreach (ValorizzazioneDS.USR_LIS_FASERow listino in listini)
            {
                if (dataInizioValidità < listino.VALIDITA)
                {
                    costoListino = listino.COSTOUNI;
                    idListino = listino.IDLISFASE.ToString();
                }
            }

            return costoListino;
        }
        private decimal ValutaCostoListino(decimal pesoInGrammi, List<ValorizzazioneDS.USR_LIS_VENRow> listini, out string idListino)
        {
            idListino = string.Empty;
            decimal costoListino = 0;
            if (listini.Count > 0)
                costoListino = listini[0].PREZZOUNI;
            foreach (ValorizzazioneDS.USR_LIS_VENRow listino in listini)
            {
                switch (listino.IDTABUNIMI)
                {
                    case "0000000011":  //numero
                        if (costoListino > listino.PREZZOUNI)
                        {
                            costoListino = listino.PREZZOUNI;
                            idListino = listino.IDLISVEN;
                        }
                        break;
                    case "0000000004":  //kg
                        {
                            decimal aux = pesoInGrammi * (listino.PREZZOUNI) / 1000;
                            if (costoListino < aux)
                            {
                                costoListino = aux;
                                idListino = listino.IDLISVEN;
                            }
                        }
                        break;
                    case "0000000012":  //gr
                        {
                            decimal aux = pesoInGrammi * listino.PREZZOUNI;
                            if (costoListino < aux)
                            {
                                costoListino = aux;
                                idListino = listino.IDLISVEN;
                            }
                        }
                        break;
                }
            }
            return costoListino;
        }
        private void RegistraCostoArticolo(decimal costoFase, decimal costoFigli, decimal costoMateriale, ValorizzazioneDS.USR_PRD_TDIBARow tdibaArticolo,
            string idInventarioT, string idmagazz, String nota, string idListino, string idProdottoFinito)
        {
            ValorizzazioneDS.COSTI_ARTICOLIRow costoArticolo = _ds.COSTI_ARTICOLI.NewCOSTI_ARTICOLIRow();
            costoArticolo.COSTOFASE = costoFase;
            if (tdibaArticolo != null)
            {
                costoArticolo.IDTDIBA = tdibaArticolo.IDTDIBA;
                costoArticolo.IDFASE = tdibaArticolo.IDTABFAS;
            }
            costoArticolo.IDRDIBA = null;
            costoArticolo.COSTOFIGLI = costoFigli;
            costoArticolo.COSTOMATERIALE = 0;
            costoArticolo.IDINVENTARIOT = idInventarioT;
            costoArticolo.IDMAGAZZ = idmagazz;
            costoArticolo.IDLISACQ = idListino;
            costoArticolo.NOTA = nota.Length > 120 ? nota.Substring(0, 120) : nota;
            costoArticolo.IDPADRE = idProdottoFinito;
            _ds.COSTI_ARTICOLI.AddCOSTI_ARTICOLIRow(costoArticolo);
        }

        private void RegistraCostoGalvanica(decimal costoMateriale, string idmagazz, string idListino)
        {
            ValorizzazioneDS.COSTI_GALVANICARow costoGalvanca = _ds.COSTI_GALVANICA.NewCOSTI_GALVANICARow();
            costoGalvanca.COSTOMATERIALE = costoMateriale;
            costoGalvanca.IDMAGAZZ = idmagazz;
            costoGalvanca.IDLISACQ = idListino;
            _ds.COSTI_GALVANICA.AddCOSTI_GALVANICARow(costoGalvanca);
        }
        public void CaricaCostiArticoli(string idInventarioT)
        {
            using (ValorizzazioniBusiness bValorizzazioni = new ValorizzazioniBusiness())
            {
                bValorizzazioni.FillCOSTI_ARTICOLI(_ds, idInventarioT);
            }
        }

        private static void EstraiDiba(string idInventarioT, ValorizzazioneDS ds, ValorizzazioneDS.USR_PRD_TDIBARow tdiba, int sequenza, string prodottoFinito, decimal qtaPadre, ref int ramo)
        {
            bool multipla = ds.USR_PRD_RDIBA.Where(x => x.IDTDIBA == tdiba.IDTDIBA).Count() > 1;
            bool infragruppo = false;

            // INFRAGRUPPO AL MOMENTO NON CONSIDERATA
            //if (!tdiba.IsCODICECLIFOPRDNull() && tdiba.CODICECLIFOPRD.Trim() == "02350")
            //{
            //    AnagraficaDS.USR_PRD_TDIBARow tdibaInfragruppo = ds.USR_PRD_TDIBA.Where(x => x.IDMAGAZZ == tdiba.IDMAGAZZ && x.AZIENDA != tdiba.AZIENDA).FirstOrDefault();
            //    if (tdibaInfragruppo != null)
            //    {
            //        EstraiDiba(ds, tdibaInfragruppo, sequenza, prodottoFinito, qtaPadre, ref ramo);
            //        infragruppo = true;
            //        //                        ramo++;
            //    }
            //}

            foreach (ValorizzazioneDS.USR_PRD_RDIBARow rdiba in ds.USR_PRD_RDIBA.Where(x => x.IDTDIBA == tdiba.IDTDIBA).OrderBy(x => x.SEQUENZA))
            {

                sequenza++;
                string padre = tdiba.IDMAGAZZ;
                string articolo = rdiba.IDMAGAZZ;
                decimal qta = rdiba.QTACONSUMO;

                ValorizzazioneDS.COSTI_ARTICOLIRow costiArticoloRow = ds.COSTI_ARTICOLI.NewCOSTI_ARTICOLIRow();
                costiArticoloRow.IDMAGAZZ = articolo;
                if (!tdiba.IsIDTABFASNull())
                    costiArticoloRow.IDFASE = tdiba.IDTABFAS;
                costiArticoloRow.IDPADRE = padre;
                costiArticoloRow.QTA = qta;
                qtaPadre = qta * qtaPadre;

                costiArticoloRow.IDRDIBA = rdiba.IDRDIBA;
                costiArticoloRow.IDTDIBA = rdiba.IDTDIBA;
                costiArticoloRow.IDINVENTARIOT = idInventarioT;

                if (infragruppo)
                {
                    infragruppo = false;
                }
                else
                {
                    ds.COSTI_ARTICOLI.AddCOSTI_ARTICOLIRow(costiArticoloRow);
                }

                if (multipla) ramo++;

                if (!rdiba.IsIDTDIBAIFFASENull() && rdiba.STOCKSN == "N")
                {
                    ValorizzazioneDS.USR_PRD_TDIBARow tdibaPrecedente = ds.USR_PRD_TDIBA.Where(x => x.IDTDIBA == rdiba.IDTDIBAIFFASE).FirstOrDefault();
                    if (tdibaPrecedente == null)
                        continue;

                    EstraiDiba(idInventarioT, ds, tdibaPrecedente, sequenza, prodottoFinito, qtaPadre, ref ramo);
                }

            }


        }


    }
}

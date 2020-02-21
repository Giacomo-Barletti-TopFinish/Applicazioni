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
        public void FillUSR_INVENTARIOD(string idInventarioT)
        {
            using (ValorizzazioniBusiness bValorizzazioni = new ValorizzazioniBusiness())
            {
                bValorizzazioni.FillUSR_INVENTARIOD(_ds, idInventarioT);
            }
        }

        public int CostiDaCalcolare
        {
            get
            {
                return _ds.USR_INVENTARIOD.Select(x => x.IDMAGAZZ).Distinct().Count();
            }
        }
        public void DeleteCostiArticoli(string idInventarioT)
        {
            using (ValorizzazioniBusiness bValorizzazioni = new ValorizzazioniBusiness())
            {
                bValorizzazioni.DeleteCostiArticoli(idInventarioT);
            }
        }
        public void CaricaTDiba()
        {
            using (ValorizzazioniBusiness bValorizzazioni = new ValorizzazioniBusiness())
            {
                bValorizzazioni.FillUSR_PRD_TDIBA(_ds);
            }
        }
        public void CaricaTDibaDefault()
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
                //                    if (prodottoFinito != "0000010963") continue;
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

        public void CalcolaCostiArticolo(Testata inventarioT, BackgroundWorker worker, DoWorkEventArgs e, bool consideraTutteLeFasi, bool consideraListiniVenditaTopFinish)
        {
            List<string> idmagazz = _ds.USR_INVENTARIOD.Select(x => x.IDMAGAZZ).Distinct().ToList();
            int i = 1;
            foreach (string articolo in idmagazz)
            {

                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                worker.ReportProgress(i);

                CalcolaCosto(articolo, inventarioT, consideraTutteLeFasi, consideraListiniVenditaTopFinish);
                i++;
            }

        }

        private decimal CalcolaCosto(string idmagazz, Testata InventarioT, bool consideraTutteLeFasi, bool consideraListiniVenditaTopFinish)
        {
            StringBuilder nota = new StringBuilder();

            ValorizzazioneDS.COSTI_ARTICOLIRow costoArticolo = _ds.COSTI_ARTICOLI.Where(x => x.IDINVENTARIOT == InventarioT.IdInventarioT && x.IDMAGAZZ == idmagazz).FirstOrDefault();
            if (costoArticolo != null)
                return costoArticolo.COSTOFASE + costoArticolo.COSTOFIGLI + costoArticolo.COSTOMATERIALE;

            decimal costoFigli = 0;
            decimal costoMateriale = 0;
            decimal costoFase = 0;
            //            decimal costoListino = 0;

            ValorizzazioneDS.USR_PRD_TDIBARow tdibaArticolo = null;
            List<ValorizzazioneDS.USR_PRD_TDIBARow> tdibaArticoli = _ds.USR_PRD_TDIBA.Where(x => x.IDMAGAZZ == idmagazz).ToList();
            Articolo articolo = _anagrafica.GetArticolo(idmagazz);

            if (tdibaArticoli.Count == 0) nota.AppendLine("Diba non definita");

            if (tdibaArticoli.Count == 1)
                tdibaArticolo = tdibaArticoli[0];

            if (tdibaArticoli.Count > 1)
            {
                tdibaArticolo = tdibaArticoli.Where(x => x.ACTIVESN == "S").FirstOrDefault();
                if (tdibaArticolo == null)
                    tdibaArticolo = tdibaArticoli[0];
            }
            string idListino = string.Empty;
            List<ValorizzazioneDS.USR_LIS_ACQRow> listini = _ds.USR_LIS_ACQ.Where(x => !x.IsIDMAGAZZNull() && x.IDMAGAZZ == idmagazz
                && x.VALIDITA <= InventarioT.DataFine
                && x.FINEVALIDITA >= InventarioT.DataInizio
                && x.AZIENDA == "MP").OrderBy(x => x.COSTOUNI).ToList();
            if (listini.Count > 0)
            {

                costoFase = ValutaCostoListino(articolo.Peso, listini, out idListino);

                //RegistraCostoArticolo(costoListino, 0, 0, tdibaArticolo, InventarioT.IdInventarioT, idmagazz, nota.ToString(), idListino);
                //return costoListino;
            }
            else
            {
                List<ValorizzazioneDS.USR_LIS_VENRow> listiniVendita = _ds.USR_LIS_VEN.Where(x => !x.IsIDMAGAZZNull() && x.IDMAGAZZ == idmagazz
                    && x.VALIDITA <= InventarioT.DataFine
                    && x.FINEVALIDITA >= InventarioT.DataInizio
                    && x.AZIENDA == "TF").OrderBy(x => x.PREZZOUNI).ToList();

                if (listiniVendita.Count > 0)
                {
                    costoFase = ValutaCostoListino(articolo.Peso, listiniVendita, out idListino);

                    //RegistraCostoArticolo(costoListino, 0, 0, tdibaArticolo, InventarioT.IdInventarioT, idmagazz, nota.ToString(), idListino);
                    //return costoListino;
                }
                else
                {
                    if (tdibaArticolo != null && (_anagrafica.FaseDaCostificare(tdibaArticolo.IDTABFAS) || consideraTutteLeFasi))
                    {
                        costoFase = EstraiCostoFase(tdibaArticolo.IDTABFAS, InventarioT.DataFine, InventarioT.DataInizio, articolo.Peso);
                    }
                }
            }

            if (tdibaArticolo == null)
            {
                RegistraCostoArticolo(costoFase, costoFigli, costoMateriale, tdibaArticolo, InventarioT.IdInventarioT, idmagazz, nota.ToString(), idListino);
                return costoFase;
            }

            foreach (ValorizzazioneDS.USR_PRD_RDIBARow rdiba in _ds.USR_PRD_RDIBA.Where(x => x.IDTDIBA == tdibaArticolo.IDTDIBA).OrderBy(x => x.SEQUENZA))
            {

                decimal costoFiglio = CalcolaCosto(rdiba.IDMAGAZZ, InventarioT, consideraTutteLeFasi, consideraListiniVenditaTopFinish);
                costoFigli = costoFigli + costoFiglio * rdiba.QTACONSUMO;
            }

            RegistraCostoArticolo(costoFase, costoFigli, costoMateriale, tdibaArticolo, InventarioT.IdInventarioT, idmagazz, nota.ToString(), idListino);
            return costoFase + costoFigli + costoMateriale;
        }

        private decimal EstraiCostoFase(string idtabfas, DateTime dataFine, DateTime dataInizio, decimal pesoInGrammi)
        {
            string idListino = string.Empty;
            List<ValorizzazioneDS.USR_LIS_ACQRow> listiniFase = _ds.USR_LIS_ACQ.Where(x => x.IsIDMAGAZZNull()
                && !x.IsIDTABFASNull()
                && x.IDTABFAS == idtabfas
                && x.VALIDITA <= dataFine
                && x.FINEVALIDITA >= dataInizio
                //                && x.CODICECLIFO.Substring(0, 1) != "0"
                ).OrderBy(x => x.COSTOUNI).ToList();
            return ValutaCostoListino(pesoInGrammi, listiniFase, out idListino);
        }

        private decimal ValutaCostoListino(decimal pesoInGrammi, List<ValorizzazioneDS.USR_LIS_ACQRow> listini, out string idListino)
        {
            idListino = string.Empty;
            decimal costoListino = 0;
            foreach (ValorizzazioneDS.USR_LIS_ACQRow listino in listini)
            {
                switch (listino.IDTABUNIMI)
                {
                    case "0000000011":  //numero
                        if (costoListino < listino.COSTOUNI)
                        {
                            costoListino = listino.COSTOUNI;
                            idListino = listino.IDLISACQ;
                        }
                        break;
                    case "0000000004":  //kg
                        {
                            decimal aux = pesoInGrammi * (listino.COSTOUNI) / 1000;
                            if (costoListino < aux)
                            {
                                costoListino = aux;
                                idListino = listino.IDLISACQ;
                            }
                        }
                        break;
                    case "0000000012":  //gr
                        {
                            decimal aux = pesoInGrammi * listino.COSTOUNI;
                            if (costoListino < aux)
                            {
                                costoListino = aux;
                                idListino = listino.IDLISACQ;
                            }
                        }
                        break;
                }
            }
            return costoListino;
        }

        private decimal ValutaCostoListino(decimal pesoInGrammi, List<ValorizzazioneDS.USR_LIS_VENRow> listini, out string idListino)
        {
            idListino = string.Empty;
            decimal costoListino = 0;
            foreach (ValorizzazioneDS.USR_LIS_VENRow listino in listini)
            {
                switch (listino.IDTABUNIMI)
                {
                    case "0000000011":  //numero
                        if (costoListino < listino.PREZZOUNI)
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
        private void RegistraCostoArticolo(decimal costoFase, decimal costoFigli, decimal costoMateriale, ValorizzazioneDS.USR_PRD_TDIBARow tdibaArticolo, string idInventarioT, string idmagazz, String nota, string idListino)
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
            _ds.COSTI_ARTICOLI.AddCOSTI_ARTICOLIRow(costoArticolo);
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

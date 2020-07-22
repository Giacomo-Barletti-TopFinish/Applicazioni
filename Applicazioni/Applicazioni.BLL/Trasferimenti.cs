using Applicazioni.Data.Trasferimenti;
using Applicazioni.Entities;
using Applicazioni.Helpers;
using Applicazioni.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Applicazioni.BLL
{
    public class Trasferimenti
    {
        private TrasferimentiDS _ds = new TrasferimentiDS();

        private void CreaTrasferimento(string barcode)
        {
            using (TrasferimentiBusiness bTrasferimenti = new TrasferimentiBusiness())
            {
                try
                {
                    TrasferimentiDS.AP_TTRASFERIMENTIRow trasferimento = _ds.AP_TTRASFERIMENTI.NewAP_TTRASFERIMENTIRow();
                    trasferimento.IDTRASFERIMENTO = bTrasferimenti.GetID();
                    trasferimento.BARCODE_PARTENZA = barcode;
                    trasferimento.DATA_PARTENZA = DateTime.Now;
                    trasferimento.ATTIVO = 1;
                    _ds.AP_TTRASFERIMENTI.AddAP_TTRASFERIMENTIRow(trasferimento);

                    foreach(TrasferimentiDS.USR_PRD_MOVFASIRow elemento in _ds.USR_PRD_MOVFASI)
                    {
                        TrasferimentiDS.AP_DTRASFERIMENTIRow destinazione = _ds.AP_DTRASFERIMENTI.NewAP_DTRASFERIMENTIRow();
                        destinazione.IDDTRASFERIMENTO = bTrasferimenti.GetID();
                        destinazione.IDTRASFERIMENTO = trasferimento.IDTRASFERIMENTO;
                        destinazione.BARCODE_ODL = elemento.IsBARCODENull() ? string.Empty : elemento.BARCODE;
                        destinazione.NUMMOVFASE = elemento.IsNUMMOVFASENull() ? string.Empty : elemento.NUMMOVFASE;

                        destinazione.REPARTO = elemento.IsCODICECLIFONull() ? "N/D" : elemento.CODICECLIFO; // tbd reparto

                        destinazione.MODELLO = elemento.IDMAGAZZ; // tbd modello
                        destinazione.QTA = elemento.QTALAV;
                        destinazione.COLLI = 1;
                        _ds.AP_DTRASFERIMENTI.AddAP_DTRASFERIMENTIRow(destinazione);
                    }
                    bTrasferimenti.SalvaTrasferimenti(_ds);
                }
                catch { bTrasferimenti.Rollback(); throw; }


            }
        }

        private bool VerificaEsistenzaTrasferimento(string barcode)
        {
            using (TrasferimentiBusiness bTrasferimenti = new TrasferimentiBusiness())
            {
                bTrasferimenti.FillAP_TTRASFERIMENTIDaBarcodePartenza(_ds, barcode);
                return !_ds.AP_TTRASFERIMENTI.Any(x => x.BARCODE_PARTENZA == barcode && x.IsBARCODE_ARRIVONull());
            }
        }


        public string SalvaTrasferimento(string barcode, string odlJSON)
        {
            string[] odls = JSonSerializer.Deserialize<string[]>(odlJSON);
            if (barcode.Substring(0, 3) != "RSF")
            {
                return "NON RISORSA FISICA";
            }


            if (!VerificaEsistenzaTrasferimento(barcode))
            {
                return "ESISTE GIA' UN TRASFERIMENTO ATTIVO PER QUESTO OPERATORE";
            }
            else
            {
                foreach (string odl in odls)
                    CaricaODL(odl, 1);
                CreaTrasferimento(barcode);
                return "OK";
            }


        }
        public BarcodeModel Elabora(string barcode)
        {
            try
            {
                string tipoBarcode = barcode.Substring(0, 3);
                switch (tipoBarcode)
                {
                    case "RSF":
                        return null;
                        break;
                    case "ODP":
                    case "ODL":
                    case "ODU":
                    case "RRF":
                    case "ODM":
                    case "ODS":
                        return CaricaODL(barcode, 1);
                        break;
                    case "DRT":
                        //                        CaricaTrasferimento(barcode, 1);
                        return null;
                        break;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private BarcodeModel CaricaODL(string barcode, decimal colli)
        {

            if (string.IsNullOrEmpty(barcode)) return null;

            using (TrasferimentiBusiness bTrasferimenti = new TrasferimentiBusiness())
            {
                if (!_ds.USR_PRD_MOVFASI.Any(x => x.BARCODE == barcode))
                    bTrasferimenti.FillUSR_PRD_MOVFASI(_ds, barcode);

                TrasferimentiDS.USR_PRD_MOVFASIRow odl = _ds.USR_PRD_MOVFASI.Where(x => x.BARCODE == barcode).FirstOrDefault();
                if (odl == null)
                {
                    return null;

                }
                //   AnagraficaDS.MAGAZZRow articolo = _anagrafica.GetMAGAZZ(odl.IDMAGAZZ);

                BarcodeModel barcodeM = new BarcodeModel()
                {
                    Barcode = odl.IsBARCODENull() ? string.Empty : odl.BARCODE,
                    Nummovfase = odl.IsNUMMOVFASENull() ? string.Empty : odl.NUMMOVFASE,
                    Reparto = odl.IsCODICECLIFONull() ? string.Empty : odl.CODICECLIFODEST,
                    Quantità = odl.QTA.ToString()
                };

                return barcodeM;
            }


        }
    }
}

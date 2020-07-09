using Applicazioni.Data.Trasferimenti;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Applicazioni.Models;

namespace TrasferimentiWeb
{
    public class ElaboraBarcode
    {
        private TrasferimentiDS _ds = new TrasferimentiDS();

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














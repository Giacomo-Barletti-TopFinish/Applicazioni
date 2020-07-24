using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Helpers
{
    public class ZebraHelper
    {
        public static void StampaEtichettaUbicazione(string zebraPrinter,string codice, string descrizione, string barcode)
        {
            StringBuilder sb = new StringBuilder();
            string fontGrande = "RN,120,80";
            string fontNormale = "SN,50,50";

            //string fontGrande = "TN,9,9";
            //string fontNormale = "QN,20,12";

            int posizioneX = 30;

            sb.Append("^XA");
            sb.Append(InserisciTesto(posizioneX, 30, fontGrande, codice));

            sb.Append(InserisciTesto(posizioneX, 120, fontNormale, descrizione));

            sb.Append(InserisciBarcode128Code(posizioneX,175,barcode));

            sb.Append("^XZ");

            RawPrinterHelper.SendStringToPrinter(zebraPrinter, sb.ToString());
        }
        private static string InserisciTesto(int x, int y, string font, string testo)
        {
            return string.Format("^FO{0},{1}^A{2}^FD{3}^FS", x, y, font, testo);
        }

        private static string InserisciBarcode128Code(int x, int y, string testo)
        {
            return string.Format("^FO{0},{1}^BY3^BCN,100,Y,N,N^FD{2}^FS", x, y, testo);
        }
    }
}

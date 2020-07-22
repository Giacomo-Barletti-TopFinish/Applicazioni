using Applicazioni.BLL;
using System.Web.Mvc;

namespace TrasferimentiWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CaricaScheda(string Barcode)
        {
            Trasferimenti eb = new Trasferimenti();
            Applicazioni.Models.BarcodeModel bm = eb.Elabora(Barcode);
            return Json(bm);
//            return PartialView("CaricaScheda", bm);

        }

        public ActionResult SalvaTrasferimento(string Barcode,string OdlJSON)
        {
            Trasferimenti eb = new Trasferimenti();
            string messaggio = eb.SalvaTrasferimento(Barcode,OdlJSON);
            return  Content(messaggio);
            //            return PartialView("CaricaScheda", bm);

        }

    }
}
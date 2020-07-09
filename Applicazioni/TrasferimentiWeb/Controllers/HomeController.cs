using Applicazioni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            ElaboraBarcode eb = new ElaboraBarcode();
            Applicazioni.Models.BarcodeModel bm = eb.Elabora(Barcode);
            return Json(bm);
//            return PartialView("CaricaScheda", bm);

        }


    }
}
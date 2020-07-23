using Applicazioni.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrasferimentiWeb.Controllers
{
    public class SpedizioniController : Controller
    {
        // GET: Spedizioni
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LeggiBarcode(string Barcode)
        {
            string risposta = "Barcode vuoto";
            if (!string.IsNullOrEmpty(Barcode))
            {
                Spedizioni spedizioni = new Spedizioni();
                risposta = spedizioni.LeggiBarcode(Barcode);
            }
            return PartialView("LeggiBarcode",risposta);
        }
    }
}
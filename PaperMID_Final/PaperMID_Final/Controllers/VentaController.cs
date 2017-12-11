using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.Models;
using PaperMID.BO;


namespace PaperMID.Controllers
{
    public class VentaController : Controller
    {
        // GET: Venta
        VentaModel _VentaMod;
        public ActionResult Ventas()
        {
            return View();
        }
    }
}
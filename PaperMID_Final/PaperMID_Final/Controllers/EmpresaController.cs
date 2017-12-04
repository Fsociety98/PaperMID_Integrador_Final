using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.BO;
using PaperMID.Models;

namespace PaperMID.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa

        EmpresaModel oEmpresa;
        BO.EmpresaBO _oEmpresaBO;
        public EmpresaController()
        {
            oEmpresa = new EmpresaModel();
        }
        public ActionResult ActualizarEmpresa()
        {
            return View(oEmpresa.Obtener_Empresa(1));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActuaDatosEmpre(String IdEmpresa,String NombreEmpre,String TelefenoEmpre,String CorreoEmpre,String MisionEmpre,String VisionEmpre,String ValoresEmpre)
        {
            _oEmpresaBO = new EmpresaBO();
            _oEmpresaBO.IdEmpresa = Convert.ToInt32(IdEmpresa);
            _oEmpresaBO.NombreEmpre = NombreEmpre;
            _oEmpresaBO.TelefenoEmpre = TelefenoEmpre;
            _oEmpresaBO.CorreoEmpre = CorreoEmpre;
            _oEmpresaBO.MisionEmpre = MisionEmpre;
            _oEmpresaBO.VisionEmpre = VisionEmpre;
            _oEmpresaBO.ValoresEmpre = ValoresEmpre;
            oEmpresa.Modificar(_oEmpresaBO);
            return RedirectToAction("Index", "Administrador");
        }
    }
}
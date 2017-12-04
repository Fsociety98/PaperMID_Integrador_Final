using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.BO;
using PaperMID.Models;
using System.Globalization;

namespace PaperMID.Controllers
{
    public class PromocionesController : Controller
    {
        // GET: Promociones
        PromocionesModel PromoModel;
        BO.PromocionesBO _PromoBO;
        public PromocionesController()
        {
            PromoModel = new PromocionesModel();
        }
        public ActionResult Promociones()
        {
            var PromoBo = new PromocionesBO();
            ViewBag.IdProve = new SelectList(PromoBo.Proveedores = PromoModel.ListaProveedor(), "IdProveedor", "NombreProv");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agg_Promocion(String NombrePromo, String IdProve,String DescripcionPromo, String RangoPromocion,String DescuentoPromo)
        {
            _PromoBO = new PromocionesBO();

            String D_Inicio = RangoPromocion.Substring(3, 2);
            String M_Inicio = RangoPromocion.Substring(0, 2);
            String A_Inicio = RangoPromocion.Substring(6, 4);
            String Fecha_Inicio = D_Inicio + "/" + M_Inicio + "/" + A_Inicio;

            String D_Final = RangoPromocion.Substring(16, 2);
            String M_Final = RangoPromocion.Substring(13, 2);
            String A_Final = RangoPromocion.Substring(19, 4);
            String Fecha_Final = D_Final + "/" + M_Final + "/" + A_Inicio;

            _PromoBO.FechaInicioPromo = Fecha_Inicio;
            _PromoBO.FechaFinPromo = Fecha_Final;
            _PromoBO.DescuentoPromo = Convert.ToDouble(DescuentoPromo);
            _PromoBO.NombrePromo = NombrePromo;
            _PromoBO.IdProve = Convert.ToInt32(IdProve);
            _PromoBO.DescripcionPromo = DescripcionPromo;
            PromoModel.Agregar(_PromoBO);
            return RedirectToAction("Promociones", "Promociones");
        }

        public ActionResult ActualizarPromocion(int id)
        {
            var PromoBo = new PromocionesBO();
            PromoModel.RecuperarPromo(id);
            ViewBag.IdProve = new SelectList(PromoBo.Proveedores = PromoModel.ListaProveedor(), "IdProveedor", "NombreProv", PromoModel.IdProveedor1);
            return View(PromoModel.RecuperarPromo(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActualizarDatosProm(String IdPromo, String NombrePromo, String IdProve, String DescripcionPromo, String RangoPromocion,String DescuentoPromo)
        {
            _PromoBO = new PromocionesBO();
            String D_Inicio = RangoPromocion.Substring(3, 2);
            String M_Inicio = RangoPromocion.Substring(0, 2);
            String A_Inicio = RangoPromocion.Substring(6, 4);
            String Fecha_Inicio = D_Inicio + "/" + M_Inicio + "/" + A_Inicio;

            String D_Final = RangoPromocion.Substring(16, 2);
            String M_Final = RangoPromocion.Substring(13, 2);
            String A_Final = RangoPromocion.Substring(19, 4);
            String Fecha_Final = D_Final + "/" + M_Final + "/" + A_Inicio;

            _PromoBO.FechaInicioPromo = Fecha_Inicio;
            _PromoBO.FechaFinPromo = Fecha_Final;

            _PromoBO.IdPromo = Convert.ToInt32(IdPromo);
            _PromoBO.NombrePromo = NombrePromo;
            _PromoBO.DescuentoPromo = Convert.ToDouble(DescuentoPromo);
            _PromoBO.IdProve = Convert.ToInt32(IdProve);
            _PromoBO.DescripcionPromo = DescripcionPromo;
            PromoModel.Modificar(_PromoBO);
            return RedirectToAction("Promociones", "Promociones");
        }
        public ActionResult EliminarPromo(string id)
        {
            int Clave = int.Parse(id);
            PromoModel.Eliminar(Clave);
            return RedirectToAction("Promociones", "Promociones");
        }

        [ChildActionOnly]
        public ActionResult ProveedorParDWL()
        {
            var PromoBo = new PromocionesBO();
            PromoBo.Proveedores = PromoModel.ListaProveedor();
            return PartialView(PromoBo);
        }

        [ChildActionOnly]
        public ActionResult ComboProvedorPromo()
        {
            var PromoBO = new PromocionesBO();
            PromoBO.Proveedores = PromoModel.ListaProveedor();
            return PartialView(PromoBO);
        }
        [ChildActionOnly]
        public ActionResult ListarPromociones()
        {
            return PartialView(PromoModel.Mostrar());
        }
    }
}
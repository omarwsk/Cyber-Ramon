using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cyber_Ramon.Models;

namespace Cyber_Ramon.Controllers
{
    public class BaseController : Controller
    {
        

        public ActionResult ChecarSessionConectada()
        {
            String Estado = "0";
            if (System.Web.HttpContext.Current.Session["Conectado"] != null)
            {
                Estado = System.Web.HttpContext.Current.Session["Conectado"].ToString();
            }

            if (!Estado.Equals("1"))
            {
                return RedirectToAction("Login", "Home");
            }
            UsuarioModel UsuarioActual = (UsuarioModel)System.Web.HttpContext.Current.Session["Usuario"];

            ViewBag.PermisoCaja = UsuarioActual.Permisos.Find(Permiso => Permiso.Nombre == "caja").Nivel;
            ViewBag.PermisoEmpleados = UsuarioActual.Permisos.Find(Permiso => Permiso.Nombre == "empleados").Nivel;
            return View();
        }

        public ActionResult ChecarSessionYPermiso(String NombrePermiso, int NivelNecesario)
        {
            String Estado = "0";
            if (System.Web.HttpContext.Current.Session["Conectado"] != null)
            {
                Estado = System.Web.HttpContext.Current.Session["Conectado"].ToString();
            }

            if (!Estado.Equals("1"))
            {
                return RedirectToAction("Login", "Home");
            }

            UsuarioModel UsuarioActual = (UsuarioModel)System.Web.HttpContext.Current.Session["Usuario"];
            int NiveldePermiso = UsuarioActual.Permisos.Find(Permiso => Permiso.Nombre == NombrePermiso).Nivel;

            if (NiveldePermiso<NivelNecesario)
            {
                return RedirectToAction("index", "Home");
            }


            return View();
        }
    }
}
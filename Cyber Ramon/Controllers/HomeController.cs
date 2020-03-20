using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cyber_Ramon.Models;

namespace Cyber_Ramon.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult ChecarSessionConectada() {
            String Estado = "0";
            if (System.Web.HttpContext.Current.Session["Conectado"] != null)
            {
                Estado = System.Web.HttpContext.Current.Session["Conectado"].ToString();
            }

            if (!Estado.Equals("1"))
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        public ActionResult Index(UsuarioModel User)
        {

            
            return ChecarSessionConectada();
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Caja()
        {
            return View();
        }

        public ActionResult Ingresar(UsuarioModel UsuarioInfo)
        {
            if (UsuarioInfo.Ingresar())
            {
                System.Web.HttpContext.Current.Session["Usuario"] = UsuarioInfo;
                System.Web.HttpContext.Current.Session["Conectado"] = "1";
                return Json(Url.Action("Index", "Home"));
            }
            else
            {
                return Json(Url.Action("Login", "Home"));
            }
        }
        public ActionResult Salir()
        {
            System.Web.HttpContext.Current.Session["Usuario"] = null;
            System.Web.HttpContext.Current.Session["Conectado"] = null;
            return RedirectToAction("Login", "Home");
        }
    }
}
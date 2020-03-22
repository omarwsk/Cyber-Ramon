using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cyber_Ramon.Models;
using Cyber_Ramon.Filters;

namespace Cyber_Ramon.Controllers
{
    
    public class HomeController : BaseController
    {
        public string alerta = "";
        

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
            return ChecarSessionYPermiso("caja", 2);
        }

        public ActionResult Ingresar(UsuarioModel UsuarioInfo)
        {
            if (UsuarioInfo.Ingresar())
            {
                Session.Timeout = 60;
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
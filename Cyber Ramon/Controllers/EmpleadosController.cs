using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cyber_Ramon.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        public ActionResult Nuevo()
        {
            return View();
        }
    }
}

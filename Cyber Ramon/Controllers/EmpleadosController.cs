using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cyber_Ramon.Models;

namespace Cyber_Ramon.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        public ActionResult Nuevo()
        {
            return View();
        }

        public String AgregarEmpleadoMYSQL(EmpleadoModel Empleado, String stringUsuario, String stringContraseña, String Ubicacion)
        {
            Empleado.Usuario.Usuario = stringUsuario;
            Empleado.Usuario.Contraseña = stringContraseña;
            Empleado.Usuario.Tipo = "Empleado";
            Empleado.Ubicacion.Nombre = Ubicacion;

            return Empleado.Registrar();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cyber_Ramon.Models
{
    public class UsuarioModel
    {
        private int ID;
        private String Usuario;
        private String Contraseña;
        private PermisosModel[] Permisos;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cyber_Ramon.Models
{
    public class EmpleadoModel
    {
        private int ID;
        private String Nombre;
        private String Puesto;
        private UbicacionModel Ubicacion;
        private String Telefono;
        private String Direccion;
        private String Foto;
        private UsuarioModel Usuario;
        private Double Salario;
        public EmpleadoModel(int id, String nombre, String puesto, UbicacionModel ubicacion, String telefono, String direccion, String foto, UsuarioModel usuario, Double salario) {
            ID = id;
            Nombre = nombre;
            Puesto = puesto;
            Ubicacion = ubicacion;
            Telefono = telefono;
            Direccion = direccion;
            Foto = foto;
            Usuario = usuario;
            Salario = salario;

        }
        
    }
}
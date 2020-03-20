using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace Cyber_Ramon.Models
{
    public class EmpleadoModel
    {
        public int ID { get;}
        public String Nombre { get; set; }
        public String Puesto { get; set; }
        public UbicacionModel Ubicacion = new UbicacionModel();
        public String Turno { get; set; }
        public String Telefono { get; set; }
        public String Direccion { get; set; }
        public String Foto { get; set; }
        public UsuarioModel Usuario = new UsuarioModel();
        public Double Salario { get; set; }

        public EmpleadoModel(int id, String nombre, String puesto, UbicacionModel ubicacion, String turno, String telefono, String direccion, String foto, UsuarioModel usuario, Double salario) {
            ID = id;
            Nombre = nombre;
            Puesto = puesto;
            Ubicacion = ubicacion;
            Turno = turno;
            Telefono = telefono;
            Direccion = direccion;
            Foto = foto;
            Usuario = usuario;
            Salario = salario;

        }
        public EmpleadoModel()
        {

        }




        ///////////// METODOS ////////////
        public string Registrar()
        {
            MySqlConnection conexion = new ConexionModel().ConexionMysql();
            String Respuesta = "";
            int idUsuario = 0;
            try
            {
                if (Usuario.existe())
                {
                    return "El usuario ya existe";
                }
                else
                {
                    idUsuario = Usuario.Registrar();
                }
                conexion.Open();
                string sql = "INSERT INTO empleados (Nombre, Puesto, Ubicacion, Telefono, Direccion, Foto, Salario, idUsuario ) " +
                    "VALUES (@Nombre, @Puesto, @Ubicacion, @Telefono, @Direccion, @Foto, @Salario, @idUsuario)";
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Puesto", Puesto);
                cmd.Parameters.AddWithValue("@Ubicacion", Ubicacion.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", Telefono);
                cmd.Parameters.AddWithValue("@Direccion", Direccion);
                cmd.Parameters.AddWithValue("@Foto", Foto);
                cmd.Parameters.AddWithValue("@Salario", Salario);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);


                cmd.ExecuteNonQuery();
                Respuesta = "Empleado agregado satisfactoriamente";
            }
            catch (Exception ex) { Respuesta = "El Empleado no se ha podido registrar:" + ex; }

            conexion.Close();


            return Respuesta;
        }

    }
}
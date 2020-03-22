using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Cyber_Ramon.Models
{
    public class PermisosModel
    {
        public string Nombre { get; set; }
        public int Nivel { get; set; }

        public PermisosModel(string nombre, int nivel)
        {
            Nombre = nombre;
            Nivel = nivel;
        }
        public void Registrar(int idUsuario)
        {
            MySqlConnection conexion = new ConexionModel().ConexionMysql();
            try
            {

                conexion.Open();
                string sql = "INSERT INTO permisos (idUsuario, Nombre, Nivel) VALUES (@idUsuario, @Nombre, @Nivel);";
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Nivel", Nivel);


                cmd.ExecuteNonQuery();


            }
            catch (Exception ex) {  }

            conexion.Close();

        }

        
    }
}
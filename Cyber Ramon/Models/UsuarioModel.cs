﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Cyber_Ramon.Models
{
    public class UsuarioModel
    {
        public int ID { get; set; }
        public String Usuario { get; set; }
        public String Contraseña { get; set; }
        public String Tipo { get; set; }

        public List<PermisosModel> Permisos = new List<PermisosModel>()
        {
         new PermisosModel("caja", 1),
         new PermisosModel("empleados", 0),
         new PermisosModel("usuarios", 0)
    };

        



        public UsuarioModel(int id, String usuario, String puesto, String tipo, List<PermisosModel> permisos)
        {
            
            ID = id;
            Usuario = usuario;
            Contraseña = puesto;
            Tipo = tipo;
            Permisos = permisos;

        }
        public UsuarioModel()
        {

        }


        public int Registrar()
        {
            MySqlConnection conexion = new ConexionModel().ConexionMysql();
            MySqlDataReader rdr = null;
            try
            {

                conexion.Open();
                string sql = "INSERT INTO usuarios (Usuario, Contraseña, Tipo) VALUES (@Usuario, @Contraseña, @Tipo);SELECT LAST_INSERT_ID() as 'ultimo';";
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@Usuario", Usuario.ToLower());
                cmd.Parameters.AddWithValue("@Contraseña", Contraseña);
                cmd.Parameters.AddWithValue("@Tipo", Tipo);


                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ID = Convert.ToInt32(rdr["ultimo"]);

                    foreach (PermisosModel Permiso in Permisos)
                    {
                        Permiso.Registrar(ID);
                    }

                }
                rdr.Close();
                
            }
            catch (Exception ex) { ID = 0; }

            conexion.Close();


            return ID;
        }

        public bool existe()
        {
            MySqlConnection conexion = new ConexionModel().ConexionMysql();
            bool Respuesta = false;
            MySqlDataReader rdr = null;
            try
            {
                conexion.Open();
                string stm = "SELECT * FROM usuarios WHERE Usuario=@Usuario ";

                MySqlCommand cmd = new MySqlCommand(stm, conexion);
                cmd.Parameters.AddWithValue("@Usuario", Usuario.ToLower());
                rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    Respuesta = true;
                }

                rdr.Close();
            }
            catch (Exception ex) {}

            conexion.Close();

            return Respuesta;
        }

        public bool Ingresar()
        {
            MySqlConnection conexion = new ConexionModel().ConexionMysql();
            bool Respuesta = false;
            MySqlDataReader rdr = null;
            try
            {
                conexion.Open();
                string stm = "SELECT * FROM usuarios WHERE Usuario=@Usuario AND Contraseña=@Contraseña;";

                MySqlCommand cmd = new MySqlCommand(stm, conexion);
                cmd.Parameters.AddWithValue("@Usuario", Usuario.ToLower());
                cmd.Parameters.AddWithValue("@Contraseña", Contraseña);
                rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    rdr.Read();
                    ID  = Convert.ToInt32(rdr["idUsuario"]);
                    Tipo = rdr["Tipo"].ToString();
                    Permisos = ObtenerListaPermisos(ID);
                    Respuesta = true;
                }

                rdr.Close();
            }
            catch (Exception ex) { }

            conexion.Close();

            return Respuesta;
        }

        public List<PermisosModel> ObtenerListaPermisos( int idUsuario)
        {
            MySqlConnection conexion = new ConexionModel().ConexionMysql();
            List<PermisosModel> Respuesta = new List<PermisosModel>();
            MySqlDataReader rdr = null;
            try
            {
                conexion.Open();
                string stm = "SELECT * FROM permisos WHERE idUsuario=@idUsuario";

                MySqlCommand cmd = new MySqlCommand(stm, conexion);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    PermisosModel Permiso = new PermisosModel(rdr["Nombre"].ToString(), Convert.ToInt32(rdr["Nivel"]));
                    Respuesta.Add(Permiso);
                }

                rdr.Close();
            }
            catch (Exception ex) { }

            conexion.Close();

            return Respuesta;
        }

    }
}
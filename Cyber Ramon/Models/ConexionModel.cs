using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Cyber_Ramon.Models
{
    public class ConexionModel
    {
        private static string server = "localhost";
        private static string user = "root";
        private static string pass = "root";
        private static string dbName = "cyber";
        private static string port = "3306";
        private static string connStr = "server=" + server + ";user=" + user + ";database=" + dbName + ";port=" + port + ";password=" + pass;
        private MySqlConnection con = new MySqlConnection(connStr);

        public MySqlConnection ConexionMysql() { 
        
            return con;
        }
    }
}
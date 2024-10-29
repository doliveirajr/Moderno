using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moderno
{
    internal class ConexaoModerno
    {
        public string connstring = "server=localhost;uid=root;pwd='';database=pdv";

        public MySqlConnection conn = null;

        public void AbrirConexao()
        {
            conn = new MySqlConnection(connstring);
            conn.Open();
        }

        public void FecharConexao()
        {
            conn = new MySqlConnection(connstring);
            conn.Close();
            conn.Dispose();
            conn.ClearAllPoolsAsync();
        }
    }
}

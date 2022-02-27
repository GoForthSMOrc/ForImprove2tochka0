using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ForImprove2._0
{
    internal class DBMySQLUtils
    {
        public static MySqlConnection GetDBConnection(string host, int port, string database, string username, string password)
        {
            String connString = "Server = " + host + "; Database = " + database + ";Port = " + port + "; User = " + username + "; Password = " + password;
            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
    }
}

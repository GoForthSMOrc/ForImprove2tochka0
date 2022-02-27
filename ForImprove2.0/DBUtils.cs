using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ForImprove2._0
{
    internal class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "ForImprove2tochka0";
            string username = "root";
            string password = "root";

            return DBMySQLUtils.GetDBConnection(host,port,database,username,password);
        }
    }
}

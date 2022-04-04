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
            string host = "194.58.121.94";
            int port = 3306;
            string username = "app_user";
            string password = "password";
            string database = "shoeaccounting";

            return DBMySQLUtils.GetDBConnection(host,port,database,username,password);
        }
    }
}

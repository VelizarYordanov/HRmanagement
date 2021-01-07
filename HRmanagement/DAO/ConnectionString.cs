using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HRmanagement.DAO
{
    public static class ConnectionString
    {
        public static string Connection = "server=localhost;database=company;user=root;password=01062004veli";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(Connection);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cafe
{
    internal class Connection
    {
    }

    public static class DatabaseConnection
    {
       public static  MySqlConnection conn;
        public static void Initialize(string connStr)
        {
            conn = new MySqlConnection(connStr);
        }
        public static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                throw new InvalidOperationException("Connection has not been initialized. Call Initialize first.");
            }
            return conn;
        }
    }
    }


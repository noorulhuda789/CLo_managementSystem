using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMidProject
{
    class Configuration
    {
        String ConnectionStr = @"Data Source=(local);Initial Catalog=ProjectB;Integrated Security=True";
        SqlConnection _connection;
        private static Configuration _instance;
        public static Configuration getInstance()
        {
            if (_instance == null)
                _instance = new Configuration();
            return _instance;
        }
        private Configuration()
        {
            this._connection = new SqlConnection(ConnectionStr);
            this._connection.Open();
        }
        public SqlConnection getConnection()
        {
            return _connection;
        }
    }
}







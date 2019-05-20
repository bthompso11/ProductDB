using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CustomerMaintenance
{
    class MMABooksDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = "Data Source = DESKTOP-U0DQ0PI\\SQLEXPRESS; Initial Catalog = MMABooks; Integrated Security = True;";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}


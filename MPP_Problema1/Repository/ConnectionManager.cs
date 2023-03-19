using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace MPP_Problema1.Repository
{
    public class ConnectionManager
    {
        public ConnectionManager() { }

        public NpgsqlConnection GetConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=tarom;User Id=postgres; Password=root");
            return conn;
        }
    }
}

using Npgsql;
namespace MPP_Problema1.Repository
{
    public class ConnectionManager
    {
        public readonly NpgsqlConnection Connection;

        public ConnectionManager() 
        {
            Connection = new NpgsqlConnection("Server=localhost;Port=5432;Database=tarom;User Id=postgres; Password=root");
        }
    }
}

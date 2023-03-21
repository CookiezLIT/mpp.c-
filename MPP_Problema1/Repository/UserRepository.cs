using System;
using System.Linq;
using MPP_Problema1.Model;
using Npgsql;
namespace MPP_Problema1.Repository
{
    public class UserRepository : ICrudRepository<User>
    {

        private readonly ConnectionManager _connectionManager;

        public UserRepository(ConnectionManager connectionManager)
        {
            this._connectionManager = connectionManager;
        }

        public User Create(User entity)
        {
            _connectionManager.Connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.user VALUES ($1), ($2), ($3) ", _connectionManager.Connection);

            cmd.Parameters.AddWithValue("p1", entity.Id);
            cmd.Parameters.AddWithValue("p2", entity.Name);
            cmd.Parameters.AddWithValue("p3", entity.Password);
            
            int query_result = cmd.ExecuteNonQuery();
            if (query_result != -1)
            {
                return entity;
            }
            else
            {
                return null;
            }

        }

        public bool isUser(User entity)
        {

            NpgsqlConnection conn = _connectionManager.Connection;
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM public.user WHERE name='DAN' and password='ROOT';", conn);

            

            //var parameter = cmd.CreateParameter();
            //parameter.ParameterName = "name";
            //parameter.Value = entity.Name;
            //cmd.Parameters.Add(parameter);
            /*
            var parameter2 = cmd.CreateParameter();
            parameter2.ParameterName = "password";
            parameter2.Value = entity.Password;
            cmd.Parameters.Add(parameter2);
            */

            NpgsqlDataReader reader = cmd.ExecuteReader();
            
            if (reader.Rows > 0)
            {
                conn.Close();
                return true;
                
            }
            else
            {
                conn.Close();
                return false;
            }
        }

        public User Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public User Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<int> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Update(int entity)
        {
            throw new NotImplementedException();
        }

        IQueryable<User> ICrudRepository<User>.GetAll()
        {
            throw new NotImplementedException();
        }

        User ICrudRepository<User>.Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}

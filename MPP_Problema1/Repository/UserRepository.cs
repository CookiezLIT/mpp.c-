using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP_Problema1.Model;
using Npgsql;
namespace MPP_Problema1.Repository
{
    public class UserRepository : ICrudRepository<User>
    {

        ConnectionManager connectionManager;

        public UserRepository(ConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }
        public User Create(User entity)
        {
            NpgsqlConnection conn = connectionManager.GetConnection();
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.user VALUES ($1), ($2), ($3) ", conn);

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

            NpgsqlConnection conn = connectionManager.GetConnection();
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

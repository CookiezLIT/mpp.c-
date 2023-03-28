using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace SimpleSql
{

    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly NpgsqlConnection _connection;
        private readonly ILogger _logger;

        public Repository(NpgsqlConnection connection, ILogger logger)
        {
            _connection = connection;
            _logger = logger;
        }

        public T? GetAsync(Guid id)
        {
            _logger.Information("getting item:");
            _connection.Open();
            var command = SqlCommandsFor<T>.Get(id, _connection);
            T? entity = null;

            using (var reader = command.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return null;
                }
                while (reader.Read())
                {
                    entity = reader.Map<T>();
                }
            }
            _connection.Close();
            return entity;
        }

        public List<T> GetAllAsync()
        {
            _connection.Open();
            _logger.Information("getting all items");
            var command = SqlCommandsFor<T>.GetAll(_connection);
            List<T> entities = new List<T>();

            using (var reader = command.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return (List<T>)Enumerable.Empty<T>();
                }
                while (reader.Read())
                {
                    //entities.Add((T)Activator.CreateInstance(typeof(T), reader));
                    entities.Add(reader.Map<T>());
                }
            }
            _connection.Close();
            return entities;
        }

        public T? CreateAsync(T entity)
        {
            _logger.Information("creating item");
            _connection.Open();
            var command = SqlCommandsFor<T>.Create(entity, _connection);

            var queryResult =  command.ExecuteNonQuery();
             _connection.Close();

            if (queryResult != -1)
            {
                return entity;
            }
            return null;
        }

        public T? UpdateAsync(T entity)
        {
            _logger.Information("updating item");
             _connection.Open();
            var command = SqlCommandsFor<T>.Update(entity, _connection);

            var queryResult =  command.ExecuteNonQuery();
             _connection.Close();

            if (queryResult != -1)
            {
                return entity;
            }
            return null;
        }

        public bool DeleteAsync(Guid id)
        {
            _logger.Information($"Delete {id}");
             _connection.Open();
            var command = SqlCommandsFor<T>.Delete(id, _connection);

            var queryResult =  command.ExecuteNonQuery();
             _connection.Close();

            if (queryResult != -1)
            {
                return true;
            }
            return false;
        }
    }
}

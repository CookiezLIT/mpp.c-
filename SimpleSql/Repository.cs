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

        public async Task<T?> GetAsync(Guid id)
        {
            await _connection.OpenAsync();
            var command = SqlCommandsFor<T>.Get(id, _connection);
            T? entity = null;

            using (var reader = await command.ExecuteReaderAsync())
            {
                if (!reader.HasRows)
                {
                    return null;
                }
                while (await reader.ReadAsync())
                {
                    entity = reader.Map<T>();
                }
            }
            await _connection.CloseAsync();
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            await _connection.OpenAsync();
            _logger.Information("test");
            var command = SqlCommandsFor<T>.GetAll(_connection);
            List<T> entities = new List<T>();

            using (var reader = await command.ExecuteReaderAsync())
            {
                if (!reader.HasRows)
                {
                    return (List<T>)Enumerable.Empty<T>();
                }
                while (await reader.ReadAsync())
                {
                    //entities.Add((T)Activator.CreateInstance(typeof(T), reader));
                    entities.Add(reader.Map<T>());
                }
            }
            await _connection.CloseAsync();
            return entities;
        }

        public async Task<T?> CreateAsync(T entity)
        {
            await _connection.OpenAsync();
            var command = SqlCommandsFor<T>.Create(entity, _connection);

            var queryResult = await command.ExecuteNonQueryAsync();
            await _connection.CloseAsync();

            if (queryResult != -1)
            {
                return entity;
            }
            return null;
        }

        public async Task<T?> UpdateAsync(T entity)
        {
            await _connection.OpenAsync();
            var command = SqlCommandsFor<T>.Update(entity, _connection);

            var queryResult = await command.ExecuteNonQueryAsync();
            await _connection.CloseAsync();

            if (queryResult != -1)
            {
                return entity;
            }
            return null;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            await _connection.OpenAsync();
            var command = SqlCommandsFor<T>.Delete(id, _connection);

            var queryResult = await command.ExecuteNonQueryAsync();
            await _connection.CloseAsync();

            if (queryResult != -1)
            {
                return true;
            }
            return false;
        }
    }
}

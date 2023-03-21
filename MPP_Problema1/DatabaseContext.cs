using MPP_Problema1.Model;
using MPP_Problema1.Repository;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Configuration;
using System.Threading.Tasks;

namespace MPP_Problema1
{
    public class DatabaseContext
    {
        private readonly ConnectionManager _connectionManager;

        public DatabaseContext(ConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public async Task<bool> UserExistsAsync(User user)
        {
            await _connectionManager.Connection.OpenAsync();
            var command = Queries.User.Exists(user, _connectionManager.Connection);

            using (var reader = await command.ExecuteReaderAsync())
            {
                if (!reader.HasRows)
                {
                    await _connectionManager.Connection.CloseAsync();
                    return false;
                }
                await _connectionManager.Connection.CloseAsync();
                return true;
            }
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            await _connectionManager.Connection.OpenAsync();
            var command = Queries.User.Get(id, _connectionManager.Connection);
            User user = null;

            using (var reader = await command.ExecuteReaderAsync())
            {
                if (!reader.HasRows)
                {
                    return null;
                }
                while (await reader.ReadAsync())
                {
                    user = new User(reader);
                }
            }
            await _connectionManager.Connection.CloseAsync();
            return user;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            await _connectionManager.Connection.OpenAsync();
            var command = Queries.User.GetAll(_connectionManager.Connection);
            List<User> users = new List<User>();

            using (var reader = await command.ExecuteReaderAsync())
            {
                if (!reader.HasRows)
                {
                    return (List<User>)Enumerable.Empty<User>();
                }
                while (await reader.ReadAsync())
                {
                    users.Add(new User(reader));
                }
            }
            await _connectionManager.Connection.CloseAsync();
            return users;
        }

        public async Task<User> CreateAsync(User user)
        {
            await _connectionManager.Connection.OpenAsync();
            var command = Queries.User.Create(user, _connectionManager.Connection);

            var queryResult = await command.ExecuteNonQueryAsync();
            await _connectionManager.Connection.CloseAsync();

            if (queryResult != -1)
            {
                return user;
            }
            return null;
        }

        public async Task<User> UpdateAsync(User user)
        {
            await _connectionManager.Connection.OpenAsync();
            var command = Queries.User.Update(user, _connectionManager.Connection);

            var queryResult = await command.ExecuteNonQueryAsync();
            await _connectionManager.Connection.CloseAsync();

            if (queryResult != -1)
            {
                return user;
            }
            return null;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            await _connectionManager.Connection.OpenAsync();
            var command = Queries.User.Delete(id, _connectionManager.Connection);

            var queryResult = await command.ExecuteNonQueryAsync();
            await _connectionManager.Connection.CloseAsync();

            if (queryResult != -1)
            {
                return true;
            }
            return false;
        }
    }
}

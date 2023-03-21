using Npgsql;
using System;

namespace MPP_Problema1
{
    public static class Queries
    {
        public static class User
        {
            public static NpgsqlCommand Exists(Model.User user, NpgsqlConnection connection) => new NpgsqlCommand(string.Format("SELECT * FROM {0} WHERE name='{1}' AND password='{2}'", DbConstants.Tables.Users, user.Name, user.Password), connection);
            
            public static NpgsqlCommand Get(Guid id, NpgsqlConnection connection) => new NpgsqlCommand(string.Format("SELECT * FROM {0} WHERE id='{1}'", DbConstants.Tables.Users, id), connection);

            public static NpgsqlCommand GetAll(NpgsqlConnection connection) => new NpgsqlCommand(string.Format("SELECT * FROM {0}", DbConstants.Tables.Users), connection);

            public static NpgsqlCommand Create(Model.User user, NpgsqlConnection connection) => new NpgsqlCommand(string.Format("INSERT INTO {0} VALUES('{1}', '{2}', '{3}')", DbConstants.Tables.Users, user.Id, user.Name, user.Password), connection);
            
            public static NpgsqlCommand Update(Model.User user, NpgsqlConnection connection) => new NpgsqlCommand(string.Format("UPDATE {0} SET name='{1}', password='{2}' WHERE id='{3}'", DbConstants.Tables.Users, user.Name, user.Password, user.Id), connection);
            
            public static NpgsqlCommand Delete(Guid id, NpgsqlConnection connection) => new NpgsqlCommand(string.Format("DELETE FROM {0} WHERE id='{1}'", DbConstants.Tables.Users, id), connection);
        }
    }
}

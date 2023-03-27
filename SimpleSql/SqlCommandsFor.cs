using Npgsql;
using System;

namespace SimpleSql
{
    public static class SqlCommandsFor<T>
    {
        public static NpgsqlCommand Get(Guid id, NpgsqlConnection connection) => new NpgsqlCommand(QueryBuilder.Build(QueryBuilder.Operations.GetById, typeof(T), id), connection);
        public static NpgsqlCommand GetAll(NpgsqlConnection connection) => new NpgsqlCommand(QueryBuilder.Build(QueryBuilder.Operations.GetAll, typeof(T)), connection);
        public static NpgsqlCommand Create(T t, NpgsqlConnection connection) => new NpgsqlCommand(QueryBuilder.Build(QueryBuilder.Operations.Create, t), connection);
        public static NpgsqlCommand Update(T t, NpgsqlConnection connection) => new NpgsqlCommand(QueryBuilder.Build(QueryBuilder.Operations.Update, t), connection);
        public static NpgsqlCommand Delete(Guid id, NpgsqlConnection connection) => new NpgsqlCommand(QueryBuilder.Build(QueryBuilder.Operations.Delete, typeof(T), id), connection);
    }
}

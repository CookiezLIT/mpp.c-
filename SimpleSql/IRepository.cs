using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleSql
{
    public interface IRepository<T>
    {
        T? GetAsync(Guid id);

        List<T> GetAllAsync();

        T? UpdateAsync(T entity);

        bool DeleteAsync(Guid id);

        T? CreateAsync(T entity);
    }
}

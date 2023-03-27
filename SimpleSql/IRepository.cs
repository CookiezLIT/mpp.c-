using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleSql
{
    public interface IRepository<T>
    {
        Task<T?> GetAsync(Guid id);

        Task<List<T>> GetAllAsync();

        Task<T?> UpdateAsync(T entity);

        Task<bool> DeleteAsync(Guid id);

        Task<T?> CreateAsync(T entity);
    }
}

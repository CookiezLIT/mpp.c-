using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP_Problema1.Repository
{
    public interface Interface1 <T>
    {
        T Get(Guid id);

        IQueryable<T> GetAll();

        T Update(T entity);

        T Delete(Guid id);

        T Create(T entity);

    }
}

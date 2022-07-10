using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SuppliersCrudOperation.Infrastructure
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> All();
        Task<T> GetById(long id);
        Task<T> Add(T entity);
        bool Delete(T entity);
       T Update(T entity);
       
    }

}

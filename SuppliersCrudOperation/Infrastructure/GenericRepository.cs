using Microsoft.EntityFrameworkCore;
using SuppliersCrudOperation.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SuppliersCrudOperation.Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected SuppliersDbContext context;
        internal DbSet<T> dbSet;
     //   public readonly ILogger _logger;

        public GenericRepository(
            SuppliersDbContext context
           ) //ILogger logger
        {
            this.context = context;
            this.dbSet = context.Set<T>();
            //_logger = logger;
        }

        public  async Task<T> GetById(long id)
        {
            return await dbSet.FindAsync(id);
        }
        public bool Delete(T entity)
        {
             dbSet.Remove(entity);
            return true;
        }

        public IQueryable<T> All()
        {
            return dbSet;
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public  T Update(T entity)
        { 
            return  dbSet.Update(entity).Entity;
            
        }



        public async Task<T> Add(T entity)
        {
            var entry = await dbSet.AddAsync(entity);

            return entry.Entity;
        }




    }

}

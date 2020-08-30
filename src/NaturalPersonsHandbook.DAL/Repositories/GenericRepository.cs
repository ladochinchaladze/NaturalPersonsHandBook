using Microsoft.EntityFrameworkCore;
using NaturalPersonsHandbook.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalPersonsHandbook.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        readonly DbContext dbContext;
        readonly DbSet<T> dbSet;

        public GenericRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public virtual async Task DeleteAsync(int id)
        {
            T obj =await dbSet.FindAsync(id);
            dbSet.Remove(obj);
        }

        public virtual async Task<T> GetAsync(int id)
        {
            var obj =await dbSet.FindAsync(id);
            return obj;
        }

        public virtual IQueryable<T> GetAll()
        {
            var objs = dbSet.AsQueryable();
            return objs;
        }

        public virtual async Task AddAsync(T obj)
        {
            await dbSet.AddAsync(obj);
        }

        public virtual async Task AddRangeAsync(ICollection<T> objs)
        {
            await dbSet.AddRangeAsync(objs);
        }

        public virtual async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }

    }
}

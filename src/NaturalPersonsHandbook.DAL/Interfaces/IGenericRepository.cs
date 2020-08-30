using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalPersonsHandbook.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        IQueryable<T> GetAll();
        Task AddAsync(T obj);
        Task AddRangeAsync(ICollection<T> objs);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}

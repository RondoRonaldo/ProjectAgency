using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository <T>
    {
        Task<T> CreateAsync(T item);
        void Remove(T item);
        void Update(T item);
        Task<T> GetAsync(string id);
        IQueryable<T> GetAllAsQueryable();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindAsQueryable(Expression<Func<T, bool>> predicate);
    }
}

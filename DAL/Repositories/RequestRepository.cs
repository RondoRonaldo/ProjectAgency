using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RequestRepository : IRepository<RequestEntity>
    {
        private readonly ApplicationContext _context;
        public RequestRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<RequestEntity> CreateAsync(RequestEntity item)
        {            
                return (await _context.Requests.AddAsync(item)).Entity;                 
        }

        public void Remove(RequestEntity item)  
        {
             _context.Requests.Remove(item);
        }

        public async Task<RequestEntity> GetAsync(string id)
        {
            return await _context.Requests.FindAsync(id);
        }

        public void Update(RequestEntity item)
        {
            _context.Requests.Update(item);
        }

        public IQueryable<RequestEntity> GetAllAsQueryable()
        {
            return _context.Requests;
        }

        public IQueryable<RequestEntity> FindAsQueryable(Expression<Func<RequestEntity, bool>> predicate)
        {
            return _context.Requests.Where(predicate);
        }

   
        public async Task<IEnumerable<RequestEntity>> FindAsync(Expression<Func<RequestEntity, bool>> predicate)
        {
            return await _context.Requests.Where(predicate).ToListAsync();
        }





    }
}

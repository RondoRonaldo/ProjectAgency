using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class DistrictRepository :IRepository<DistrictEntity>
    {
        private readonly DbSet<DistrictEntity> _dbSet;


        public DistrictRepository(ApplicationContext applicationContext)
        {
            _dbSet = applicationContext.Districts;
        }

        public async Task<DistrictEntity> CreateAsync(DistrictEntity item)
        {
           return (await _dbSet.AddAsync(item)).Entity;
        }

        public void Remove(DistrictEntity item)
        {
            _dbSet.Remove(item);
        }

        public void Update(DistrictEntity item)
        {
            _dbSet.Update(item);
        }

        public async  Task<DistrictEntity> GetAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<DistrictEntity> GetAllAsQueryable()
        {
            return _dbSet;
        }

        public async Task<IEnumerable<DistrictEntity>> FindAsync(Expression<Func<DistrictEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public IQueryable<DistrictEntity> FindAsQueryable(Expression<Func<DistrictEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}

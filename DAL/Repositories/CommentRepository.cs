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
    public class CommentRepository : IRepository<CommentEntity>
    {
        private readonly DbSet<CommentEntity> _dbSet;
        public CommentRepository(ApplicationContext context)
        {
            _dbSet = context.Set<CommentEntity>();
        }

        public async Task<CommentEntity> CreateAsync(CommentEntity item)
        {
            return (await _dbSet.AddAsync(item)).Entity;

        }

        public async Task<CommentEntity> GetAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(CommentEntity item)
        {
            _dbSet.Remove(item);
        }

        public void Update(CommentEntity item)
        {
            _dbSet.Update(item);
        }

        public IQueryable<CommentEntity> GetAllAsQueryable()
        {
            return _dbSet;
        }

        public async Task<IEnumerable<CommentEntity>> FindAsync(Expression<Func<CommentEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public IQueryable<CommentEntity> FindAsQueryable(Expression<Func<CommentEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}

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
    public class UserProfileRepository : IRepository<UserProfileEntity>
    {
        private readonly ApplicationContext _context;
        public UserProfileRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<UserProfileEntity> CreateAsync(UserProfileEntity item)
        {
            return (await _context.UserProfiles.AddAsync(item)).Entity;
        }

        public async Task<UserProfileEntity> GetAsync(string id)
        {            
                return await _context.UserProfiles.FindAsync(id);         
        }

        public void Remove(UserProfileEntity item)
        {
            _context.UserProfiles.Remove(item);
        }

        public void Update(UserProfileEntity item)
        {
            _context.UserProfiles.Update(item);
        }

        public IQueryable<UserProfileEntity> GetAllAsQueryable()
        {
            return _context.UserProfiles;
        }

        public async Task<IEnumerable<UserProfileEntity>> FindAsync(Expression<Func<UserProfileEntity, bool>> predicate)
        {
            return await _context.UserProfiles.Where(predicate).ToListAsync();
        }

        public IQueryable<UserProfileEntity> FindAsQueryable(Expression<Func<UserProfileEntity, bool>> predicate)
        {
            return _context.UserProfiles.Where(predicate);
        }
    }
}

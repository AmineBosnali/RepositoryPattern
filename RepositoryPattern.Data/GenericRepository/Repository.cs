using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.GenericRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly RepositoryPatternContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(RepositoryPatternContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(List<T> entityList)
        {
            await _dbSet.AddRangeAsync(entityList);
        }

        public async Task DeleteAsync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).SingleOrDefaultAsync();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null) return _dbSet.ToListAsync();
            return _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }


        public async Task<PaginationResponseModel<T>> PaginationAsync(int pageSize, int pageNumber)
        {
            var res = new PaginationResponseModel<T>();
            var count = await _dbSet.CountAsync();
            var size = (pageNumber - 1) * pageSize;
            var list = await _dbSet
                .Skip(size)
                .Take(pageSize)
                .ToListAsync();
            res.Items = list;
            res.TotalCount = count;
            return res;
        }
    }
}

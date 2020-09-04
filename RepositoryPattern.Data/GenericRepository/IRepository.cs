using RepositoryPattern.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.GenericRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T,bool>> predicate= null);
        Task<T> GetByIdAsync(object id);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entityList);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<PaginationResponseModel<T>> PaginationAsync(int pageSize, int pageNumber);
    }
}

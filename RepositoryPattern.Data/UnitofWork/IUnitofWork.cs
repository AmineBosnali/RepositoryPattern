using RepositoryPattern.Data.GenericRepository;
using System;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.UnitofWork
{
    public interface IUnitofWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        Task<int> SaveChanges();
        Task BeginTransaction();
        Task Commit();
        Task RollBack();
    }
}

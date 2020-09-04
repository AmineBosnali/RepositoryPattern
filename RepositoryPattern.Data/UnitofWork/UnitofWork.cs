using Microsoft.EntityFrameworkCore.Storage;
using RepositoryPattern.Data.GenericRepository;
using System;
using System.Threading.Tasks;


namespace RepositoryPattern.Data.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly RepositoryPatternContext _context;
        IDbContextTransaction trans;
        private bool disposed = false;
        public UnitofWork(RepositoryPatternContext context)
        {
            _context = context;
        }
        public async Task BeginTransaction()
        {
            trans = await _context.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await trans.CommitAsync();
        }

        public async virtual Task Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    await _context.DisposeAsync();
                }
            }
            this.disposed = true;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context);
        }

        public async Task RollBack()
        {
            await trans.RollbackAsync();
        }

        public async Task<int> SaveChanges()
        {
            int affectedRow = 0;
            try
            {
                affectedRow = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            return affectedRow;
        }

        async void IDisposable.Dispose()
        {
            await Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

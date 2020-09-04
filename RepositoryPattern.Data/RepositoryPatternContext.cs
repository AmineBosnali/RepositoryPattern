using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RepositoryPattern.Data.Entities;
using System.Threading.Tasks;

namespace RepositoryPattern.Data
{
    public class RepositoryPatternContext : DbContext
    {
        IDbContextTransaction _transaction;

        public virtual DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Testt;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }

    }
}

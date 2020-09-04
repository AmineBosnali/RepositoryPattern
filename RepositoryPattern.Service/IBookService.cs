using RepositoryPattern.Data.Entities;
using RepositoryPattern.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Service
{
    public interface IBookService
    {
        Task<List<Book>> GetBooks();
        Task<PaginationResponseModel<Book>> Pagination();
    }
}

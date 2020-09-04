using RepositoryPattern.Data.Entities;
using RepositoryPattern.Data.GenericRepository;
using RepositoryPattern.Data.Models;
using RepositoryPattern.Data.UnitofWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryPattern.Service
{
    public class BookService : IBookService
    {
        private readonly IUnitofWork _uow;
        private readonly IRepository<Book> _bookRepository;

  
        public BookService(IUnitofWork uow)
        {
            _uow = uow;
            _bookRepository = _uow.GetRepository<Book>();
        }

        public async Task<List<Book>> GetBooks()
        {
            var res = await  _bookRepository.GetAllAsync();
            return res;
        }

        public async Task<PaginationResponseModel<Book>> Pagination()
        {
            var res = await _bookRepository.PaginationAsync(2, 2);
            return res;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using RepositoryPattern.Data.UnitofWork;
using RepositoryPattern.Service;
using System;

namespace RepositoryPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            IUnitofWork uow = new UnitofWork(new Data.RepositoryPatternContext());
            IBookService bookService = new BookService(uow);
            var books = bookService.GetBooks().Result;

            Console.WriteLine("==Books==");
            foreach (var item in books)
            {
                Console.WriteLine(item.Id + ". " + item.Name);
            }
          
        }
    }


}

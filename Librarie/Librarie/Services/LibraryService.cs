using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Librarie.Data.Entities;
using Librarie.Data;
using Microsoft.EntityFrameworkCore;

namespace Librarie.Services
{
    public class LibraryService : ILibraryService
    {

        private ApplicationDbContext _applicationDbService;

        public LibraryService(ApplicationDbContext applicationDbService)
        {
            _applicationDbService = applicationDbService;
        }

        public List<Book> GetBooks()
        {
            return _applicationDbService.Books.ToList();
        }

        public List<Tranzaction> GetTranzactions()
        {
            return _applicationDbService.Tranzactions.Include(item => item.User).ToList();
        }

        public bool Borrow(string userId, int id)
        {
            _applicationDbService.Tranzactions.Add(new Tranzaction
            {
                UserId = userId,
                BookId = id
            });

            var book = _applicationDbService.Books.Single(t => t.id == id);
            book.numberOfCopies--;
            _applicationDbService.Books.Update(book);

            return _applicationDbService.SaveChanges() == 2;
            
        }

        public bool Return(int id,string userId)
        {
            var tranzaction = _applicationDbService.Tranzactions.Single(t => t.BookId == id && t.UserId == userId);

            var book = _applicationDbService.Books.Single(t => t.id == id);
            book.numberOfCopies++;
            _applicationDbService.Books.Update(book);

            _applicationDbService.Tranzactions.Remove(tranzaction);

            return _applicationDbService.SaveChanges() == 2;
        }
    }
}

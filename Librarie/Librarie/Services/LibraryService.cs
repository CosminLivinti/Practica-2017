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
            return _applicationDbService.books.ToList();
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

            return _applicationDbService.SaveChanges() == 1;
            
        }

        public bool Return(int id,string userId)
        {
            var tranzaction = _applicationDbService.Tranzactions.Single(t => t.BookId == id && t.UserId == userId);

            _applicationDbService.Tranzactions.Remove(tranzaction);

            return _applicationDbService.SaveChanges() == 1;
        }
    }
}

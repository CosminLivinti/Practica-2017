using Librarie.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarie.Services
{
    public interface ILibraryService
    {
        List<Book> GetBooks();
        List<Tranzaction> GetTranzactions();
        bool Borrow(string userId, int id);
        bool Return(int id, string userId);
    }
}

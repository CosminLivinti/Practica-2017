using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Librarie.Data.Entities;

namespace Librarie.Services
{
    public class LibraryService : ILibraryService
    {
        public List<Book> getBooks()
        {
            return new List<Book>()
            {
                new Book() { id = 1, title = "The Autumn Republic", author = "Brian McClellan"},
                new Book() { id = 2, title = "Anna Karenina", author = "Lev Tolstoi"},
                new Book() { id = 3, title = "Hamlet", author = "William Shakespeare"},
                new Book() { id = 4, title = "Norse Mythology", author = "Neil Gaiman"},
                new Book() { id = 5, title = "Caraval", author = "Stephanie Garber"}
            };
        }
    }
}

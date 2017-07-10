using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Librarie.Data.Entities;

namespace Librarie.Models.LibraryViewModels
{
    public class LibraryViewModel
    {
        private List<Book> books1;

        public InformationsViewModel informations { set; get; }
        public List<BookViewModel> books { set; get; }
        public List<Tranzaction> tranzactions { set; get; }

        public LibraryViewModel()
        {
            informations = new InformationsViewModel();
            books = new List<BookViewModel>();
        }

        public LibraryViewModel(List<Book> Books)
        {
            informations = new InformationsViewModel();
            books = new List<BookViewModel>();
            foreach(var book in Books)
            {
                var bookViewModel = new BookViewModel()
                {
                    id = book.id,
                    title = book.title,
                    author = book.author,
                    numberOfCopies = book.numberOfCopies
                };

                books.Add(bookViewModel);
            }

            tranzactions = new List<Tranzaction>();
        }

        public LibraryViewModel(List<Book> Books, List<Tranzaction> Tranzactions)
        {
            informations = new InformationsViewModel();
            books = new List<BookViewModel>();
            foreach(var book in Books)
            {
                var bookViewModel = new BookViewModel()
                {
                    id = book.id,
                    title = book.title,
                    author = book.author,
                    numberOfCopies = book.numberOfCopies
                };

                books.Add(bookViewModel);
            }

            tranzactions = new List<Tranzaction>();
            foreach(var tranzaction in Tranzactions)
            {
                var tranzactie = new Tranzaction()
                {
                    Id = tranzaction.Id,
                    UserId = tranzaction.UserId,
                    BookId = tranzaction.BookId
                };

                tranzactions.Add(tranzactie);
            }
        }
    }
}

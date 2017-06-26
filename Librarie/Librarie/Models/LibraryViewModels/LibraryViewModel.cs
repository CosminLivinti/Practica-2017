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

        public LibraryViewModel()
        {
            informations = new InformationsViewModel();
            books = new List<BookViewModel>();
        }

        public LibraryViewModel(List<Book> books1)
        {
            informations = new InformationsViewModel();
            books = new List<BookViewModel>();
            foreach(var book in books1)
            {
                var bookViewModel = new BookViewModel()
                {
                    id = book.id,
                    title = book.title,
                    author = book.author
                };

                books.Add(bookViewModel);
            }
        }
    }
}

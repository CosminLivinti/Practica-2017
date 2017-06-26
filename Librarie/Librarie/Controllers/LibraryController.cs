using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Librarie.Models;
using Microsoft.AspNetCore.Mvc;
using Librarie.Models.LibraryViewModels;

namespace Librarie.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Index()
        {
            var model = new LibraryViewModel();
            model.informations = new InformationsViewModel();

            BookViewModel book1 = new BookViewModel();
            book1.id = 1; book1.title = "The Autumn Republic"; book1.author = "Brian McClellan";

            BookViewModel book2 = new BookViewModel();
            book2.id = 2; book2.title = "Anna Karenina"; book2.author = "Lev Tolstoi";

            BookViewModel book3 = new BookViewModel();
            book3.id = 3; book3.title = "Hamlet"; book3.author = "William Shakespeare";

            BookViewModel book4 = new BookViewModel();
            book4.id = 4; book4.title = "Norse Mythology"; book4.author = "Neil Gaiman";

            BookViewModel book5 = new BookViewModel();
            book5.id = 5; book5.title = "Caraval"; book5.author = "Stephanie Garber";

            model.books.Add(book1);
            model.books.Add(book2);
            model.books.Add(book3);
            model.books.Add(book4);
            model.books.Add(book5);

            model.informations.NumberOfBooks = model.books.Count;
            model.informations.Date = DateTime.Now;

            return View(model);
        }
    }
}
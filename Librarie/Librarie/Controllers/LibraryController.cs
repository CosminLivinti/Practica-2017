using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Librarie.Models;
using Microsoft.AspNetCore.Mvc;
using Librarie.Models.LibraryViewModels;
using Librarie.Services;

namespace Librarie.Controllers
{
    public class LibraryController : Controller
    {
        private ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
          
        }

        public IActionResult Index()
        {
            var books = _libraryService.getBooks(); //luam cartile din DB prin intermediul unui LibraryService

            var model = new LibraryViewModel(books);

            model.informations.NumberOfBooks = model.books.Count;
            model.informations.Date = DateTime.Now;

            return View(model);
        }
    }
}
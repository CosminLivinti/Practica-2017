using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Librarie.Models;
using Microsoft.AspNetCore.Mvc;
using Librarie.Models.LibraryViewModels;
using Librarie.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Librarie.Controllers
{
    [Authorize]
    public class LibraryController : Controller
    {
 
        private ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
          
        }

        public IActionResult Index()
        {
            var books = _libraryService.GetBooks(); //luam cartile din DB prin intermediul unui LibraryService

            var tranzactions = _libraryService.GetTranzactions();

            var model = new LibraryViewModel(books,tranzactions);

            model.informations.NumberOfBooks = model.books.Count;
            model.informations.Date = DateTime.Now;

            return View(model);
        }

        public IActionResult Borrow(int id)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool isSuccessful = _libraryService.Borrow(userId, id);

            var book = _libraryService.GetBooks().Single(item => item.id == id);

            var borrowViewModel = new BorrowViewModel
            {
                isSuccessful = isSuccessful,
                BookName = book.title
            };

            return View(borrowViewModel);
        }

        public IActionResult Return(int id)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool isSuccessful = _libraryService.Return(id, userId);

            var returnViewModel = new ReturnViewModel()
            {
                IsSuccessful = isSuccessful,
                BookName = _libraryService.GetBooks().Single(t => t.id == id)?.title
        };

            return View(returnViewModel);
        }
    }
}
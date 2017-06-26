using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarie.Models.LibraryViewModels
{
    public class LibraryViewModel
    {
        public InformationsViewModel informations { set; get; }
        public List<BookViewModel> books = new List<BookViewModel>();
    }
}

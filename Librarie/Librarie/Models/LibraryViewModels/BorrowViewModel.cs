using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarie.Models.LibraryViewModels
{
    public class BorrowViewModel
    {
        public bool isSuccessful { get; set; }
        public string BookName { get; set; }
        public int numberOfBooks { get; set; }
    }
}

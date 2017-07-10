using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarie.Data.Entities
{
    public class Book
    {
        public int id { get; set; }
        public String title { get; set; }
        public String author { get; set; }
        public virtual string Type { get; set; }
        public virtual int Score { get; set; }
    }
}

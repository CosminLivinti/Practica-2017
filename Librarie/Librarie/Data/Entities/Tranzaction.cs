using Librarie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librarie.Data.Entities
{
    public class Tranzaction
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int BookId { get; set; }

        public virtual ApplicationUser User { get; set; }
        
        public virtual Book Book { get; set; }
    }
}

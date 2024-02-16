using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RentABook.Models
{
    internal class RentABookDB: DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }

}

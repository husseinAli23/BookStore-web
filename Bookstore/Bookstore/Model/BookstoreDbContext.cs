using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Model
{
    public class BookstoreDbContext:DbContext
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options)
        {
                
        }
        public DbSet<Auther> Auther { get; set; }
        public DbSet<Book> Book { get; set; }
    }
}

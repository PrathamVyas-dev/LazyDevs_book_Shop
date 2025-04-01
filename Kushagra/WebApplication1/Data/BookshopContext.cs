using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace WebApplication1.Data
{
    public class BookshopContext : DbContext
    {
        public BookshopContext(DbContextOptions<BookshopContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
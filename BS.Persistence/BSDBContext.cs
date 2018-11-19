using Microsoft.EntityFrameworkCore;
using BS.Domain.Entities;

namespace BS.Persistence
{
    public class BSDBContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<BookStore> BookStores { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=BookStore.db");
        }
    }
}

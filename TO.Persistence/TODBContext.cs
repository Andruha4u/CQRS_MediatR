using Microsoft.EntityFrameworkCore;
using TO.Domain.Entities;
using TO.Persistence.Extensions;

namespace TO.Persistence
{
    public class TODBContext : DbContext
    {
        public DbSet<AttributeType> AttributeTypes { get; set; }

        public DbSet<AttributeValue> AttributeValues { get; set; }

        public DbSet<Interface> Interfaces { get; set; }

        public DbSet<ObjectItem> ObjectItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=TypeOriented.db");
        }
    }
}

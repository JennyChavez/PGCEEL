using Microsoft.EntityFrameworkCore;
using PGCEEL.Shared.Entities;

namespace PGCELL.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<TypeNovelty> TypeNovelty { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<TypeNovelty>().HasIndex(c => c.Name).IsUnique();
        }
    }
}
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PGCEEL.Shared.Entities;

namespace PGCELL.Backend.Data
{
  

    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Employer> Employers{ get; set; }
        public DbSet<Modality> Modalities{ get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<TypeNovelty> TypesNovelties { get; set; }

        public DbSet<Role> roles { get; set; }

        public DbSet<UserRol> UserRols { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().HasIndex(c => new { c.StateId, c.Name }).IsUnique();
            modelBuilder.Entity<Contract>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Employer>().HasIndex(e => e.Name).IsUnique();
            modelBuilder.Entity<Modality>().HasIndex(m => m.Name).IsUnique();
            modelBuilder.Entity<Pet>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Role>().HasIndex(r => r.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex(s => new { s.CountryId, s.Name }).IsUnique();
            modelBuilder.Entity<TypeNovelty>().HasIndex(t => t.Name).IsUnique();
            modelBuilder.Entity<UserRol>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<Worker>().HasIndex(w => w.Name).IsUnique();
            modelBuilder.Entity<WorkingHours>().HasIndex(w => w.Name).IsUnique();
        }
    }
}
using Microsoft.EntityFrameworkCore;

namespace MyStore
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Departament> Departaments { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Departament>().HasMany(e => e.Employees);
        }
    }
}
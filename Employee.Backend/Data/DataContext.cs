using Employee.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Employee.Backend.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Country> countries { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<EmployeeModel> employees { get; set; }
        public DbSet<State> states { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<City>().HasIndex(x => new { x.Id, x.Name }).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex(x => new { x.Id, x.Name }).IsUnique();
            DisableCascading(modelBuilder);
        }

        private void DisableCascading(ModelBuilder modelBuilder)
        {
            var relationship = modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys());

            foreach (var item in relationship)
            {
                item.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}

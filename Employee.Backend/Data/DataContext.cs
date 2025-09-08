using Employee.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<EmployeeModel> employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeModel>().HasIndex(x => new { x.FirstName, x.LastName }).IsUnique();
        }
    }
}

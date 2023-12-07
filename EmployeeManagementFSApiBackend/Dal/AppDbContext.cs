using EmployeeManagementFSApiBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementFSApiBackend.Dal
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<EState> EStates { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Gender>().ToTable("Gender");
            modelBuilder.Entity<City>().ToTable("City");
            modelBuilder.Entity<EState>().ToTable("EState");
        }
    }
}

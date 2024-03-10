using Microsoft.EntityFrameworkCore;
using PersonnelManagementSystem.API.Infrastructure.Configuration;
using PersonnelManagementSystem.Models.Models;

namespace PersonnelManagementSystem.API.Infrastructure;

public class ManagementDbContext : DbContext
{
    public DbSet<Department> Departments { get; set; } = default!;
    public DbSet<Education> Educations { get; set; } = default!;
    public DbSet<Employee> Employees { get; set; } = default!;
    public DbSet<SalaryIncrease> SalaryIncreases { get; set; } = default!;

    public ManagementDbContext(DbContextOptions<ManagementDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        string connectionString = "Data Source=blogging.db"; // Путь к файлу базы данных SQLite

        optionsBuilder.UseSqlite(connectionString);
    }
}
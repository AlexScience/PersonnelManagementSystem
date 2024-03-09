using Microsoft.EntityFrameworkCore;
using PersonnelManagementSystem.Models.Models;

namespace PersonnelManagementSystem.API.Infrastructure;

public class PersonnelContext : DbContext
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<SalaryIncrease> SalaryIncreases { get; set; }
    
    public string DbPath { get; }

    public PersonnelContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

}
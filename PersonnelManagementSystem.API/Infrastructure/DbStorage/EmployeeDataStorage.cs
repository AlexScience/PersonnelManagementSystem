using PersonnelManagementSystem.Models.Models;

namespace PersonnelManagementSystem.API.Infrastructure.DbStorage;

public class EmployeeDataStorage : IDataStorage<Employee>
{
    private readonly ManagementDbContext _context;

    public EmployeeDataStorage(ManagementDbContext context)
    {
        _context = context;
    }

    public void Save(Employee obj)
    {
        _context.Employees.Add(obj);
        _context.SaveChanges();
    }

    public Employee? Fetch(Guid id)
    {
        return _context.Employees.FirstOrDefault(c => c.Id.Equals(id));
    }

    public IEnumerable<Employee> FetchAll()
    {
        return _context.Employees.ToList();
    }
}
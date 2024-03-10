using PersonnelManagementSystem.API.Infrastructure;
using PersonnelManagementSystem.Models.Models;

namespace PersonnelManagementSystem.API.Services;

public class EmployeeService : IEntityService<Employee>
{
    private readonly IDataStorage<Employee> _employeeStorage;

    public EmployeeService(IDataStorage<Employee> employeeStorage)
    {
        _employeeStorage = employeeStorage;
    }

    public void Create(Employee obj)
    {
        _employeeStorage.Save(obj);
    }

    public IEnumerable<Employee> GetAll()
    {
        return _employeeStorage.FetchAll();
    }

    public Employee? GetById(Guid id)
    {
        return _employeeStorage.Fetch(id);
    }
}
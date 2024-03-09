using PersonnelManagementSystem.Models.Models;

namespace PersonnelManagementSystem.API.Services;

public interface IPersonnelServices
{
    public void AddEmployee(Employee employee);
    public IEnumerable<Employee> GetAllEmployees();
}
using PersonnelManagementSystem.API.Entities;
using PersonnelManagementSystem.API.Models;

namespace PersonnelManagementSystem.API.Services
{
    public interface IEmployeeService : IEntityService<Employee>
    {
        public Task<IEnumerable<Employee>> GetByFilter(EmployeeFilter? filter);
    }
}

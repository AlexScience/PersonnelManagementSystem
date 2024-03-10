using Microsoft.EntityFrameworkCore;
using PersonnelManagementSystem.API.Infrastructure;
using PersonnelManagementSystem.Models.Models;

namespace PersonnelManagementSystem.API.Services;

public sealed class EmployeeService : IEntityService<Employee>
{
    private readonly ManagementDbContext _context;

    public EmployeeService(ManagementDbContext context)
    {
        _context = context;
    }

    public async Task Create(Employee emp)
    {
        await _context.AddAsync(emp);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Employee>> GetAll()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee?> GetById(Guid id)
    {
        return await _context.Employees.FirstOrDefaultAsync(emp => emp.Id == id);
    }
}
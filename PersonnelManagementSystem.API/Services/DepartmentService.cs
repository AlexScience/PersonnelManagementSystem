using Microsoft.EntityFrameworkCore;
using PersonnelManagementSystem.API.Infrastructure;
using PersonnelManagementSystem.Models.Models;

namespace PersonnelManagementSystem.API.Services;

public sealed class DepartmentService : IEntityService<Department>
{
    private readonly ManagementDbContext _context;

    public DepartmentService(ManagementDbContext context)
    {
        _context = context;
    }

    public async Task Create(Department department)
    {
        await _context.AddAsync(department);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Department>> GetAll()
    {
        return await _context.Departments.ToListAsync();
    }

    public async Task<Department?> GetById(Guid id)
    {
        return await _context.Departments.FirstOrDefaultAsync(dep => dep.Id == id);
    }
}
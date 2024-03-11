using Microsoft.EntityFrameworkCore;
using PersonnelManagementSystem.API.Infrastructure;
using PersonnelManagementSystem.API.Entities;

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

    public async Task Delete(Guid id)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department != null)
        {
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            _context.Update(department);
        }
    }

    public async Task Update(Department employee)
    {
        var existingDepartment = await _context.Departments.FindAsync(employee.Id);
    
        if (existingDepartment == null)
        {
            throw new Exception("Отдел не найден.");
        }
    
        existingDepartment.DepartmentName = employee.DepartmentName;

        await _context.SaveChangesAsync();
    }

    
}
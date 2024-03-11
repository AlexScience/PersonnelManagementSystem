using Microsoft.EntityFrameworkCore;
using PersonnelManagementSystem.API.Infrastructure;
using PersonnelManagementSystem.API.Entities;

namespace PersonnelManagementSystem.API.Services;

public class EducationService : IEntityService<Education>
{
    private readonly ManagementDbContext _context;

    public EducationService(ManagementDbContext context)
    {
        _context = context;
    }

    public async Task Create(Education education)
    {
        await _context.AddAsync(education);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Education>> GetAll()
    {
        return await _context.Educations.ToListAsync();
    }

    public async Task<Education?> GetById(Guid id)
    {
        return await _context.Educations.FirstOrDefaultAsync(ed => ed.Id == id);
    }

    public async Task Delete(Guid id)
    {
        var education = await _context.Educations.FindAsync(id);
        if (education != null)
        {
            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Update(Education employee)
    {
        var existingEducation = await _context.Educations.FindAsync(employee.Id);
    
        if (existingEducation == null)
        {
            throw new Exception("Вид образования не найден.");
        }
    
        existingEducation.EducationLevel = employee.EducationLevel;

        await _context.SaveChangesAsync();
    }

   
}
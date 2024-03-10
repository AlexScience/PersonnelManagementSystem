using Microsoft.EntityFrameworkCore;
using PersonnelManagementSystem.API.Infrastructure;
using PersonnelManagementSystem.Models.Models;

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
}
using Microsoft.AspNetCore.Mvc;
using PersonnelManagementSystem.API.Services;
using PersonnelManagementSystem.API.Entities;

namespace PersonnelManagementSystem.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EducationController : ControllerBase
{
    private readonly IEntityService<Education> _educationEntityService;

    public EducationController(IEntityService<Education> educationEntityService)
    {
        _educationEntityService = educationEntityService;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Education>>> GetAll()
    {
        var result = await _educationEntityService.GetAll();
        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<IEnumerable<Education>>> GetById(Guid id)
    {
        var education = await _educationEntityService.GetById(id);
        return education == null ? NotFound("Вид образования не найден") : Ok(education);
    }

    [HttpPost]
    public async Task Create(Education education)
    {
        await _educationEntityService.Create(education);
    }
    
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<IEnumerable<Education>>> Delete(Guid id)
    {
        
        var education = await _educationEntityService.GetById(id);
        if (education == null)
        {
            return NotFound("Вид образования не найден");
        }

        await _educationEntityService.Delete(id);
        return NoContent();            
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, Education education)
    {
        if (id != education.Id)
        {
            return BadRequest("Идентификатор отдела не соответствует.");
        }

        var existingEducation = await _educationEntityService.GetById(id);
        if (existingEducation == null)
        {
            return NotFound("Вид образования не найден.");
        }

        await _educationEntityService.Update(education);
        return Ok();
    }
}
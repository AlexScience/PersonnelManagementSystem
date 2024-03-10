using Microsoft.AspNetCore.Mvc;
using PersonnelManagementSystem.API.Services;
using PersonnelManagementSystem.Models.Models;

namespace PersonnelManagementSystem.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EducationController : ControllerBase
{
    private readonly IEntityService<Education> _educationEntityController;

    public EducationController(IEntityService<Education> educationEntityController)
    {
        _educationEntityController = educationEntityController;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Education>>> GetAll()
    {
        var result = await _educationEntityController.GetAll();
        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<IEnumerable<Education>>> GetById(Guid id)
    {
        var education = await _educationEntityController.GetById(id);
        return education == null ? NotFound("Вид образования не найден") : Ok(education);
    }

    [HttpPost]
    public async Task Create(Education education)
    {
        await _educationEntityController.Create(education);
    }
}
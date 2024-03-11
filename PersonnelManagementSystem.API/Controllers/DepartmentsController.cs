using Microsoft.AspNetCore.Mvc;
using PersonnelManagementSystem.API.Services;
using PersonnelManagementSystem.API.Entities;

namespace PersonnelManagementSystem.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly IEntityService<Department> _departmentEntityService;

    public DepartmentsController(IEntityService<Department> departmentEntityService)
    {
        _departmentEntityService = departmentEntityService;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Department>>> GetAll()
    {
        var result = await _departmentEntityService.GetAll();
        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<IEnumerable<Department>>> GetById(Guid id)
    {
        var department = await _departmentEntityService.GetById(id);
        return department == null ? NotFound("Отдел не найден") : Ok(department);
    }

    [HttpPost]
    public async Task Create(Department department)
    {
        await _departmentEntityService.Create(department);
    }
    
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<IEnumerable<Department>>> Delete(Guid id)
    {
        
        var department = await _departmentEntityService.GetById(id);
        if (department == null)
        {
            return NotFound("Отдел не найден");
        }

        await _departmentEntityService.Delete(id);
        return NoContent();            
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, Department department)
    {
        if (id != department.Id)
        {
            return BadRequest("Идентификатор отдела не соответствует.");
        }

        var existingDepartment = await _departmentEntityService.GetById(id);
        if (existingDepartment == null)
        {
            return NotFound("Отдел не найден.");
        }

        await _departmentEntityService.Update(department);
        return Ok();
    }
    
}
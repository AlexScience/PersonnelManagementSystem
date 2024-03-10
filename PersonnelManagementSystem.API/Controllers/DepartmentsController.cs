using Microsoft.AspNetCore.Mvc;
using PersonnelManagementSystem.API.Services;
using PersonnelManagementSystem.Models.Models;

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
}
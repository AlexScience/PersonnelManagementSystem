using Microsoft.AspNetCore.Mvc;
using PersonnelManagementSystem.API.Services;
using PersonnelManagementSystem.Models.Models;

namespace PersonnelManagementSystem.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEntityService<Employee> _employeeEntityService;

    public EmployeeController(IEntityService<Employee> employeeEntityService)
    {
        _employeeEntityService = employeeEntityService;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
    {
        var employees = await _employeeEntityService.GetAll();
        return Ok(employees);
    }

    [HttpGet("/{id:guid}")]
    public async Task<ActionResult<IEnumerable<Employee>>> GetById(Guid id)
    {
        var employee = await _employeeEntityService.GetById(id);
        return employee == null ? NotFound("Работник не найден") : Ok(employee);
    }

    [HttpPost]
    public async Task Create(Employee employee)
    {
        await _employeeEntityService.Create(employee);
    }
}
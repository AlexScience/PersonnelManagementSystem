using Microsoft.AspNetCore.Mvc;
using PersonnelManagementSystem.API.Services;
using PersonnelManagementSystem.API.Entities;
using PersonnelManagementSystem.API.Models;

namespace PersonnelManagementSystem.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeEntityService;
    private readonly IReportService _reportService;

    public EmployeeController(IEmployeeService employeeEntityService,IReportService reportService)
    {
        _employeeEntityService = employeeEntityService;
        _reportService = reportService;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
    {
        var employees = await _employeeEntityService.GetAll();
        return Ok(employees);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<IEnumerable<Employee>>> GetById(Guid id)
    {
        var employee = await _employeeEntityService.GetById(id);
        return employee == null ? NotFound("Работник не найден") : Ok(employee);
    }

    [HttpGet("filter")]
    public async Task<ActionResult<IEnumerable<Employee>>> GetByFilter([FromQuery]EmployeeFilter filter)
    {
        var result = await _employeeEntityService.GetByFilter(filter);
        return Ok(result);
    }

    [HttpPost]
    public async Task Create(Employee employee)
    {
        await _employeeEntityService.Create(employee);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<IEnumerable<Employee>>> Delete(Guid id)
    {
        
        var employee = await _employeeEntityService.GetById(id);
        if (employee == null)
        {
            return NotFound("Работник не найден");
        }

        await _employeeEntityService.Delete(id);
        return NoContent();            
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, Employee employee)
    {
        if (id != employee.Id)
        {
            return BadRequest("Идентификатор сотрудника не соответствует.");
        }

        var existingEmployee = await _employeeEntityService.GetById(id);
        if (existingEmployee == null)
        {
            return NotFound("Сотрудник не найден.");
        }

        await _employeeEntityService.Update(employee);
        return Ok();
    }
    
    [HttpGet("report")]
    public async Task<IActionResult> GenerateReport()
    {
        try
        {
            var reportBytes = await _reportService.GenerateReport();
            return File(reportBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "EmployeeReport.xlsx");
        }
        catch (Exception ex)
        {
            return BadRequest($"Ошибка при создании отчета: {ex.Message}");
        }
    }
}
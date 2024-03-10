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
    public ActionResult<IEnumerable<Employee>> GetAllEmployee()
    {
        var employees = _employeeEntityService.GetAll();
        return Ok(employees);
    }

    [HttpGet("id")]
    public ActionResult<IEnumerable<Employee>> GetEmployeeById(Guid employeeId)
    {
        var employee = _employeeEntityService.GetById(employeeId);
        return employee == null ? NotFound("Работник не найден") : Ok(employee);
    }

    [HttpPost]
    public void CreateEmployee(Employee employee)
    {
        _employeeEntityService.Create(employee);
    }

}
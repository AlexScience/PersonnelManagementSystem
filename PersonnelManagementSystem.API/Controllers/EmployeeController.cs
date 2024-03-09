using Microsoft.AspNetCore.Mvc;
using PersonnelManagementSystem.Models.Models;

namespace PersonnelManagementSystem.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Employee>> GetAllEmployee()
    {
        return Ok(new List<Employee>());
    }

}
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using PersonnelManagementSystem.API.Infrastructure;
using PersonnelManagementSystem.API.Entities;
using PersonnelManagementSystem.API.Models;

namespace PersonnelManagementSystem.API.Services;

public sealed class EmployeeService : IEmployeeService, IReportService
{
    private readonly ManagementDbContext _context;

    public EmployeeService(ManagementDbContext context)
    {
        _context = context;
    }

    public async Task Create(Employee emp)
    {
        await _context.AddAsync(emp);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Employee>> GetAll()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<IEnumerable<Employee>> GetByFilter(EmployeeFilter? filter)
    {
        var employees = _context.Employees.AsQueryable();

        if (filter?.DepartmentId != null)
        {
            employees = employees.Where(emp => emp.DepartmentId == filter.DepartmentId);
        }

        if (filter?.PartialName != null)
        {
            employees = employees.Where(emp => EF.Functions.Like(emp.FullName, $"%{filter.PartialName}%"));
        }

        if (filter?.HireDateFrom != null)
        {
            employees = employees.Where(emp => emp.HireDate >= filter.HireDateFrom);
        }

        if (filter?.HireDateTo != null)
        {
            employees = employees.Where(emp => emp.HireDate <= filter.HireDateFrom);
        }

        if (filter?.FireDateFrom != null)
        {
            employees = employees.Where(emp => emp.FireDate >= filter.FireDateFrom);
        }

        if (filter?.FireDateTo != null)
        {
            employees = employees.Where(emp => emp.FireDate <= filter.FireDateTo);
        }

        var result = await employees.ToListAsync();

        return result;
    }

    public async Task<Employee?> GetById(Guid id)
    {
        return await _context.Employees.FirstOrDefaultAsync(emp => emp.Id == id);
    }

    public async Task Delete(Guid id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Update(Employee employee)
    {
        var existingEmployee = await _context.Employees.FindAsync(employee.Id);

        if (existingEmployee == null)
        {
            throw new Exception("Сотрудник не найден.");
        }

        existingEmployee.DepartmentId = employee.DepartmentId;

        await _context.SaveChangesAsync();
    }

    public async Task<byte[]> GenerateReport()
    {
        var employees = await _context.Employees
            .Include(e => e.Department)
            .Include(e => e.Education)
            .ToListAsync();

        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Employees");

            worksheet.Cell(1, 1).Value = "Employee Id";
            worksheet.Cell(1, 2).Value = "Full Name";
            worksheet.Cell(1, 3).Value = "Department";
            worksheet.Cell(1, 4).Value = "Education";
            worksheet.Cell(1, 5).Value = "Date of Birth";
            worksheet.Cell(1, 6).Value = "Date of Hire";
            worksheet.Cell(1, 7).Value = "Date of Termination";

            var row = 2;
            foreach (var employee in employees)
            {
                worksheet.Cell(row, 1).Value = employee.Id.ToString(); // Convert Guid to string
                worksheet.Cell(row, 2).Value = employee.FullName;
                worksheet.Cell(row, 3).Value = employee.Department?.DepartmentName ?? "N/A";
                worksheet.Cell(row, 4).Value = employee.Education?.EducationLevel ?? "N/A";
                worksheet.Cell(row, 5).Value = employee.BirthDate;
                worksheet.Cell(row, 6).Value = employee.HireDate;
                worksheet.Cell(row, 7).Value = employee.FireDate.HasValue ? employee.FireDate.ToString() : "N/A";

                row++;
            }

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                return stream.ToArray();
            }
        }
    }
}
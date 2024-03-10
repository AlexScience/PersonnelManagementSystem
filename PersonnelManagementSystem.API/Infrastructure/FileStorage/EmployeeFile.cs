using PersonnelManagementSystem.Models.Models;

namespace PersonnelManagementSystem.API.Infrastructure.FileStorage;

public class EmployeeFile : FileDataStorage<Employee>
{
    private const string Path = "Data Source=blogging.db";

    protected EmployeeFile(string path) : base(path)
    {
    }
}
using System.Text.Json.Serialization;

namespace PersonnelManagementSystem.API.Entities;

public record Employee : IEntity
{
    public Guid Id { get; init; }
    public int EmployeeNumber { get; init; }
    public string FullName { get; init; } = string.Empty;
    public Gender EmployeeGender { get; init; }
    public DateTime BirthDate { get; init; }
    public DateTime HireDate { get; init; }
    public DateTime? FireDate { get; set; }
  
    public Guid DepartmentId { get; set; }

    [JsonIgnore]
    public Department? Department { get; set; }
    
    public Guid EducationId { get; set; }

    [JsonIgnore]
    public Education? Education { get; set; }
}
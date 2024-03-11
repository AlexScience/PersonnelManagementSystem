namespace PersonnelManagementSystem.API.Entities;

public record Employee : IEntity
{
    public Guid Id { get; init; }
    public int EmployeeNumber { get; init; }
    public string FullName { get; init; } = string.Empty;
    public Gender EmployeeGender { get; init; }
    public DateTime DateBirth { get; init; }
    public DateTime DateHire { get; init; }
    public DateTime? DateTermination { get; set; }
  
    public Guid DepartmentId { get; set; }
    public Department Department { get; set; }
    
    public Guid EducationId { get; set; }
    public Education Education { get; set; }
}
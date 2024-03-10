namespace PersonnelManagementSystem.Models.Models;

public record Employee : IEntity
{
    public Guid Id { get; init; }
    public Guid EmployeeNumber { get; init; }
    public string FullName { get; init; } = string.Empty;
    public Gender EmployeeGender { get; init; }
    public DateTime DateBirth { get; init; }
    public Department Department { get; set; }
    public Education Education { get; set; }
    public DateTime DateHire { get; init; }
    public DateTime? DateTermination { get; set; }
}
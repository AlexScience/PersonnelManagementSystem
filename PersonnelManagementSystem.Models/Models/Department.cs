namespace PersonnelManagementSystem.Models.Models;

public record Department : IEntity
{
    public Guid Id { get; init; }
    public string DepartmentName { get; init; } = string.Empty;
}
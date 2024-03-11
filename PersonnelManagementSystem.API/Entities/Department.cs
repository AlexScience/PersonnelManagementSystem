namespace PersonnelManagementSystem.API.Entities;

public record Department : IEntity
{
    public Guid Id { get; init; }
    public string DepartmentName { get; set; } = string.Empty;
}
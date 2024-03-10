namespace PersonnelManagementSystem.Models.Models;

public record Education : IEntity
{
    public Guid Id { get; init; }
    public string EducationLevel { get; set; } = string.Empty;
}
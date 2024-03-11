namespace PersonnelManagementSystem.API.Entities;

public record SalaryIncrease : IEntity
{
    public Guid Id { get; init; }
    public Guid EmployeeId { get; init; }
    public decimal SalaryIncreasePercentage { get; set; }
    
}
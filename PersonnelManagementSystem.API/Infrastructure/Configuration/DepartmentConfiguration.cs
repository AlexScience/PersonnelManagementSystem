using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelManagementSystem.Models.Models;

namespace PersonnelManagementSystem.API.Infrastructure.Configuration;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("department");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id").IsRequired();
        
        builder.Property(e => e.DepartmentName).HasColumnName("department_name").IsRequired();

        builder.HasMany<Employee>()
            .WithOne(e => e.Department)
            .HasForeignKey(e => e.DepartmentId)
            .HasPrincipalKey(e => e.Id);
    }
}
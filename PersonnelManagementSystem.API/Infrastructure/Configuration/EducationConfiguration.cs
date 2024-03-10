using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelManagementSystem.Models.Models;

namespace PersonnelManagementSystem.API.Infrastructure.Configuration;

public class EducationConfiguration : IEntityTypeConfiguration<Education>
{
    public void Configure(EntityTypeBuilder<Education> builder)
    {
        builder.ToTable("education");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        
        builder.Property(e => e.EducationLevel).HasColumnName("EmployeeNumber").IsRequired();
        builder.Property(e => e.EmployeeId).HasColumnName("EmployeeId").IsRequired();

    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelManagementSystem.Models.Models;

namespace PersonnelManagementSystem.API.Infrastructure.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("employees");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id").IsRequired();

        builder.Property(e => e.EmployeeNumber).HasColumnName("employee_number").IsRequired();
        builder.Property(e => e.FullName).HasColumnName("full_name").IsRequired();
        builder.Property(e => e.EmployeeGender).HasColumnName("employee_gender").IsRequired();
        builder.Property(e => e.DateBirth).HasColumnName("date_birth").IsRequired();
        builder.Property(e => e.DateHire).HasColumnName("date_hire").IsRequired();
        builder.Property(e => e.DateTermination).HasColumnName("date_termination");
    }
}
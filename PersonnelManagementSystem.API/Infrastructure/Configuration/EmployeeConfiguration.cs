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
        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

        builder.Property(e => e.EmployeeNumber).HasColumnName("EmployeeNumber").IsRequired();
        builder.Property(e => e.FullName).HasColumnName("FullName").IsRequired();
        builder.Property(e => e.EmployeeGender).HasColumnName("EmployeeGender").IsRequired();
        builder.Property(e => e.DateBirth).HasColumnName("DateBirth").IsRequired();
        builder.Property(e => e.DateHire).HasColumnName("DateHire").IsRequired();
        builder.Property(e => e.DateTermination).HasColumnName("DateTermination");

        builder.HasOne(e => e.Department)
            .WithOne()
            .HasForeignKey(e => e.Id)
            .IsRequired();
        
        // Настройка связи с образованием (Education)
        builder.HasOne(e => e.Education)
            .WithOne(e => e.Employee)
            .HasForeignKey(e => e.Id)
            .IsRequired();
    }
}
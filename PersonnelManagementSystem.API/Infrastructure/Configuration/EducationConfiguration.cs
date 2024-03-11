using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelManagementSystem.API.Entities;

namespace PersonnelManagementSystem.API.Infrastructure.Configuration;

public class EducationConfiguration : IEntityTypeConfiguration<Education>
{
    public void Configure(EntityTypeBuilder<Education> builder)
    {
        builder.ToTable("education");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id").IsRequired();
        
        builder.Property(e => e.EducationLevel).HasColumnName("education_level").IsRequired();

        builder.HasMany<Employee>()
            .WithOne(e => e.Education)
            .HasForeignKey(e => e.EducationId)
            .HasPrincipalKey(e => e.Id);
    }
}
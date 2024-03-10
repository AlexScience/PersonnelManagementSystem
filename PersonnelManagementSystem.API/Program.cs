using Microsoft.EntityFrameworkCore;
using PersonnelManagementSystem.API.Infrastructure;
using PersonnelManagementSystem.API.Services;
using PersonnelManagementSystem.Models.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ManagementDbContext>((options) => { options.UseSqlite("Data Source=employees.db"); });

builder.Services.AddScoped<IEntityService<Employee>, EmployeeService>();
builder.Services.AddScoped<IEntityService<Education>, EducationService>();
builder.Services.AddScoped<IEntityService<Department>, DepartmentService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
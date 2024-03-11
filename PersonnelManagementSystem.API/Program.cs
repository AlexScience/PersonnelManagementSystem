using Microsoft.EntityFrameworkCore;
using PersonnelManagementSystem.API.Infrastructure;
using PersonnelManagementSystem.API.Services;
using PersonnelManagementSystem.API.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ManagementDbContext>((options) => { options.UseSqlite("Data Source=employees.db"); });

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEntityService<Education>, EducationService>();
builder.Services.AddScoped<IEntityService<Department>, DepartmentService>();

builder.Services.AddScoped<IReportService, EmployeeService>();


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
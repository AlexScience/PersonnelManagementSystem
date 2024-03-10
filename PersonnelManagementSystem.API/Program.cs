using Microsoft.EntityFrameworkCore;
using PersonnelManagementSystem.API.Infrastructure;
using PersonnelManagementSystem.API.Infrastructure.DbStorage;
using PersonnelManagementSystem.API.Infrastructure.FileStorage;
using PersonnelManagementSystem.API.Services;
using PersonnelManagementSystem.Models.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ManagementDbContext>((options) => { options.UseSqlite("Data Source=blogging.db"); });

builder.Services.AddScoped<IDataStorage<Employee>, EmployeeDataStorage>();
builder.Services.AddScoped<IEntityService<Employee>, EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonnelManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    employee_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    department_name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.id);
                    table.UniqueConstraint("AK_department_employee_id", x => x.employee_id);
                });

            migrationBuilder.CreateTable(
                name: "education",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    employee_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    employee_number = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_education", x => x.id);
                    table.UniqueConstraint("AK_education_employee_id", x => x.employee_id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryIncreases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SalaryIncreasePercentage = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryIncreases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    employee_number = table.Column<Guid>(type: "TEXT", nullable: false),
                    full_name = table.Column<string>(type: "TEXT", nullable: false),
                    employee_gender = table.Column<int>(type: "INTEGER", nullable: false),
                    date_birth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    date_hire = table.Column<DateTime>(type: "TEXT", nullable: false),
                    date_termination = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.id);
                    table.ForeignKey(
                        name: "FK_employees_department_id",
                        column: x => x.id,
                        principalTable: "department",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employees_education_id",
                        column: x => x.id,
                        principalTable: "education",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "SalaryIncreases");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "education");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagment.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "HR" },
                    { 3, "Management" },
                    { 4, "Travel" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateOfBirth", "DepartmentId", "Email", "FirstName", "Gender", "LastName", "PhotoPath" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "tsreenu.9@gmail.com", "Sreenu", 0, "Thuraka", "images/sreenu.jpeg" },
                    { 2, new DateTime(1990, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "tsreenu.9@gmail.com", "Sreenu", 0, "Thuraka", "images/sreenu.jpeg" },
                    { 3, new DateTime(1990, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "tsreenu.9@gmail.com", "Sreenu", 0, "Thuraka", "images/sreenu.jpeg" },
                    { 4, new DateTime(1990, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "tsreenu.9@gmail.com", "Sreenu", 0, "Thuraka", "images/sreenu.jpeg" },
                    { 5, new DateTime(1990, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "tsreenu.9@gmail.com", "Sreenu", 0, "Thuraka", "images/sreenu.jpeg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}

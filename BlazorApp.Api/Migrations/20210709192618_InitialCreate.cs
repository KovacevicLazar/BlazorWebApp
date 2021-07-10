using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "Name" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "HR" },
                    { 3, "Admin" },
                    { 4, "Management" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "DateOfBirth", "DepartmentID", "Email", "FirstName", "Gender", "LastName", "PhotoPath" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 7, 9, 21, 26, 17, 756, DateTimeKind.Local).AddTicks(3755), 1, "andrea@gmail.com", "Andrea", 1, "Johnson", "images/andrea.png" },
                    { 2, new DateTime(2021, 7, 9, 21, 26, 17, 762, DateTimeKind.Local).AddTicks(3738), 2, "tom@gmail.com", "Tommy", 1, "Tom", "images/tom.jpg" },
                    { 3, new DateTime(2021, 7, 9, 21, 26, 17, 762, DateTimeKind.Local).AddTicks(4137), 3, "niko@gmail.com", "Niko", 1, "Devis", "images/niko.jpg" },
                    { 4, new DateTime(2021, 7, 9, 21, 26, 17, 762, DateTimeKind.Local).AddTicks(4216), 3, "alex@gmail.com", "Alex", 1, "Greg", "images/alex.jpg" }
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

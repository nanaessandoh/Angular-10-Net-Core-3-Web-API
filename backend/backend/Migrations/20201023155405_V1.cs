using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepartmentName = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeName = table.Column<string>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    DOJ = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "CreatedOn", "DepartmentName" },
                values: new object[] { 1, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "CreatedOn", "DepartmentName" },
                values: new object[] { 2, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Audit" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "CreatedOn", "DepartmentName" },
                values: new object[] { 3, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accounts" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "CreatedOn", "DepartmentName" },
                values: new object[] { 4, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "HR" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "CreatedOn", "DepartmentName" },
                values: new object[] { 5, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marketing" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "DOB", "DOJ", "DepartmentId", "EmployeeName", "Gender" },
                values: new object[] { 1, new DateTime(2000, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karl Reit", "Male" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "DOB", "DOJ", "DepartmentId", "EmployeeName", "Gender" },
                values: new object[] { 2, new DateTime(1995, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Catty Floyd", "Female" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "DOB", "DOJ", "DepartmentId", "EmployeeName", "Gender" },
                values: new object[] { 3, new DateTime(1995, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Jimmy Trudeau", "Male" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "DOB", "DOJ", "DepartmentId", "EmployeeName", "Gender" },
                values: new object[] { 4, new DateTime(1997, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Linda Oltah", "Female" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "DOB", "DOJ", "DepartmentId", "EmployeeName", "Gender" },
                values: new object[] { 5, new DateTime(2003, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Steven Reeves", "Male" });
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

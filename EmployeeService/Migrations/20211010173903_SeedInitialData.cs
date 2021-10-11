using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeService.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Technical" },
                    { 2, "Human Resources" },
                    { 3, "Finance" },
                    { 4, "Admin" },
                    { 5, "Help Desk" }
                });

            migrationBuilder.InsertData(
                table: "Designations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "A", "CEO" },
                    { "B", "CTO" },
                    { "C", "Delivery Manager" },
                    { "D", "Manager" },
                    { "E", "Lead" },
                    { "F", "Senior Engineer" },
                    { "G", "Engineer" },
                    { "H", "Junior Engineer" }
                });

            migrationBuilder.InsertData(
                table: "EmploymentTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Permanent" },
                    { 2, "Contract" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "DepartmentId", "EmploymentTypeId", "FirstName", "Grade", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Ashwin", "E", "Gatadi" },
                    { 3, new DateTime(1993, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, "Shalini", "D", "Hazari" },
                    { 4, new DateTime(1986, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, "Sheetal", "G", "Bhosale" },
                    { 5, new DateTime(1977, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Kaustubh", "C", "Kulkarni" },
                    { 2, new DateTime(1987, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Aditya", "D", "Kiran" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "Id",
                keyValue: "A");

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "Id",
                keyValue: "B");

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "Id",
                keyValue: "F");

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "Id",
                keyValue: "H");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "Id",
                keyValue: "C");

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "Id",
                keyValue: "D");

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "Id",
                keyValue: "E");

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "Id",
                keyValue: "G");

            migrationBuilder.DeleteData(
                table: "EmploymentTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmploymentTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

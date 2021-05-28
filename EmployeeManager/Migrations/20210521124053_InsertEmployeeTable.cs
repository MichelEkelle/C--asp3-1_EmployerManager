using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManager.Migrations
{
    public partial class InsertEmployeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmployeeDbSet",
                columns: new[] { "Id", "Department", "Email", "Name" },
                values: new object[] { 1, 1, "michel@logient.ca", "Michel" });

            migrationBuilder.InsertData(
                table: "EmployeeDbSet",
                columns: new[] { "Id", "Department", "Email", "Name" },
                values: new object[] { 2, 1, "adrien@logient.ca", "Adrien" });

            migrationBuilder.InsertData(
                table: "EmployeeDbSet",
                columns: new[] { "Id", "Department", "Email", "Name" },
                values: new object[] { 3, 1, "sophie@logient.ca", "Sophie" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeDbSet",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmployeeDbSet",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmployeeDbSet",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManager.Migrations
{
    public partial class RemoveHasDataElts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmployeeDbSet",
                columns: new[] { "Id", "Department", "Email", "Name", "Photopath" },
                values: new object[] { 1, 1, "michel@logient.ca", "Michel", null });

            migrationBuilder.InsertData(
                table: "EmployeeDbSet",
                columns: new[] { "Id", "Department", "Email", "Name", "Photopath" },
                values: new object[] { 2, 1, "adrien@logient.ca", "Adrien", null });

            migrationBuilder.InsertData(
                table: "EmployeeDbSet",
                columns: new[] { "Id", "Department", "Email", "Name", "Photopath" },
                values: new object[] { 3, 1, "sophie@logient.ca", "Sophie", null });
        }
    }
}

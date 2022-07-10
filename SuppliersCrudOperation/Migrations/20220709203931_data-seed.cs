using Microsoft.EntityFrameworkCore.Migrations;

namespace SuppliersCrudOperation.Migrations
{
    public partial class dataseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Governorates",
                columns: new[] { "Id", "Name", "Order" },
                values: new object[,]
                {
                    { 1L, "Cairo", 1 },
                    { 2L, "Alex", 2 },
                    { 3L, "Contractor", 3 }
                });

            migrationBuilder.InsertData(
                table: "SupplierTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Manufacturer" },
                    { 2L, "Importer" },
                    { 3L, "Contractor" },
                    { 4L, "Distriputer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "SupplierTypes",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "SupplierTypes",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "SupplierTypes",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "SupplierTypes",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}

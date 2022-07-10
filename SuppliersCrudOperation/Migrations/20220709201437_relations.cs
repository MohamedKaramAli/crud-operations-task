using Microsoft.EntityFrameworkCore.Migrations;

namespace SuppliersCrudOperation.Migrations
{
    public partial class relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_GovernorateId",
                table: "Suppliers",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_TypeId",
                table: "Suppliers",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Governorates_GovernorateId",
                table: "Suppliers",
                column: "GovernorateId",
                principalTable: "Governorates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_SupplierTypes_TypeId",
                table: "Suppliers",
                column: "TypeId",
                principalTable: "SupplierTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Governorates_GovernorateId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_SupplierTypes_TypeId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_GovernorateId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_TypeId",
                table: "Suppliers");
        }
    }
}

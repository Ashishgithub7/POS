using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedSupplierFromSalesDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Suppliers_SupplierId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_SupplierId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Sales");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_SupplierId",
                table: "Sales",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Suppliers_SupplierId",
                table: "Sales",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }
    }
}

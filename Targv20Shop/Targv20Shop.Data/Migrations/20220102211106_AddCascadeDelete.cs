using Microsoft.EntityFrameworkCore.Migrations;

namespace Targv20Shop.Data.Migrations
{
    public partial class AddCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExistingFilePath_Car_CarId",
                table: "ExistingFilePath");

            migrationBuilder.DropForeignKey(
                name: "FK_ExistingFilePath_Product_ProductId",
                table: "ExistingFilePath");

            migrationBuilder.AddForeignKey(
                name: "FK_ExistingFilePath_Car_CarId",
                table: "ExistingFilePath",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExistingFilePath_Product_ProductId",
                table: "ExistingFilePath",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExistingFilePath_Car_CarId",
                table: "ExistingFilePath");

            migrationBuilder.DropForeignKey(
                name: "FK_ExistingFilePath_Product_ProductId",
                table: "ExistingFilePath");

            migrationBuilder.AddForeignKey(
                name: "FK_ExistingFilePath_Car_CarId",
                table: "ExistingFilePath",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExistingFilePath_Product_ProductId",
                table: "ExistingFilePath",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

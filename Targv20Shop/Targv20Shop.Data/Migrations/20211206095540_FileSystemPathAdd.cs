using Microsoft.EntityFrameworkCore.Migrations;

namespace Targv20Shop.Data.Migrations
{
    public partial class FileSystemPathAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ExistingFilePath_CarId",
                table: "ExistingFilePath",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExistingFilePath_Car_CarId",
                table: "ExistingFilePath",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExistingFilePath_Car_CarId",
                table: "ExistingFilePath");

            migrationBuilder.DropIndex(
                name: "IX_ExistingFilePath_CarId",
                table: "ExistingFilePath");
        }
    }
}

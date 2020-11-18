using Microsoft.EntityFrameworkCore.Migrations;

namespace Example.API.Migrations
{
    public partial class RenameElementsTable : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Elements",
                table: "Elements");

            migrationBuilder.RenameTable(
                name: "Elements",
                newName: "elements");

            migrationBuilder.RenameIndex(
                name: "IX_Elements_Id",
                table: "elements",
                newName: "IX_elements_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_elements",
                table: "elements",
                column: "Id");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_elements",
                table: "elements");

            migrationBuilder.RenameTable(
                name: "elements",
                newName: "Elements");

            migrationBuilder.RenameIndex(
                name: "IX_elements_Id",
                table: "Elements",
                newName: "IX_Elements_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Elements",
                table: "Elements",
                column: "Id");
        }
    }
}

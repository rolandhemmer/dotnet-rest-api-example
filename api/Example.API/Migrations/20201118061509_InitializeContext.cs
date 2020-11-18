using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Example.API.Migrations
{
    public partial class InitializeContext : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "elements");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "elements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_elements", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_elements_Id",
                table: "elements",
                column: "Id",
                unique: true);
        }
    }
}

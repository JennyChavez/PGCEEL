using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PGCELL.Backend.Migrations
{
    /// <inheritdoc />
    public partial class correctionTypeNoveltyEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeNovelty",
                table: "TypeNovelty");

            migrationBuilder.RenameTable(
                name: "TypeNovelty",
                newName: "TypesNovelties");

            migrationBuilder.RenameIndex(
                name: "IX_TypeNovelty_Name",
                table: "TypesNovelties",
                newName: "IX_TypesNovelties_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypesNovelties",
                table: "TypesNovelties",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TypesNovelties",
                table: "TypesNovelties");

            migrationBuilder.RenameTable(
                name: "TypesNovelties",
                newName: "TypeNovelty");

            migrationBuilder.RenameIndex(
                name: "IX_TypesNovelties_Name",
                table: "TypeNovelty",
                newName: "IX_TypeNovelty_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeNovelty",
                table: "TypeNovelty",
                column: "Id");
        }
    }
}

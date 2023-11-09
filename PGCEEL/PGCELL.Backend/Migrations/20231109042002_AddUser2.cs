using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PGCELL.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "roles");

            migrationBuilder.RenameIndex(
                name: "IX_Role_Name",
                table: "roles",
                newName: "IX_roles_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Role");

            migrationBuilder.RenameIndex(
                name: "IX_roles_Name",
                table: "Role",
                newName: "IX_Role_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");
        }
    }
}

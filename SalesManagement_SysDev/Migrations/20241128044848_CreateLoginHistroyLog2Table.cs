using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesManagement_SysDev.Migrations
{
    /// <inheritdoc />
    public partial class CreateLoginHistroyLog2Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginHistroyLog2",
                table: "LoginHistroyLog2");

            migrationBuilder.RenameTable(
                name: "LoginHistroyLog2",
                newName: "LoginHistroyLog2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginHistroyLog2",
                table: "LoginHistroyLog2",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginHistroyLog2",
                table: "LoginHistroyLog2");

            migrationBuilder.RenameTable(
                name: "LoginHistroyLog2",
                newName: "LoginHistroyLog2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginHistroyLog2",
                table: "LoginHistroyLog2",
                column: "ID");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesManagement_SysDev.Migrations
{
    /// <inheritdoc />
    public partial class AddLoginHistoryLogTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginHistoryLog");

            migrationBuilder.CreateTable(
                name: "LoginHistoryLogs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSuccessful = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginHistoryLogs", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginHistoryLogs");

            migrationBuilder.CreateTable(
                name: "LoginHistoryLog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSuccessful = table.Column<int>(type: "int", nullable: false),
                    LoginDateTime = table.Column<DateTime>(type: "date", nullable: false),
                    LoginID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}

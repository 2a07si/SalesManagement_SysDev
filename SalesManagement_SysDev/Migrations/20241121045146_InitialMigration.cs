using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesManagement_SysDev.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginHistoryLog");

            migrationBuilder.AlterColumn<int>(
                name: "PrFlag",
                table: "M_Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PrFlag",
                table: "M_Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "LoginHistoryLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginEmId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LoginEmName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LoginTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginHistoryLog", x => x.Id);
                });
        }
    }
}

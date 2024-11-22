using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesManagement_SysDev.Migrations
{
    /// <inheritdoc />
    public partial class AddLoginHistoryLogDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginHistoryLogDetails",
                columns: table => new
                {
                    DetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<int>(type: "int", nullable: false),
                    Display = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Process = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogID = table.Column<int>(type: "int", nullable: false),
                    AcceptDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginHistoryLogDetails", x => x.DetailID);
                    table.ForeignKey(
                        name: "FK_LoginHistoryLogDetails_LoginHistoryLog_ID",
                        column: x => x.ID,
                        principalTable: "LoginHistoryLog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoginHistoryLogDetails_ID",
                table: "LoginHistoryLogDetails",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginHistoryLogDetails");
        }
    }
}

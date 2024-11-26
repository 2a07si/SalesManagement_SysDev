using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesManagement_SysDev.Migrations
{
    /// <inheritdoc /> 
    public partial class CreateNyuukoCheckerTable : Migration
    {
        /// <inheritdoc /> 
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // NyuukoCheckerテーブルの作成
            migrationBuilder.CreateTable(
                name: "NyuukoCheckers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SyukkoID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JyutyuID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Flag = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DelFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NyuukoCheckers", x => x.ID);
                });
        }

        /// <inheritdoc /> 
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // NyuukoCheckerテーブルの削除
            migrationBuilder.DropTable(
                name: "NyuukoCheckers"
            );
        }
    }
}

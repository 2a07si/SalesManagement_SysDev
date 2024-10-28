using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesManagement_SysDev.Migrations
{
    /// <inheritdoc />
    public partial class CreateLoginHistoryLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginHistoryLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LoginDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsSuccessful = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginHistoryLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M_MajorClassification",
                columns: table => new
                {
                    McID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    McName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    McFlag = table.Column<int>(type: "int", nullable: false),
                    McHidden = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__M_MajorC__27B1E232B6CE2E6D", x => x.McID);
                });

            migrationBuilder.CreateTable(
                name: "M_Maker",
                columns: table => new
                {
                    MaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaPhone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    MaPostal = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    MaFAX = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    MaFlag = table.Column<int>(type: "int", nullable: false),
                    MaHidden = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__M_Maker__2725BF40FEBFC979", x => x.MaID);
                });

            migrationBuilder.CreateTable(
                name: "M_Position",
                columns: table => new
                {
                    PoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PoFlag = table.Column<int>(type: "int", nullable: false),
                    PoHidden = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__M_Positi__A4C01F9E8A03A2CA", x => x.PoID);
                });

            migrationBuilder.CreateTable(
                name: "M_SalesOffice",
                columns: table => new
                {
                    SoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoPhone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    SoPostal = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    SoFAX = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    SoFlag = table.Column<int>(type: "int", nullable: false),
                    SoHidden = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__M_SalesO__BC3C9374243FA851", x => x.SoID);
                });

            migrationBuilder.CreateTable(
                name: "M_SmallClassification",
                columns: table => new
                {
                    ScID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    McID = table.Column<int>(type: "int", nullable: false),
                    ScName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ScFlag = table.Column<int>(type: "int", nullable: false),
                    ScHidden = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__M_SmallC__ACB791BA805D9A7F", x => x.ScID);
                    table.ForeignKey(
                        name: "FK_M_SmallClassification_ToM_MajorClassification",
                        column: x => x.McID,
                        principalTable: "M_MajorClassification",
                        principalColumn: "McID");
                });

            migrationBuilder.CreateTable(
                name: "M_Client",
                columns: table => new
                {
                    ClID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoID = table.Column<int>(type: "int", nullable: false),
                    ClName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClPhone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    ClPostal = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    ClFAX = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    ClFlag = table.Column<int>(type: "int", nullable: false),
                    ClHidden = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__M_Client__B1FCF8D58C35E4D2", x => x.ClID);
                    table.ForeignKey(
                        name: "FK_M_Client_ToM_SalesOffice",
                        column: x => x.SoID,
                        principalTable: "M_SalesOffice",
                        principalColumn: "SoID");
                });

            migrationBuilder.CreateTable(
                name: "M_Employee",
                columns: table => new
                {
                    EmID = table.Column<int>(type: "int", nullable: false),
                    EmName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoID = table.Column<int>(type: "int", nullable: false),
                    PoID = table.Column<int>(type: "int", nullable: false),
                    EmHiredate = table.Column<DateTime>(type: "date", nullable: false),
                    EmPassword = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EmPhone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    EmFlag = table.Column<int>(type: "int", nullable: false),
                    EmHidden = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__M_Employ__DCB5BEC24482B998", x => x.EmID);
                    table.ForeignKey(
                        name: "FK_M_Employee_ToM_Position",
                        column: x => x.PoID,
                        principalTable: "M_Position",
                        principalColumn: "PoID");
                    table.ForeignKey(
                        name: "FK_M_Employee_ToM_SalesOffice",
                        column: x => x.SoID,
                        principalTable: "M_SalesOffice",
                        principalColumn: "SoID");
                });

            migrationBuilder.CreateTable(
                name: "M_Product",
                columns: table => new
                {
                    PrID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaID = table.Column<int>(type: "int", nullable: false),
                    PrName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(9,0)", nullable: false),
                    PrJCode = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    PrSafetyStock = table.Column<int>(type: "int", nullable: false),
                    ScID = table.Column<int>(type: "int", nullable: false),
                    PrModelNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PrColor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PrReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    PrFlag = table.Column<int>(type: "int", nullable: false),
                    PrHidden = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__M_Produc__A5021A4FEB48A98E", x => x.PrID);
                    table.ForeignKey(
                        name: "FK_M_Product_ToM_Maker",
                        column: x => x.MaID,
                        principalTable: "M_Maker",
                        principalColumn: "MaID");
                    table.ForeignKey(
                        name: "FK_M_Product_ToM_SmallClassification",
                        column: x => x.ScID,
                        principalTable: "M_SmallClassification",
                        principalColumn: "ScID");
                });

            migrationBuilder.CreateTable(
                name: "T_Hattyu",
                columns: table => new
                {
                    HaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaID = table.Column<int>(type: "int", nullable: false),
                    EmID = table.Column<int>(type: "int", nullable: false),
                    HaDate = table.Column<DateTime>(type: "date", nullable: false),
                    WaWarehouseFlag = table.Column<int>(type: "int", nullable: true),
                    HaFlag = table.Column<int>(type: "int", nullable: false),
                    HaHidden = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Hattyu", x => x.HaID);
                    table.ForeignKey(
                        name: "FK_T_Hattyu_ToM_Employee",
                        column: x => x.EmID,
                        principalTable: "M_Employee",
                        principalColumn: "EmID");
                    table.ForeignKey(
                        name: "FK_T_Hattyu_ToM_Maker",
                        column: x => x.MaID,
                        principalTable: "M_Maker",
                        principalColumn: "MaID");
                });

            migrationBuilder.CreateTable(
                name: "T_Order",
                columns: table => new
                {
                    OrID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoID = table.Column<int>(type: "int", nullable: false),
                    EmID = table.Column<int>(type: "int", nullable: false),
                    ClID = table.Column<int>(type: "int", nullable: false),
                    ClCharge = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrDate = table.Column<DateTime>(type: "date", nullable: false),
                    OrStateFlag = table.Column<int>(type: "int", nullable: true),
                    OrFlag = table.Column<int>(type: "int", nullable: false),
                    OrHidden = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__T_Order__E1649648FAE4D6E9", x => x.OrID);
                    table.ForeignKey(
                        name: "FK_T_Order_ToM_Client",
                        column: x => x.ClID,
                        principalTable: "M_Client",
                        principalColumn: "ClID");
                    table.ForeignKey(
                        name: "FK_T_Order_ToM_Employee",
                        column: x => x.EmID,
                        principalTable: "M_Employee",
                        principalColumn: "EmID");
                    table.ForeignKey(
                        name: "FK_T_Order_ToM_SalesOffice",
                        column: x => x.SoID,
                        principalTable: "M_SalesOffice",
                        principalColumn: "SoID");
                });

            migrationBuilder.CreateTable(
                name: "T_Stock",
                columns: table => new
                {
                    StID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrID = table.Column<int>(type: "int", nullable: false),
                    StQuantity = table.Column<int>(type: "int", nullable: false),
                    StFlag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__T_Stock__C33CEFE204B2DFA6", x => x.StID);
                    table.ForeignKey(
                        name: "FK_T_Stock_ToM_Product",
                        column: x => x.PrID,
                        principalTable: "M_Product",
                        principalColumn: "PrID");
                });

            migrationBuilder.CreateTable(
                name: "T_HattyuDetail",
                columns: table => new
                {
                    HaDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HaID = table.Column<int>(type: "int", nullable: false),
                    PrID = table.Column<int>(type: "int", nullable: false),
                    HaQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_HattyuDetail", x => x.HaDetailID);
                    table.ForeignKey(
                        name: "FK_T_HattyuDetail_ToM_Product",
                        column: x => x.PrID,
                        principalTable: "M_Product",
                        principalColumn: "PrID");
                    table.ForeignKey(
                        name: "FK_T_HattyuDetail_ToT_Hattyu",
                        column: x => x.HaID,
                        principalTable: "T_Hattyu",
                        principalColumn: "HaID");
                });

            migrationBuilder.CreateTable(
                name: "T_Warehousing",
                columns: table => new
                {
                    WaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HaID = table.Column<int>(type: "int", nullable: false),
                    EmID = table.Column<int>(type: "int", nullable: false),
                    WaDate = table.Column<DateTime>(type: "date", nullable: false),
                    WaShelfFlag = table.Column<int>(type: "int", nullable: true),
                    WaHidden = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaFlag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Warehousing", x => x.WaID);
                    table.ForeignKey(
                        name: "FK_T_Warehousing_ToM_Employee",
                        column: x => x.EmID,
                        principalTable: "M_Employee",
                        principalColumn: "EmID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_Warehousing_ToT_Hattyu",
                        column: x => x.HaID,
                        principalTable: "T_Hattyu",
                        principalColumn: "HaID");
                });

            migrationBuilder.CreateTable(
                name: "T_Arrival",
                columns: table => new
                {
                    ArID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoID = table.Column<int>(type: "int", nullable: false),
                    EmID = table.Column<int>(type: "int", nullable: true),
                    ClID = table.Column<int>(type: "int", nullable: false),
                    OrID = table.Column<int>(type: "int", nullable: false),
                    ArDate = table.Column<DateTime>(type: "date", nullable: true),
                    ArStateFlag = table.Column<int>(type: "int", nullable: true),
                    ArFlag = table.Column<int>(type: "int", nullable: false),
                    ArHidden = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Arrival", x => x.ArID);
                    table.ForeignKey(
                        name: "FK_T_Arrival_ToM_Client",
                        column: x => x.ClID,
                        principalTable: "M_Client",
                        principalColumn: "ClID");
                    table.ForeignKey(
                        name: "FK_T_Arrival_ToM_Employee",
                        column: x => x.EmID,
                        principalTable: "M_Employee",
                        principalColumn: "EmID");
                    table.ForeignKey(
                        name: "FK_T_Arrival_ToM_SalesOffice",
                        column: x => x.SoID,
                        principalTable: "M_SalesOffice",
                        principalColumn: "SoID");
                    table.ForeignKey(
                        name: "FK_T_Arrival_ToT_Order",
                        column: x => x.OrID,
                        principalTable: "T_Order",
                        principalColumn: "OrID");
                });

            migrationBuilder.CreateTable(
                name: "T_Chumon",
                columns: table => new
                {
                    ChID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoID = table.Column<int>(type: "int", nullable: false),
                    EmID = table.Column<int>(type: "int", nullable: true),
                    ClID = table.Column<int>(type: "int", nullable: false),
                    OrID = table.Column<int>(type: "int", nullable: false),
                    ChDate = table.Column<DateTime>(type: "date", nullable: true),
                    ChStateFlag = table.Column<int>(type: "int", nullable: true),
                    ChFlag = table.Column<int>(type: "int", nullable: false),
                    ChHidden = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__T_Chumon__AF02F0B8EDF28122", x => x.ChID);
                    table.ForeignKey(
                        name: "FK_T_Chumon_ToM_Client",
                        column: x => x.ClID,
                        principalTable: "M_Client",
                        principalColumn: "ClID");
                    table.ForeignKey(
                        name: "FK_T_Chumon_ToM_Employee",
                        column: x => x.EmID,
                        principalTable: "M_Employee",
                        principalColumn: "EmID");
                    table.ForeignKey(
                        name: "FK_T_Chumon_ToM_SalesOffice",
                        column: x => x.SoID,
                        principalTable: "M_SalesOffice",
                        principalColumn: "SoID");
                    table.ForeignKey(
                        name: "FK_T_Chumon_ToT_Order",
                        column: x => x.OrID,
                        principalTable: "T_Order",
                        principalColumn: "OrID");
                });

            migrationBuilder.CreateTable(
                name: "T_OrderDetail",
                columns: table => new
                {
                    OrDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrID = table.Column<int>(type: "int", nullable: false),
                    PrID = table.Column<int>(type: "int", nullable: false),
                    OrQuantity = table.Column<int>(type: "int", nullable: false),
                    OrTotalPrice = table.Column<decimal>(type: "decimal(10,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__T_OrderD__45EDE90EEC5B2390", x => x.OrDetailID);
                    table.ForeignKey(
                        name: "FK_T_OrderDetail_ToM_Product",
                        column: x => x.PrID,
                        principalTable: "M_Product",
                        principalColumn: "PrID");
                    table.ForeignKey(
                        name: "FK_T_OrderDetail_ToT_Order",
                        column: x => x.OrID,
                        principalTable: "T_Order",
                        principalColumn: "OrID");
                });

            migrationBuilder.CreateTable(
                name: "T_Sale",
                columns: table => new
                {
                    SaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClID = table.Column<int>(type: "int", nullable: false),
                    SoID = table.Column<int>(type: "int", nullable: false),
                    EmID = table.Column<int>(type: "int", nullable: false),
                    OrID = table.Column<int>(type: "int", nullable: false),
                    SaDate = table.Column<DateTime>(type: "date", nullable: false),
                    SaHidden = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaFlag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Sale", x => x.SaID);
                    table.ForeignKey(
                        name: "FK_T_Sale_ToM_Client",
                        column: x => x.ClID,
                        principalTable: "M_Client",
                        principalColumn: "ClID");
                    table.ForeignKey(
                        name: "FK_T_Sale_ToM_Employee",
                        column: x => x.EmID,
                        principalTable: "M_Employee",
                        principalColumn: "EmID");
                    table.ForeignKey(
                        name: "FK_T_Sale_ToM_SalesOffice",
                        column: x => x.SoID,
                        principalTable: "M_SalesOffice",
                        principalColumn: "SoID");
                    table.ForeignKey(
                        name: "FK_T_Sale_ToT_Order",
                        column: x => x.OrID,
                        principalTable: "T_Order",
                        principalColumn: "OrID");
                });

            migrationBuilder.CreateTable(
                name: "T_Shipment",
                columns: table => new
                {
                    ShID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClID = table.Column<int>(type: "int", nullable: false),
                    EmID = table.Column<int>(type: "int", nullable: true),
                    SoID = table.Column<int>(type: "int", nullable: false),
                    OrID = table.Column<int>(type: "int", nullable: false),
                    ShStateFlag = table.Column<int>(type: "int", nullable: true),
                    ShFinishDate = table.Column<DateTime>(type: "date", nullable: true),
                    ShFlag = table.Column<int>(type: "int", nullable: false),
                    ShHidden = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Shipment", x => x.ShID);
                    table.ForeignKey(
                        name: "FK_T_Shipment_ToM_Client",
                        column: x => x.ClID,
                        principalTable: "M_Client",
                        principalColumn: "ClID");
                    table.ForeignKey(
                        name: "FK_T_Shipment_ToM_Employee",
                        column: x => x.EmID,
                        principalTable: "M_Employee",
                        principalColumn: "EmID");
                    table.ForeignKey(
                        name: "FK_T_Shipment_ToM_SalesOffice",
                        column: x => x.SoID,
                        principalTable: "M_SalesOffice",
                        principalColumn: "SoID");
                    table.ForeignKey(
                        name: "FK_T_Shipment_ToT_Order",
                        column: x => x.OrID,
                        principalTable: "T_Order",
                        principalColumn: "OrID");
                });

            migrationBuilder.CreateTable(
                name: "T_Syukko",
                columns: table => new
                {
                    SyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmID = table.Column<int>(type: "int", nullable: true),
                    ClID = table.Column<int>(type: "int", nullable: false),
                    SoID = table.Column<int>(type: "int", nullable: false),
                    OrID = table.Column<int>(type: "int", nullable: false),
                    SyDate = table.Column<DateTime>(type: "date", nullable: true),
                    SyStateFlag = table.Column<int>(type: "int", nullable: true),
                    SyFlag = table.Column<int>(type: "int", nullable: false),
                    SyHidden = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Syukko", x => x.SyID);
                    table.ForeignKey(
                        name: "FK_T_Syukko_ToM_Client",
                        column: x => x.ClID,
                        principalTable: "M_Client",
                        principalColumn: "ClID");
                    table.ForeignKey(
                        name: "FK_T_Syukko_ToM_Employee",
                        column: x => x.EmID,
                        principalTable: "M_Employee",
                        principalColumn: "EmID");
                    table.ForeignKey(
                        name: "FK_T_Syukko_ToM_SalesOffice",
                        column: x => x.SoID,
                        principalTable: "M_SalesOffice",
                        principalColumn: "SoID");
                    table.ForeignKey(
                        name: "FK_T_Syukko_ToT_Order",
                        column: x => x.OrID,
                        principalTable: "T_Order",
                        principalColumn: "OrID");
                });

            migrationBuilder.CreateTable(
                name: "T_WarehousingDetail",
                columns: table => new
                {
                    WaDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WaID = table.Column<int>(type: "int", nullable: false),
                    PrID = table.Column<int>(type: "int", nullable: false),
                    WaQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WarehousingDetail", x => x.WaDetailID);
                    table.ForeignKey(
                        name: "FK_T_WarehousingDetail_ToM_Product",
                        column: x => x.PrID,
                        principalTable: "M_Product",
                        principalColumn: "PrID");
                    table.ForeignKey(
                        name: "FK_T_WarehousingDetail_ToT_Warehousing",
                        column: x => x.WaID,
                        principalTable: "T_Warehousing",
                        principalColumn: "WaID");
                });

            migrationBuilder.CreateTable(
                name: "T_ArrivalDetail",
                columns: table => new
                {
                    ArDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArID = table.Column<int>(type: "int", nullable: true),
                    PrID = table.Column<int>(type: "int", nullable: true),
                    ArQuantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ArrivalDetail", x => x.ArDetailID);
                    table.ForeignKey(
                        name: "FK_T_ArrivalDetail_ToM_Product",
                        column: x => x.PrID,
                        principalTable: "M_Product",
                        principalColumn: "PrID");
                    table.ForeignKey(
                        name: "FK_T_ArrivalDetail_ToT_Arrival",
                        column: x => x.ArID,
                        principalTable: "T_Arrival",
                        principalColumn: "ArID");
                });

            migrationBuilder.CreateTable(
                name: "T_ChumonDetail",
                columns: table => new
                {
                    ChDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChID = table.Column<int>(type: "int", nullable: false),
                    PrID = table.Column<int>(type: "int", nullable: false),
                    ChQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ChumonDetail", x => x.ChDetailID);
                    table.ForeignKey(
                        name: "FK_T_ChumonDetail_ToM_Product",
                        column: x => x.PrID,
                        principalTable: "M_Product",
                        principalColumn: "PrID");
                    table.ForeignKey(
                        name: "FK_T_ChumonDetail_ToT_Chumon",
                        column: x => x.ChID,
                        principalTable: "T_Chumon",
                        principalColumn: "ChID");
                });

            migrationBuilder.CreateTable(
                name: "T_SaleDetail",
                columns: table => new
                {
                    SaDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaID = table.Column<int>(type: "int", nullable: false),
                    PrID = table.Column<int>(type: "int", nullable: false),
                    SaQuantity = table.Column<int>(type: "int", nullable: false),
                    SaPrTotalPrice = table.Column<decimal>(type: "decimal(10,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_SaleDetail", x => x.SaDetailID);
                    table.ForeignKey(
                        name: "FK_T_SaleDetail_ToM_Product",
                        column: x => x.PrID,
                        principalTable: "M_Product",
                        principalColumn: "PrID");
                    table.ForeignKey(
                        name: "FK_T_SaleDetail_ToT_Sale",
                        column: x => x.SaID,
                        principalTable: "T_Sale",
                        principalColumn: "SaID");
                });

            migrationBuilder.CreateTable(
                name: "T_ShipmentDetail",
                columns: table => new
                {
                    ShDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShID = table.Column<int>(type: "int", nullable: false),
                    PrID = table.Column<int>(type: "int", nullable: false),
                    ShQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ShipmentDetail", x => x.ShDetailID);
                    table.ForeignKey(
                        name: "FK_T_ShipmentDetail_ToM_Product",
                        column: x => x.PrID,
                        principalTable: "M_Product",
                        principalColumn: "PrID");
                    table.ForeignKey(
                        name: "FK_T_ShipmentDetail_ToT_Shipment",
                        column: x => x.ShID,
                        principalTable: "T_Shipment",
                        principalColumn: "ShID");
                });

            migrationBuilder.CreateTable(
                name: "T_SyukkoDetail",
                columns: table => new
                {
                    SyDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SyID = table.Column<int>(type: "int", nullable: false),
                    PrID = table.Column<int>(type: "int", nullable: false),
                    SyQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_SyukkoDetail", x => x.SyDetailID);
                    table.ForeignKey(
                        name: "FK_T_SyukkoDetail_ToM_Product",
                        column: x => x.PrID,
                        principalTable: "M_Product",
                        principalColumn: "PrID");
                    table.ForeignKey(
                        name: "FK_T_SyukkoDetail_ToT_Syukko",
                        column: x => x.SyID,
                        principalTable: "T_Syukko",
                        principalColumn: "SyID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_M_Client_SoID",
                table: "M_Client",
                column: "SoID");

            migrationBuilder.CreateIndex(
                name: "IX_M_Employee_PoID",
                table: "M_Employee",
                column: "PoID");

            migrationBuilder.CreateIndex(
                name: "IX_M_Employee_SoID",
                table: "M_Employee",
                column: "SoID");

            migrationBuilder.CreateIndex(
                name: "IX_M_Product_MaID",
                table: "M_Product",
                column: "MaID");

            migrationBuilder.CreateIndex(
                name: "IX_M_Product_ScID",
                table: "M_Product",
                column: "ScID");

            migrationBuilder.CreateIndex(
                name: "IX_M_SmallClassification_McID",
                table: "M_SmallClassification",
                column: "McID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Arrival_ClID",
                table: "T_Arrival",
                column: "ClID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Arrival_EmID",
                table: "T_Arrival",
                column: "EmID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Arrival_OrID",
                table: "T_Arrival",
                column: "OrID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Arrival_SoID",
                table: "T_Arrival",
                column: "SoID");

            migrationBuilder.CreateIndex(
                name: "IX_T_ArrivalDetail_ArID",
                table: "T_ArrivalDetail",
                column: "ArID");

            migrationBuilder.CreateIndex(
                name: "IX_T_ArrivalDetail_PrID",
                table: "T_ArrivalDetail",
                column: "PrID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Chumon_ClID",
                table: "T_Chumon",
                column: "ClID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Chumon_EmID",
                table: "T_Chumon",
                column: "EmID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Chumon_OrID",
                table: "T_Chumon",
                column: "OrID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Chumon_SoID",
                table: "T_Chumon",
                column: "SoID");

            migrationBuilder.CreateIndex(
                name: "IX_T_ChumonDetail_ChID",
                table: "T_ChumonDetail",
                column: "ChID");

            migrationBuilder.CreateIndex(
                name: "IX_T_ChumonDetail_PrID",
                table: "T_ChumonDetail",
                column: "PrID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Hattyu_EmID",
                table: "T_Hattyu",
                column: "EmID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Hattyu_MaID",
                table: "T_Hattyu",
                column: "MaID");

            migrationBuilder.CreateIndex(
                name: "IX_T_HattyuDetail_HaID",
                table: "T_HattyuDetail",
                column: "HaID");

            migrationBuilder.CreateIndex(
                name: "IX_T_HattyuDetail_PrID",
                table: "T_HattyuDetail",
                column: "PrID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Order_ClID",
                table: "T_Order",
                column: "ClID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Order_EmID",
                table: "T_Order",
                column: "EmID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Order_SoID",
                table: "T_Order",
                column: "SoID");

            migrationBuilder.CreateIndex(
                name: "IX_T_OrderDetail_OrID",
                table: "T_OrderDetail",
                column: "OrID");

            migrationBuilder.CreateIndex(
                name: "IX_T_OrderDetail_PrID",
                table: "T_OrderDetail",
                column: "PrID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Sale_ClID",
                table: "T_Sale",
                column: "ClID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Sale_EmID",
                table: "T_Sale",
                column: "EmID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Sale_OrID",
                table: "T_Sale",
                column: "OrID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Sale_SoID",
                table: "T_Sale",
                column: "SoID");

            migrationBuilder.CreateIndex(
                name: "IX_T_SaleDetail_PrID",
                table: "T_SaleDetail",
                column: "PrID");

            migrationBuilder.CreateIndex(
                name: "IX_T_SaleDetail_SaID",
                table: "T_SaleDetail",
                column: "SaID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Shipment_ClID",
                table: "T_Shipment",
                column: "ClID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Shipment_EmID",
                table: "T_Shipment",
                column: "EmID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Shipment_OrID",
                table: "T_Shipment",
                column: "OrID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Shipment_SoID",
                table: "T_Shipment",
                column: "SoID");

            migrationBuilder.CreateIndex(
                name: "IX_T_ShipmentDetail_PrID",
                table: "T_ShipmentDetail",
                column: "PrID");

            migrationBuilder.CreateIndex(
                name: "IX_T_ShipmentDetail_ShID",
                table: "T_ShipmentDetail",
                column: "ShID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Stock_PrID",
                table: "T_Stock",
                column: "PrID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Syukko_ClID",
                table: "T_Syukko",
                column: "ClID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Syukko_EmID",
                table: "T_Syukko",
                column: "EmID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Syukko_OrID",
                table: "T_Syukko",
                column: "OrID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Syukko_SoID",
                table: "T_Syukko",
                column: "SoID");

            migrationBuilder.CreateIndex(
                name: "IX_T_SyukkoDetail_PrID",
                table: "T_SyukkoDetail",
                column: "PrID");

            migrationBuilder.CreateIndex(
                name: "IX_T_SyukkoDetail_SyID",
                table: "T_SyukkoDetail",
                column: "SyID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Warehousing_EmID",
                table: "T_Warehousing",
                column: "EmID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Warehousing_HaID",
                table: "T_Warehousing",
                column: "HaID");

            migrationBuilder.CreateIndex(
                name: "IX_T_WarehousingDetail_PrID",
                table: "T_WarehousingDetail",
                column: "PrID");

            migrationBuilder.CreateIndex(
                name: "IX_T_WarehousingDetail_WaID",
                table: "T_WarehousingDetail",
                column: "WaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginHistoryLog");

            migrationBuilder.DropTable(
                name: "T_ArrivalDetail");

            migrationBuilder.DropTable(
                name: "T_ChumonDetail");

            migrationBuilder.DropTable(
                name: "T_HattyuDetail");

            migrationBuilder.DropTable(
                name: "T_OrderDetail");

            migrationBuilder.DropTable(
                name: "T_SaleDetail");

            migrationBuilder.DropTable(
                name: "T_ShipmentDetail");

            migrationBuilder.DropTable(
                name: "T_Stock");

            migrationBuilder.DropTable(
                name: "T_SyukkoDetail");

            migrationBuilder.DropTable(
                name: "T_WarehousingDetail");

            migrationBuilder.DropTable(
                name: "T_Arrival");

            migrationBuilder.DropTable(
                name: "T_Chumon");

            migrationBuilder.DropTable(
                name: "T_Sale");

            migrationBuilder.DropTable(
                name: "T_Shipment");

            migrationBuilder.DropTable(
                name: "T_Syukko");

            migrationBuilder.DropTable(
                name: "M_Product");

            migrationBuilder.DropTable(
                name: "T_Warehousing");

            migrationBuilder.DropTable(
                name: "T_Order");

            migrationBuilder.DropTable(
                name: "M_SmallClassification");

            migrationBuilder.DropTable(
                name: "T_Hattyu");

            migrationBuilder.DropTable(
                name: "M_Client");

            migrationBuilder.DropTable(
                name: "M_MajorClassification");

            migrationBuilder.DropTable(
                name: "M_Employee");

            migrationBuilder.DropTable(
                name: "M_Maker");

            migrationBuilder.DropTable(
                name: "M_Position");

            migrationBuilder.DropTable(
                name: "M_SalesOffice");
        }
    }
}

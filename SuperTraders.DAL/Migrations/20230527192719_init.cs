using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SuperTraders.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Shares",
                columns: table => new
                {
                    Symbol = table.Column<string>(type: "char(3)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shares", x => x.Symbol);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    PortfolioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.PortfolioId);
                    table.ForeignKey(
                        name: "FK_Portfolios_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShareSymbol = table.Column<string>(type: "char(3)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Direction = table.Column<int>(type: "int", nullable: false),
                    PortfolioId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Trades_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "PortfolioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trades_Shares_ShareSymbol",
                        column: x => x.ShareSymbol,
                        principalTable: "Shares",
                        principalColumn: "Symbol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CreatedAt", "FullName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(5786), "Emre Kurtar", new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(5789) },
                    { 2, new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(5791), "Can Avsar", new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(5792) },
                    { 3, new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(5793), "Ugur Evren", new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(5793) },
                    { 4, new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(5794), "Kemal Kilicdaroglu", new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(5794) },
                    { 5, new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(5795), "Tayyip Erdogan", new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(5796) }
                });

            migrationBuilder.InsertData(
                table: "Shares",
                columns: new[] { "Symbol", "CreatedAt", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { "ATP", new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(4649), 5m, new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(4661) },
                    { "EKG", new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(4664), 10m, new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(4664) },
                    { "SIS", new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(4665), 15m, new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(4666) }
                });

            migrationBuilder.InsertData(
                table: "Portfolios",
                columns: new[] { "PortfolioId", "Balance", "CreatedAt", "CustomerId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 100m, new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(6737), 1, new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(6739) },
                    { 2, 90m, new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(6741), 2, new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(6742) },
                    { 3, 85m, new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(6743), 3, new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(6743) },
                    { 4, 80m, new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(6744), 4, new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(6744) },
                    { 5, 75m, new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(6745), 5, new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(6746) }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "ID", "CreatedAt", "Direction", "IsActive", "PortfolioId", "Quantity", "ShareSymbol", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(7462), 1, true, 1, 2, "ATP", new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(7464) },
                    { 2, new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(7466), 1, true, 2, 3, "ATP", new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(7466) },
                    { 3, new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(7468), 1, true, 3, 4, "EKG", new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(7468) },
                    { 4, new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(7469), 1, true, 4, 2, "EKG", new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(7469) },
                    { 5, new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(7470), 1, true, 5, 1, "SIS", new DateTime(2023, 5, 27, 22, 27, 19, 595, DateTimeKind.Local).AddTicks(7471) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_CustomerId",
                table: "Portfolios",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trades_PortfolioId",
                table: "Trades",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_ShareSymbol",
                table: "Trades",
                column: "ShareSymbol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "Shares");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}

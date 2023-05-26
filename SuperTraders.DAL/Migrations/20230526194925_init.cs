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
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PortfolioId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "PortfolioId",
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
                table: "Portfolios",
                columns: new[] { "PortfolioId", "Balance", "CreatedAt", "CustomerId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 100m, new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(5693), 1, new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(5697) },
                    { 2, 90m, new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(5698), 2, new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(5699) },
                    { 3, 85m, new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(5700), 3, new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(5700) },
                    { 4, 80m, new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(5701), 4, new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(5702) },
                    { 5, 75m, new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(5703), 5, new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(5703) }
                });

            migrationBuilder.InsertData(
                table: "Shares",
                columns: new[] { "Symbol", "CreatedAt", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { "ATP", new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(7149), 5m, new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(7152) },
                    { "EKG", new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(7153), 10m, new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(7154) },
                    { "SIS", new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(7155), 15m, new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(7155) }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CreatedAt", "FullName", "PortfolioId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 26, 22, 49, 25, 268, DateTimeKind.Local).AddTicks(8500), "Emre Kurtar", 1, new DateTime(2023, 5, 26, 22, 49, 25, 268, DateTimeKind.Local).AddTicks(8513) },
                    { 2, new DateTime(2023, 5, 26, 22, 49, 25, 268, DateTimeKind.Local).AddTicks(8515), "Can Avsar", 2, new DateTime(2023, 5, 26, 22, 49, 25, 268, DateTimeKind.Local).AddTicks(8516) },
                    { 3, new DateTime(2023, 5, 26, 22, 49, 25, 268, DateTimeKind.Local).AddTicks(8517), "Ugur Evren", 3, new DateTime(2023, 5, 26, 22, 49, 25, 268, DateTimeKind.Local).AddTicks(8518) },
                    { 4, new DateTime(2023, 5, 26, 22, 49, 25, 268, DateTimeKind.Local).AddTicks(8518), "Kemal Kilicdaroglu", 4, new DateTime(2023, 5, 26, 22, 49, 25, 268, DateTimeKind.Local).AddTicks(8519) },
                    { 5, new DateTime(2023, 5, 26, 22, 49, 25, 268, DateTimeKind.Local).AddTicks(8520), "Tayyip Erdogan", 5, new DateTime(2023, 5, 26, 22, 49, 25, 268, DateTimeKind.Local).AddTicks(8520) }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "ID", "CreatedAt", "Direction", "IsActive", "PortfolioId", "Quantity", "ShareSymbol", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(7828), 0, true, 1, 2, "ATP", new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(7829) },
                    { 2, new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(7832), 0, true, 2, 3, "ATP", new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(7832) },
                    { 3, new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(7834), 0, true, 3, 4, "EKG", new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(7834) },
                    { 4, new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(7836), 0, true, 4, 2, "EKG", new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(7836) },
                    { 5, new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(7838), 0, true, 5, 1, "SIS", new DateTime(2023, 5, 26, 22, 49, 25, 269, DateTimeKind.Local).AddTicks(7838) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PortfolioId",
                table: "Customers",
                column: "PortfolioId",
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
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "Shares");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sklep.Migrations
{
    /// <inheritdoc />
    public partial class SeedData3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    StockQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Indoor Plants" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, "Description for plant 1", "http://localhost:5000/productimg/fikus.jpg", "Plant 1", 1.5m, 10 },
                    { 2, 1, "Description for plant 2", "http://localhost:5000/productimg/fikus.jpg", "Plant 2", 3m, 10 },
                    { 3, 1, "Description for plant 3", "http://localhost:5000/productimg/fikus.jpg", "Plant 3", 4.5m, 10 },
                    { 4, 1, "Description for plant 4", "http://localhost:5000/productimg/fikus.jpg", "Plant 4", 6m, 10 },
                    { 5, 1, "Description for plant 5", "http://localhost:5000/productimg/fikus.jpg", "Plant 5", 7.5m, 10 },
                    { 6, 1, "Description for plant 6", "http://localhost:5000/productimg/fikus.jpg", "Plant 6", 9m, 10 },
                    { 7, 1, "Description for plant 7", "http://localhost:5000/productimg/fikus.jpg", "Plant 7", 10.5m, 10 },
                    { 8, 1, "Description for plant 8", "http://localhost:5000/productimg/fikus.jpg", "Plant 8", 12m, 10 },
                    { 9, 1, "Description for plant 9", "http://localhost:5000/productimg/fikus.jpg", "Plant 9", 13.5m, 10 },
                    { 10, 1, "Description for plant 10", "http://localhost:5000/productimg/fikus.jpg", "Plant 10", 15m, 10 },
                    { 11, 1, "Description for plant 11", "http://localhost:5000/productimg/fikus.jpg", "Plant 11", 16.5m, 10 },
                    { 12, 1, "Description for plant 12", "http://localhost:5000/productimg/fikus.jpg", "Plant 12", 18m, 10 },
                    { 13, 1, "Description for plant 13", "http://localhost:5000/productimg/fikus.jpg", "Plant 13", 19.5m, 10 },
                    { 14, 1, "Description for plant 14", "http://localhost:5000/productimg/fikus.jpg", "Plant 14", 21m, 10 },
                    { 15, 1, "Description for plant 15", "http://localhost:5000/productimg/fikus.jpg", "Plant 15", 22.5m, 10 },
                    { 16, 1, "Description for plant 16", "http://localhost:5000/productimg/fikus.jpg", "Plant 16", 24m, 10 },
                    { 17, 1, "Description for plant 17", "http://localhost:5000/productimg/fikus.jpg", "Plant 17", 25.5m, 10 },
                    { 18, 1, "Description for plant 18", "http://localhost:5000/productimg/fikus.jpg", "Plant 18", 27m, 10 },
                    { 19, 1, "Description for plant 19", "http://localhost:5000/productimg/fikus.jpg", "Plant 19", 28.5m, 10 },
                    { 20, 1, "Description for plant 20", "http://localhost:5000/productimg/fikus.jpg", "Plant 20", 30m, 10 },
                    { 21, 1, "Description for plant 21", "http://localhost:5000/productimg/fikus.jpg", "Plant 21", 31.5m, 10 },
                    { 22, 1, "Description for plant 22", "http://localhost:5000/productimg/fikus.jpg", "Plant 22", 33m, 10 },
                    { 23, 1, "Description for plant 23", "http://localhost:5000/productimg/fikus.jpg", "Plant 23", 34.5m, 10 },
                    { 24, 1, "Description for plant 24", "http://localhost:5000/productimg/fikus.jpg", "Plant 24", 36m, 10 },
                    { 25, 1, "Description for plant 25", "http://localhost:5000/productimg/fikus.jpg", "Plant 25", 37.5m, 10 },
                    { 26, 1, "Description for plant 26", "http://localhost:5000/productimg/fikus.jpg", "Plant 26", 39m, 10 },
                    { 27, 1, "Description for plant 27", "http://localhost:5000/productimg/fikus.jpg", "Plant 27", 40.5m, 10 },
                    { 28, 1, "Description for plant 28", "http://localhost:5000/productimg/fikus.jpg", "Plant 28", 42m, 10 },
                    { 29, 1, "Description for plant 29", "http://localhost:5000/productimg/fikus.jpg", "Plant 29", 43.5m, 10 },
                    { 30, 1, "Description for plant 30", "http://localhost:5000/productimg/fikus.jpg", "Plant 30", 45m, 10 },
                    { 31, 1, "Description for plant 31", "http://localhost:5000/productimg/fikus.jpg", "Plant 31", 46.5m, 10 },
                    { 32, 1, "Description for plant 32", "http://localhost:5000/productimg/fikus.jpg", "Plant 32", 48m, 10 },
                    { 33, 1, "Description for plant 33", "http://localhost:5000/productimg/fikus.jpg", "Plant 33", 49.5m, 10 },
                    { 34, 1, "Description for plant 34", "http://localhost:5000/productimg/fikus.jpg", "Plant 34", 51m, 10 },
                    { 35, 1, "Description for plant 35", "http://localhost:5000/productimg/fikus.jpg", "Plant 35", 52.5m, 10 },
                    { 36, 1, "Description for plant 36", "http://localhost:5000/productimg/fikus.jpg", "Plant 36", 54m, 10 },
                    { 37, 1, "Description for plant 37", "http://localhost:5000/productimg/fikus.jpg", "Plant 37", 55.5m, 10 },
                    { 38, 1, "Description for plant 38", "http://localhost:5000/productimg/fikus.jpg", "Plant 38", 57m, 10 },
                    { 39, 1, "Description for plant 39", "http://localhost:5000/productimg/fikus.jpg", "Plant 39", 58.5m, 10 },
                    { 40, 1, "Description for plant 40", "http://localhost:5000/productimg/fikus.jpg", "Plant 40", 60m, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sklep.Migrations
{
    /// <inheritdoc />
    public partial class Ok : Migration
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
                    TotalPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeliveryStatus = table.Column<string>(type: "TEXT", nullable: false)
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
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
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
                values: new object[,]
                {
                    { 1, "Rośliny doniczkowe" },
                    { 2, "Rośliny ogrodowe" },
                    { 3, "Sukulenty" },
                    { 4, "Zioła" },
                    { 5, "Kwiaty cięte" },
                    { 6, "Drzewka bonsai" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, "Piękna roślina: Monstera deliciosa. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/fikus.jpg", "Monstera deliciosa", 15m, 1 },
                    { 2, 2, "Piękna roślina: Fikus benjamina. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/monstera.jpg", "Fikus benjamina", 20m, 4 },
                    { 3, 3, "Piękna roślina: Sansewieria. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/sansevieria.jpg", "Sansewieria", 25m, 7 },
                    { 4, 4, "Piękna roślina: Dracena marginata. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/fikus.jpg", "Dracena marginata", 30m, 10 },
                    { 5, 5, "Piękna roślina: Zamiokulkas zamiolistny. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/monstera.jpg", "Zamiokulkas zamiolistny", 35m, 13 },
                    { 6, 6, "Piękna roślina: Aloes zwyczajny. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/sansevieria.jpg", "Aloes zwyczajny", 40m, 16 },
                    { 7, 1, "Piękna roślina: Kaktus opuncja. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/fikus.jpg", "Kaktus opuncja", 45m, 19 },
                    { 8, 2, "Piękna roślina: Kalanchoe. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/monstera.jpg", "Kalanchoe", 50m, 22 },
                    { 9, 3, "Piękna roślina: Bonsai fikus ginseng. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/sansevieria.jpg", "Bonsai fikus ginseng", 55m, 25 },
                    { 10, 4, "Piękna roślina: Rozmaryn. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/fikus.jpg", "Rozmaryn", 60m, 28 },
                    { 11, 5, "Piękna roślina: Bazylia. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/monstera.jpg", "Bazylia", 65m, 31 },
                    { 12, 6, "Piękna roślina: Lawenda. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/sansevieria.jpg", "Lawenda", 70m, 34 },
                    { 13, 1, "Piękna roślina: Mięta pieprzowa. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/fikus.jpg", "Mięta pieprzowa", 75m, 37 },
                    { 14, 2, "Piękna roślina: Chryzantema. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/monstera.jpg", "Chryzantema", 80m, 40 },
                    { 15, 3, "Piękna roślina: Róża. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/sansevieria.jpg", "Róża", 85m, 43 },
                    { 16, 4, "Piękna roślina: Tulipan. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/fikus.jpg", "Tulipan", 90m, 46 },
                    { 17, 5, "Piękna roślina: Stokrotka. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/monstera.jpg", "Stokrotka", 95m, 49 },
                    { 18, 6, "Piękna roślina: Bluszcz pospolity. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/sansevieria.jpg", "Bluszcz pospolity", 100m, 2 },
                    { 19, 1, "Piękna roślina: Paprotka. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/fikus.jpg", "Paprotka", 105m, 5 },
                    { 20, 2, "Piękna roślina: Anturium. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/monstera.jpg", "Anturium", 110m, 8 },
                    { 21, 3, "Piękna roślina: Orchidea. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/sansevieria.jpg", "Orchidea", 115m, 11 },
                    { 22, 4, "Piękna roślina: Palma areka. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/fikus.jpg", "Palma areka", 120m, 14 },
                    { 23, 5, "Piękna roślina: Juka. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/monstera.jpg", "Juka", 125m, 17 },
                    { 24, 6, "Piękna roślina: Liwia. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/sansevieria.jpg", "Liwia", 130m, 20 },
                    { 25, 1, "Piękna roślina: Kroton. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/fikus.jpg", "Kroton", 135m, 23 },
                    { 26, 2, "Piękna roślina: Skrzydłokwiat. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/monstera.jpg", "Skrzydłokwiat", 140m, 26 },
                    { 27, 3, "Piękna roślina: Grubosz drzewiasty. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/sansevieria.jpg", "Grubosz drzewiasty", 145m, 29 },
                    { 28, 4, "Piękna roślina: Eszeweria. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/fikus.jpg", "Eszeweria", 150m, 32 },
                    { 29, 5, "Piękna roślina: Haworcja. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/monstera.jpg", "Haworcja", 155m, 35 },
                    { 30, 6, "Piękna roślina: Szałwia lekarska. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/sansevieria.jpg", "Szałwia lekarska", 160m, 38 },
                    { 31, 1, "Piękna roślina: Tymianek. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/fikus.jpg", "Tymianek", 165m, 41 },
                    { 32, 2, "Piękna roślina: Oregano. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/monstera.jpg", "Oregano", 170m, 44 },
                    { 33, 3, "Piękna roślina: Begonia. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/sansevieria.jpg", "Begonia", 175m, 47 },
                    { 34, 4, "Piękna roślina: Geranium. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/fikus.jpg", "Geranium", 180m, 50 },
                    { 35, 5, "Piękna roślina: Storczyk falenopsis. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/monstera.jpg", "Storczyk falenopsis", 185m, 3 },
                    { 36, 6, "Piękna roślina: Kaktus gwiazda betlejemska. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/sansevieria.jpg", "Kaktus gwiazda betlejemska", 190m, 6 },
                    { 37, 1, "Piękna roślina: Hibiskus. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/fikus.jpg", "Hibiskus", 195m, 9 },
                    { 38, 2, "Piękna roślina: Azalia. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/monstera.jpg", "Azalia", 15m, 12 },
                    { 39, 3, "Piękna roślina: Magnolia. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/sansevieria.jpg", "Magnolia", 20m, 15 },
                    { 40, 4, "Piękna roślina: Drzewko cytrynowe. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/fikus.jpg", "Drzewko cytrynowe", 25m, 18 },
                    { 41, 5, "Piękna roślina: Drzewko oliwne. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/monstera.jpg", "Drzewko oliwne", 30m, 21 },
                    { 42, 6, "Piękna roślina: Fiołek afrykański. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/sansevieria.jpg", "Fiołek afrykański", 35m, 24 },
                    { 43, 1, "Piękna roślina: Pelargonia. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/fikus.jpg", "Pelargonia", 40m, 27 },
                    { 44, 2, "Piękna roślina: Amarylis. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/monstera.jpg", "Amarylis", 45m, 30 },
                    { 45, 3, "Piękna roślina: Asparagus. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/sansevieria.jpg", "Asparagus", 50m, 33 },
                    { 46, 4, "Piękna roślina: Szeflera. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/fikus.jpg", "Szeflera", 55m, 36 },
                    { 47, 5, "Piękna roślina: Papryczka chili. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/monstera.jpg", "Papryczka chili", 60m, 39 },
                    { 48, 6, "Piękna roślina: Rozplenica japońska. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/sansevieria.jpg", "Rozplenica japońska", 65m, 42 },
                    { 49, 1, "Piękna roślina: Kocanka włochata. Idealna do domu lub ogrodu.", "http://localhost:5000/productimg/fikus.jpg", "Kocanka włochata", 70m, 45 }
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

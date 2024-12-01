using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sklep.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUseless : Migration
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
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Indoor Plants" },
                    { 2, "Outdoor Plants" },
                    { 3, "Succulents" },
                    { 4, "Herbs" },
                    { 5, "Trees" },
                    { 6, "Flowers" },
                    { 7, "Fruits" },
                    { 8, "Vegetables" },
                    { 9, "Air Purifying Plants" },
                    { 10, "Tropical Plants" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { 1, "john@example.com", "hashedpassword1", "john_doe" },
                    { 2, "jane@example.com", "hashedpassword2", "jane_doe" },
                    { 3, "alex@example.com", "hashedpassword3", "alex_smith" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 2, "Description for product 1", "http://localhost:5000/productimg/fikus.jpg", "Product 1", 11m, 2 },
                    { 2, 3, "Description for product 2", "http://localhost:5000/productimg/fikus.jpg", "Product 2", 12m, 3 },
                    { 3, 4, "Description for product 3", "http://localhost:5000/productimg/fikus.jpg", "Product 3", 13m, 4 },
                    { 4, 5, "Description for product 4", "http://localhost:5000/productimg/fikus.jpg", "Product 4", 14m, 5 },
                    { 5, 6, "Description for product 5", "http://localhost:5000/productimg/fikus.jpg", "Product 5", 15m, 6 },
                    { 6, 7, "Description for product 6", "http://localhost:5000/productimg/fikus.jpg", "Product 6", 16m, 7 },
                    { 7, 8, "Description for product 7", "http://localhost:5000/productimg/fikus.jpg", "Product 7", 17m, 8 },
                    { 8, 9, "Description for product 8", "http://localhost:5000/productimg/fikus.jpg", "Product 8", 18m, 9 },
                    { 9, 10, "Description for product 9", "http://localhost:5000/productimg/fikus.jpg", "Product 9", 19m, 10 },
                    { 10, 1, "Description for product 10", "http://localhost:5000/productimg/fikus.jpg", "Product 10", 20m, 1 },
                    { 11, 2, "Description for product 11", "http://localhost:5000/productimg/fikus.jpg", "Product 11", 21m, 2 },
                    { 12, 3, "Description for product 12", "http://localhost:5000/productimg/fikus.jpg", "Product 12", 22m, 3 },
                    { 13, 4, "Description for product 13", "http://localhost:5000/productimg/fikus.jpg", "Product 13", 23m, 4 },
                    { 14, 5, "Description for product 14", "http://localhost:5000/productimg/fikus.jpg", "Product 14", 24m, 5 },
                    { 15, 6, "Description for product 15", "http://localhost:5000/productimg/fikus.jpg", "Product 15", 25m, 6 },
                    { 16, 7, "Description for product 16", "http://localhost:5000/productimg/fikus.jpg", "Product 16", 26m, 7 },
                    { 17, 8, "Description for product 17", "http://localhost:5000/productimg/fikus.jpg", "Product 17", 27m, 8 },
                    { 18, 9, "Description for product 18", "http://localhost:5000/productimg/fikus.jpg", "Product 18", 28m, 9 },
                    { 19, 10, "Description for product 19", "http://localhost:5000/productimg/fikus.jpg", "Product 19", 29m, 10 },
                    { 20, 1, "Description for product 20", "http://localhost:5000/productimg/fikus.jpg", "Product 20", 10m, 1 },
                    { 21, 2, "Description for product 21", "http://localhost:5000/productimg/fikus.jpg", "Product 21", 11m, 2 },
                    { 22, 3, "Description for product 22", "http://localhost:5000/productimg/fikus.jpg", "Product 22", 12m, 3 },
                    { 23, 4, "Description for product 23", "http://localhost:5000/productimg/fikus.jpg", "Product 23", 13m, 4 },
                    { 24, 5, "Description for product 24", "http://localhost:5000/productimg/fikus.jpg", "Product 24", 14m, 5 },
                    { 25, 6, "Description for product 25", "http://localhost:5000/productimg/fikus.jpg", "Product 25", 15m, 6 },
                    { 26, 7, "Description for product 26", "http://localhost:5000/productimg/fikus.jpg", "Product 26", 16m, 7 },
                    { 27, 8, "Description for product 27", "http://localhost:5000/productimg/fikus.jpg", "Product 27", 17m, 8 },
                    { 28, 9, "Description for product 28", "http://localhost:5000/productimg/fikus.jpg", "Product 28", 18m, 9 },
                    { 29, 10, "Description for product 29", "http://localhost:5000/productimg/fikus.jpg", "Product 29", 19m, 10 },
                    { 30, 1, "Description for product 30", "http://localhost:5000/productimg/fikus.jpg", "Product 30", 20m, 1 },
                    { 31, 2, "Description for product 31", "http://localhost:5000/productimg/fikus.jpg", "Product 31", 21m, 2 },
                    { 32, 3, "Description for product 32", "http://localhost:5000/productimg/fikus.jpg", "Product 32", 22m, 3 },
                    { 33, 4, "Description for product 33", "http://localhost:5000/productimg/fikus.jpg", "Product 33", 23m, 4 },
                    { 34, 5, "Description for product 34", "http://localhost:5000/productimg/fikus.jpg", "Product 34", 24m, 5 },
                    { 35, 6, "Description for product 35", "http://localhost:5000/productimg/fikus.jpg", "Product 35", 25m, 6 },
                    { 36, 7, "Description for product 36", "http://localhost:5000/productimg/fikus.jpg", "Product 36", 26m, 7 },
                    { 37, 8, "Description for product 37", "http://localhost:5000/productimg/fikus.jpg", "Product 37", 27m, 8 },
                    { 38, 9, "Description for product 38", "http://localhost:5000/productimg/fikus.jpg", "Product 38", 28m, 9 },
                    { 39, 10, "Description for product 39", "http://localhost:5000/productimg/fikus.jpg", "Product 39", 29m, 10 },
                    { 40, 1, "Description for product 40", "http://localhost:5000/productimg/fikus.jpg", "Product 40", 10m, 1 },
                    { 41, 2, "Description for product 41", "http://localhost:5000/productimg/fikus.jpg", "Product 41", 11m, 2 },
                    { 42, 3, "Description for product 42", "http://localhost:5000/productimg/fikus.jpg", "Product 42", 12m, 3 },
                    { 43, 4, "Description for product 43", "http://localhost:5000/productimg/fikus.jpg", "Product 43", 13m, 4 },
                    { 44, 5, "Description for product 44", "http://localhost:5000/productimg/fikus.jpg", "Product 44", 14m, 5 },
                    { 45, 6, "Description for product 45", "http://localhost:5000/productimg/fikus.jpg", "Product 45", 15m, 6 },
                    { 46, 7, "Description for product 46", "http://localhost:5000/productimg/fikus.jpg", "Product 46", 16m, 7 },
                    { 47, 8, "Description for product 47", "http://localhost:5000/productimg/fikus.jpg", "Product 47", 17m, 8 },
                    { 48, 9, "Description for product 48", "http://localhost:5000/productimg/fikus.jpg", "Product 48", 18m, 9 },
                    { 49, 10, "Description for product 49", "http://localhost:5000/productimg/fikus.jpg", "Product 49", 19m, 10 },
                    { 50, 1, "Description for product 50", "http://localhost:5000/productimg/fikus.jpg", "Product 50", 20m, 1 },
                    { 51, 2, "Description for product 51", "http://localhost:5000/productimg/fikus.jpg", "Product 51", 21m, 2 },
                    { 52, 3, "Description for product 52", "http://localhost:5000/productimg/fikus.jpg", "Product 52", 22m, 3 },
                    { 53, 4, "Description for product 53", "http://localhost:5000/productimg/fikus.jpg", "Product 53", 23m, 4 },
                    { 54, 5, "Description for product 54", "http://localhost:5000/productimg/fikus.jpg", "Product 54", 24m, 5 },
                    { 55, 6, "Description for product 55", "http://localhost:5000/productimg/fikus.jpg", "Product 55", 25m, 6 },
                    { 56, 7, "Description for product 56", "http://localhost:5000/productimg/fikus.jpg", "Product 56", 26m, 7 },
                    { 57, 8, "Description for product 57", "http://localhost:5000/productimg/fikus.jpg", "Product 57", 27m, 8 },
                    { 58, 9, "Description for product 58", "http://localhost:5000/productimg/fikus.jpg", "Product 58", 28m, 9 },
                    { 59, 10, "Description for product 59", "http://localhost:5000/productimg/fikus.jpg", "Product 59", 29m, 10 },
                    { 60, 1, "Description for product 60", "http://localhost:5000/productimg/fikus.jpg", "Product 60", 10m, 1 },
                    { 61, 2, "Description for product 61", "http://localhost:5000/productimg/fikus.jpg", "Product 61", 11m, 2 },
                    { 62, 3, "Description for product 62", "http://localhost:5000/productimg/fikus.jpg", "Product 62", 12m, 3 },
                    { 63, 4, "Description for product 63", "http://localhost:5000/productimg/fikus.jpg", "Product 63", 13m, 4 },
                    { 64, 5, "Description for product 64", "http://localhost:5000/productimg/fikus.jpg", "Product 64", 14m, 5 },
                    { 65, 6, "Description for product 65", "http://localhost:5000/productimg/fikus.jpg", "Product 65", 15m, 6 },
                    { 66, 7, "Description for product 66", "http://localhost:5000/productimg/fikus.jpg", "Product 66", 16m, 7 },
                    { 67, 8, "Description for product 67", "http://localhost:5000/productimg/fikus.jpg", "Product 67", 17m, 8 },
                    { 68, 9, "Description for product 68", "http://localhost:5000/productimg/fikus.jpg", "Product 68", 18m, 9 },
                    { 69, 10, "Description for product 69", "http://localhost:5000/productimg/fikus.jpg", "Product 69", 19m, 10 },
                    { 70, 1, "Description for product 70", "http://localhost:5000/productimg/fikus.jpg", "Product 70", 20m, 1 },
                    { 71, 2, "Description for product 71", "http://localhost:5000/productimg/fikus.jpg", "Product 71", 21m, 2 },
                    { 72, 3, "Description for product 72", "http://localhost:5000/productimg/fikus.jpg", "Product 72", 22m, 3 },
                    { 73, 4, "Description for product 73", "http://localhost:5000/productimg/fikus.jpg", "Product 73", 23m, 4 },
                    { 74, 5, "Description for product 74", "http://localhost:5000/productimg/fikus.jpg", "Product 74", 24m, 5 },
                    { 75, 6, "Description for product 75", "http://localhost:5000/productimg/fikus.jpg", "Product 75", 25m, 6 },
                    { 76, 7, "Description for product 76", "http://localhost:5000/productimg/fikus.jpg", "Product 76", 26m, 7 },
                    { 77, 8, "Description for product 77", "http://localhost:5000/productimg/fikus.jpg", "Product 77", 27m, 8 },
                    { 78, 9, "Description for product 78", "http://localhost:5000/productimg/fikus.jpg", "Product 78", 28m, 9 },
                    { 79, 10, "Description for product 79", "http://localhost:5000/productimg/fikus.jpg", "Product 79", 29m, 10 },
                    { 80, 1, "Description for product 80", "http://localhost:5000/productimg/fikus.jpg", "Product 80", 10m, 1 },
                    { 81, 2, "Description for product 81", "http://localhost:5000/productimg/fikus.jpg", "Product 81", 11m, 2 },
                    { 82, 3, "Description for product 82", "http://localhost:5000/productimg/fikus.jpg", "Product 82", 12m, 3 },
                    { 83, 4, "Description for product 83", "http://localhost:5000/productimg/fikus.jpg", "Product 83", 13m, 4 },
                    { 84, 5, "Description for product 84", "http://localhost:5000/productimg/fikus.jpg", "Product 84", 14m, 5 },
                    { 85, 6, "Description for product 85", "http://localhost:5000/productimg/fikus.jpg", "Product 85", 15m, 6 },
                    { 86, 7, "Description for product 86", "http://localhost:5000/productimg/fikus.jpg", "Product 86", 16m, 7 },
                    { 87, 8, "Description for product 87", "http://localhost:5000/productimg/fikus.jpg", "Product 87", 17m, 8 },
                    { 88, 9, "Description for product 88", "http://localhost:5000/productimg/fikus.jpg", "Product 88", 18m, 9 },
                    { 89, 10, "Description for product 89", "http://localhost:5000/productimg/fikus.jpg", "Product 89", 19m, 10 },
                    { 90, 1, "Description for product 90", "http://localhost:5000/productimg/fikus.jpg", "Product 90", 20m, 1 },
                    { 91, 2, "Description for product 91", "http://localhost:5000/productimg/fikus.jpg", "Product 91", 21m, 2 },
                    { 92, 3, "Description for product 92", "http://localhost:5000/productimg/fikus.jpg", "Product 92", 22m, 3 },
                    { 93, 4, "Description for product 93", "http://localhost:5000/productimg/fikus.jpg", "Product 93", 23m, 4 },
                    { 94, 5, "Description for product 94", "http://localhost:5000/productimg/fikus.jpg", "Product 94", 24m, 5 },
                    { 95, 6, "Description for product 95", "http://localhost:5000/productimg/fikus.jpg", "Product 95", 25m, 6 },
                    { 96, 7, "Description for product 96", "http://localhost:5000/productimg/fikus.jpg", "Product 96", 26m, 7 },
                    { 97, 8, "Description for product 97", "http://localhost:5000/productimg/fikus.jpg", "Product 97", 27m, 8 },
                    { 98, 9, "Description for product 98", "http://localhost:5000/productimg/fikus.jpg", "Product 98", 28m, 9 },
                    { 99, 10, "Description for product 99", "http://localhost:5000/productimg/fikus.jpg", "Product 99", 29m, 10 },
                    { 100, 1, "Description for product 100", "http://localhost:5000/productimg/fikus.jpg", "Product 100", 10m, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductId",
                table: "Carts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

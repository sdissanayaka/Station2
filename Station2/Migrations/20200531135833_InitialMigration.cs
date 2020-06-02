using Microsoft.EntityFrameworkCore.Migrations;

namespace Station2.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true),
                    CategoryDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ItemMaster",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(nullable: true),
                    ItemDescription = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    InStock = table.Column<bool>(nullable: false),
                    IsItemOfTheWeek = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMaster", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_ItemMaster_ItemCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ItemCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    ShoppingCartId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_ItemMaster_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ItemMaster",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ItemCategories",
                columns: new[] { "CategoryId", "CategoryDescription", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Buy your raw materials", "Raw Materials" },
                    { 2, "Get your service", "Services" }
                });

            migrationBuilder.InsertData(
                table: "ItemMaster",
                columns: new[] { "ItemId", "CategoryId", "InStock", "IsItemOfTheWeek", "ItemDescription", "ItemName", "Price" },
                values: new object[,]
                {
                    { 1, null, true, true, "Replace your engine oil", "Engine oil", 12.95m },
                    { 2, null, true, true, "Cleaning the body of the car", "Body Wash", 120.90m },
                    { 3, null, true, false, "DSI", "Tyre", 33m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemMaster_CategoryId",
                table: "ItemMaster",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ItemId",
                table: "ShoppingCartItems",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "ItemMaster");

            migrationBuilder.DropTable(
                name: "ItemCategories");
        }
    }
}

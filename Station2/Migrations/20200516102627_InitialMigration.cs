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
                    CategoryId = table.Column<int>(nullable: false),
                    CategoryNameCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMaster", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_ItemMaster_ItemCategories_CategoryNameCategoryId",
                        column: x => x.CategoryNameCategoryId,
                        principalTable: "ItemCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ItemCategories",
                columns: new[] { "CategoryId", "CategoryDescription", "CategoryName" },
                values: new object[] { 1, null, "Raw Materials" });

            migrationBuilder.InsertData(
                table: "ItemCategories",
                columns: new[] { "CategoryId", "CategoryDescription", "CategoryName" },
                values: new object[] { 2, null, "Services" });

            migrationBuilder.InsertData(
                table: "ItemMaster",
                columns: new[] { "ItemId", "CategoryId", "CategoryNameCategoryId", "InStock", "IsItemOfTheWeek", "ItemDescription", "ItemName", "Price" },
                values: new object[] { 1, 1, null, true, true, "Our famous apple pies!", "Engine oil", 12.95});

            migrationBuilder.CreateIndex(
                name: "IX_ItemMaster_CategoryNameCategoryId",
                table: "ItemMaster",
                column: "CategoryNameCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemMaster");

            migrationBuilder.DropTable(
                name: "ItemCategories");
        }
    }
}

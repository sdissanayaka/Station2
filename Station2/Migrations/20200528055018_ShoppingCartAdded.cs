using Microsoft.EntityFrameworkCore.Migrations;

namespace Station2.Migrations
{
    public partial class ShoppingCartAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CategoryDescription",
                value: "Buy your raw materials");

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CategoryDescription",
                value: "Get your service");

            migrationBuilder.UpdateData(
                table: "ItemMaster",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "ItemDescription",
                value: "Replace your engine oil");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ItemId",
                table: "ShoppingCartItems",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CategoryDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CategoryDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "ItemMaster",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "ItemDescription",
                value: "Our famous apple pies!");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Station2.Migrations
{
    public partial class CustomerOrderadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerOrders",
                columns: table => new
                {
                    CustomerOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    State = table.Column<string>(maxLength: 10, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 25, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    OrderTotal = table.Column<decimal>(nullable: false),
                    OrderPlaced = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrders", x => x.CustomerOrderId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrderDetails",
                columns: table => new
                {
                    CustomerOrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerOrderId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrderDetails", x => x.CustomerOrderDetailId);
                    table.ForeignKey(
                        name: "FK_CustomerOrderDetails_CustomerOrders_CustomerOrderId",
                        column: x => x.CustomerOrderId,
                        principalTable: "CustomerOrders",
                        principalColumn: "CustomerOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerOrderDetails_ItemMaster_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ItemMaster",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrderDetails_CustomerOrderId",
                table: "CustomerOrderDetails",
                column: "CustomerOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrderDetails_ItemId",
                table: "CustomerOrderDetails",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOrderDetails");

            migrationBuilder.DropTable(
                name: "CustomerOrders");
        }
    }
}

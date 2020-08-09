using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Station2.Migrations
{
    public partial class Rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OrderPlaced",
                table: "CustomerOrderDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "OrderTotal",
                table: "CustomerOrderDetails",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderPlaced",
                table: "CustomerOrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderTotal",
                table: "CustomerOrderDetails");
        }
    }
}

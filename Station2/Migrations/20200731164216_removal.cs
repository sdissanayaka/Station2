using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Station2.Migrations
{
    public partial class removal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "CustomerOrders");

            migrationBuilder.DropColumn(
                name: "City",
                table: "CustomerOrders");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "CustomerOrders");

            migrationBuilder.DropColumn(
                name: "OrderPlaced",
                table: "CustomerOrders");

            migrationBuilder.DropColumn(
                name: "OrderTotal",
                table: "CustomerOrders");

            migrationBuilder.DropColumn(
                name: "State",
                table: "CustomerOrders");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "CustomerOrders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "CustomerOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "CustomerOrders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "CustomerOrders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderPlaced",
                table: "CustomerOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "OrderTotal",
                table: "CustomerOrders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "CustomerOrders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "CustomerOrders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}

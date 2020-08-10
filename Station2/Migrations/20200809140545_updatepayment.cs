using Microsoft.EntityFrameworkCore.Migrations;

namespace Station2.Migrations
{
    public partial class updatepayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemainAmount",
                table: "CustomerPayments");

            migrationBuilder.AlterColumn<double>(
                name: "InvoiceTotal",
                table: "Invoice",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "InvoiceTotal",
                table: "Invoice",
                type: "float",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<float>(
                name: "RemainAmount",
                table: "CustomerPayments",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}

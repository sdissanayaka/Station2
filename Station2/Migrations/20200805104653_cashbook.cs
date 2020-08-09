using Microsoft.EntityFrameworkCore.Migrations;

namespace Station2.Migrations
{
    public partial class cashbook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashBooks",
                columns: table => new
                {
                    CashTableId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(nullable: false),
                    CashBookType = table.Column<int>(nullable: false),
                    PaymentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashBooks", x => x.CashTableId);
                    table.ForeignKey(
                        name: "FK_CashBooks_CustomerPayments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "CustomerPayments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashBooks_PaymentId",
                table: "CashBooks",
                column: "PaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashBooks");
        }
    }
}

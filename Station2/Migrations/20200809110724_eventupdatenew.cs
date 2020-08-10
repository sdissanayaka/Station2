using Microsoft.EntityFrameworkCore.Migrations;

namespace Station2.Migrations
{
    public partial class eventupdatenew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "servicetype",
                table: "Events",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "servicetype",
                table: "Events");
        }
    }
}

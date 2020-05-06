using Microsoft.EntityFrameworkCore.Migrations;

namespace P0.Migrations
{
    public partial class InitialCreatd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderTotalPrice",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderTotalPrice",
                table: "Orders");
        }
    }
}

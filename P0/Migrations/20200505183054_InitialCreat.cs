using Microsoft.EntityFrameworkCore.Migrations;

namespace P0.Migrations
{
    public partial class InitialCreat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductQuantity",
                table: "OrderProducts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductQuantity",
                table: "OrderProducts");
        }
    }
}

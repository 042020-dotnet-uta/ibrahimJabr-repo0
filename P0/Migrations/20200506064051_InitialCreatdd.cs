using Microsoft.EntityFrameworkCore.Migrations;

namespace P0.Migrations
{
    public partial class InitialCreatdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmen",
                table: "Customers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmen",
                table: "Customers");
        }
    }
}

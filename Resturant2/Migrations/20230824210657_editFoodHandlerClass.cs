using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant2.Migrations
{
    public partial class editFoodHandlerClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Menus");
        }
    }
}

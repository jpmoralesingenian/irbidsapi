using Microsoft.EntityFrameworkCore.Migrations;

namespace IrbidsAPI.Migrations
{
    public partial class AreaNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Area",
                table: "Word",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Word",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Word");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Word");
        }
    }
}

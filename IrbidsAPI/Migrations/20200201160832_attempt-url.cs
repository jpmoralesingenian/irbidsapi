using Microsoft.EntityFrameworkCore.Migrations;

namespace IrbidsAPI.Migrations
{
    public partial class attempturl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecordedURL",
                table: "Attempt",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordedURL",
                table: "Attempt");
        }
    }
}

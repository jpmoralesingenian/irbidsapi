using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IrbidsAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ani = table.Column<string>(maxLength: 100, nullable: false),
                    Score = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Word",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextEnglish = table.Column<string>(maxLength: 100, nullable: false),
                    TextSpanish = table.Column<string>(maxLength: 100, nullable: false),
                    AudioURL = table.Column<string>(maxLength: 200, nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Language = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Word", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attempt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Confidence = table.Column<float>(nullable: false),
                    WordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attempt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attempt_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attempt_Word_WordId",
                        column: x => x.WordId,
                        principalTable: "Word",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attempt_UserId",
                table: "Attempt",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Attempt_WordId",
                table: "Attempt",
                column: "WordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attempt");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Word");
        }
    }
}

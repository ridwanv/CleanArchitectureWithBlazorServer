using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Blazor.Infrastructure.Persistence.Migrations
{
    public partial class updateanswerTypepoly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "AnswerFormats");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AnswerFormats");

            migrationBuilder.CreateTable(
                name: "ShortTextAnswerFormats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortTextAnswerFormats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShortTextAnswerFormats_AnswerFormats_Id",
                        column: x => x.Id,
                        principalTable: "AnswerFormats",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShortTextAnswerFormats");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "AnswerFormats",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AnswerFormats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

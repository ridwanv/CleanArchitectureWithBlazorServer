using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Blazor.Infrastructure.Persistence.Migrations
{
    public partial class evalanswerformats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EvaluationAnswerFormats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    SelfAssessment = table.Column<int>(type: "int", nullable: false),
                    InternalAssessment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationAnswerFormats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationAnswerFormats_AnswerFormats_Id",
                        column: x => x.Id,
                        principalTable: "AnswerFormats",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvaluationAnswerFormats");
        }
    }
}

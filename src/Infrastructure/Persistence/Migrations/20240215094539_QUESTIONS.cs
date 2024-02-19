using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Blazor.Infrastructure.Persistence.Migrations
{
    public partial class QUESTIONS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "QuestionaireId",
                table: "Question",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuestionaireId",
                table: "Question",
                column: "QuestionaireId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Questionaires_QuestionaireId",
                table: "Question",
                column: "QuestionaireId",
                principalTable: "Questionaires",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Questionaires_QuestionaireId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_QuestionaireId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "QuestionaireId",
                table: "Question");
        }
    }
}

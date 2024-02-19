using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Blazor.Infrastructure.Persistence.Migrations
{
    public partial class questionResponses24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Questions_Questionaires_QuestionaireId",
            //    table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuestionaireId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionaireId",
                table: "Questions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "QuestionaireId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionaireId",
                table: "Questions",
                column: "QuestionaireId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Questions_Questionaires_QuestionaireId",
            //    table: "Questions",
            //    column: "QuestionaireId",
            //    principalTable: "Questionaires",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}

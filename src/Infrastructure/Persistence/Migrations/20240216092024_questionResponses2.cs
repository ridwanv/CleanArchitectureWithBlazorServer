using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Blazor.Infrastructure.Persistence.Migrations
{
    public partial class questionResponses2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionResponses",
                table: "QuestionResponses");

            migrationBuilder.DropIndex(
                name: "IX_QuestionResponses_SupplierQuestionaireId",
                table: "QuestionResponses");

            migrationBuilder.DropColumn(
                name: "QuestionResponseId",
                table: "QuestionResponses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionResponses",
                table: "QuestionResponses",
                columns: new[] { "SupplierQuestionaireId", "QuestionId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionResponses",
                table: "QuestionResponses");

            migrationBuilder.AddColumn<Guid>(
                name: "QuestionResponseId",
                table: "QuestionResponses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionResponses",
                table: "QuestionResponses",
                column: "QuestionResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponses_SupplierQuestionaireId",
                table: "QuestionResponses",
                column: "SupplierQuestionaireId");
        }
    }
}

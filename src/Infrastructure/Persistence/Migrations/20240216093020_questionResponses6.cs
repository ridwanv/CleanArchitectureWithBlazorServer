using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Blazor.Infrastructure.Persistence.Migrations
{
    public partial class questionResponses6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionResponses",
                table: "QuestionResponses");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "QuestionResponses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionResponses",
                table: "QuestionResponses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponses_SupplierQuestionaireId",
                table: "QuestionResponses",
                column: "SupplierQuestionaireId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionResponses",
                table: "QuestionResponses");

            migrationBuilder.DropIndex(
                name: "IX_QuestionResponses_SupplierQuestionaireId",
                table: "QuestionResponses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "QuestionResponses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionResponses",
                table: "QuestionResponses",
                columns: new[] { "SupplierQuestionaireId", "QuestionId" });
        }
    }
}

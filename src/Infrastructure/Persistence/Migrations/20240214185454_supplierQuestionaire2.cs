using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Blazor.Infrastructure.Persistence.Migrations
{
    public partial class supplierQuestionaire2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionaireResponse_AnswerFormats_AnswerFormatId",
                table: "QuestionaireResponse");

            migrationBuilder.DropIndex(
                name: "IX_QuestionaireResponse_AnswerFormatId",
                table: "QuestionaireResponse");

            migrationBuilder.DropColumn(
                name: "AnswerFormatId",
                table: "QuestionaireResponse");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "QuestionaireResponse",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "AnswerFormats",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AnswerFormats",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "AnswerFormats",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "AnswerFormats",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "QuestionaireResponse");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "AnswerFormats");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AnswerFormats");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "AnswerFormats");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "AnswerFormats");

            migrationBuilder.AddColumn<Guid>(
                name: "AnswerFormatId",
                table: "QuestionaireResponse",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_QuestionaireResponse_AnswerFormatId",
                table: "QuestionaireResponse",
                column: "AnswerFormatId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionaireResponse_AnswerFormats_AnswerFormatId",
                table: "QuestionaireResponse",
                column: "AnswerFormatId",
                principalTable: "AnswerFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

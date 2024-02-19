using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Blazor.Infrastructure.Persistence.Migrations
{
    public partial class questionResponses1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropIndex(
                name: "IX_QuestionResponses_QuestionResponseId1",
                table: "QuestionResponses");

            migrationBuilder.DropColumn(
                name: "QuestionResponseId1",
                table: "QuestionResponses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "QuestionResponseId1",
                table: "QuestionResponses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponses_QuestionResponseId1",
                table: "QuestionResponses",
                column: "QuestionResponseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionResponses_QuestionResponses_QuestionResponseId1",
                table: "QuestionResponses",
                column: "QuestionResponseId1",
                principalTable: "QuestionResponses",
                principalColumn: "QuestionResponseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

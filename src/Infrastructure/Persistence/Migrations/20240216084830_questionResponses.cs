using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Blazor.Infrastructure.Persistence.Migrations
{
    public partial class questionResponses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_AnswerFormats_AnswerTypeId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Questionaires_QuestionaireId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Section_SectionId",
                table: "Question");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_QuestionResponse_SupplierQuestionaires_SupplierQuestionaireId",
            //    table: "QuestionResponse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionResponse",
                table: "QuestionResponse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.RenameTable(
                name: "QuestionResponse",
                newName: "QuestionResponses");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.RenameIndex(
                name: "IX_Question_SectionId",
                table: "Questions",
                newName: "IX_Questions_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_QuestionaireId",
                table: "Questions",
                newName: "IX_Questions_QuestionaireId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_AnswerTypeId",
                table: "Questions",
                newName: "IX_Questions_AnswerTypeId");

            migrationBuilder.AddColumn<Guid>(
                name: "QuestionResponseId",
                table: "QuestionResponses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Answers",
                table: "QuestionResponses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "QuestionResponses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "QuestionResponseId1",
                table: "QuestionResponses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionResponses",
                table: "QuestionResponses",
                column: "QuestionResponseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponses_QuestionResponseId1",
                table: "QuestionResponses",
                column: "QuestionResponseId1");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponses_SupplierQuestionaireId",
                table: "QuestionResponses",
                column: "SupplierQuestionaireId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_QuestionResponses_QuestionResponses_QuestionResponseId1",
            //    table: "QuestionResponses",
            //    column: "QuestionResponseId1",
            //    principalTable: "QuestionResponses",
            //    principalColumn: "QuestionResponseId",
            //    onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionResponses_SupplierQuestionaires_SupplierQuestionaireId",
                table: "QuestionResponses",
                column: "SupplierQuestionaireId",
                principalTable: "SupplierQuestionaires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_AnswerFormats_AnswerTypeId",
                table: "Questions",
                column: "AnswerTypeId",
                principalTable: "AnswerFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Questions_Questionaires_QuestionaireId",
            //    table: "Questions",
            //    column: "QuestionaireId",
            //    principalTable: "Questionaires",
            //    principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Section_SectionId",
                table: "Questions",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionResponses_QuestionResponses_QuestionResponseId1",
                table: "QuestionResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionResponses_SupplierQuestionaires_SupplierQuestionaireId",
                table: "QuestionResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_AnswerFormats_AnswerTypeId",
                table: "Questions");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Questions_Questionaires_QuestionaireId",
            //    table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Section_SectionId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionResponses",
                table: "QuestionResponses");

            migrationBuilder.DropIndex(
                name: "IX_QuestionResponses_QuestionResponseId1",
                table: "QuestionResponses");

            migrationBuilder.DropIndex(
                name: "IX_QuestionResponses_SupplierQuestionaireId",
                table: "QuestionResponses");

            migrationBuilder.DropColumn(
                name: "QuestionResponseId",
                table: "QuestionResponses");

            migrationBuilder.DropColumn(
                name: "Answers",
                table: "QuestionResponses");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "QuestionResponses");

            migrationBuilder.DropColumn(
                name: "QuestionResponseId1",
                table: "QuestionResponses");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.RenameTable(
                name: "QuestionResponses",
                newName: "QuestionResponse");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_SectionId",
                table: "Question",
                newName: "IX_Question_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_QuestionaireId",
                table: "Question",
                newName: "IX_Question_QuestionaireId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_AnswerTypeId",
                table: "Question",
                newName: "IX_Question_AnswerTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionResponse",
                table: "QuestionResponse",
                columns: new[] { "SupplierQuestionaireId", "QuestionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Question_AnswerFormats_AnswerTypeId",
                table: "Question",
                column: "AnswerTypeId",
                principalTable: "AnswerFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Questionaires_QuestionaireId",
                table: "Question",
                column: "QuestionaireId",
                principalTable: "Questionaires",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Section_SectionId",
                table: "Question",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_QuestionResponse_SupplierQuestionaires_SupplierQuestionaireId",
            //    table: "QuestionResponse",
            //    column: "SupplierQuestionaireId",
            //    principalTable: "SupplierQuestionaires",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}

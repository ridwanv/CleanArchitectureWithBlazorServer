using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Blazor.Infrastructure.Persistence.Migrations
{
    public partial class invitations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationAnswerFormats_AnswerFormats_Id",
                table: "EvaluationAnswerFormats");

            migrationBuilder.DropForeignKey(
                name: "FK_ShortTextAnswerFormats_AnswerFormats_Id",
                table: "ShortTextAnswerFormats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShortTextAnswerFormats",
                table: "ShortTextAnswerFormats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EvaluationAnswerFormats",
                table: "EvaluationAnswerFormats");

            migrationBuilder.RenameTable(
                name: "ShortTextAnswerFormats",
                newName: "AnswerFormatShortTexts");

            migrationBuilder.RenameTable(
                name: "EvaluationAnswerFormats",
                newName: "AnswerFormatEvaluations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswerFormatShortTexts",
                table: "AnswerFormatShortTexts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswerFormatEvaluations",
                table: "AnswerFormatEvaluations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Questionaire",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionaire", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invitations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionaireId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invitations_Questionaire_QuestionaireId",
                        column: x => x.QuestionaireId,
                        principalTable: "Questionaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invitations_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionaireId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Section_Questionaire_QuestionaireId",
                        column: x => x.QuestionaireId,
                        principalTable: "Questionaire",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Section_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerTypeEnum = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionLabel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    AnswerTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_AnswerFormats_AnswerTypeId",
                        column: x => x.AnswerTypeId,
                        principalTable: "AnswerFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Question_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_QuestionaireId",
                table: "Invitations",
                column: "QuestionaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_SupplierId",
                table: "Invitations",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_AnswerTypeId",
                table: "Question",
                column: "AnswerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_SectionId",
                table: "Question",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_QuestionaireId",
                table: "Section",
                column: "QuestionaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_SectionId",
                table: "Section",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerFormatEvaluations_AnswerFormats_Id",
                table: "AnswerFormatEvaluations",
                column: "Id",
                principalTable: "AnswerFormats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerFormatShortTexts_AnswerFormats_Id",
                table: "AnswerFormatShortTexts",
                column: "Id",
                principalTable: "AnswerFormats",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerFormatEvaluations_AnswerFormats_Id",
                table: "AnswerFormatEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerFormatShortTexts_AnswerFormats_Id",
                table: "AnswerFormatShortTexts");

            migrationBuilder.DropTable(
                name: "Invitations");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Questionaire");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswerFormatShortTexts",
                table: "AnswerFormatShortTexts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswerFormatEvaluations",
                table: "AnswerFormatEvaluations");

            migrationBuilder.RenameTable(
                name: "AnswerFormatShortTexts",
                newName: "ShortTextAnswerFormats");

            migrationBuilder.RenameTable(
                name: "AnswerFormatEvaluations",
                newName: "EvaluationAnswerFormats");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShortTextAnswerFormats",
                table: "ShortTextAnswerFormats",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EvaluationAnswerFormats",
                table: "EvaluationAnswerFormats",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationAnswerFormats_AnswerFormats_Id",
                table: "EvaluationAnswerFormats",
                column: "Id",
                principalTable: "AnswerFormats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShortTextAnswerFormats_AnswerFormats_Id",
                table: "ShortTextAnswerFormats",
                column: "Id",
                principalTable: "AnswerFormats",
                principalColumn: "Id");
        }
    }
}

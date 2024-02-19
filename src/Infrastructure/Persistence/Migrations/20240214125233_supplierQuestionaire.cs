using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Blazor.Infrastructure.Persistence.Migrations
{
    public partial class supplierQuestionaire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionaireResponse",
                columns: table => new
                {
                    SupplierQuestionaireId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerFormatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierQuestionaireSupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierQuestionaireQuestionaireId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionaireResponse", x => new { x.SupplierQuestionaireId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_QuestionaireResponse_AnswerFormats_AnswerFormatId",
                        column: x => x.AnswerFormatId,
                        principalTable: "AnswerFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionaireResponse_SupplierQuestionaires_SupplierQuestionaireSupplierId_SupplierQuestionaireQuestionaireId",
                        columns: x => new { x.SupplierQuestionaireSupplierId, x.SupplierQuestionaireQuestionaireId },
                        principalTable: "SupplierQuestionaires",
                        principalColumns: new[] { "SupplierId", "QuestionaireId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionaireResponse_AnswerFormatId",
                table: "QuestionaireResponse",
                column: "AnswerFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionaireResponse_SupplierQuestionaireSupplierId_SupplierQuestionaireQuestionaireId",
                table: "QuestionaireResponse",
                columns: new[] { "SupplierQuestionaireSupplierId", "SupplierQuestionaireQuestionaireId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionaireResponse");
        }
    }
}

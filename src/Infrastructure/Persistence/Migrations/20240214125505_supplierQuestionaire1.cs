using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Blazor.Infrastructure.Persistence.Migrations
{
    public partial class supplierQuestionaire1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionaireResponse_SupplierQuestionaires_SupplierQuestionaireSupplierId_SupplierQuestionaireQuestionaireId",
                table: "QuestionaireResponse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierQuestionaires",
                table: "SupplierQuestionaires");

            migrationBuilder.DropIndex(
                name: "IX_QuestionaireResponse_SupplierQuestionaireSupplierId_SupplierQuestionaireQuestionaireId",
                table: "QuestionaireResponse");

            migrationBuilder.DropColumn(
                name: "SupplierQuestionaireQuestionaireId",
                table: "QuestionaireResponse");

            migrationBuilder.DropColumn(
                name: "SupplierQuestionaireSupplierId",
                table: "QuestionaireResponse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierQuestionaires",
                table: "SupplierQuestionaires",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierQuestionaires_SupplierId",
                table: "SupplierQuestionaires",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionaireResponse_SupplierQuestionaires_SupplierQuestionaireId",
                table: "QuestionaireResponse",
                column: "SupplierQuestionaireId",
                principalTable: "SupplierQuestionaires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionaireResponse_SupplierQuestionaires_SupplierQuestionaireId",
                table: "QuestionaireResponse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierQuestionaires",
                table: "SupplierQuestionaires");

            migrationBuilder.DropIndex(
                name: "IX_SupplierQuestionaires_SupplierId",
                table: "SupplierQuestionaires");

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierQuestionaireQuestionaireId",
                table: "QuestionaireResponse",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierQuestionaireSupplierId",
                table: "QuestionaireResponse",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierQuestionaires",
                table: "SupplierQuestionaires",
                columns: new[] { "SupplierId", "QuestionaireId" });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionaireResponse_SupplierQuestionaireSupplierId_SupplierQuestionaireQuestionaireId",
                table: "QuestionaireResponse",
                columns: new[] { "SupplierQuestionaireSupplierId", "SupplierQuestionaireQuestionaireId" });

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionaireResponse_SupplierQuestionaires_SupplierQuestionaireSupplierId_SupplierQuestionaireQuestionaireId",
                table: "QuestionaireResponse",
                columns: new[] { "SupplierQuestionaireSupplierId", "SupplierQuestionaireQuestionaireId" },
                principalTable: "SupplierQuestionaires",
                principalColumns: new[] { "SupplierId", "QuestionaireId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Blazor.Infrastructure.Persistence.Migrations
{
    public partial class onetomanyy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Questionaire_QuestionaireId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_Questionaire_QuestionaireId",
                table: "Invitations");

            migrationBuilder.DropForeignKey(
                name: "FK_Questionaire_Suppliers_SupplierId",
                table: "Questionaire");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Questionaire_QuestionaireId",
                table: "Section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questionaire",
                table: "Questionaire");

            migrationBuilder.DropIndex(
                name: "IX_Questionaire_SupplierId",
                table: "Questionaire");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Questionaire");

            migrationBuilder.RenameTable(
                name: "Questionaire",
                newName: "Questionaires");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questionaires",
                table: "Questionaires",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "QuestionaireSupplier",
                columns: table => new
                {
                    QuestionairesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SuppliersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionaireSupplier", x => new { x.QuestionairesId, x.SuppliersId });
                    table.ForeignKey(
                        name: "FK_QuestionaireSupplier_Questionaires_QuestionairesId",
                        column: x => x.QuestionairesId,
                        principalTable: "Questionaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionaireSupplier_Suppliers_SuppliersId",
                        column: x => x.SuppliersId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierQuestionaires",
                columns: table => new
                {
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionaireId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierQuestionaires", x => new { x.SupplierId, x.QuestionaireId });
                    table.ForeignKey(
                        name: "FK_SupplierQuestionaires_Questionaires_QuestionaireId",
                        column: x => x.QuestionaireId,
                        principalTable: "Questionaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierQuestionaires_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionaireSupplier_SuppliersId",
                table: "QuestionaireSupplier",
                column: "SuppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierQuestionaires_QuestionaireId",
                table: "SupplierQuestionaires",
                column: "QuestionaireId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Questionaires_QuestionaireId",
                table: "Events",
                column: "QuestionaireId",
                principalTable: "Questionaires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_Questionaires_QuestionaireId",
                table: "Invitations",
                column: "QuestionaireId",
                principalTable: "Questionaires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Questionaires_QuestionaireId",
                table: "Section",
                column: "QuestionaireId",
                principalTable: "Questionaires",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Questionaires_QuestionaireId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_Questionaires_QuestionaireId",
                table: "Invitations");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Questionaires_QuestionaireId",
                table: "Section");

            migrationBuilder.DropTable(
                name: "QuestionaireSupplier");

            migrationBuilder.DropTable(
                name: "SupplierQuestionaires");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questionaires",
                table: "Questionaires");

            migrationBuilder.RenameTable(
                name: "Questionaires",
                newName: "Questionaire");

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                table: "Questionaire",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questionaire",
                table: "Questionaire",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Questionaire_SupplierId",
                table: "Questionaire",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Questionaire_QuestionaireId",
                table: "Events",
                column: "QuestionaireId",
                principalTable: "Questionaire",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_Questionaire_QuestionaireId",
                table: "Invitations",
                column: "QuestionaireId",
                principalTable: "Questionaire",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questionaire_Suppliers_SupplierId",
                table: "Questionaire",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Questionaire_QuestionaireId",
                table: "Section",
                column: "QuestionaireId",
                principalTable: "Questionaire",
                principalColumn: "Id");
        }
    }
}

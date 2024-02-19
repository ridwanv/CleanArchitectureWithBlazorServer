using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Blazor.Infrastructure.Persistence.Migrations
{
    public partial class supplierQuestionaire4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionaireResponse");

            migrationBuilder.CreateTable(
                name: "QuestionResponse",
                columns: table => new
                {
                    SupplierQuestionaireId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionResponse", x => new { x.SupplierQuestionaireId, x.QuestionId });
                    //table.ForeignKey(
                    //    name: "FK_QuestionResponse_SupplierQuestionaires_SupplierQuestionaireId",
                    //    column: x => x.SupplierQuestionaireId,
                    //    principalTable: "SupplierQuestionaires",
                    //    principalColumn: "Id",
                    //    onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionResponse");

            migrationBuilder.CreateTable(
                name: "QuestionaireResponse",
                columns: table => new
                {
                    SupplierQuestionaireId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionaireResponse", x => new { x.SupplierQuestionaireId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_QuestionaireResponse_SupplierQuestionaires_SupplierQuestionaireId",
                        column: x => x.SupplierQuestionaireId,
                        principalTable: "SupplierQuestionaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}

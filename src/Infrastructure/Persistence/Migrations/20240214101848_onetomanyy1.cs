using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Blazor.Infrastructure.Persistence.Migrations
{
    public partial class onetomanyy1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionaireSupplier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_QuestionaireSupplier_SuppliersId",
                table: "QuestionaireSupplier",
                column: "SuppliersId");
        }
    }
}

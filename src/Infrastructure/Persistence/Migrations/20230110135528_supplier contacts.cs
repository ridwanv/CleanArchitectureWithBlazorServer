using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Blazor.Infrastructure.Persistence.Migrations
{
    public partial class suppliercontacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Suppliers_SupplierId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_SupplierId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Contacts");

            migrationBuilder.CreateTable(
                name: "ContactSupplier",
                columns: table => new
                {
                    ContactsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SuppliersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactSupplier", x => new { x.ContactsId, x.SuppliersId });
                    table.ForeignKey(
                        name: "FK_ContactSupplier_Contacts_ContactsId",
                        column: x => x.ContactsId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactSupplier_Suppliers_SuppliersId",
                        column: x => x.SuppliersId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactSupplier_SuppliersId",
                table: "ContactSupplier",
                column: "SuppliersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactSupplier");

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                table: "Contacts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_SupplierId",
                table: "Contacts",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Suppliers_SupplierId",
                table: "Contacts",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Blazor.Infrastructure.Persistence.Migrations
{
    public partial class Updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Questionaire",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Questionaire",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                table: "Questionaire",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questionaire_SupplierId",
                table: "Questionaire",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questionaire_Suppliers_SupplierId",
                table: "Questionaire",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questionaire_Suppliers_SupplierId",
                table: "Questionaire");

            migrationBuilder.DropIndex(
                name: "IX_Questionaire_SupplierId",
                table: "Questionaire");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Questionaire");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Questionaire");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Questionaire");
        }
    }
}

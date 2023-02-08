using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Blazor.Infrastructure.Persistence.Migrations
{
    public partial class suppolierinvites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Events_EventId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_EventId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Suppliers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "Suppliers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_EventId",
                table: "Suppliers",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Events_EventId",
                table: "Suppliers",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}

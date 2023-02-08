using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Blazor.Infrastructure.Persistence.Migrations
{
    public partial class AddSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Addresses_PhysicalAddressId1",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_PhysicalAddressId1",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "PhysicalAddressId1",
                table: "Suppliers");

            migrationBuilder.AlterColumn<Guid>(
                name: "PhysicalAddressId",
                table: "Suppliers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_PhysicalAddressId",
                table: "Suppliers",
                column: "PhysicalAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Addresses_PhysicalAddressId",
                table: "Suppliers",
                column: "PhysicalAddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Addresses_PhysicalAddressId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_PhysicalAddressId",
                table: "Suppliers");

            migrationBuilder.AlterColumn<string>(
                name: "PhysicalAddressId",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PhysicalAddressId1",
                table: "Suppliers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_PhysicalAddressId1",
                table: "Suppliers",
                column: "PhysicalAddressId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Addresses_PhysicalAddressId1",
                table: "Suppliers",
                column: "PhysicalAddressId1",
                principalTable: "Addresses",
                principalColumn: "Id");
        }
    }
}

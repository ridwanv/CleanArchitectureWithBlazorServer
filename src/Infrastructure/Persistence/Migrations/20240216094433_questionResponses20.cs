﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Blazor.Infrastructure.Persistence.Migrations
{
    public partial class questionResponses20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "QuestionResponses");

            migrationBuilder.CreateTable(
                name: "QuestionResponseShortTexts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionResponseShortTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionResponseShortTexts_QuestionResponses_Id",
                        column: x => x.Id,
                        principalTable: "QuestionResponses",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionResponseShortTexts");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "QuestionResponses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

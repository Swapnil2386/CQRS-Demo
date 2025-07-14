using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CQRSAndMediatRDemo.Migrations
{
    public partial class AddJwtTokenTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "ClassDetailsId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JwtTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JwtTokens", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassDetailsId",
                table: "Students",
                column: "ClassDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassDetailsId",
                table: "Students",
                column: "ClassDetailsId",
                principalTable: "Classes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassDetailsId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "JwtTokens");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassDetailsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ClassDetailsId",
                table: "Students");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

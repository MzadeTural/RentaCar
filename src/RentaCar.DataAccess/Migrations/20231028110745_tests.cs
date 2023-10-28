using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentaCar.DataAccess.Migrations
{
    public partial class tests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrentLoactions_AspNetUsers_AppUserId1",
                table: "CurrentLoactions");

            migrationBuilder.DropIndex(
                name: "IX_CurrentLoactions_AppUserId1",
                table: "CurrentLoactions");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "CurrentLoactions");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "CurrentLoactions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentLoactions_AppUserId",
                table: "CurrentLoactions",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentLoactions_AspNetUsers_AppUserId",
                table: "CurrentLoactions",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrentLoactions_AspNetUsers_AppUserId",
                table: "CurrentLoactions");

            migrationBuilder.DropIndex(
                name: "IX_CurrentLoactions_AppUserId",
                table: "CurrentLoactions");

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "CurrentLoactions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "CurrentLoactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrentLoactions_AppUserId1",
                table: "CurrentLoactions",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentLoactions_AspNetUsers_AppUserId1",
                table: "CurrentLoactions",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

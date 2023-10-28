using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentaCar.DataAccess.Migrations
{
    public partial class Fixed_Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrentLoactions_AspNetUsers_AppUserId",
                table: "CurrentLoactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscribtionRecords_AspNetUsers_AppUserId",
                table: "SubscribtionRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCards_AspNetUsers_AppUserId",
                table: "UserCards");

            migrationBuilder.DropIndex(
                name: "IX_UserCards_AppUserId",
                table: "UserCards");

            migrationBuilder.DropIndex(
                name: "IX_SubscribtionRecords_AppUserId",
                table: "SubscribtionRecords");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_CurrentLoactions_AppUserId",
                table: "CurrentLoactions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserCards");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CurrentLoactions");

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "UserCards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "UserCards",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "SubscribtionRecords",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "SubscribtionRecords",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "CurrentLoactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "CurrentLoactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCards_AppUserId1",
                table: "UserCards",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_SubscribtionRecords_AppUserId1",
                table: "SubscribtionRecords",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId1",
                table: "Reservations",
                column: "UserId1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId1",
                table: "Reservations",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscribtionRecords_AspNetUsers_AppUserId1",
                table: "SubscribtionRecords",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCards_AspNetUsers_AppUserId1",
                table: "UserCards",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrentLoactions_AspNetUsers_AppUserId1",
                table: "CurrentLoactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId1",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscribtionRecords_AspNetUsers_AppUserId1",
                table: "SubscribtionRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCards_AspNetUsers_AppUserId1",
                table: "UserCards");

            migrationBuilder.DropIndex(
                name: "IX_UserCards_AppUserId1",
                table: "UserCards");

            migrationBuilder.DropIndex(
                name: "IX_SubscribtionRecords_AppUserId1",
                table: "SubscribtionRecords");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserId1",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_CurrentLoactions_AppUserId1",
                table: "CurrentLoactions");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "UserCards");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "SubscribtionRecords");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "CurrentLoactions");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "UserCards",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserCards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "SubscribtionRecords",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "CurrentLoactions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CurrentLoactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserCards_AppUserId",
                table: "UserCards",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscribtionRecords_AppUserId",
                table: "SubscribtionRecords",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentLoactions_AppUserId",
                table: "CurrentLoactions",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentLoactions_AspNetUsers_AppUserId",
                table: "CurrentLoactions",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubscribtionRecords_AspNetUsers_AppUserId",
                table: "SubscribtionRecords",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCards_AspNetUsers_AppUserId",
                table: "UserCards",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

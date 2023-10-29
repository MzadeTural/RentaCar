using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentaCar.DataAccess.Migrations
{
    public partial class Create_WishList_And_Status_Table_Fixed_reservation_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Locations_LocationId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "IsAccept",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Reservations",
                newName: "StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_LocationId",
                table: "Reservations",
                newName: "IX_Reservations_StatusId");

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UptadetAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishLists_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishLists_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DeliveryLocationId",
                table: "Reservations",
                column: "DeliveryLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TakeAwayLoactionId",
                table: "Reservations",
                column: "TakeAwayLoactionId");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_AppUserId",
                table: "WishLists",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_CarId",
                table: "WishLists",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Locations_DeliveryLocationId",
                table: "Reservations",
                column: "DeliveryLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Locations_TakeAwayLoactionId",
                table: "Reservations",
                column: "TakeAwayLoactionId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Statuses_StatusId",
                table: "Reservations",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Locations_DeliveryLocationId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Locations_TakeAwayLoactionId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Statuses_StatusId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_DeliveryLocationId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_TakeAwayLoactionId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Reservations",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_StatusId",
                table: "Reservations",
                newName: "IX_Reservations_LocationId");

            migrationBuilder.AddColumn<bool>(
                name: "IsAccept",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Locations_LocationId",
                table: "Reservations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

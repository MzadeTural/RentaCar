using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentaCar.DataAccess.Migrations
{
    public partial class Added_New_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccept",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccept",
                table: "Reservations");
        }
    }
}

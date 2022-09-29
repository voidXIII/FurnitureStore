using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    public partial class ModifiedEntityConfigs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomTypeId",
                table: "RoomTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BookingStatusId",
                table: "BookingStatuses",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RoomTypes",
                newName: "RoomTypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BookingStatuses",
                newName: "BookingStatusId");
        }
    }
}

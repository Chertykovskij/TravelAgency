using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Migrations
{
    public partial class UpdateHotelHotelFacility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelHotelFacility_HotelFacility_RoomAmenityId",
                table: "HotelHotelFacility");

            migrationBuilder.RenameColumn(
                name: "RoomAmenityId",
                table: "HotelHotelFacility",
                newName: "HotelFacilityId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelHotelFacility_RoomAmenityId",
                table: "HotelHotelFacility",
                newName: "IX_HotelHotelFacility_HotelFacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelHotelFacility_HotelFacility_HotelFacilityId",
                table: "HotelHotelFacility",
                column: "HotelFacilityId",
                principalTable: "HotelFacility",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelHotelFacility_HotelFacility_HotelFacilityId",
                table: "HotelHotelFacility");

            migrationBuilder.RenameColumn(
                name: "HotelFacilityId",
                table: "HotelHotelFacility",
                newName: "RoomAmenityId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelHotelFacility_HotelFacilityId",
                table: "HotelHotelFacility",
                newName: "IX_HotelHotelFacility_RoomAmenityId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelHotelFacility_HotelFacility_RoomAmenityId",
                table: "HotelHotelFacility",
                column: "RoomAmenityId",
                principalTable: "HotelFacility",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

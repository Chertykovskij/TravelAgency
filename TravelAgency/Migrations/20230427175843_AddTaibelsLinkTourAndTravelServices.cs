using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Migrations
{
    public partial class AddTaibelsLinkTourAndTravelServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourIncludedServices_Tours_NotIcludedToursId",
                table: "TourIncludedServices");

            migrationBuilder.DropForeignKey(
                name: "FK_TourIncludedServices_TravelService_IncludedServicesId",
                table: "TourIncludedServices");

            migrationBuilder.DropForeignKey(
                name: "FK_TourNotIncludedServices_Tours_IncludedToursId",
                table: "TourNotIncludedServices");

            migrationBuilder.DropForeignKey(
                name: "FK_TourNotIncludedServices_TravelService_NotIncludedServicesId",
                table: "TourNotIncludedServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourNotIncludedServices",
                table: "TourNotIncludedServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourIncludedServices",
                table: "TourIncludedServices");

            migrationBuilder.DropColumn(
                name: "IncludedServicesId",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "NotIncludedServicesId",
                table: "Tours");

            migrationBuilder.RenameColumn(
                name: "NotIncludedServicesId",
                table: "TourNotIncludedServices",
                newName: "TravelServiceId");

            migrationBuilder.RenameColumn(
                name: "IncludedToursId",
                table: "TourNotIncludedServices",
                newName: "TourId");

            migrationBuilder.RenameIndex(
                name: "IX_TourNotIncludedServices_NotIncludedServicesId",
                table: "TourNotIncludedServices",
                newName: "IX_TourNotIncludedServices_TravelServiceId");

            migrationBuilder.RenameColumn(
                name: "NotIcludedToursId",
                table: "TourIncludedServices",
                newName: "TravelServiceId");

            migrationBuilder.RenameColumn(
                name: "IncludedServicesId",
                table: "TourIncludedServices",
                newName: "TourId");

            migrationBuilder.RenameIndex(
                name: "IX_TourIncludedServices_NotIcludedToursId",
                table: "TourIncludedServices",
                newName: "IX_TourIncludedServices_TravelServiceId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TourNotIncludedServices",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TourIncludedServices",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourNotIncludedServices",
                table: "TourNotIncludedServices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourIncludedServices",
                table: "TourIncludedServices",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TourNotIncludedServices_TourId",
                table: "TourNotIncludedServices",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_TourIncludedServices_TourId",
                table: "TourIncludedServices",
                column: "TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourIncludedServices_Tours_TourId",
                table: "TourIncludedServices",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourIncludedServices_TravelService_TravelServiceId",
                table: "TourIncludedServices",
                column: "TravelServiceId",
                principalTable: "TravelService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourNotIncludedServices_Tours_TourId",
                table: "TourNotIncludedServices",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourNotIncludedServices_TravelService_TravelServiceId",
                table: "TourNotIncludedServices",
                column: "TravelServiceId",
                principalTable: "TravelService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourIncludedServices_Tours_TourId",
                table: "TourIncludedServices");

            migrationBuilder.DropForeignKey(
                name: "FK_TourIncludedServices_TravelService_TravelServiceId",
                table: "TourIncludedServices");

            migrationBuilder.DropForeignKey(
                name: "FK_TourNotIncludedServices_Tours_TourId",
                table: "TourNotIncludedServices");

            migrationBuilder.DropForeignKey(
                name: "FK_TourNotIncludedServices_TravelService_TravelServiceId",
                table: "TourNotIncludedServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourNotIncludedServices",
                table: "TourNotIncludedServices");

            migrationBuilder.DropIndex(
                name: "IX_TourNotIncludedServices_TourId",
                table: "TourNotIncludedServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourIncludedServices",
                table: "TourIncludedServices");

            migrationBuilder.DropIndex(
                name: "IX_TourIncludedServices_TourId",
                table: "TourIncludedServices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TourNotIncludedServices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TourIncludedServices");

            migrationBuilder.RenameColumn(
                name: "TravelServiceId",
                table: "TourNotIncludedServices",
                newName: "NotIncludedServicesId");

            migrationBuilder.RenameColumn(
                name: "TourId",
                table: "TourNotIncludedServices",
                newName: "IncludedToursId");

            migrationBuilder.RenameIndex(
                name: "IX_TourNotIncludedServices_TravelServiceId",
                table: "TourNotIncludedServices",
                newName: "IX_TourNotIncludedServices_NotIncludedServicesId");

            migrationBuilder.RenameColumn(
                name: "TravelServiceId",
                table: "TourIncludedServices",
                newName: "NotIcludedToursId");

            migrationBuilder.RenameColumn(
                name: "TourId",
                table: "TourIncludedServices",
                newName: "IncludedServicesId");

            migrationBuilder.RenameIndex(
                name: "IX_TourIncludedServices_TravelServiceId",
                table: "TourIncludedServices",
                newName: "IX_TourIncludedServices_NotIcludedToursId");

            migrationBuilder.AddColumn<int>(
                name: "IncludedServicesId",
                table: "Tours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NotIncludedServicesId",
                table: "Tours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourNotIncludedServices",
                table: "TourNotIncludedServices",
                columns: new[] { "IncludedToursId", "NotIncludedServicesId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourIncludedServices",
                table: "TourIncludedServices",
                columns: new[] { "IncludedServicesId", "NotIcludedToursId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TourIncludedServices_Tours_NotIcludedToursId",
                table: "TourIncludedServices",
                column: "NotIcludedToursId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourIncludedServices_TravelService_IncludedServicesId",
                table: "TourIncludedServices",
                column: "IncludedServicesId",
                principalTable: "TravelService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourNotIncludedServices_Tours_IncludedToursId",
                table: "TourNotIncludedServices",
                column: "IncludedToursId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourNotIncludedServices_TravelService_NotIncludedServicesId",
                table: "TourNotIncludedServices",
                column: "NotIncludedServicesId",
                principalTable: "TravelService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

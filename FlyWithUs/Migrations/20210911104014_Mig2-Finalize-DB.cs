using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class Mig2FinalizeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinationCityId",
                table: "Travels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OriginCityId",
                table: "Travels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MultiPartTravel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    TravelId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiPartTravel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultiPartTravel_Travels_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Travels_DestinationCityId",
                table: "Travels",
                column: "DestinationCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_OriginCityId",
                table: "Travels",
                column: "OriginCityId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiPartTravel_TravelId",
                table: "MultiPartTravel",
                column: "TravelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Cities_DestinationCityId",
                table: "Travels",
                column: "DestinationCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Cities_OriginCityId",
                table: "Travels",
                column: "OriginCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Cities_DestinationCityId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Cities_OriginCityId",
                table: "Travels");

            migrationBuilder.DropTable(
                name: "MultiPartTravel");

            migrationBuilder.DropIndex(
                name: "IX_Travels_DestinationCityId",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Travels_OriginCityId",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "DestinationCityId",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "OriginCityId",
                table: "Travels");
        }
    }
}

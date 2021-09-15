using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class MigUpateTD2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgancyId",
                table: "TravelDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AgancyId",
                table: "Agancies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TravelDetails_AgancyId",
                table: "TravelDetails",
                column: "AgancyId");

            migrationBuilder.CreateIndex(
                name: "IX_Agancies_AgancyId",
                table: "Agancies",
                column: "AgancyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agancies_Agancies_AgancyId",
                table: "Agancies",
                column: "AgancyId",
                principalTable: "Agancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelDetails_Agancies_AgancyId",
                table: "TravelDetails",
                column: "AgancyId",
                principalTable: "Agancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agancies_Agancies_AgancyId",
                table: "Agancies");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelDetails_Agancies_AgancyId",
                table: "TravelDetails");

            migrationBuilder.DropIndex(
                name: "IX_TravelDetails_AgancyId",
                table: "TravelDetails");

            migrationBuilder.DropIndex(
                name: "IX_Agancies_AgancyId",
                table: "Agancies");

            migrationBuilder.DropColumn(
                name: "AgancyId",
                table: "TravelDetails");

            migrationBuilder.DropColumn(
                name: "AgancyId",
                table: "Agancies");
        }
    }
}

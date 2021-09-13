using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class MigUpdateAirAgancy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airplanes_Agancies_AgancyId",
                table: "Airplanes");

            migrationBuilder.DropIndex(
                name: "IX_Airplanes_AgancyId",
                table: "Airplanes");

            migrationBuilder.AlterColumn<int>(
                name: "AgancyId",
                table: "Airplanes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Airplanes");

            migrationBuilder.AlterColumn<int>(
                name: "AgancyId",
                table: "Airplanes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Airplanes_AgancyId",
                table: "Airplanes",
                column: "AgancyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Airplanes_Agancies_AgancyId",
                table: "Airplanes",
                column: "AgancyId",
                principalTable: "Agancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

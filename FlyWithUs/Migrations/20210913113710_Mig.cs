using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airplanes_Agancies_AgancyId",
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

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Airplanes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Airplanes_Agancies_AgancyId",
                table: "Airplanes",
                column: "AgancyId",
                principalTable: "Agancies",
                principalColumn: "Id",
                onUpdate:ReferentialAction.NoAction,
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airplanes_Agancies_AgancyId",
                table: "Airplanes");

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

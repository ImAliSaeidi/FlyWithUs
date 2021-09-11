using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class MigUpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MultiPartTravel_Travels_TravelId",
                table: "MultiPartTravel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MultiPartTravel",
                table: "MultiPartTravel");

            migrationBuilder.RenameTable(
                name: "MultiPartTravel",
                newName: "MultiPartTravels");

            migrationBuilder.RenameIndex(
                name: "IX_MultiPartTravel_TravelId",
                table: "MultiPartTravels",
                newName: "IX_MultiPartTravels_TravelId");

            migrationBuilder.AlterColumn<string>(
                name: "PassportIssunaceDate",
                table: "User",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "PassportExpirationDate",
                table: "User",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "BirthdateAD",
                table: "User",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Birthdate",
                table: "User",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MultiPartTravels",
                table: "MultiPartTravels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MultiPartTravels_Travels_TravelId",
                table: "MultiPartTravels",
                column: "TravelId",
                principalTable: "Travels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MultiPartTravels_Travels_TravelId",
                table: "MultiPartTravels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MultiPartTravels",
                table: "MultiPartTravels");

            migrationBuilder.RenameTable(
                name: "MultiPartTravels",
                newName: "MultiPartTravel");

            migrationBuilder.RenameIndex(
                name: "IX_MultiPartTravels_TravelId",
                table: "MultiPartTravel",
                newName: "IX_MultiPartTravel_TravelId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PassportIssunaceDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PassportExpirationDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthdateAD",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthdate",
                table: "User",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MultiPartTravel",
                table: "MultiPartTravel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MultiPartTravel_Travels_TravelId",
                table: "MultiPartTravel",
                column: "TravelId",
                principalTable: "Travels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

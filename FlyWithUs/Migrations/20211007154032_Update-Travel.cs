using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class UpdateTravel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Airplanes_AirplaneId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Airports_DestinationAirportId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Airports_OriginAirportId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Cities_DestinationCityId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Cities_OriginCityId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Countries_DestinationCountryId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Countries_OriginCountryId",
                table: "Travels");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: "4ea62ba4-3b2c-46cd-ac20-071cfc04679f");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: "b13ffe5b-d8ad-43b0-92a4-13103b69f37a");

            migrationBuilder.AlterColumn<int>(
                name: "OriginCountryId",
                table: "Travels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OriginCityId",
                table: "Travels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OriginAirportId",
                table: "Travels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DestinationCountryId",
                table: "Travels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DestinationCityId",
                table: "Travels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DestinationAirportId",
                table: "Travels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AirplaneId",
                table: "Travels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1af962a6-d464-467f-8fea-8f6e9c4be780", "25aef75d-ec1b-4684-a79a-a5fe2694cf1c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "586faa77-67b7-477e-849f-e174c7924f95", "74420f99-6c7a-44ad-bc18-6bdfe611136c", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Airplanes_AirplaneId",
                table: "Travels",
                column: "AirplaneId",
                principalTable: "Airplanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Airports_DestinationAirportId",
                table: "Travels",
                column: "DestinationAirportId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Airports_OriginAirportId",
                table: "Travels",
                column: "OriginAirportId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Cities_DestinationCityId",
                table: "Travels",
                column: "DestinationCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Cities_OriginCityId",
                table: "Travels",
                column: "OriginCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Countries_DestinationCountryId",
                table: "Travels",
                column: "DestinationCountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Countries_OriginCountryId",
                table: "Travels",
                column: "OriginCountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Airplanes_AirplaneId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Airports_DestinationAirportId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Airports_OriginAirportId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Cities_DestinationCityId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Cities_OriginCityId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Countries_DestinationCountryId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Countries_OriginCountryId",
                table: "Travels");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95");

            migrationBuilder.AlterColumn<int>(
                name: "OriginCountryId",
                table: "Travels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OriginCityId",
                table: "Travels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OriginAirportId",
                table: "Travels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DestinationCountryId",
                table: "Travels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DestinationCityId",
                table: "Travels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DestinationAirportId",
                table: "Travels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AirplaneId",
                table: "Travels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b13ffe5b-d8ad-43b0-92a4-13103b69f37a", "14f2af81-e086-4036-a7c8-88dd2b6bf70e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4ea62ba4-3b2c-46cd-ac20-071cfc04679f", "9ac2d5d1-b38e-4080-9d63-73cdaa642a18", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Airplanes_AirplaneId",
                table: "Travels",
                column: "AirplaneId",
                principalTable: "Airplanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Airports_DestinationAirportId",
                table: "Travels",
                column: "DestinationAirportId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Airports_OriginAirportId",
                table: "Travels",
                column: "OriginAirportId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Countries_DestinationCountryId",
                table: "Travels",
                column: "DestinationCountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Countries_OriginCountryId",
                table: "Travels",
                column: "OriginCountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

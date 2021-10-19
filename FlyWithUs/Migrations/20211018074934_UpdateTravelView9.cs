using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class UpdateTravelView9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW TravelViews
AS
SELECT 
T.Id Id,
T.Code TravelCode,
T.Price Price,
T.MaxCapacity MaxCapacity,
T.[Type] [Type],
T.Class Class,
T.MovingDate MovingDate,
T.MovingTime MovingTime,
T.ArrivingDate ArrivingDate,
T.ArrivingTime ArrivingTime,
AG.[Name] AgancyName,
AP.[Name] AirplaneName,
OAP.[Name] OriginAirportName,
DOP.[Name] DestinationAirportName,
OC.[Name] OriginCityName,
DC.[Name] DestinationCityName,
OCI.[PersianName] OriginCountryName,
DCI.[PersianName] DestinationCountryName,
T.IsDeleted IsDeleted
FROM Travels  T 
INNER JOIN Agancies AG ON T.AgancyId=AG.Id
INNER JOIN Airplanes AP  ON T.AirplaneId=AP.Id 
INNER JOIN Airports OAP ON T.OriginAirportId=OAP.Id
INNER JOIN Airports DOP ON T.DestinationAirportId=DOP.Id
INNER JOIN Cities OC ON T.OriginCityId=OC.Id
INNER JOIN Cities DC ON T.DestinationAirportId=DC.Id
INNER JOIN Countries OCI ON T.OriginCountryId=OCI.Id
INNER JOIN Countries DCI ON T.DestinationCountryId=DCI.Id");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Agancies_AgancyId",
                table: "Travels");

            migrationBuilder.AlterColumn<int>(
                name: "AgancyId",
                table: "Travels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "a596a187-f893-451d-8b8a-916c6762417c");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "0625a9bd-1981-4f1f-90d5-23d447e41f9a");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Agancies_AgancyId",
                table: "Travels",
                column: "AgancyId",
                principalTable: "Agancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Agancies_AgancyId",
                table: "Travels");

            migrationBuilder.AlterColumn<int>(
                name: "AgancyId",
                table: "Travels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "2e5a9b2a-2303-4730-b416-bced178f9749");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "98569a16-e015-4020-a7e6-719bd888941f");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Agancies_AgancyId",
                table: "Travels",
                column: "AgancyId",
                principalTable: "Agancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}

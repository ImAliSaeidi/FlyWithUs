using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class UpdateTravel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW TravelViews
AS
SELECT 
t.Id Id,
T.Code TravelCode,
T.MovingDate MovingDate,
AP.[Name] AirplaneName,
OAP.[Name] OriginAirportName,
DOP.[Name] DestinationAirportName,
OC.[Name] OriginCityName,
DC.[Name] DestinationCityName,
OCI.[PersianName] OriginCountryName,
DCI.[PersianName] DestinationCountryName
FROM Travels  T 
INNER JOIN Airplanes AP  ON T.AirplaneId=AP.Id 
INNER JOIN Airports OAP ON T.OriginAirportId=OAP.Id
INNER JOIN Airports DOP ON T.DestinationAirportId=DOP.Id
INNER JOIN Cities OC ON T.OriginCityId=OC.Id
INNER JOIN Cities DC ON T.DestinationAirportId=DC.Id
INNER JOIN Countries OCI ON T.OriginCountryId=OCI.Id
INNER JOIN Countries DCI ON T.DestinationCountryId=DCI.Id

");
            migrationBuilder.AddColumn<int>(
                name: "AgancyId",
                table: "Travels",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "751a30f4-ecfa-4eff-825c-3dce8650d648");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "ecd88246-1fc4-4259-8cf1-5e4e7bf01cd9");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_AgancyId",
                table: "Travels",
                column: "AgancyId");

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

            migrationBuilder.DropIndex(
                name: "IX_Travels_AgancyId",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "AgancyId",
                table: "Travels");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "981d7318-bca5-4f76-80dd-4db7e737d7eb");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "1f11e778-69a3-498d-8d9f-344298f7cb45");
        }
    }
}

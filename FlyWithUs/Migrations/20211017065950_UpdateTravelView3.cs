using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class UpdateTravelView3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW TravelViews
AS
SELECT 
T.Id Id,
T.Code TravelCode,
T.Price Price,
T.MovingDate MovingDate,
T.MovingTime MovingTime,
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
INNER JOIN Countries DCI ON T.DestinationCountryId=DCI.Id

");
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "d8cd3c9e-0e81-45af-b0f0-fd7f0c6e1edf");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "0a5b32bf-a69f-48a4-88eb-828499d05f27");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "78c4545c-497b-4fed-b962-97768c0a013d");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "9c5fa2bb-42c5-4b36-9d14-dc9b12161652");
        }
    }
}

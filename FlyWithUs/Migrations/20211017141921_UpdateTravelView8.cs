using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class UpdateTravelView8 : Migration
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
INNER JOIN Countries DCI ON T.DestinationCountryId=DCI.Id
GROUP BY
T.Id,
T.Code,
T.Price,
T.MaxCapacity,
T.[Type],
T.Class,
T.MovingDate,
T.MovingTime,
T.ArrivingTime,
AG.[Name],
AP.[Name],
OAP.[Name],
DOP.[Name],
OC.[Name],
DC.[Name],
OCI.[PersianName],
DCI.[PersianName],
T.IsDeleted
");
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "0115c06f-3192-4b52-a39e-1fedba360976");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "12b1d0cc-5670-460e-907e-8da3d440237c");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class UpdateTravelView5 : Migration
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
T.Class Class,
COUNT(TC.Id) SoldTicket,
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
INNER JOIN Tickets TC ON T.Id=TC.TravelId
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
T.Class,
T.MovingDate,
T.MovingTime,
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
                value: "a44e4d38-8354-411a-a831-86072d61cfb3");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "e5e8a250-ed86-4625-81b6-fdee669f72a9");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "713b7ddb-cbc6-4b1f-a89f-99de127b868d");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "09bc1141-f57c-4b89-877b-02e211109fda");
        }
    }
}

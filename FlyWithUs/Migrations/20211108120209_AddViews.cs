using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class AddViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW TravelViews
AS
SELECT 
T.Id Id,
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
OAP.PersianName OriginAirportName,
DOP.PersianName DestinationAirportName,
OC.PersianName OriginCityName,
DC.PersianName DestinationCityName,
OCI.[PersianName] OriginCountryName,
DCI.[PersianName] DestinationCountryName,
T.IsDeleted IsDeleted
FROM Travels  T 
INNER JOIN Agancies AG 
ON T.AgancyId=AG.Id
INNER JOIN Airplanes AP  
ON T.AirplaneId=AP.Id 
INNER JOIN Airports OAP 
ON T.OriginAirportId=OAP.Id
INNER JOIN Airports DOP 
ON T.DestinationAirportId=DOP.Id
INNER JOIN Cities OC 
ON T.OriginCityId=OC.Id
INNER JOIN Cities DC 
ON T.DestinationCityId=DC.Id
INNER JOIN Countries OCI 
ON T.OriginCountryId=OCI.Id
INNER JOIN Countries DCI 
ON T.DestinationCountryId=DCI.Id");

            migrationBuilder.Sql(@"CREATE OR ALTER VIEW PaymentResultViews
AS
SELECT 
U.Id UserId,
TI.Id TicketId,
TI.Code TicketCode,
O.TrackingCode TrackingCode,
OA.PersianName OriginAirport,
DA.PersianName DestinationAirport,
TR.MovingDate MovingDate,
TR.MovingTime MovingTime,
TI.CreateDate TicketCreateDate
FROM Orders O 
INNER JOIN [User] U ON O.UserId=U.Id
INNER JOIN OrderTickets OT ON O.Id=OT.OrderId
INNER JOIN Tickets TI ON OT.TicketId=TI.Id
INNER JOIN Travels TR ON TI.TravelId=TR.Id
INNER JOIN Airports OA ON TR.OriginAirportId=OA.Id
INNER JOIN Airports DA ON TR.DestinationAirportId=DA.Id
WHERE
TI.IsDeleted=0
");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "1e9e2d2d-bc32-4508-abd1-a55ef9a028ec");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "a77af80e-86d3-4c32-823e-2337d622c3b8");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "58b8fe1e-5c42-4c2a-a1b3-e247ae048194");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "739e6968-e2d1-4db7-9efc-d1e3c1e86f01");
        }
    }
}

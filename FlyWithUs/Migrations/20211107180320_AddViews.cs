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
                value: "fa805ad5-d36c-4f43-a4d5-713f22dde527");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "67bb9a8c-9dde-436c-97d0-3da6ab6454ad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "a3a19c3c-e29a-41d3-bd74-6733f4b768d6");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "f352f0f9-a10d-4847-a417-de4552d68f63");
        }
    }
}

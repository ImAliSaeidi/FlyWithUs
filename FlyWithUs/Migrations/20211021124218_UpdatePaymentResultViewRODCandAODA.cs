using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class UpdatePaymentResultViewRODCandAODA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW PaymentResultViews
AS
SELECT 
U.Id UserId,
TI.Id TicketId,
TI.Code TicketCode,
O.TrackingCode TrackingCode,
OA.[Name] OriginAirport,
DA.[Name] DestinationAirport,
TR.MovingDate MovingDate,
TR.MovingTime MovingTime,
TI.CreateDate TicketCreateDate
FROM Orders O 
INNER JOIN [User] U ON O.UserId=U.Id
INNER JOIN OrderTickets OT ON O.Id=OT.OrderId
INNER JOIN Tickets TI ON OT.TicketId=TI.Id
INNER JOIN Travels TR ON TI.TravelId=TR.Id
INNER JOIN Airports OA ON TR.OriginCityId=OA.Id
INNER JOIN Airports DA ON TR.DestinationCityId=DA.Id
WHERE
TI.IsDeleted=0
");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "d6217c10-020f-4291-ac17-9c39570a1193");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "0033d851-ed45-4824-9440-d2f6f0101986");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "f4bed1ee-31b3-4795-9e97-8f3e3dab8546");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "f7235aea-878c-4b4f-8455-7662f5c23e36");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class UpdatePaymnetView2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW PaymentResultViews
AS
SELECT 
TI.Id TicketId,
TI.Code TicketCode,
O.TrackingCode TrackingCode,
O.TransactionCode TransactionCode,
OC.[Name] Origin,
DC.[Name] Destination,
TR.MovingDate MovingDate,
TR.MovingTime MovingTime
FROM Orders O
INNER JOIN OrderTickets OT ON O.Id=OT.OrderId
INNER JOIN Tickets TI ON OT.TicketId=TI.Id
INNER JOIN Travels TR ON TI.TravelId=TR.Id
INNER JOIN Cities OC ON TR.OriginCityId=OC.Id
INNER JOIN Cities DC ON TR.DestinationCityId=DC.Id
");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "6d16a203-c46f-4174-ab08-0c32f3cf43b7");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "be9e7987-5075-4b90-9d8d-3f5ae6e427b8");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "c0f32d1d-aef1-4a6e-8d64-004fd7f2ca0d");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "130ea676-f9a1-4e90-8feb-e1e2f6e8ef9e");
        }
    }
}

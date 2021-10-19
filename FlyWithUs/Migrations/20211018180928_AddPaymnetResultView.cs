using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class AddPaymnetResultView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW PaymentResultViews
AS
SELECT 
O.Id OrderId,
O.TrackingCode TrackingCode,
O.TransactionCode TransactionCode,
TI.Code TicketCode,
OC.[Name] Origin,
DC.[Name] Destination,
O.CreateDate CreateDate
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
                value: "3977e4b5-646a-4bc0-a976-38b3e9870756");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "cda39e5f-4f8f-4ba2-80d6-ecc5f8154b33");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "5f8338f3-2698-45ec-8299-600db7d51a70");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "93d90aa5-62f7-47b0-92e7-f19c7d7b0e10");
        }
    }
}

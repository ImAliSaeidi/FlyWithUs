using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class UpdatePaymentView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW PaymentResultViews
AS
SELECT 
TI.Id TicketId,
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
                value: "c0f32d1d-aef1-4a6e-8d64-004fd7f2ca0d");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "130ea676-f9a1-4e90-8feb-e1e2f6e8ef9e");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}

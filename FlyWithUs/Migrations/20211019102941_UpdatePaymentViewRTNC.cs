using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class UpdatePaymentViewRTNC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW PaymentResultViews
AS
SELECT 
TI.Id TicketId,
TI.Code TicketCode,
O.TrackingCode TrackingCode,
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
                value: "0b20984f-f500-4dc7-8467-1374adfef710");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "dc5d9b3d-4019-4b84-858a-0d3efbef5034");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "b053cea9-de9d-49d5-ab66-fd19fdcfae58");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "68677991-8cf2-4717-9846-6d61e7c9705b");
        }
    }
}

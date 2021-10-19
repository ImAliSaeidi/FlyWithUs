using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class UpdateOrderTicketAndPayment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTickets_User_ApplicationUserId",
                table: "UserTickets");

            migrationBuilder.DropIndex(
                name: "IX_UserTickets_ApplicationUserId",
                table: "UserTickets");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserTickets");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "d1e3409d-b74c-43e6-a3e7-83a23cd57ef0");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "458c705e-3231-4d5a-a214-434e11b4add6");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserTickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "ba372216-2763-4692-b4bd-915c987c50cd");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "890ed3a1-ef3a-4981-a6b7-cadf9643ba5a");

            migrationBuilder.CreateIndex(
                name: "IX_UserTickets_ApplicationUserId",
                table: "UserTickets",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTickets_User_ApplicationUserId",
                table: "UserTickets",
                column: "ApplicationUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}

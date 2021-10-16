using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class UpdateTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTickets_User_UserId1",
                table: "UserTickets");

            migrationBuilder.DropIndex(
                name: "IX_UserTickets_UserId1",
                table: "UserTickets");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserTickets");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserTickets",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "0bce30ea-c8b4-4721-8332-2830b25536b2");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "f67a58ea-3289-4a2f-b352-6ffe99847616");

            migrationBuilder.CreateIndex(
                name: "IX_UserTickets_UserId",
                table: "UserTickets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTickets_User_UserId",
                table: "UserTickets",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTickets_User_UserId",
                table: "UserTickets");

            migrationBuilder.DropIndex(
                name: "IX_UserTickets_UserId",
                table: "UserTickets");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserTickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserTickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "02d20383-ee85-4f63-aac6-c3bc26d2dd77");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "7804176e-8788-4722-8c99-822741ce9249");

            migrationBuilder.CreateIndex(
                name: "IX_UserTickets_UserId1",
                table: "UserTickets",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTickets_User_UserId1",
                table: "UserTickets",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

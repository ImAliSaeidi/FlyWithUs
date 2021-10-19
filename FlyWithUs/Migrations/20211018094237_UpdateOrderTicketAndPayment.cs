using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class UpdateOrderTicketAndPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_Userid",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTickets_User_UserId",
                table: "UserTickets");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_UserTickets_UserId",
                table: "UserTickets");

            migrationBuilder.DropColumn(
                name: "IsFinaly",
                table: "UserTickets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserTickets");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "Order",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Userid",
                table: "Order",
                newName: "IX_Order_UserId");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserTickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "UserTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_UserTickets_OrderId",
                table: "UserTickets",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTickets_Order_OrderId",
                table: "UserTickets",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTickets_User_ApplicationUserId",
                table: "UserTickets",
                column: "ApplicationUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTickets_Order_OrderId",
                table: "UserTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTickets_User_ApplicationUserId",
                table: "UserTickets");

            migrationBuilder.DropIndex(
                name: "IX_UserTickets_ApplicationUserId",
                table: "UserTickets");

            migrationBuilder.DropIndex(
                name: "IX_UserTickets_OrderId",
                table: "UserTickets");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserTickets");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "UserTickets");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Order",
                newName: "Userid");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserId",
                table: "Order",
                newName: "IX_Order_Userid");

            migrationBuilder.AddColumn<bool>(
                name: "IsFinaly",
                table: "UserTickets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserTickets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "8aca82d9-b1a3-4351-b44e-fff09014cc9a");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "c8b29ba4-6538-45d1-86f3-f1dafdeb1eb3");

            migrationBuilder.CreateIndex(
                name: "IX_UserTickets_UserId",
                table: "UserTickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_TicketId",
                table: "OrderDetail",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_Userid",
                table: "Order",
                column: "Userid",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTickets_User_UserId",
                table: "UserTickets",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}

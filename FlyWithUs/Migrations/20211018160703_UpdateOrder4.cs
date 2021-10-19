using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class UpdateOrder4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TrackingCode",
                table: "Orders",
                type: "nvarchar(8)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "8e4ee940-a6bb-469d-8749-02077026721f");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "b91e9636-c228-4b8f-ba27-9d9c033e005f");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "TrackingCode",
                table: "Orders",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "b83afa8c-7172-441c-a3b6-f3381e43bf26");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "561e116f-1e47-478e-8767-6d5522c29db2");
        }
    }
}

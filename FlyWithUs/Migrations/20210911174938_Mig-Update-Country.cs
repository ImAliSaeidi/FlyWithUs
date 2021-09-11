using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class MigUpdateCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ISO2",
                table: "Countries",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ISO3",
                table: "Countries",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NiceName",
                table: "Countries",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<short>(
                name: "NumCode",
                table: "Countries",
                type: "smallint",
                maxLength: 6,
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "PhoneCode",
                table: "Countries",
                type: "smallint",
                maxLength: 5,
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISO2",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "ISO3",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "NiceName",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "NumCode",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "PhoneCode",
                table: "Countries");
        }
    }
}

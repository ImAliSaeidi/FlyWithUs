using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class MigUpdateUserNationality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "User",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");
        }
    }
}

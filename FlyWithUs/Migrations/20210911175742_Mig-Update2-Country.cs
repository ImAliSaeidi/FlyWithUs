using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class MigUpdate2Country : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "PhoneCode",
                table: "Countries",
                type: "smallint",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<short>(
                name: "NumCode",
                table: "Countries",
                type: "smallint",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldMaxLength: 6);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "PhoneCode",
                table: "Countries",
                type: "smallint",
                maxLength: 5,
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "NumCode",
                table: "Countries",
                type: "smallint",
                maxLength: 6,
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldMaxLength: 6,
                oldNullable: true);
        }
    }
}

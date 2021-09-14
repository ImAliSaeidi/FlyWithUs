using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class MigUpdateCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ISO3",
                table: "Countries",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ISO2",
                table: "Countries",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ISO3",
                table: "Countries",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "ISO2",
                table: "Countries",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);
        }
    }
}

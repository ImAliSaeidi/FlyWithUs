using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyWithUs.Hosted.Service.Migrations
{
    public partial class UpdateTravelView2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW TravelViews
AS
SELECT 
T.Id Id,
T.Price Price,
T.MaxCapacity MaxCapacity,
T.[Type] [Type],
T.Class Class,
T.MovingDate MovingDate,
T.MovingTime MovingTime,
T.ArrivingDate ArrivingDate,
T.ArrivingTime ArrivingTime,
AG.[Name] AgancyName,
AP.[Name] AirplaneName,
OAP.PersianName OriginAirportName,
DOP.PersianName DestinationAirportName,
OC.PersianName OriginCityName,
DC.PersianName DestinationCityName,
OCI.[PersianName] OriginCountryName,
DCI.[PersianName] DestinationCountryName,
T.IsDeleted IsDeleted
FROM Travels  T 
INNER JOIN Agancies AG 
ON T.AgancyId=AG.Id
INNER JOIN Airplanes AP  
ON T.AirplaneId=AP.Id 
INNER JOIN Airports OAP 
ON T.OriginAirportId=OAP.Id
INNER JOIN Airports DOP 
ON T.DestinationAirportId=DOP.Id
INNER JOIN Cities OC 
ON T.OriginCityId=OC.Id
INNER JOIN Cities DC 
ON T.DestinationCityId=DC.Id
INNER JOIN Countries OCI 
ON T.OriginCountryId=OCI.Id
INNER JOIN Countries DCI 
ON T.DestinationCountryId=DCI.Id");


            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "c1b20659-759f-41a1-aa9e-033920eb2f2f");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "c9d2f323-2b82-43f1-8170-5e6dd9ac969f");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1af962a6-d464-467f-8fea-8f6e9c4be780",
                column: "ConcurrencyStamp",
                value: "f8e369ea-1c4e-4731-a2c3-9ad0702cd870");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "586faa77-67b7-477e-849f-e174c7924f95",
                column: "ConcurrencyStamp",
                value: "73802b38-d1c2-463a-a345-a93d1c30d75c");
        }
    }
}

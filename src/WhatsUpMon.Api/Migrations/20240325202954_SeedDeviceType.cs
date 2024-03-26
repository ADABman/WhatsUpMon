using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhatsUpMon.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedDeviceType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DeviceTypes",
                columns: new[] { "DeviceTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Server" },
                    { 2, "Switch" },
                    { 3, "Router" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeviceTypes",
                keyColumn: "DeviceTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DeviceTypes",
                keyColumn: "DeviceTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DeviceTypes",
                keyColumn: "DeviceTypeId",
                keyValue: 3);
        }
    }
}

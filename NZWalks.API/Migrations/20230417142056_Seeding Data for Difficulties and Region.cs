using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataforDifficultiesandRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5b1429a6-da33-4331-bd09-1b8112b1bf6b"), "Easy" },
                    { new Guid("7b85028e-211f-4c42-95f3-713b2a33e7b0"), "Hard" },
                    { new Guid("ce75fbef-6bd6-459e-aa07-446a747014f4"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0a26c63c-0754-449d-80d0-e500cba9488d"), "NSN", "Nelson", null },
                    { new Guid("160da0c5-bee7-4045-96c8-3893028c3fb5"), "BOP", "Bay Of Plenty", null },
                    { new Guid("3153abda-7349-4806-9c6d-a779a3579f86"), "STL", "Southland", null },
                    { new Guid("c3c3291c-a662-40e0-b487-f7f56b710fa4"), "WGN", "Wellington", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("5b1429a6-da33-4331-bd09-1b8112b1bf6b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7b85028e-211f-4c42-95f3-713b2a33e7b0"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ce75fbef-6bd6-459e-aa07-446a747014f4"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0a26c63c-0754-449d-80d0-e500cba9488d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("160da0c5-bee7-4045-96c8-3893028c3fb5"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3153abda-7349-4806-9c6d-a779a3579f86"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c3c3291c-a662-40e0-b487-f7f56b710fa4"));
        }
    }
}

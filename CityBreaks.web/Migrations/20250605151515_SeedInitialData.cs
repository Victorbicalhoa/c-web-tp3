using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CityBreaks.web.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Country_Code", "Country_Name" },
                values: new object[,]
                {
                    { 1, "PT", "Portugal" },
                    { 2, "ES", "Espanha" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "City_Name" },
                values: new object[,]
                {
                    { 1, 1, "Lisboa" },
                    { 2, 1, "Porto" },
                    { 3, 2, "Madrid" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "CityId", "Property_Name", "Price_Per_Night" },
                values: new object[,]
                {
                    { 1, 1, "Apartamento Central Lisboa", 80.00m },
                    { 2, 2, "Estúdio Moderno no Porto", 65.50m },
                    { 3, 3, "Apartamento Plaza Mayor", 120.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

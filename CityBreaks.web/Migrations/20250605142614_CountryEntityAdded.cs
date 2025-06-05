using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityBreaks.web.Migrations
{
    /// <inheritdoc />
    public partial class CountryEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Countries",
                newName: "CountryName");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Countries",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Countries");

            migrationBuilder.RenameColumn(
                name: "CountryName",
                table: "Countries",
                newName: "Name");
        }
    }
}

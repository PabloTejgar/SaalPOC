using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Saal.API.Migrations
{
    /// <inheritdoc />
    public partial class fixDBErrors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_City_CityId",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_City_CityId",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "City");

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "León" },
                    { 2, "London" },
                    { 3, "Berlin" },
                    { 4, "Rome" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "City",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_City_CityId",
                table: "City",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_City_CityId",
                table: "City",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id");
        }
    }
}

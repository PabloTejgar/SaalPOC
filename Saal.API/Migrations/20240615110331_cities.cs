using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saal.API.Migrations
{
    /// <inheritdoc />
    public partial class cities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Restaurant");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Restaurant",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_CityId",
                table: "Restaurant",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Restaurant_CityId",
                table: "Restaurant",
                column: "CityId",
                principalTable: "Restaurant",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Restaurant_CityId",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_CityId",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Restaurant");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

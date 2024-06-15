using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saal.API.Migrations
{
    /// <inheritdoc />
    public partial class restaurantrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_City_CityId",
                table: "Restaurant");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Restaurant",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_City_CityId",
                table: "Restaurant",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_City_CityId",
                table: "Restaurant");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Restaurant",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_City_CityId",
                table: "Restaurant",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

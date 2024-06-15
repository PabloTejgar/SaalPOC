using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saal.API.Migrations
{
    /// <inheritdoc />
    public partial class expandRestaurants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Address",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_CityId",
                table: "City",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "Phone",
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
    }
}

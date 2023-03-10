using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Seat_Available",
                table: "Airlines",
                newName: "Seat");

            migrationBuilder.RenameColumn(
                name: "Flight_No",
                table: "Airlines",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Airline_Name",
                table: "Airlines",
                newName: "FlightNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Seat",
                table: "Airlines",
                newName: "Seat_Available");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Airlines",
                newName: "Flight_No");

            migrationBuilder.RenameColumn(
                name: "FlightNo",
                table: "Airlines",
                newName: "Airline_Name");
        }
    }
}

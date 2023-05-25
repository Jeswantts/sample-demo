using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flyhigh_Airlines.Migrations
{
    /// <inheritdoc />
    public partial class flyhigh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Fid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 2"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeatAvailability = table.Column<int>(type: "int", nullable: false),
                    YourLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Fid);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10, 1"),
                    Pid = table.Column<int>(type: "int", nullable: false),
                    PName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PNumber = table.Column<int>(type: "int", nullable: false),
                    PAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfSeats = table.Column<int>(type: "int", nullable: false),
                    FlightFid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Passengers_Flights_FlightFid",
                        column: x => x.FlightFid,
                        principalTable: "Flights",
                        principalColumn: "Fid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_FlightFid",
                table: "Passengers",
                column: "FlightFid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}

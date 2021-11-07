using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MOVIE_BOOKING_CORE.Migrations
{
    public partial class oneToMany_Relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total = table.Column<int>(type: "int", nullable: false),
                    showtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ticketType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ticketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieBookings_MovieTickets_ticketId",
                        column: x => x.ticketId,
                        principalTable: "MovieTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieBookings_ticketId",
                table: "MovieBookings",
                column: "ticketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieBookings");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace MOVIE_BOOKING_CORE.Migrations
{
    public partial class MB_OneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieBookings_MovieTickets_ticketId",
                table: "MovieBookings");

            migrationBuilder.RenameColumn(
                name: "ticketId",
                table: "MovieBookings",
                newName: "TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieBookings_ticketId",
                table: "MovieBookings",
                newName: "IX_MovieBookings_TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieBookings_MovieTickets_TicketId",
                table: "MovieBookings",
                column: "TicketId",
                principalTable: "MovieTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieBookings_MovieTickets_TicketId",
                table: "MovieBookings");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "MovieBookings",
                newName: "ticketId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieBookings_TicketId",
                table: "MovieBookings",
                newName: "IX_MovieBookings_ticketId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieBookings_MovieTickets_ticketId",
                table: "MovieBookings",
                column: "ticketId",
                principalTable: "MovieTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MOVIE_BOOKING_CORE.Migrations
{
    public partial class removedPoster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieBookings_MovieTickets_TicketId",
                table: "MovieBookings");

            migrationBuilder.DropIndex(
                name: "IX_MovieBookings_TicketId",
                table: "MovieBookings");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "MovieBookings");

            migrationBuilder.AlterColumn<string>(
                name: "ticketType",
                table: "MovieBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "showtime",
                table: "MovieBookings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "MovieBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ticketType",
                table: "MovieBookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "showtime",
                table: "MovieBookings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "MovieBookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "MovieBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MovieBookings_TicketId",
                table: "MovieBookings",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieBookings_MovieTickets_TicketId",
                table: "MovieBookings",
                column: "TicketId",
                principalTable: "MovieTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

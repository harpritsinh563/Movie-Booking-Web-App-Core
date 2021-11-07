using Microsoft.EntityFrameworkCore.Migrations;

namespace MOVIE_BOOKING_CORE.Migrations
{
    public partial class added_StartDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "startDate",
                table: "MovieTickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "startDate",
                table: "MovieTickets");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace MOVIE_BOOKING_CORE.Migrations
{
    public partial class Add_Relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "MovieBookings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieBookings_AppUserId",
                table: "MovieBookings",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieBookings_AspNetUsers_AppUserId",
                table: "MovieBookings",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieBookings_AspNetUsers_AppUserId",
                table: "MovieBookings");

            migrationBuilder.DropIndex(
                name: "IX_MovieBookings_AppUserId",
                table: "MovieBookings");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "MovieBookings");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace MOVIE_BOOKING_CORE.Migrations
{
    public partial class Remove_Relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieBookings_AspNetUsers_AppUserId1",
                table: "MovieBookings");

            migrationBuilder.DropIndex(
                name: "IX_MovieBookings_AppUserId1",
                table: "MovieBookings");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "MovieBookings");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "MovieBookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "MovieBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "MovieBookings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieBookings_AppUserId1",
                table: "MovieBookings",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieBookings_AspNetUsers_AppUserId1",
                table: "MovieBookings",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

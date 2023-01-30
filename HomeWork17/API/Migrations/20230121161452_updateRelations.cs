using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class updateRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Showtimes_Halls_CinemaHallId",
                table: "Showtimes");

            migrationBuilder.DropIndex(
                name: "IX_Showtimes_CinemaHallId",
                table: "Showtimes");

            migrationBuilder.DropIndex(
                name: "IX_Showtimes_MovieId",
                table: "Showtimes");

            migrationBuilder.CreateIndex(
                name: "IX_Showtimes_MovieId",
                table: "Showtimes",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Showtimes_MovieId",
                table: "Showtimes");

            migrationBuilder.CreateIndex(
                name: "IX_Showtimes_CinemaHallId",
                table: "Showtimes",
                column: "CinemaHallId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Showtimes_MovieId",
                table: "Showtimes",
                column: "MovieId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Showtimes_Halls_CinemaHallId",
                table: "Showtimes",
                column: "CinemaHallId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

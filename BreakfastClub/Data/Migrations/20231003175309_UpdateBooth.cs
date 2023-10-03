using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreakfastClub.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBooth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Booths_BoothId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_BoothId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "BoothId",
                table: "Reservations");
        }

        /// <inheritdoc />
    }
}

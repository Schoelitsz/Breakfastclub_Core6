using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreakfastClub.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedDateBoothTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoothReservation");

            migrationBuilder.AddColumn<int>(
                name: "BoothId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BoothId",
                table: "Reservations",
                column: "BoothId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Booths_BoothId",
                table: "Reservations",
                column: "BoothId",
                principalTable: "Booths",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "BoothReservation",
                columns: table => new
                {
                    BoothReservationsID = table.Column<int>(type: "int", nullable: false),
                    BoothsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoothReservation", x => new { x.BoothReservationsID, x.BoothsId });
                    table.ForeignKey(
                        name: "FK_BoothReservation_Booths_BoothsId",
                        column: x => x.BoothsId,
                        principalTable: "Booths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoothReservation_Reservations_BoothReservationsID",
                        column: x => x.BoothReservationsID,
                        principalTable: "Reservations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoothReservation_BoothsId",
                table: "BoothReservation",
                column: "BoothsId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreakfastClub.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewModelBoothsandReservationProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoothNumber = table.Column<int>(type: "int", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    isAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booths", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoothReservation");

            migrationBuilder.DropTable(
                name: "Booths");
        }
    }
}

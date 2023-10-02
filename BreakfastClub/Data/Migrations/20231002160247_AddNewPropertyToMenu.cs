using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreakfastClub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPropertyToMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Course",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Course",
                table: "MenuItems");
        }
    }
}

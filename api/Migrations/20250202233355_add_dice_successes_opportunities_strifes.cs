using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class add_dice_successes_opportunities_strifes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Opportunities",
                table: "DiceRolls",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Strifes",
                table: "DiceRolls",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Successes",
                table: "DiceRolls",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opportunities",
                table: "DiceRolls");

            migrationBuilder.DropColumn(
                name: "Strifes",
                table: "DiceRolls");

            migrationBuilder.DropColumn(
                name: "Successes",
                table: "DiceRolls");
        }
    }
}

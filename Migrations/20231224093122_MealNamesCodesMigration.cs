using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechroseDemo.Migrations
{
    /// <inheritdoc />
    public partial class MealNamesCodesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "meal_name",
                table: "meals");

            migrationBuilder.AddColumn<int>(
                name: "meal_name_code",
                table: "meals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "meal_names_codes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    meal_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meal_names_codes", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_meals_meal_name_code",
                table: "meals",
                column: "meal_name_code");

            migrationBuilder.AddForeignKey(
                name: "FK_meals_meal_names_codes_meal_name_code",
                table: "meals",
                column: "meal_name_code",
                principalTable: "meal_names_codes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_meals_meal_names_codes_meal_name_code",
                table: "meals");

            migrationBuilder.DropTable(
                name: "meal_names_codes");

            migrationBuilder.DropIndex(
                name: "IX_meals_meal_name_code",
                table: "meals");

            migrationBuilder.DropColumn(
                name: "meal_name_code",
                table: "meals");

            migrationBuilder.AddColumn<string>(
                name: "meal_name",
                table: "meals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

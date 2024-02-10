using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechroseDemo.Migrations
{
    /// <inheritdoc />
    public partial class NutritionTypeMigrationAddImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "nutrition_types",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "nutrition_types");
        }
    }
}

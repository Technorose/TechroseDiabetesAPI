using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechroseDemo.Migrations
{
    /// <inheritdoc />
    public partial class NutritionTypeMigrationAddTypeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nutrition_type_name",
                table: "nutrition_types",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nutrition_type_name",
                table: "nutrition_types");
        }
    }
}

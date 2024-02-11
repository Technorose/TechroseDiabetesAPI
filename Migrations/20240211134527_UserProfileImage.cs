using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechroseDemo.Migrations
{
    /// <inheritdoc />
    public partial class UserProfileImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_nutritions_nutrition_types_nutrition_type_id",
                table: "nutritions");

            migrationBuilder.DropIndex(
                name: "IX_nutritions_nutrition_type_id",
                table: "nutritions");

            migrationBuilder.DropColumn(
                name: "image",
                table: "users");

            migrationBuilder.DropColumn(
                name: "nutrition_type_id",
                table: "nutritions");

            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "nutritions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

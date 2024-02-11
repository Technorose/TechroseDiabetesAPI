using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechroseDemo.Migrations
{
    /// <inheritdoc />
    public partial class MealModelFKUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "meals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_meals_user_id",
                table: "meals",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_meals_users_user_id",
                table: "meals",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_meals_users_user_id",
                table: "meals");

            migrationBuilder.DropIndex(
                name: "IX_meals_user_id",
                table: "meals");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "meals");
        }
    }
}

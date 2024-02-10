using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechroseDemo.Migrations
{
    /// <inheritdoc />
    public partial class MealMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "blood_sugar_value",
                table: "users",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "total_dose_value",
                table: "users",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "weight",
                table: "users",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "meal_id",
                table: "user_nutritions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "meals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    meal_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    total_calorie = table.Column<double>(type: "float", nullable: false),
                    total_carbohydrate = table.Column<double>(type: "float", nullable: false),
                    total_sugar = table.Column<double>(type: "float", nullable: false),
                    blood_sugar = table.Column<double>(type: "float", nullable: false),
                    meal_time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meals", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_nutritions_meal_id",
                table: "user_nutritions",
                column: "meal_id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_nutritions_meals_meal_id",
                table: "user_nutritions",
                column: "meal_id",
                principalTable: "meals",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_nutritions_meals_meal_id",
                table: "user_nutritions");

            migrationBuilder.DropTable(
                name: "meals");

            migrationBuilder.DropIndex(
                name: "IX_user_nutritions_meal_id",
                table: "user_nutritions");

            migrationBuilder.DropColumn(
                name: "blood_sugar_value",
                table: "users");

            migrationBuilder.DropColumn(
                name: "total_dose_value",
                table: "users");

            migrationBuilder.DropColumn(
                name: "weight",
                table: "users");

            migrationBuilder.DropColumn(
                name: "meal_id",
                table: "user_nutritions");
        }
    }
}

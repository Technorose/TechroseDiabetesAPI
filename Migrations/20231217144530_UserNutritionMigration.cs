using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechroseDemo.Migrations
{
    /// <inheritdoc />
    public partial class UserNutritionMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nutritions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serving_size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    calories = table.Column<long>(type: "bigint", nullable: false),
                    total_fat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cholesterol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    caffeine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sugars = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nutritions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hashed_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salted_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_nutritions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    nutrition_id = table.Column<int>(type: "int", nullable: false),
                    portion = table.Column<double>(type: "float", nullable: false),
                    meal_time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_nutritions", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_nutritions_nutritions_nutrition_id",
                        column: x => x.nutrition_id,
                        principalTable: "nutritions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_nutritions_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_nutritions_nutrition_id",
                table: "user_nutritions",
                column: "nutrition_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_nutritions_user_id",
                table: "user_nutritions",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_nutritions");

            migrationBuilder.DropTable(
                name: "nutritions");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}

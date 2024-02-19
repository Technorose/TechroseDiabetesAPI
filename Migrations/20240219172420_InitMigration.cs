using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechroseDemo.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "nutrition_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nutrition_type_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nutrition_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hashed_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salted_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    total_dose_value = table.Column<double>(type: "float", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    weight = table.Column<double>(type: "float", nullable: false),
                    blood_sugar_value = table.Column<double>(type: "float", nullable: false),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nutritions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nutrition_type_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serving_size = table.Column<long>(type: "bigint", nullable: false),
                    calorie = table.Column<long>(type: "bigint", nullable: false),
                    sugar = table.Column<double>(type: "float", nullable: false),
                    carbo_hydrate = table.Column<long>(type: "bigint", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nutritions", x => x.id);
                    table.ForeignKey(
                        name: "FK_nutritions_nutrition_types_nutrition_type_id",
                        column: x => x.nutrition_type_id,
                        principalTable: "nutrition_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "meals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    meal_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    meal_name_code = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    total_calorie = table.Column<double>(type: "float", nullable: false),
                    total_carbohydrate = table.Column<double>(type: "float", nullable: false),
                    total_sugar = table.Column<double>(type: "float", nullable: false),
                    blood_sugar = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meals", x => x.id);
                    table.ForeignKey(
                        name: "FK_meals_meal_names_codes_meal_name_code",
                        column: x => x.meal_name_code,
                        principalTable: "meal_names_codes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_meals_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_nutritions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    nutrition_id = table.Column<long>(type: "bigint", nullable: false),
                    meal_id = table.Column<int>(type: "int", nullable: false),
                    portion = table.Column<double>(type: "float", nullable: false),
                    meal_time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_nutritions", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_nutritions_meals_meal_id",
                        column: x => x.meal_id,
                        principalTable: "meals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_meals_meal_name_code",
                table: "meals",
                column: "meal_name_code");

            migrationBuilder.CreateIndex(
                name: "IX_meals_user_id",
                table: "meals",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_nutritions_nutrition_type_id",
                table: "nutritions",
                column: "nutrition_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_nutritions_meal_id",
                table: "user_nutritions",
                column: "meal_id");

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
                name: "meals");

            migrationBuilder.DropTable(
                name: "nutritions");

            migrationBuilder.DropTable(
                name: "meal_names_codes");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "nutrition_types");
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechroseDemo;

#nullable disable

namespace TechroseDemo.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20240210193218_NutritionTypeMigration")]
    partial class NutritionTypeMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TechroseDemo.MealModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("BloodSugar")
                        .HasColumnType("float")
                        .HasColumnName("blood_sugar")
                        .HasAnnotation("Relational:JsonPropertyName", "blood_sugar");

                    b.Property<int>("MealNameCode")
                        .HasColumnType("int")
                        .HasColumnName("meal_name_code")
                        .HasAnnotation("Relational:JsonPropertyName", "meal_name_code");

                    b.Property<DateTime>("MealTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("meal_time")
                        .HasAnnotation("Relational:JsonPropertyName", "meal_time");

                    b.Property<double>("TotalCalorie")
                        .HasColumnType("float")
                        .HasColumnName("total_calorie")
                        .HasAnnotation("Relational:JsonPropertyName", "total_calorie");

                    b.Property<double>("TotalCarbohydrate")
                        .HasColumnType("float")
                        .HasColumnName("total_carbohydrate")
                        .HasAnnotation("Relational:JsonPropertyName", "total_carbohydrate");

                    b.Property<double>("TotalSugar")
                        .HasColumnType("float")
                        .HasColumnName("total_sugar")
                        .HasAnnotation("Relational:JsonPropertyName", "total_sugar");

                    b.HasKey("Id");

                    b.HasIndex("MealNameCode");

                    b.ToTable("meals");
                });

            modelBuilder.Entity("TechroseDemo.MealNamesCodesModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MealName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("meal_name")
                        .HasAnnotation("Relational:JsonPropertyName", "meal_name");

                    b.HasKey("Id");

                    b.ToTable("meal_names_codes");
                });

            modelBuilder.Entity("TechroseDemo.NutritionModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("Calorie")
                        .HasColumnType("bigint")
                        .HasColumnName("calorie")
                        .HasAnnotation("Relational:JsonPropertyName", "calorie");

                    b.Property<long>("Carbohydrate")
                        .HasColumnType("bigint")
                        .HasColumnName("carbo_hydrate")
                        .HasAnnotation("Relational:JsonPropertyName", "carbo_hydrate");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("category")
                        .HasAnnotation("Relational:JsonPropertyName", "category");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("image")
                        .HasAnnotation("Relational:JsonPropertyName", "image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<long>("ServingSize")
                        .HasColumnType("bigint")
                        .HasColumnName("serving_size")
                        .HasAnnotation("Relational:JsonPropertyName", "serving_size");

                    b.Property<long>("Sugar")
                        .HasColumnType("bigint")
                        .HasColumnName("sugar")
                        .HasAnnotation("Relational:JsonPropertyName", "sugar");

                    b.HasKey("Id");

                    b.ToTable("nutritions");
                });

            modelBuilder.Entity("TechroseDemo.NutritionTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("nutrition_types");
                });

            modelBuilder.Entity("TechroseDemo.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birth_date")
                        .HasAnnotation("Relational:JsonPropertyName", "birth_date");

                    b.Property<double>("BloodSugarValue")
                        .HasColumnType("float")
                        .HasColumnName("blood_sugar_value")
                        .HasAnnotation("Relational:JsonPropertyName", "blood_sugar_value");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email")
                        .HasAnnotation("Relational:JsonPropertyName", "email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name")
                        .HasAnnotation("Relational:JsonPropertyName", "first_name");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("hashed_password");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name")
                        .HasAnnotation("Relational:JsonPropertyName", "last_name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone_number")
                        .HasAnnotation("Relational:JsonPropertyName", "phone_number");

                    b.Property<string>("SaltedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("salted_password");

                    b.Property<double>("TotalDoseValue")
                        .HasColumnType("float")
                        .HasColumnName("total_dose_value")
                        .HasAnnotation("Relational:JsonPropertyName", "total_dose_value");

                    b.Property<double>("Weight")
                        .HasColumnType("float")
                        .HasColumnName("weight")
                        .HasAnnotation("Relational:JsonPropertyName", "weight");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("TechroseDemo.UserNutritionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MealId")
                        .HasColumnType("int")
                        .HasColumnName("meal_id")
                        .HasAnnotation("Relational:JsonPropertyName", "meal_id");

                    b.Property<DateTime>("MealTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("meal_time")
                        .HasAnnotation("Relational:JsonPropertyName", "meal_time");

                    b.Property<long>("NutritionId")
                        .HasColumnType("bigint")
                        .HasColumnName("nutrition_id")
                        .HasAnnotation("Relational:JsonPropertyName", "nutrition_id");

                    b.Property<double>("Portion")
                        .HasColumnType("float")
                        .HasColumnName("portion")
                        .HasAnnotation("Relational:JsonPropertyName", "portion");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id")
                        .HasAnnotation("Relational:JsonPropertyName", "user_id");

                    b.HasKey("Id");

                    b.HasIndex("MealId");

                    b.HasIndex("NutritionId");

                    b.HasIndex("UserId");

                    b.ToTable("user_nutritions");
                });

            modelBuilder.Entity("TechroseDemo.MealModel", b =>
                {
                    b.HasOne("TechroseDemo.MealNamesCodesModel", "MealNamesCodes")
                        .WithMany("MealModels")
                        .HasForeignKey("MealNameCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MealNamesCodes");
                });

            modelBuilder.Entity("TechroseDemo.UserNutritionModel", b =>
                {
                    b.HasOne("TechroseDemo.MealModel", "MealModel")
                        .WithMany("UserNutritionModels")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechroseDemo.NutritionModel", "NutritionModel")
                        .WithMany("UserNutritionModels")
                        .HasForeignKey("NutritionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechroseDemo.UserModel", "UserModel")
                        .WithMany("UserNutritionModels")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MealModel");

                    b.Navigation("NutritionModel");

                    b.Navigation("UserModel");
                });

            modelBuilder.Entity("TechroseDemo.MealModel", b =>
                {
                    b.Navigation("UserNutritionModels");
                });

            modelBuilder.Entity("TechroseDemo.MealNamesCodesModel", b =>
                {
                    b.Navigation("MealModels");
                });

            modelBuilder.Entity("TechroseDemo.NutritionModel", b =>
                {
                    b.Navigation("UserNutritionModels");
                });

            modelBuilder.Entity("TechroseDemo.UserModel", b =>
                {
                    b.Navigation("UserNutritionModels");
                });
#pragma warning restore 612, 618
        }
    }
}

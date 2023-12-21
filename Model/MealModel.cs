﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechroseDemo
{
    public class MealModelBase
    {
        public MealModelBase() 
        {
            MealName = string.Empty;
            TotalCalorie = double.MinValue;
            TotalCarbohydrate = double.MinValue;
            TotalSugar = double.MinValue;
            BloodSugar = double.MinValue;
            MealTime = DateTime.Now;
        }

        [Column("meal_name")]
        [JsonPropertyName("meal_name")]
        public required string MealName { get; set; }

        [Column("total_calorie")]
        [JsonPropertyName("total_calorie")]
        public required double TotalCalorie { get; set; }

        [Column("total_carbohydrate")]
        [JsonPropertyName("total_carbohydrate")]
        public required double TotalCarbohydrate { get; set; }

        [Column("total_sugar")]
        [JsonPropertyName("total_sugar")]
        public required double TotalSugar { get; set;}

        [Column("blood_sugar")]
        [JsonPropertyName("blood_sugar")]
        public required double BloodSugar { get; set; }

        [Column("meal_time")]
        [JsonPropertyName("meal_time")]
        public required DateTime MealTime { get; set; }
    }

    [Table("meals")]
    public class MealModel : MealModelBase
    {
        public MealModel()
        {
            Id = int.MinValue;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserNutritionModel>? UserNutritionModels { get; set; }
    }
}

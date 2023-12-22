using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechroseDemo
{
    public class MealModelBaseArgs
    {
        public MealModelBaseArgs() 
        {
            MealTime = DateTime.MinValue;
        }

        [Column("meal_time")]
        [JsonPropertyName("meal_time")]
        public required DateTime MealTime { get; set; }
    }

    public class MealModelBase : MealModelBaseArgs
    {
        public MealModelBase() 
        {
            MealName = string.Empty;
            TotalCalorie = double.MinValue;
            TotalCarbohydrate = double.MinValue;
            TotalSugar = double.MinValue;
            BloodSugar = double.MinValue;
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
    }

    [Table("meals")]
    public class MealModel : MealModelBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserNutritionModel>? UserNutritionModels { get; set; }
    }

    public class MealModelCreateArgs : MealModelBaseArgs
    {
        public MealModelCreateArgs()
        {
            MealNameCode = int.MinValue;
        }

        [JsonPropertyName("meal_name_code")]
        public int MealNameCode { get; set; }
    }

    public class MealModelCreateResult
    {
        public MealModelCreateResult()
        {
            Result = new ResultModel();
        }

        public ResultModel Result { get; set; }
    }
}

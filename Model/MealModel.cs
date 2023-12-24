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
            MealNameCode = int.MinValue;
            TotalCalorie = double.MinValue;
            TotalCarbohydrate = double.MinValue;
            TotalSugar = double.MinValue;
            BloodSugar = double.MinValue;
        }

        [Column("meal_name_code")]
        [JsonPropertyName("meal_name_code")]
        [ForeignKey(nameof(MealNamesCodes))]
        public required int MealNameCode { get; set; }

        [JsonIgnore]
        public virtual MealNamesCodesModel? MealNamesCodes { get; set; } 

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
            BloodSugar = int.MinValue;
            MealNameCode = int.MinValue;
        }

        [JsonPropertyName("blood_sugar")]
        public int BloodSugar { get; set; }

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

    public class MealModelUpdateArgs
    {
        public MealModelUpdateArgs()
        {
            Id = int.MinValue;
            UserNutritionsIds = new List<int>();
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("user_nutritions_ids")]
        public List<int> UserNutritionsIds { get; set;}
    }

    public class MealModelUpdateResult
    {
        public MealModelUpdateResult()
        {
            Result = new ResultModel();
        }

        public ResultModel Result { get; set; }
    }
}

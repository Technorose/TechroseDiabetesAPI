using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TechroseDemo
{
    public class UserNutritionBaseModel
    {
        public UserNutritionBaseModel()
        {
            NutritionId = long.MinValue;
            MealId = int.MinValue;
            Portion = double.MinValue;
            MealTime = DateTime.Now;
        }

        [JsonPropertyName("nutrition_id")]
        [Column("nutrition_id")]
        [ForeignKey(nameof(NutritionModel))]
        public required long NutritionId { get; set; }

        [JsonIgnore]
        public virtual NutritionModel? NutritionModel { get; set; }

        [JsonPropertyName("meal_id")]
        [Column("meal_id")]
        [ForeignKey(nameof(MealModel))]
        public required int MealId { get; set; }

        [JsonIgnore]
        public virtual MealModel? MealModel { get; set; }

        [JsonPropertyName("portion")]
        [Column("portion")]
        public required double Portion { get; set; }

        [JsonPropertyName("meal_time")]
        [Column("meal_time")]
        public required DateTime MealTime { get; set; }
    }

    [Table("user_nutritions")]
    public class UserNutritionModel : UserNutritionBaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
    }

    #region UserNutritionCreateModels
    public class UserNutritionModelCreateArgs : List<UserNutritionBaseModel>
    {
        public UserNutritionModelCreateArgs() 
        {
             
        }
    }

    public class UserNutritionModelCreateResult
    {
        public UserNutritionModelCreateResult()
        {
            Result = new ResultModel();
        }

        public ResultModel Result { get; set; }
    }
    #endregion

    #region ForeignKeysClasses
    public class UserNutritionsMealUpdateArgs
    {
        public required UserNutritionModel UserNutrition;

        public required NutritionModel Nutrition;
    }

    public class UserNutritionsMealUpdateResult
    {
        public required double TotalCalorie;

        public required double TotalCarbohydrate;

        public required double TotalSugar;
    }
    #endregion
}

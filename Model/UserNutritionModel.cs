using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TechroseDemo
{
    public class UserNutritionBaseModel
    {
        public UserNutritionBaseModel()
        {
            UserId = int.MinValue;
            NutritionId = int.MinValue;
            Portion = double.MinValue;
            BloodSugar = int.MinValue;
            MealTime = DateTime.Now;
        }

        [JsonPropertyName("user_id")]
        [Column("user_id")]
        [ForeignKey("UserModel")]
        public required int UserId { get; set; }

        [JsonIgnore]
        public virtual UserModel? UserModel { get; set; }

        [JsonPropertyName("nutrition_id")]
        [Column("nutrition_id")]
        [ForeignKey("NutritionModel")]
        public required int NutritionId { get; set; }

        [JsonIgnore]
        public virtual NutritionModel? NutritionModel { get; set; }

        [JsonPropertyName("portion")]
        [Column("portion")]
        public required double Portion { get; set; }

        [JsonPropertyName("blood_sugar")]
        [Column("blood_sugar")]
        public required int BloodSugar { get; set; }

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
    public class UserNutritionModelCreateArgs : UserNutritionBaseModel
    {
        public UserNutritionModelCreateArgs() 
        {
             
        }
    }

    public class UserNutritionModelCreateResult
    {
        public UserNutritionModelCreateResult()
        {
            InsulinDose = int.MinValue;
            Result = new ResultModel();
        }

        public int InsulinDose { get; set; }

        public ResultModel Result { get; set; }
    }
    #endregion
}

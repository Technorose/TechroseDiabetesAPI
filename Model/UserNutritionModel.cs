using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TechroseDemo
{
    public class UserBaseNutritionModel
    {
        public UserBaseNutritionModel()
        {
            UserId = int.MinValue;
            NutritionId = int.MinValue;
            Portion = double.MinValue;
            MealTime = DateTime.Now;
        }

        [JsonPropertyName("user_id")]
        [Column("user_id")]
        [ForeignKey("UserModel")]
        public required int UserId { get; set; }
        public virtual UserModel? UserModel { get; set; }

        [JsonPropertyName("nutrition_id")]
        [Column("nutrition_id")]
        [ForeignKey("NutritionModel")]
        public required int NutritionId { get; set; }
        public virtual NutritionModel? NutritionModel { get; set; }

        [JsonPropertyName("portion")]
        [Column("portion")]
        public required double Portion { get; set; }

        [JsonPropertyName("meal_time")]
        [Column("meal_time")]
        public required DateTime MealTime { get; set; }
    }

    [Table("user_nutritions")]
    public class UserNutritionModel : UserBaseNutritionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
    }

    #region UserNutritionCreateModels

    #endregion
}

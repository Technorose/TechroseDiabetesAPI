using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechroseDemo
{
    public class NutritionTypeBaseModel
    {
        public NutritionTypeBaseModel()
        {
            NutritionTypeName = string.Empty;
            Image = string.Empty;
        }

        [JsonPropertyName("nutrition_type_name")]
        [Column("nutrition_type_name")]
        public string NutritionTypeName { get; set; }

        [JsonPropertyName("image")]
        [Column("image")]
        public string Image { get; set; }
    }

    [Table("nutrition_types")]
    public class NutritionTypeModel : NutritionTypeBaseModel
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }

    public class NutritionTypeListModelArgs
    {
        public NutritionTypeListModelArgs()
        {
            Skip = int.MinValue;
            Take = int.MinValue;
        }

        [FromQuery(Name = "skip")]
        public int Skip { get; set; }

        [FromQuery(Name = "take")]
        public int Take { get; set; }

    }

    public class NutritionTypeListModelResult
    {
        public NutritionTypeListModelResult()
        {
            Result = new ResultModel();
            NutritionTypes = new List<NutritionTypeModel>();
        }
        
        public ResultModel Result { get; set; }


        [JsonPropertyName("nutrition_types")]
        public List<NutritionTypeModel> NutritionTypes { get; set; }
    }
}

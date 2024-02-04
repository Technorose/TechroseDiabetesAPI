using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text.Json.Serialization;

namespace TechroseDemo
{
    public class NutritionBaseModel
    {
        public NutritionBaseModel()
        {
            Name = string.Empty;
            ServingSize = string.Empty;
            Calories = long.MinValue;
            TotalFat = string.Empty;
            Cholesterol = string.Empty;
            Caffeine = string.Empty;
            Sugars = string.Empty;
            Carbohydrate = string.Empty;
        }

        [Column("name")]
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [Column("serving_size")]
        [JsonPropertyName("serving_size")]
        public required string ServingSize { get; set; }

        [Column("calories")]
        [JsonPropertyName("calories")]
        public required long Calories { get; set; }

        [Column("total_fat")]
        [JsonPropertyName("total_fat")]
        public required string TotalFat { get; set; }

        [Column("cholesterol")]
        [JsonPropertyName("cholesterol")]
        public required string Cholesterol { get; set;}

        [Column("caffeine")]
        [JsonPropertyName("caffeine")]
        public required string Caffeine { get; set;}

        [Column("sugars")]
        [JsonPropertyName("sugars")]
        public required string Sugars { get; set;}

        [Column("carbohydrate")]
        [JsonPropertyName("carbohydrate")]
        public required string Carbohydrate { get; set;}
    }

    [Table("nutritions")]
    public class NutritionModel : NutritionBaseModel
    {
        public NutritionModel()
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

    public class NutritionModelListArgs
    {
        public NutritionModelListArgs()
        {
            Limit = int.MinValue;
            Offset = int.MinValue;
        }

        [FromQuery(Name = "limit")]
        public int Limit { get; set;}

        [FromQuery(Name = "offset")]
        public int Offset { get; set;}
    }

    public class NutritionModelListResult
    {
        public NutritionModelListResult()
        {
            Nutritions = new List<NutritionModel>();
            Result = new ResultModel();
        }

        public ResultModel Result { get; set; }

        [JsonPropertyName("nutritions")]
        public List<NutritionModel> Nutritions { get; set; }

    }

    public class NutritionModelSearchArgs
    {
        public NutritionModelSearchArgs()
        {
            SearchArgument = string.Empty;
            Limit = int.MinValue;
            Offset = int.MinValue;
        }

        [FromQuery(Name = "search_argument")]
        public string SearchArgument { get; set; }

        [FromQuery(Name = "limit")]
        public int Limit { get; set;}

        [FromQuery(Name = "offset")]
        public int Offset { get; set;}
    }

    public class NutritionModelDetailsArgs
    {

        public NutritionModelDetailsArgs()
        {
            Id = int.MinValue;
        }

        [FromQuery(Name = "id")]
        public int Id { get; set; }
    }

    public class NutritionModelDetailsResult
    {
        public NutritionModelDetailsResult()
        {
            Result = new ResultModel();
        }

        public ResultModel Result { get; set; }

        public NutritionModel? Nutrition { get; set; }
    }

    public class NutritionModelSearchResult
    {
        public NutritionModelSearchResult()
        {
            Nutritions = new List<NutritionModel>();
            Result = new ResultModel();
        }

        [JsonPropertyName("nutritions")]
        public List<NutritionModel> Nutritions { get; set; }

        public ResultModel Result { get; set; }
    }
}

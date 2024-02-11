using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Numerics;
using System.Text.Json.Serialization;

namespace TechroseDemo
{
    public class NutritionBaseModel
    {
        public NutritionBaseModel()
        {
            Name = string.Empty;
            ServingSize = long.MinValue;
            Calorie = long.MinValue;
            Sugar = long.MinValue;
            Carbohydrate = long.MinValue;
            Category = string.Empty;
            Image = string.Empty;
        }

        [Column("name")]
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [Column("serving_size")]
        [JsonPropertyName("serving_size")]
        public required long ServingSize { get; set; }

        [Column("calorie")]
        [JsonPropertyName("calorie")]
        public required long Calorie { get; set; }

        [Column("sugar")]
        [JsonPropertyName("sugar")]
        public required long Sugar { get; set;}

        [Column("carbo_hydrate")]
        [JsonPropertyName("carbo_hydrate")]
        public required long Carbohydrate { get; set;}

        [Column("category")]
        [JsonPropertyName("category")]
        public required string Category { get; set; }

        [Column("image")]
        [JsonPropertyName("image")]
        public required string Image { get; set; }
    }

    [Table("nutritions")]
    public class NutritionModel : NutritionBaseModel
    {
        public NutritionModel()
        {
            Id = long.MinValue;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserNutritionModel>? UserNutritionModels { get; set; }
    }

    public class NutritionModelDto : NutritionBaseModel
    {
        public NutritionModelDto()
        {
            Id = long.MinValue;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }
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
            Nutritions = new List<NutritionModelDto>();
            Result = new ResultModel();
        }

        public ResultModel Result { get; set; }

        [JsonPropertyName("nutritions")]
        public List<NutritionModelDto> Nutritions { get; set; }

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

        public NutritionModelDto? Nutrition { get; set; }
    }

    public class NutritionModelSearchResult
    {
        public NutritionModelSearchResult()
        {
            Nutritions = new List<NutritionModelDto>();
            Result = new ResultModel();
        }

        [JsonPropertyName("nutritions")]
        public List<NutritionModelDto> Nutritions { get; set; }

        public ResultModel Result { get; set; }
    }

    public class NutritionModelListByNutritionTypeArgs 
    {
        public NutritionModelListByNutritionTypeArgs()
        {
            NutritionTypeId = int.MinValue;
            Skip = CoreStaticVars.DefaultOffsetValue;
            Take = CoreStaticVars.DefaultLimitValue;
        }

        [FromQuery(Name = "nutrition_type_id")]
        public int NutritionTypeId { get; set; }


        [FromQuery(Name = "skip")]
        public int Skip { get; set; }


        [FromQuery(Name = "take")]
        public int Take { get; set; }
    }

    public class NutritionModelListByNutritionTypeResult
    {
        public NutritionModelListByNutritionTypeResult()
        {
            Result = new ResultModel();
            Nutritions = new List<NutritionModelDto>();
        }

        public ResultModel Result { get; set; }

        [JsonPropertyName("nutritions")]
        public List<NutritionModelDto> Nutritions { get; set; }
        
    }
}

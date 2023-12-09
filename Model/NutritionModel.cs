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
        }

        [Column("name")]
        public required string Name { get; set; }

        [Column("serving_size")]
        public required string ServingSize { get; set; }

        [Column("calories")]
        public required long Calories { get; set;}

        [Column("total_fat")]
        public required string TotalFat { get; set;}

        [Column("cholesterol")]
        public required string Cholesterol { get; set;}

        [Column("caffeine")]
        public required string Caffeine { get; set;}

        [Column("sugars")]
        public required string Sugars { get; set;}
    }

    [Table("nutritions")]
    public class NutritionModel : NutritionBaseModel
    {
        public NutritionModel()
        {
            Id = long.MinValue;
        }

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

        public int Limit { get; set;}
        
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

        public string SearchArgument { get; set; }

        public int Limit { get; set;}

        public int Offset { get; set;}
    }

    public class NutritionModelSearchResult
    {
        public NutritionModelSearchResult()
        {
            Nutritions = new List<NutritionModel>();
            Result = new ResultModel();
        }

        public List<NutritionModel> Nutritions { get; set; }

        public ResultModel Result { get; set; }
    }
}

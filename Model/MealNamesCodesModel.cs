using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechroseDemo
{
    public class MealNamesCodesModelBase
    {
        public MealNamesCodesModelBase()
        {
            MealName = string.Empty;
        }

        [Column("meal_name")]
        [JsonPropertyName("meal_name")]
        public string MealName { get; set; }
    }

    [Table("meal_names_codes")]
    public class MealNamesCodesModel : MealNamesCodesModelBase 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [JsonIgnore]
        public virtual ICollection<MealModel>? MealModels { get; set; }
    }

    public class MealNamesCodesModelListArgs
    {
        public MealNamesCodesModelListArgs()
        {
            Skip = int.MinValue;
            Take = int.MinValue;
        }

        [FromQuery(Name = "take")]
        public int Take { get; set; }

        [FromQuery(Name = "skip")]
        public int Skip { get; set; }
    }

    public class MealNamesCodesModelListResult
    {
        public MealNamesCodesModelListResult()
        {
            MealNamesCodes = new List<MealNamesCodesModel>();
            Result = new ResultModel();
        }

        [JsonPropertyName("meal_names_codes")]
        public List<MealNamesCodesModel> MealNamesCodes { get; set; }

        public ResultModel Result { get; set; }
    }
}

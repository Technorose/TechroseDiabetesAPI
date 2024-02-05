using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TechroseDemo
{
    public class UserBaseModel
    {
        public UserBaseModel()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            Weight = double.MinValue;
            BloodSugarValue = double.MinValue;
            BirthDate = default(DateTime);
        }

        [Column("first_name")]
        [JsonPropertyName("first_name")]
        public required string FirstName { get; set; }

        [Column("last_name")]
        [JsonPropertyName("last_name")]
        public required string LastName { get; set; }

        [Column("email")]
        [JsonPropertyName("email")]
        public required string Email { get; set; }

        [Column("phone_number")]
        [JsonPropertyName("phone_number")]
        public required string PhoneNumber { get; set; }

        [Column("weight")]
        [JsonPropertyName("weight")]
        public required double Weight { get; set; }

        [Column("blood_sugar_value")]
        [JsonPropertyName("blood_sugar_value")]
        public required double BloodSugarValue { get; set; }

        [Column("birth_date")]
        [JsonPropertyName("birth_date")]
        public required DateTime BirthDate { get; set;}
    }

    [Table("users")]
    public class UserModel : UserBaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("hashed_password")]
        public required string HashedPassword { get; set; }

        [Column("salted_password")]
        public required string SaltedPassword { get; set; }

        [Column("total_dose_value")]
        [JsonPropertyName("total_dose_value")]
        public required double TotalDoseValue { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserNutritionModel>? UserNutritionModels { get; set; }
    }

    public class UserModelDto : UserBaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("total_dose_value")]
        [JsonPropertyName("total_dose_value")]
        public required double TotalDoseValue { get; set; }
    }

    public class UserModelDeleteArgs
    {
        public UserModelDeleteArgs()
        {
            Id = int.MinValue;
        }

        [FromQuery(Name = "id")]
        public int Id { get; set; }
    }

    public class UserModelDeleteResult
    {
        public UserModelDeleteResult()
        {
            Result = new ResultModel();
        }

        public ResultModel Result { get; set; }
    }

    public class UserModelCreateArgs : UserBaseModel
    {
        public UserModelCreateArgs()
        {
            Password = string.Empty;
            SecurityTokenKey = string.Empty;
        }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("security_token_key")]
        public string SecurityTokenKey { get; set;}
    }

    public class UserModelCreateResult
    {
        public UserModelCreateResult()
        {
            Result = new ResultModel();
        }

        public ResultModel Result { get; set; }
    }

    public class UserModelLoginArgs
    {
        public UserModelLoginArgs() 
        {
            UserName = string.Empty;
            Password = string.Empty;
            SecurityTokenKey = string.Empty;
        }

        [JsonPropertyName("user_name")]
        public string UserName { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("security_token_key")]
        public string SecurityTokenKey { get; set;}
    }

    public class UserModelLoginResult
    {
        public UserModelLoginResult()
        {
            Token = string.Empty;
            Result = new ResultModel();
        }

        [JsonPropertyName("user")]
        [AllowNull]
        public UserModelDto User { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        public ResultModel Result { get; set; }
    }

    public class UserModelListArgs
    {
        public UserModelListArgs()
        {
            Limit = int.MinValue;
            Offset = int.MinValue;
        }

        [FromQuery(Name = "limit")]
        public int Limit { get; set; }

        [FromQuery(Name = "offset")]
        public int Offset { get; set; }
    }

    public class UserModelListResult
    {
        public UserModelListResult()
        {
            Users = new List<UserModelDto>();
            Result = new ResultModel();
        }

        [JsonPropertyName("users")]
        public List<UserModelDto> Users { get; set; }

        [JsonPropertyName("result")]
        public ResultModel Result { get; set; }
    }

    public class UserModelUpdatePasswordArgs
    {
        public UserModelUpdatePasswordArgs()
        {
            OldPassword = string.Empty;
            NewPassword = string.Empty;
            ConfirmPassword = string.Empty;
        }

        [JsonPropertyName("old_password")]
        public string OldPassword { get; set; }

        [JsonPropertyName("new_password")]
        public string NewPassword { get; set; }

        [JsonPropertyName("confirm_password")]
        public string ConfirmPassword { get; set;}
    }

    public class UserModelUpdatePasswordResult
    {
        public UserModelUpdatePasswordResult()
        {
            Result = new ResultModel();
        }

        public ResultModel Result { get; set; }
    }
}

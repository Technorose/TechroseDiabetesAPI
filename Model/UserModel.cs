﻿using Microsoft.AspNetCore.Mvc;
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
        [Required]
        public string FirstName { get; set; }

        [Column("last_name")]
        [JsonPropertyName("last_name")]
        [Required]
        public string LastName { get; set; }

        [Column("email")]
        [JsonPropertyName("email")]
        [Required]
        public string Email { get; set; }

        [Column("phone_number")]
        [JsonPropertyName("phone_number")]
        [Required]
        public string PhoneNumber { get; set; }

        [Column("weight")]
        [JsonPropertyName("weight")]
        [Required]
        public double Weight { get; set; }

        [Column("blood_sugar_value")]
        [JsonPropertyName("blood_sugar_value")]
        [Required]
        public double BloodSugarValue { get; set; }

        [Column("birth_date")]
        [JsonPropertyName("birth_date")]
        [Required]
        public DateTime BirthDate { get; set;}
    }

    [Table("users")]
    public class UserModel : UserBaseModel
    {
        public UserModel()
        {
            HashedPassword = string.Empty;
            SaltedPassword = string.Empty;
            Image = string.Empty;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("hashed_password")]
        [Required]
        public string HashedPassword { get; set; }

        [Column("salted_password")]
        [Required]
        public string SaltedPassword { get; set; }

        [Column("total_dose_value")]
        [JsonPropertyName("total_dose_value")]
        [Required]
        public double TotalDoseValue { get; set; }

        [Column("image")]
        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonIgnore]
        public virtual ICollection<MealModel>? MealModels { get; set; }
    }
    
    public class UserModelDto : UserBaseModel
    {
        public UserModelDto()
        {
            Image = string.Empty;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("total_dose_value")]
        [JsonPropertyName("total_dose_value")]
        [Required]
        public double TotalDoseValue { get; set; }

        [Column("image")]
        [JsonPropertyName("image")]
        public string Image { get; set; }

        public static implicit operator UserModelDto(UserModel v)
        {
            throw new NotImplementedException();
        }
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

    public class UserModelDetailsArgs
    {
        public UserModelDetailsArgs()
        {
            Id = int.MinValue;
        }

        [FromQuery(Name = "id")]
        public int Id { get; set; }
    }

    public class UserModelDetailsResult
    {
        public UserModelDetailsResult()
        {
            Result = new ResultModel();
        }
        public ResultModel Result { get; set; }
        public UserModelDto? User { get; set; }
        
    }

    public class UserModelUploadProfileImageArgs
    {
        public UserModelUploadProfileImageArgs()
        {
            Image = null;
        }

        [FromForm(Name = "file")]
        public IFormFile? Image { get; set; }
    }

    public class UserModelUploadProfileImageResult
    {
        public UserModelUploadProfileImageResult()
        {
            Image = string.Empty;
            Result = new ResultModel();
        }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        public ResultModel Result { get; set; }
    }

    public class UserModelTakeMealsValuesByDateArgs 
    {
        public UserModelTakeMealsValuesByDateArgs()
        {
            Date = DateTime.Now;
        }

        [FromQuery(Name = "date")] 
        public DateTime Date { get; set; }
    }

    public class UserModelTakeMealsValuesByDateResult
    {
        public UserModelTakeMealsValuesByDateResult()
        {
            Result = new ResultModel();
            TotalCalories = double.MinValue;
            TotalCarbohydrate = double.MinValue;
            TotalSugar = double.MinValue;
            BloodSugar = double.MinValue; 
        }
        public ResultModel Result { get; set; }

        [JsonPropertyName("total_calories")] 
        public double TotalCalories { get; set; }
        
        [JsonPropertyName("total_carbohydrate")]
        public double TotalCarbohydrate { get; set; }

        [JsonPropertyName("total_sugar")]
        public double TotalSugar { get; set; }

        [JsonPropertyName("blood_sugar")]
        public double BloodSugar { get; set; }
    }

    public class UserModelUpdateArgs : UserBaseModel
    {
    }

    public class UserModelUpdateResult
    {
        public UserModelUpdateResult()
        {
            Result = new ResultModel();
            User = new UserModelDto();
        }
        public ResultModel Result { get; set; }
        public UserModelDto User { get; set; } 
        
    }
}

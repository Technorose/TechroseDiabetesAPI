﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public virtual ICollection<UserNutritionModel>? UserNutritionModels { get; set; }
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
            Id = int.MinValue;
            FullName = string.Empty;
            Token = string.Empty;
            Result = new ResultModel();
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        public ResultModel Result { get; set; }
    }
}

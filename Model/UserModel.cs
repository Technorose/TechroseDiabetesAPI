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
        public required string FirstName { get; set; }

        [Column("last_name")]
        public required string LastName { get; set; }

        [Column("email")]
        public required string Email { get; set; }

        [Column("phone_number")]
        public required string PhoneNumber { get; set; }

        [Column("birth_date")]
        public required DateTime BirthDate { get; set;}
    }

    [Table("users")]
    public class UserModel : UserBaseModel
    {
        public UserModel()
        {
            Id = string.Empty;
            HashedPassword = string.Empty;
        }

        [Column("id")]
        public string Id { get; set; }

        [Column("hashed_password")]
        public string HashedPassword { get; set; }
    }

    public class UserModelDeleteArgs
    {
        public UserModelDeleteArgs()
        {
            Id = string.Empty;
        }

        [JsonPropertyName("id")]
        public string Id { get; set; }
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

        public string Password { get; set; }

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

        public string UserName { get; set; }

        public string Password { get; set; }

        public string SecurityTokenKey { get; set;}
    }

    public class UserModelLoginResult
    {
        public UserModelLoginResult()
        {
            Id = string.Empty;
            FullName = string.Empty;
            Token = string.Empty;
            Result = new ResultModel();
        }

        public string Id { get; set; }
        
        public string FullName { get; set; }

        public string Token { get; set; }

        public ResultModel Result { get; set; }
    }
}

using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
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

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }

        public required DateTime BirthDate { get; set;}
    }

    public class UserModel : UserBaseModel
    {
        public UserModel()
        {
            Id = string.Empty;
            HashedPassword = string.Empty;
        }

        [Key]
        public string Id { get; set; }

        public string HashedPassword { get; set; }
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

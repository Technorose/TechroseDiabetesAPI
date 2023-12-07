using System.ComponentModel.DataAnnotations;

namespace TechroseDemo
{
    public class UserBaseModel
    {

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }
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

        public required string HashedPassword { get; set; }
    }

    public class UserModelCreateArgs : UserBaseModel
    {
        public UserModelCreateArgs()
        {
            Password = string.Empty;
        }

        public string Password { get; set; }
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
        }
        
        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class UserModelLoginResult
    {
        public UserModelLoginResult()
        {
            Result = new ResultModel();
        }

        public ResultModel Result { get; set; }
    }
}

using TechroseDemo.Repo;
using static TechroseDemo.Enums;

namespace TechroseDemo
{
    public partial class BaseRepo : IRepo
    {
        #region UserLogin
        public UserModelLoginResult UserLogin(UserModelLoginArgs args)
        {
            UserModelLoginResult result = new();

            return result;
        }
        #endregion

        #region UserCreate
        public UserModelCreateResult UserCreate(UserModelCreateArgs args)
        {
            UserModelCreateResult result = new();

            if (args.FirstName.Equals(null) || args.FirstName.Trim().Equals(""))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            if (args.LastName.Equals(null) || args.LastName.Trim().Equals(""))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            if (args.PhoneNumber.Equals(null) || args.PhoneNumber.Trim().Equals(""))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            if (args.Email.Equals(null) || args.Email.Trim().Equals(""))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            if (args.Password.Equals(null) || args.Password.Trim().Equals("") || args.Password.Length < 6)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            return result;
        }
        #endregion
    }
}

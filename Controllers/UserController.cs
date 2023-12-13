using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using TechroseDemo.Repo;
using static TechroseDemo.Enums;

namespace TechroseDemo
{
    public partial class BaseController : ControllerBase
    {
        #region UserControllers
        #region UserLoginEndpoint
        [AllowAnonymous]
        [Route(nameof(UserLogin))]
        [HttpPost]
        public async Task<UserModelLoginResult> UserLogin([FromBody] UserModelLoginArgs args)
        {
            UserModelLoginResult result = new();

            if (args.SecurityTokenKey != Constants.tConstant_SecurityTokenKey)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0001.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0001.ToDescription();

                return result;
            }

            await Task.Run(() =>
            {
                try
                {
                    result = repoInterface.UserLogin(args);
                }
                catch (Exception ex)
                {
                    result.Result.Success = false;
                    result.Result.ErrorCode = EnumErrorCodes.ERRORx0001.ToString();
                    result.Result.ErrorDescription = EnumErrorCodes.ERRORx0001.ToDescription();
                    result.Result.ErrorException = Common.ExceptionToString(ex);
                }
            });

            return result;
        }
        #endregion

        #region UserCreate
        [AllowAnonymous]
        [Route(nameof(UserCreate))]
        [HttpPost]
        public async Task<UserModelCreateResult> UserCreate([FromBody] UserModelCreateArgs args)
        {
            UserModelCreateResult result = new();

            if (args.SecurityTokenKey != Constants.tConstant_SecurityTokenKey)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0001.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0001.ToDescription();

                return result;
            }

            await Task.Run(() =>
            {
                try
                {
                    result = repoInterface.UserCreate(args);
                }

                catch (Exception ex)
                {
                    result.Result.Success = false;
                    result.Result.ErrorCode = EnumErrorCodes.ERRORx0001.ToString();
                    result.Result.ErrorDescription = EnumErrorCodes.ERRORx0001.ToDescription();
                    result.Result.ErrorException = Common.ExceptionToString(ex);
                }
            });

            return result;
        }
        #endregion

        #region TokenCheck
        [Authorize]
        [Route(nameof(TokenCheck))]
        [HttpPost]
        public async Task<TokenCheckModelResult> TokenCheck([FromBody] TokenCheckModelArgs args)
        {
            TokenCheckModelResult result = new();

            await Task.Run(() =>
            {
                try
                {
                    result.ClientTime = args.ClientTime;
                    result.ServerTime = DateTime.UtcNow;
                    result.Result.Success = true;
                    result.Result.ErrorCode = "";
                    result.Result.ErrorDescription = "";
                }
                catch (Exception ex)
                {
                    result.Result.Success = false;
                    result.Result.ErrorCode = EnumErrorCodes.ERRORx0001.ToString();
                    result.Result.ErrorDescription = EnumErrorCodes.ERRORx0001.ToDescription();
                    result.Result.ErrorException = Common.ExceptionToString(ex);
                }
            });

            return result;
        }
        #endregion

        #region UserDeleteAPI
        [Authorize]
        [Route(nameof(UserDelete))]
        [HttpDelete]
        public async Task<UserModelDeleteResult> UserDelete([FromQuery] UserModelDeleteArgs args)
        {
            UserModelDeleteResult result = new();

            await Task.Run(() =>
            {
                try
                {
                    result = repoInterface.UserDelete(args);
                }
                catch (Exception ex)
                {
                    result.Result.Success = false;
                    result.Result.ErrorCode = EnumErrorCodes.ERRORx0001.ToString();
                    result.Result.ErrorDescription = EnumErrorCodes.ERRORx0001.ToDescription();
                    result.Result.ErrorException = Common.ExceptionToString(ex);
                }
            });

            return result;
        }
        #endregion
        #endregion
    }
}

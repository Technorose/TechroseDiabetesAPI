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
        #endregion
    }
}

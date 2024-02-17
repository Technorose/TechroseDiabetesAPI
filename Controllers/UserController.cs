using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
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
        public async Task<UserModelLoginResult> UserLogin([FromBody] UserModelLoginArgs args, [FromServices] ILoggerService loggerService)
        {
            loggerService.LogInformation(LoggerStatic.LogTrigger, nameof(UserLogin));

            UserModelLoginResult result = new();

            if (args.SecurityTokenKey != Constants.tConstant_SecurityTokenKey)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0001.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0001.ToDescription();

                loggerService.LogWarning(LoggerStatic.LogFail, result.Result, nameof(UserLogin));

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

                    loggerService.LogError(LoggerStatic.LogException, ex, result.Result, nameof(UserLogin));
                }
            });

            if(result.Result.Success)
            {
                loggerService.LogInformation(LoggerStatic.LogSuccess, result.Token, result.User.Id, nameof(UserLogin));
            }
            else
            {
                loggerService.LogWarning(LoggerStatic.LogFail, result.Result, nameof(UserLogin));
            }

            return result;
        }
        #endregion

        #region UserCreate
        [AllowAnonymous]    
        [Route(nameof(UserCreate))]
        [HttpPost]
        public async Task<UserModelCreateResult> UserCreate([FromBody] UserModelCreateArgs args, [FromServices] ILoggerService loggerService)
        {

            loggerService.LogInformation(LoggerStatic.LogTrigger, nameof(UserCreate));

            UserModelCreateResult result = new();

            if (args.SecurityTokenKey != Constants.tConstant_SecurityTokenKey)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0001.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0001.ToDescription();

                loggerService.LogWarning(LoggerStatic.LogFail, result.Result, nameof(UserCreate));

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

                    loggerService.LogError(LoggerStatic.LogException, ex, result.Result, nameof(UserCreate));
                }
            });

            if (result.Result.Success)
            {
                loggerService.LogInformation(LoggerStatic.LogSuccess, nameof(UserCreate));
            }
            else
            {
                loggerService.LogWarning(LoggerStatic.LogFail, result.Result, nameof(UserCreate));
            }

            return result;
        }
        #endregion

        #region TokenCheck
        [Authorize]
        [Route(nameof(TokenCheck))]
        [HttpPost]
        public async Task<TokenCheckModelResult> TokenCheck([FromBody] TokenCheckModelArgs args, [FromServices] ILoggerService loggerService)
        {

            loggerService.LogInformation(LoggerStatic.LogTrigger, nameof(TokenCheck));

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

                    loggerService.LogError(LoggerStatic.LogException, ex, result.Result, nameof(TokenCheck));
                }
            });

            if (result.Result.Success)
            {
                loggerService.LogInformation(LoggerStatic.LogSuccess, nameof(TokenCheck));
            }
            else
            {
                loggerService.LogWarning(LoggerStatic.LogFail, result.Result, nameof(TokenCheck));
            }

            return result;
        }
        #endregion

        #region UserDeleteAPI
        [Authorize]
        [Route(nameof(UserDelete))]
        [HttpDelete]
        public async Task<UserModelDeleteResult> UserDelete([FromQuery] UserModelDeleteArgs args, [FromServices] ILoggerService loggerService)
        {

            loggerService.LogInformation(LoggerStatic.LogTrigger, nameof(UserDelete));

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

                    loggerService.LogError(LoggerStatic.LogException, ex, result.Result, nameof(UserDelete));
                }
            });

            if (result.Result.Success)
            {
                loggerService.LogInformation(LoggerStatic.LogSuccess, nameof(UserDelete));
            }
            else
            {
                loggerService.LogWarning(LoggerStatic.LogFail, result.Result, nameof(UserDelete));
            }

            return result;
        }
        #endregion

        #region UserListAPI
        [Authorize]
        [Route(nameof(UserList))]
        [HttpGet]
        public async Task<UserModelListResult> UserList([FromQuery] UserModelListArgs args)
        {
            UserModelListResult result = new();

            await Task.Run(() =>
            {
                try
                {
                    result = repoInterface.UserList(args);
                }
                catch(Exception ex)
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

        #region UserUpdatePassword
        [HttpPut]
        [Authorize]
        [Route(nameof(UserUpdatePassword))]
        public async Task<UserModelUpdatePasswordResult> UserUpdatePassword([FromBody] UserModelUpdatePasswordArgs args, [FromHeader] HeaderModelArgs headers)
        {
            UserModelUpdatePasswordResult result = new();

            await Task.Run(() =>
            {
                try
                {
                    result = repoInterface.UserUpdatePassword(args, headers);
                }
                catch(Exception ex)
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

        #region UserModelDetails
        [HttpGet]
        [Route(nameof(UserDetails))]
        [Authorize]
        public async Task<UserModelDetailsResult> UserDetails([FromQuery] UserModelDetailsArgs args)

        {
            UserModelDetailsResult result = new();

            await Task.Run(() =>
            {
                try
                {
                    result = repoInterface.UserDetails(args);
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

        [HttpPost]
        [Authorize]
        [Route(nameof(UserUploadProfileImage))]
        public async Task<UserModelUploadProfileImageResult> UserUploadProfileImage([FromForm] UserModelUploadProfileImageArgs args, [FromHeader] HeaderModelArgs headerArgs)
        {
            UserModelUploadProfileImageResult result = new();

            await Task.Run(async() =>
            {
                try
                {
                    result = await repoInterface.UserUploadProfileImage(args, headerArgs);
                }
                catch(Exception ex)
                {
                    result.Result.Success = false;
                    result.Result.ErrorCode = EnumErrorCodes.ERRORx0001.ToString();
                    result.Result.ErrorDescription = EnumErrorCodes.ERRORx0001.ToDescription();
                    result.Result.ErrorException = Common.ExceptionToString(ex);
                }
            });

            return result;
        }

        [HttpGet]
        [Authorize]
        [Route(nameof(UserGetMealsValues))]
        public async Task<UserModelTakeMealsValuesByDateResult> UserGetMealsValues([FromQuery]UserModelTakeMealsValuesByDateArgs args,[FromHeader] HeaderModelArgs headerArgs)
        {
            UserModelTakeMealsValuesByDateResult result = new();

            await Task.Run(() =>
            {
                try
                {
                    result = repoInterface.UserGetMealsValues(args, headerArgs);
                }
                catch (Exception ex)
                {
                    result.Result.Success = false;
                    result.Result.ErrorCode= EnumErrorCodes.ERRORx0001.ToString();  
                    result.Result.ErrorDescription = EnumErrorCodes.ERRORx0001.ToDescription();
                    result.Result.ErrorException= Common.ExceptionToString(ex);
                }
            });

            return result;
        }


        #region UserUpdates
        [HttpPost]
        [Authorize]
        [Route(nameof(UserUpdate))]
        public async Task<UserModelUpdateResult> UserUpdate([FromBody] UserModelUpdateArgs args, [FromHeader] HeaderModelArgs headerArgs)
        {
            UserModelUpdateResult result = new();

            await Task.Run(() =>
            {
                try
                {
                    result = repoInterface.UserUpdate(args, headerArgs);
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
    }
}

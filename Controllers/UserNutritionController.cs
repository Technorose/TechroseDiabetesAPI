using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TechroseDemo.Repo;
using static TechroseDemo.Enums;

namespace TechroseDemo
{
    public partial class BaseController : ControllerBase
    {
        [Authorize]
        [Route(nameof(UserNutritionCreate))]
        [HttpPost]
        public async Task<UserNutritionModelCreateResult> UserNutritionCreate([FromBody] UserNutritionModelCreateArgs args, [FromServices] ILoggerService loggerService)
        {

            loggerService.LogInformation(LoggerStatic.LogTrigger, nameof(UserNutritionCreate));

            UserNutritionModelCreateResult result = new();

            await Task.Run(() =>
            {
                try
                {
                    result = repoInterface.UserNutritionCreate(args);
                }
                catch (Exception ex)
                {
                    result.Result.Success = false;
                    result.Result.ErrorCode = EnumErrorCodes.ERRORx0001.ToString();
                    result.Result.ErrorDescription = EnumErrorCodes.ERRORx0001.ToDescription();
                    result.Result.ErrorException = Common.ExceptionToString(ex);

                    loggerService.LogError(LoggerStatic.LogException, ex, result.Result, nameof(UserNutritionCreate));
                }
            });

            if (result.Result.Success)
            {
                loggerService.LogInformation(LoggerStatic.LogSuccess, nameof(UserNutritionCreate));
            }
            else
            {
                loggerService.LogWarning(LoggerStatic.LogFail, result.Result, nameof(UserNutritionCreate));
            }

            return result;
        }
    }
}

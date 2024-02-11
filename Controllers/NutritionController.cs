using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TechroseDemo.Repo;
using static TechroseDemo.Enums;

namespace TechroseDemo
{
    public partial class BaseController : ControllerBase
    {
        #region NutritionController
        #region NutritionListAPI
        [Authorize]
        [Route(nameof(NutritionsList))]
        [HttpGet]
        public async Task<NutritionModelListResult> NutritionsList([FromQuery] NutritionModelListArgs args, [FromServices] ILoggerService loggerService)
        {

            loggerService.LogInformation(LoggerStatic.LogTrigger, nameof(NutritionsList));

            NutritionModelListResult result = new();

            await Task.Run(() =>
            {
                try
                {
                    result = repoInterface.NutritionsList(args);
                }
                catch (Exception ex)
                {
                    result.Result.Success = false;
                    result.Result.ErrorCode = EnumErrorCodes.ERRORx0001.ToString();
                    result.Result.ErrorDescription = EnumErrorCodes.ERRORx0001.ToDescription();
                    result.Result.ErrorException = Common.ExceptionToString(ex);

                    loggerService.LogError(LoggerStatic.LogException, ex, result.Result, nameof(NutritionsList));
                }
            });

            if (result.Result.Success)
            {
                loggerService.LogInformation(LoggerStatic.LogSuccess, nameof(NutritionsList));
            }
            else
            {
                loggerService.LogWarning(LoggerStatic.LogFail, result.Result, nameof(NutritionsList));
            }

            return result;
        }

        #region NutritionSearchAPI
        [Authorize]
        [Route(nameof(NutritionSearch))]
        [HttpGet]
        public async Task<NutritionModelSearchResult> NutritionSearch([FromQuery] NutritionModelSearchArgs args, [FromServices] ILoggerService loggerService)
        {

            loggerService.LogInformation(LoggerStatic.LogTrigger, nameof(NutritionSearch));

            NutritionModelSearchResult result = new();

            await Task.Run(() =>
            {
                try
                {
                    result = repoInterface.NutritionSearch(args);
                }
                catch (Exception ex)
                {
                    result.Result.Success = false;
                    result.Result.ErrorCode = EnumErrorCodes.ERRORx0001.ToString();
                    result.Result.ErrorDescription = EnumErrorCodes.ERRORx0001.ToDescription();
                    result.Result.ErrorException = Common.ExceptionToString(ex);

                    loggerService.LogError(LoggerStatic.LogException, ex, result.Result, nameof(NutritionSearch));
                }
            });

            if (result.Result.Success)
            {
                loggerService.LogInformation(LoggerStatic.LogSuccess, nameof(NutritionSearch));
            }
            else
            {
                loggerService.LogWarning(LoggerStatic.LogFail, result.Result, nameof(NutritionSearch));
            }

            return result;
        }

        [Route(nameof(NutritionDetails))]
        [HttpGet]
        [Authorize]
        public async Task<NutritionModelDetailsResult> NutritionDetails([FromQuery] NutritionModelDetailsArgs args)
        {
            NutritionModelDetailsResult result = new();

            await Task.Run(() =>
            {
                try
                {
                    result = repoInterface.NutritionDetails(args);
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


        [Route(nameof(NutritionListByNutritionType))]
        [HttpGet] 
        [Authorize]
        public async Task<NutritionModelListByNutritionTypeResult> NutritionListByNutritionType([FromQuery] NutritionModelListByNutritionTypeArgs args)
        {
            NutritionModelListByNutritionTypeResult result = new();
            
            await Task.Run(() =>
            {
                try
                {
                    result = repoInterface.NutritionListByNutritionType(args);
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
        #endregion
    }
}

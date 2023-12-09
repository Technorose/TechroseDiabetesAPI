using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<NutritionModelListResult> NutritionsList([FromQuery] NutritionModelListArgs args)
        {
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
                }
            });

            return result;
        }

        #region NutritionSearchAPI
        [AllowAnonymous]
        [Route(nameof(NutritionSearch))]
        [HttpGet]
        public async Task<NutritionModelSearchResult> NutritionSearch([FromQuery] NutritionModelSearchArgs args)
        {
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
                }
            });

            return result;
        }
        #endregion
        #endregion
        #endregion
    }
}

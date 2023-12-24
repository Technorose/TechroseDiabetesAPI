using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechroseDemo.Repo;
using static TechroseDemo.Enums;

namespace TechroseDemo
{
    public partial class BaseController : ControllerBase
    {
        [AllowAnonymous]
        [Route(nameof(MealNamesCodesList))]
        [HttpGet]
        public async Task<MealNamesCodesModelListResult> MealNamesCodesList([FromQuery] MealNamesCodesModelListArgs args)
        {
            MealNamesCodesModelListResult result = new();

            await Task.Run(() =>
            {
                try
                {
                    result = repoInterface.MealNamesCodesList(args);
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
    }
}

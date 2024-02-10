using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechroseDemo.Repo;
using static TechroseDemo.Enums;

namespace TechroseDemo
{
    public partial class BaseController : ControllerBase 
    {
        [HttpGet]
        [AllowAnonymous]
        [Route(nameof(NutritionTypeList))]
        public async Task<NutritionTypeListModelResult> NutritionTypeList([FromBody] NutritionTypeListModelArgs args)
        {
            NutritionTypeListModelResult result = new();

            await Task.Run(() =>
            {
                try
                {
                    result = repoInterface.NutritionTypeList(args);
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

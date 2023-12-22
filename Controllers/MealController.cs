using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechroseDemo.Repo;
using static TechroseDemo.Enums;

namespace TechroseDemo
{
    public partial class BaseController : ControllerBase
    {
        [AllowAnonymous]
        [Route(nameof(MealCreate))]
        [HttpPost]
        public async Task<MealModelCreateResult> MealCreate([FromBody] MealModelCreateArgs args)
        {
            MealModelCreateResult result = new();

            await Task.Run(() =>
            {
                try
                {
                    result = repoInterface.MealCreate(args);
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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechroseDemo.Repo;
using static TechroseDemo.Enums;

namespace TechroseDemo
{
    public partial class BaseController : ControllerBase
    {
        [AllowAnonymous]
        [Route(nameof(UserNutritionCreate))]
        [HttpPost]
        public async Task<UserNutritionModelCreateResult> UserNutritionCreate([FromBody] UserNutritionModelCreateArgs args)
        {
            UserNutritionModelCreateResult result = new();

            await Task.Run(async () =>
            {
                try
                {
                    result = await repoInterface.UserNutritionCreate(args);
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

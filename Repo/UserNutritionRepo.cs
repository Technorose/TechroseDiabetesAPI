using TechroseDemo.Repo;
using static TechroseDemo.Enums;

namespace TechroseDemo
{
    public partial class BaseRepo : IRepo
    {
        public async Task<UserNutritionModelCreateResult> UserNutritionCreate(UserNutritionModelCreateArgs args)
        {
            UserNutritionModelCreateResult result = new();

            List<UserNutritionModel> userNutritionsToAdd = Mapper.Map<List<UserNutritionModel>>(args);

            if (userNutritionsToAdd.Count != args.Count)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0903.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0903.ToDescription();

                return result;
            }

            await DatabaseContext.UserNutritions.AddRangeAsync(userNutritionsToAdd);

            MealUpdate(new MealModelUpdateArgs()
            {
                Id = args[0].MealId,
                UserNutritionsIds = userNutritionsToAdd.Select(item => item.Id).ToList()
            });
            
            await DatabaseContext.SaveChangesAsync();


            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";

            return result;
        }
    }
}

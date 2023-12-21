using TechroseDemo.Repo;
using static TechroseDemo.Enums;

namespace TechroseDemo
{
    public partial class BaseRepo : IRepo
    {
        public async Task<UserNutritionModelCreateResult> UserNutritionCreate(UserNutritionModelCreateArgs args)
        {
            UserNutritionModelCreateResult result = new();


            #pragma warning disable CS8619
            List<UserNutritionModel> userNutritionsToAdd = args.Select(
                    arg =>
                    {
                        if (arg.UserId.Equals(int.MinValue) || arg.UserId.Equals(null))
                        {
                            return null;
                        }

                        if (arg.NutritionId.Equals(int.MinValue) || arg.NutritionId.Equals(null))
                        {
                            return null;
                        }

                        if (arg.MealId.Equals(int.MinValue) || arg.MealId.Equals(null))
                        {
                            return null;
                        }

                        return new UserNutritionModel()
                        {
                            MealId = arg.MealId,
                            MealModel = arg.MealModel,
                            NutritionId = arg.NutritionId,
                            Portion = arg.Portion.Equals(int.MinValue) ? 1 : arg.Portion,
                            UserId = arg.UserId,
                            MealTime = arg.MealTime
                        };
                    })
                .Where(model => model != null)
                .ToList();

            if (userNutritionsToAdd.Count != args.Count)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0903.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0903.ToDescription();

                return result;
            }

            await DatabaseContext.UserNutritions.AddRangeAsync(userNutritionsToAdd);
            
            await DatabaseContext.SaveChangesAsync();


            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";

            return result;
        }
    }
}

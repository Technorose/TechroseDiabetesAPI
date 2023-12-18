using TechroseDemo.Repo;
using static TechroseDemo.Enums;

namespace TechroseDemo
{
    public partial class BaseRepo : IRepo
    {
        public UserNutritionModelCreateResult UserNutritionCreate(UserNutritionModelCreateArgs args)
        {
            UserNutritionModelCreateResult result = new();

            if (args.UserId.Equals(int.MinValue) || args.UserId.Equals(null))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0900.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0900.ToDescription();

                return result;
            }

            if (args.NutritionId.Equals(int.MinValue) || args.NutritionId.Equals(null))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0901.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0901.ToDescription();

                return result;
            }

            if (args.BloodSugar.Equals(int.MinValue) || args.BloodSugar.Equals(null))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0902.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0902.ToDescription();

                return result;
            }

            if (args.Portion.Equals(double.MinValue) || args.Portion.Equals(null))
            {
                args.Portion = 1;
            }

            UserNutritionModel userNutrition = new()
            {
                MealTime = args.MealTime,
                NutritionId = args.NutritionId,
                Portion = args.Portion,
                UserId = args.UserId,
                BloodSugar = args.BloodSugar
            };

            DatabaseContext.UserNutritions.Add(userNutrition);
            DatabaseContext.SaveChanges();

            result.InsulinDose = (int)Math.Ceiling(500 / userNutrition.UserModel.TotalDoseValue);

            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";

            return result;
        }
    }
}

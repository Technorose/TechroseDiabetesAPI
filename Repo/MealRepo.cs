using TechroseDemo.Repo;
using static TechroseDemo.Enums;

namespace TechroseDemo
{
    public partial class BaseRepo : IRepo
    {
        public MealModelCreateResult MealCreate(MealModelCreateArgs args)
        {
            MealModelCreateResult result = new();
            
            if (args.MealNameCode.Equals(int.MinValue) || args.MealNameCode.Equals(null))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0699.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0699.ToDescription();

                return result;
            }

            if (args.MealTime.Equals(DateTime.MinValue) || args.MealTime.Equals(null))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0700.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0700.ToDescription();

                return result;
            }

            string mealName = string.Empty;

            foreach(EnumMealNames enumMeal in Enum.GetValues(typeof(EnumMealNames)))
            {
                if (enumMeal.Equals(args.MealNameCode))
                {
                    mealName = enumMeal.ToDescription();
                }
            }

            if (mealName.Trim().Equals(""))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0699.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0699.ToDescription();

                return result;
            }

            MealModel meal = new()
            {
                BloodSugar = 0.0,
                MealTime = args.MealTime,
                TotalCalorie = 0.0,
                TotalCarbohydrate = 0.0,
                TotalSugar = 0.0,
                MealName = mealName,
            };

            DatabaseContext.Meals.Add(meal);
            DatabaseContext.SaveChanges();

            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";

            return result;
        }
    }
}

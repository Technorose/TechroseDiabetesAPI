using Microsoft.EntityFrameworkCore;
using TechroseDemo.Repo;
using static TechroseDemo.Enums;

namespace TechroseDemo
{
    public partial class BaseRepo : IRepo
    {
        #region MealCreate
        public MealModelCreateResult MealCreate(MealModelCreateArgs args)
        {
            MealModelCreateResult result = new();

            if (args.BloodSugar.Equals(int.MinValue) || args.BloodSugar.Equals(null))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0698.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0698.ToDescription();

                return result;
            }

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


            MealModel meal = new()
            {
                BloodSugar = args.BloodSugar,
                MealTime = args.MealTime,
                TotalCalorie = 0.0,
                TotalCarbohydrate = 0.0,
                TotalSugar = 0.0,
                MealNameCode = args.MealNameCode,
                UserId = args.UserId,
            };

            DatabaseContext.Meals.Add(meal);
            DatabaseContext.SaveChanges();

            result.Id = meal.Id;
            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";

            return result;
        }
        #endregion

        #region MealUpdate
        public MealModelUpdateResult MealUpdate(MealModelUpdateArgs args)
        {
            MealModelUpdateResult result = new();

            if (args.Id.Equals(int.MinValue) || args.Id.Equals(null))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0701.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0701.ToDescription();

                return result;
            }

            if (args.UserNutritionsIds.Count.Equals(0) || args.UserNutritionsIds.Equals(null))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0702.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0702.ToDescription();

                return result;
            }

            MealModel? model = DatabaseContext.Meals.SingleOrDefault(
                m => m.Id == args.Id
            );

            if (model == null)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0703.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0703.ToDescription();

                return result;
            }

            UserNutritionsMealUpdateResult? usrnResult = DatabaseContext.UserNutritions
                .Where(usrn => usrn.MealId == model.Id)
                .Join(DatabaseContext.Nutritions,
                      usrn => usrn.NutritionId,
                      nutr => nutr.Id,
                      (usrn, nutr) => new UserNutritionsMealUpdateArgs { UserNutrition = usrn, Nutrition = nutr })
                .GroupBy(group => group.UserNutrition.MealId)
                .Select(group => new UserNutritionsMealUpdateResult
                {
                    TotalCalorie = group.Sum(entry => Convert.ToDouble(entry.Nutrition.Calorie) * entry.UserNutrition.Portion),
                    TotalCarbohydrate = group.Sum(entry => Convert.ToDouble(entry.Nutrition.Carbohydrate) * entry.UserNutrition.Portion),
                    TotalSugar = group.Sum(entry => Convert.ToDouble(entry.Nutrition.Sugar) * entry.UserNutrition.Portion)
                })
                .FirstOrDefault();

            model.TotalCalorie += usrnResult == null ? 0 : usrnResult.TotalCalorie;

            model.TotalCarbohydrate += usrnResult == null ? 0 : usrnResult.TotalCarbohydrate;

            model.TotalSugar += usrnResult == null ? 0 : usrnResult.TotalSugar;


            DatabaseContext.Meals.Update(model);
            DatabaseContext.SaveChanges();

            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";

            return result;
        }
        #endregion

        public MealModelDetailsResult MealDetails(MealModelDetailsArgs args)
        {
            MealModelDetailsResult result = new();

            if(args.Id.Equals(null) || args.Id.Equals(int.MinValue))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            MealModel? meal = DatabaseContext.Meals.FirstOrDefault(
                m => m.Id == args.Id
            );

            if(meal == null)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0704.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0704.ToDescription();

                return result;
            }

            result.Meal = meal;
            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";

            return result;
        }
    }
}

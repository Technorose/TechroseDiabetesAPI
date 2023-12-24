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
            };

            DatabaseContext.Meals.Add(meal);
            DatabaseContext.SaveChanges();

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

            var usrnResult = DatabaseContext.UserNutritions
                .Where(usrn => usrn.MealId == model.Id)
                .Join(DatabaseContext.Nutritions,
                      usrn => usrn.NutritionId,
                      nutr => nutr.Id,
                      (usrn, nutr) => new { UserNutrition = usrn, Nutrition = nutr })
                .ToList(); 

            model.TotalCalorie += usrnResult.Sum(entry => Convert.ToDouble(entry.Nutrition.Calories) * entry.UserNutrition.Portion);

            model.TotalCarbohydrate += usrnResult.Sum(entry => Convert.ToDouble(entry.Nutrition.Carbohydrate.Split(' ').Length > 0 ? entry.Nutrition.Carbohydrate.Split(' ')[0] : entry.Nutrition.Carbohydrate) * entry.UserNutrition.Portion);

            model.TotalSugar += usrnResult.Sum(entry => Convert.ToDouble(entry.Nutrition.Sugars.Split(' ').Length > 0 ? entry.Nutrition.Sugars.Split(' ')[0] : entry.Nutrition.Sugars) * entry.UserNutrition.Portion);


            DatabaseContext.Meals.Update(model);
            DatabaseContext.SaveChanges();

            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";

            return result;
        }
        #endregion
    }
}

using Microsoft.AspNetCore.Mvc.ModelBinding;
using TechroseDemo.Repo;
using static TechroseDemo.Enums;
namespace TechroseDemo
{
    public partial class BaseRepo : IRepo
    {

        public NutritionTypeListModelResult NutritionTypeList(NutritionTypeListModelArgs args)
        {
            NutritionTypeListModelResult result = new();

            if (args.Skip.Equals(null) || args.Skip.Equals(int.MinValue))
            {
                args.Skip = CoreStaticVars.DefaultOffsetValue;
            }
            
            if(args.Take.Equals(null) || args.Take.Equals(int.MinValue))
            {
                args.Take = CoreStaticVars.DefaultLimitValue;
            }

            List<NutritionTypeModel> nutritionTypes = DatabaseContext.NutritionTypes
                .OrderBy(n => n.Id) 
                .Skip(args.Skip)
                .Take(args.Take)
                .ToList();

            if (nutritionTypes == null)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx1000.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx1000.ToDescription();

                return result;
            }

            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";
            
            result.NutritionTypes = nutritionTypes;
            return result;
        }
    }
}

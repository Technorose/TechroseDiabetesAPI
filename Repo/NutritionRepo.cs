using TechroseDemo.Repo;
using static TechroseDemo.Enums;

namespace TechroseDemo
{
    public partial class BaseRepo : IRepo
    {
        #region NutritionsList
        public NutritionModelListResult NutritionsList(NutritionModelListArgs args)
        {
            NutritionModelListResult result = new();

            #region CheckCredential
            if (args.Limit.Equals(int.MinValue))
            {
                args.Limit = 10;
            }

            if (args.Offset.Equals(int.MinValue))
            {
                args.Offset = 0;
            }
            #endregion

            #region TakeListFromDatabase
            IQueryable<NutritionModel> query = DatabaseContext.Nutritions
                .OrderBy(n => n.Id)
                .Skip(args.Offset)
                .Take(args.Limit);
            #endregion

            #region CheckList
            if (query.Equals(null))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0600.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0600.ToDescription();

                return result;
            }
            #endregion

            #region PreparingToResult
            result.Nutritions = [.. query];
            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";
            #endregion

            return result;
        }
        #endregion
    }
}

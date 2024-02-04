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
                args.Limit = CoreStaticVars.DefaultLimitValue;
            }

            if (args.Offset.Equals(int.MinValue))
            {
                args.Offset = CoreStaticVars.DefaultOffsetValue;
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

        #region NutritionSearch
        public NutritionModelSearchResult NutritionSearch(NutritionModelSearchArgs args)
        {
            NutritionModelSearchResult result = new();

            #region CheckCredentials
            if (args.SearchArgument.Equals(null) || args.SearchArgument.Trim().Equals(""))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0601.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0601.ToDescription();

                return result;
            }

            if (args.Limit.Equals(int.MinValue))
            {
                args.Limit = CoreStaticVars.DefaultLimitValue;
            }

            if (args.Offset.Equals(int.MinValue))
            {
                args.Offset = CoreStaticVars.DefaultOffsetValue;
            }
            #endregion

            #region SearchingOnTable
            IQueryable<NutritionModel> query = DatabaseContext.Nutritions
                .OrderBy(n => n.Id)
                .Where(n => n.Name.Contains(args.SearchArgument))
                .Skip(args.Offset)
                .Take(args.Limit);
            #endregion

            #region CheckQuery
            if (query.Equals(null))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0601.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0601.ToDescription();

                return result;
            }
            #endregion

            #region PreparingResponse
            result.Nutritions = [.. query];
            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";
            #endregion

            return result;
        }

        public NutritionModelDetailsResult NutritionDetails(NutritionModelDetailsArgs args)
        {
            NutritionModelDetailsResult result = new();

            if(args.Id.Equals(int.MinValue) || args.Id.Equals(null))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            NutritionModel? nutrition = DatabaseContext.Nutritions.FirstOrDefault(
                    n => n.Id == args.Id
                );

            if(nutrition == null)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0602.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0602.ToDescription();

                return result;
            }

            result.Nutrition = nutrition;
            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";

            return result;
        }
        #endregion
    }
}

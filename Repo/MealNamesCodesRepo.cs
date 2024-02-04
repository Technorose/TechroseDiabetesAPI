using System.Globalization;
using TechroseDemo.Repo;
using static TechroseDemo.Enums;

namespace TechroseDemo
{
    public partial class BaseRepo : IRepo
    {
        #region MealNamesCodesListRepo
        public MealNamesCodesModelListResult MealNamesCodesList(MealNamesCodesModelListArgs args)
        {
            MealNamesCodesModelListResult result = new();

            if (args.Take.Equals(int.MinValue))
            {
                args.Take = CoreStaticVars.DefaultLimitValue;
            }

            if (args.Skip.Equals(int.MinValue))
            {
                args.Skip = CoreStaticVars.DefaultOffsetValue;
            }

            List<MealNamesCodesModel> query = DatabaseContext.MealNamesCodes
                .OrderBy(m => m.Id)
                .Select(x => new MealNamesCodesModel
                {
                    Id = x.Id,
                    MealName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(x.MealName.ToLower()),
                })
                .Skip(args.Skip)
                .Take(args.Take)
                .ToList();

            if (query.Count.Equals(0) || query.Equals(null))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0995.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0995.ToDescription();

                return result;
            }

            result.MealNamesCodes = query;
            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";

            return result;
        }
        #endregion
    }
}

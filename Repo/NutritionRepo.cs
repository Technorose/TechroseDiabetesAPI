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
            #pragma warning disable CS8601 // Possible null reference assignment.
            #region TakeListFromDatabase
            List<NutritionModelDto> query = DatabaseContext.Nutritions
                .OrderBy(n => n.Id)
                .Select(n => new NutritionModelDto
                {
                    Id = n.Id,
                    Name = n.Name,
                    Calorie = n.Calorie,
                    Carbohydrate = n.Carbohydrate,
                    NutritionType = n.NutritionTypeModels,
                    ServingSize = n.ServingSize,
                    Sugar = n.Sugar,
                    Image = googleCloudStorage.GenerateDownloadImageUrl(new GenerateDownloadImageUrlArgs() { FileName = n.Image})
                })
                .Skip(args.Offset)
                .Take(args.Limit)
                .ToList();
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
            result.Nutritions = query;
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
            #pragma warning disable CS8601 // Possible null reference assignment.
            #region SearchingOnTable
            List<NutritionModelDto> query = DatabaseContext.Nutritions
                .OrderBy(n => n.Id)
                .Where(n => n.Name.Contains(args.SearchArgument))
                .Select(n => new NutritionModelDto
                {
                    Id = n.Id,
                    Name = n.Name,
                    Calorie = n.Calorie,
                    Carbohydrate = n.Carbohydrate,
                    NutritionType = n.NutritionTypeModels,
                    ServingSize = n.ServingSize,
                    Sugar = n.Sugar,
                    Image = googleCloudStorage.GenerateDownloadImageUrl(new GenerateDownloadImageUrlArgs() { FileName = n.Image })
                })
                .Skip(args.Offset)
                .Take(args.Limit)
                .ToList();
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
            result.Nutritions = query;
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

            #pragma warning disable CS8601 // Possible null reference assignment.
            NutritionModelDto? nutrition = DatabaseContext.Nutritions
                .Select(n => new NutritionModelDto
                {
                    Id = n.Id,
                    Name = n.Name,
                    Calorie = n.Calorie,
                    Carbohydrate = n.Carbohydrate,
                    NutritionType = n.NutritionTypeModels,
                    ServingSize = n.ServingSize,
                    Sugar = n.Sugar,
                    Image = googleCloudStorage.GenerateDownloadImageUrl(new GenerateDownloadImageUrlArgs()
                    {
                        FileName = n.Image
                    })
                })
                .FirstOrDefault(
                    n => n.Id == args.Id
                );

            if (nutrition == null)
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

        #region NutritionListByNutritionType
        
        public NutritionModelListByNutritionTypeResult NutritionListByNutritionType(NutritionModelListByNutritionTypeArgs args)
        {
            NutritionModelListByNutritionTypeResult result = new();

            if(args.NutritionTypeId.Equals(null) || args.NutritionTypeId.Equals(int.MinValue))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0001.ToDescription();

                return result;
            }

            List<NutritionModelDto> nutritions = DatabaseContext.Nutritions
                .Where(n => n.NutritionTypeId == args.NutritionTypeId)
                .Select(n => new NutritionModelDto
                {
                    Id = n.Id,
                    Calorie = n.Calorie,
                    Carbohydrate = n.Carbohydrate,
                    Name = n.Name,
                    ServingSize = n.ServingSize,
                    Sugar = n.Sugar,
                    NutritionType = n.NutritionTypeModels,
                    Image = googleCloudStorage.GenerateDownloadImageUrl(new GenerateDownloadImageUrlArgs()
                    {
                        FileName = n.Image
                    }),
                })
                .OrderBy(n => n.Id)
                .Skip(args.Skip)
                .Take(args.Take)
                .ToList();

            if(nutritions.Count == 0)
            {
                result.Result.Success = false;
                result.Result.ErrorCode= EnumErrorCodes.ERRORx0600.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0600.ToDescription();

                return result;
            }
            
            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";
            result.Nutritions = nutritions; 

            return result;
        }
        #endregion
    }
}

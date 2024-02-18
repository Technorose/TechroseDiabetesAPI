using Microsoft.AspNetCore.Mvc;

namespace TechroseDemo
{
    public interface IRepo
    {
        #region UserRepo
        UserModelLoginResult UserLogin(UserModelLoginArgs args);

        UserModelCreateResult UserCreate(UserModelCreateArgs args);

        UserModelDeleteResult UserDelete(UserModelDeleteArgs args);

        UserModelListResult UserList(UserModelListArgs args);

        UserModelUpdatePasswordResult UserUpdatePassword(UserModelUpdatePasswordArgs args, HeaderModelArgs headers);

        UserModelDetailsResult UserDetails(UserModelDetailsArgs args);

        Task<UserModelUploadProfileImageResult> UserUploadProfileImage(UserModelUploadProfileImageArgs args, HeaderModelArgs headerArgs);

        UserModelTakeMealsValuesByDateResult UserGetMealsValues(UserModelTakeMealsValuesByDateArgs args, HeaderModelArgs headerArgs);

        UserModelUpdateResult UserUpdate(UserModelUpdateArgs args , HeaderModelArgs headerArgs);
        #endregion

        #region NutritionRepo
        NutritionModelListResult NutritionsList(NutritionModelListArgs args);

        NutritionModelSearchResult NutritionSearch(NutritionModelSearchArgs args);

        NutritionModelDetailsResult NutritionDetails(NutritionModelDetailsArgs args);

        NutritionModelListByNutritionTypeResult NutritionListByNutritionType(NutritionModelListByNutritionTypeArgs args);
        #endregion

        #region UserNutritionRepo
        Task<UserNutritionModelCreateResult> UserNutritionCreate(UserNutritionModelCreateArgs args);
        #endregion

        #region MealRepo
        MealModelCreateResult MealCreate(MealModelCreateArgs args);

        Task<MealModelUpdateResult> MealUpdate(MealModelUpdateArgs args);

        MealModelDetailsResult MealDetails(MealModelDetailsArgs args);

        #endregion

        #region MealNamesCodesRepo
        MealNamesCodesModelListResult MealNamesCodesList(MealNamesCodesModelListArgs args);
        #endregion

        #region NutritionTypeRepo
        NutritionTypeListModelResult NutritionTypeList(NutritionTypeListModelArgs args);
        #endregion
    }
}

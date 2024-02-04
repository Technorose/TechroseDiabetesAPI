namespace TechroseDemo
{
    public interface IRepo
    {
        #region UserRepo
        UserModelLoginResult UserLogin(UserModelLoginArgs args);

        UserModelCreateResult UserCreate(UserModelCreateArgs args);

        UserModelDeleteResult UserDelete(UserModelDeleteArgs args);

        UserModelListResult UserList(UserModelListArgs args);
        #endregion

        #region NutritionRepo
        NutritionModelListResult NutritionsList(NutritionModelListArgs args);

        NutritionModelSearchResult NutritionSearch(NutritionModelSearchArgs args);

        NutritionModelDetailsResult NutritionDetails(NutritionModelDetailsArgs args);
        #endregion

        #region UserNutritionRepo
        Task<UserNutritionModelCreateResult> UserNutritionCreate(UserNutritionModelCreateArgs args);
        #endregion

        #region MealRepo
        MealModelCreateResult MealCreate(MealModelCreateArgs args);

        MealModelUpdateResult MealUpdate(MealModelUpdateArgs args);

        #endregion

        #region MealNamesCodesRepo
        MealNamesCodesModelListResult MealNamesCodesList(MealNamesCodesModelListArgs args);
        #endregion
    }
}

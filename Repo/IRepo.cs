﻿namespace TechroseDemo
{
    public interface IRepo
    {
        #region UserRepo
        UserModelLoginResult UserLogin(UserModelLoginArgs args);

        UserModelCreateResult UserCreate(UserModelCreateArgs args);

        UserModelDeleteResult UserDelete(UserModelDeleteArgs args);
        #endregion

        #region NutritionRepo
        NutritionModelListResult NutritionsList(NutritionModelListArgs args);

        NutritionModelSearchResult NutritionSearch(NutritionModelSearchArgs args);
        #endregion

        #region UserNutritionRepo
        UserNutritionModelCreateResult UserNutritionCreate(UserNutritionModelCreateArgs args);
        #endregion
    }
}

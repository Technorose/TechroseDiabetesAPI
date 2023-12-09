namespace TechroseDemo
{
    public interface IRepo
    {
        #region UserRepo
        UserModelLoginResult UserLogin(UserModelLoginArgs args);

        UserModelCreateResult UserCreate(UserModelCreateArgs args);
        #endregion

        #region NutritionRepo
        NutritionModelListResult NutritionsList(NutritionModelListArgs args);
        #endregion
    }
}

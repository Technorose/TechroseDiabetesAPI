using System.ComponentModel;

namespace TechroseDemo
{
    public class Enums
    {
        public enum EnumErrorCodes
        {
            #region SystemErrorHandling
            [Description("Unhandled Exception Occurred!")]
            ERRORx0001,
            #endregion

            #region UserOperationsErrorEnums
            [Description("Invalid Credentials")]
            ERRORx0100,

            [Description("Already User Exist")]
            ERRORx0404,

            [Description("User Not Found!")]
            ERRORx0401,

            [Description("Incorrect Password!")]
            ERRORx0400,

            [Description("Error Occurred While Getting User Details By ID")]
            ERRORx0402,

            [Description("Profile Image Extensions Error! (Must be png or jpg)")]
            ERRORx0403,

            [Description("Profile Image Uploading Error!")]
            ERRORx0405,

            [Description("The email is not valid!")]
            ERRORx0406,
            #endregion

            #region NutritionsOperationsErrorEnums
            [Description("Error Occurred While Getting Nutritions List!")]
            ERRORx0600,

            [Description("Error Occurred While Searching Nutritions!")]
            ERRORx0601,

            [Description("Error Occurred While Getting Details of Nutrition!")]
            ERRORx0602,
            #endregion

            #region MealOperationsErrorEnums
            [Description("The blood sugar must be valid!")]
            ERRORx0698,

            [Description("The meal name must be valid!")]
            ERRORx0699,

            [Description("The meal time must be valid!")]
            ERRORx0700,

            [Description("The meal id must be valid!")]
            ERRORx0701,

            [Description("The user nutritions id's must be valid!")]
            ERRORx0702,

            [Description("The meal not found on records!")]
            ERRORx0703,

            [Description("Error Occurred While Getting Meal Details By ID!")]
            ERRORx0704,
            #endregion

            #region UserNutritionOperationsErrorEnums
            [Description("Error Occurred While Getting Users List!")]
            ERRORx0899,

            [Description("The User must be valid!")]
            ERRORx0900,

            [Description("The Nutrition must be valid!")]
            ERRORx0901,

            [Description("The blood sugar value must be valid!")]
            ERRORx0902,

            [Description("Error Occurred While Creating User Nutritions!")]
            ERRORx0903,
            #endregion

            #region MealNamesCodesOperationsErrorEnums
            [Description("Error Occurred While Getting Meal Names Codes List!")]
            ERRORx0995,
            #endregion

            #region NutritionTypeErrorEnums
            [Description("Error Occurred While Getting Nutrition Type List")]
            ERRORx1000,
            #endregion
        }

        public enum EnumMealNames
        {
            #region MealNames
            [Description("breakfast")]
            Breakfast = 1,

            [Description("lunch")]
            Lunch = 2,

            [Description("dinner")]
            Dinner = 3,

            [Description("snack")]
            Snack = 4,
            #endregion
        }
    }
}

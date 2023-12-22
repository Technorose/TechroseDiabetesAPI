﻿using System.ComponentModel;

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
            #endregion

            #region NutritionsOperationsErrorEnums
            [Description("Error Occurred While Getting Nutritions List!")]
            ERRORx0600,

            [Description("Error Occurred While Searching Nutritions!")]
            ERRORx0601,
            #endregion

            #region MealOperationsErrorEnums
            [Description("The meal name must be valid!")]
            ERRORx0699,

            [Description("The meal time must be valid!")]
            ERRORx0700,
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

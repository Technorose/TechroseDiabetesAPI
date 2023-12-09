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
            #endregion

            #region NutritionsOperationsErrorEnums
            [Description("Error Occurred While Getting Nutritions List!")]
            ERRORx0600,

            [Description("Error Occurred While Searching Nutritions!")]
            ERRORx0601,
            #endregion
        }
    }
}

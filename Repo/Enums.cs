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
            #endregion
        }
    }
}

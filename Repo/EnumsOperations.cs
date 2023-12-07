using System.ComponentModel;

namespace TechroseDemo.Repo
{
    public static class EnumsOperations
    {
        public static string ToDescription(this Enum value)
        {
            var desc = (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return desc.Length > 0 ? desc[0].Description : value.ToString();
        }
    }
}

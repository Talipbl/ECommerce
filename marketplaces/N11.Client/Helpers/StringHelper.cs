using System.ComponentModel;

namespace N11.Client
{
    public static class StringHelper
    {
        public static string GetEnumDescription(Enum enums)
        {
            var reason = enums;
            string description = string.Empty;

            DescriptionAttribute[] attributes = (DescriptionAttribute[])reason.GetType().GetField(reason.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                description = attributes[0].Description;
            }

            return description;
        }
    }
}

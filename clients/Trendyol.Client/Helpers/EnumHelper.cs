using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Client
{
    public static class EnumHelper
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

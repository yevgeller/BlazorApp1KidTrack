using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp1.Shared.Models
{
    public static class StaticUtils
    {
        public static string BoolToStringYesNo(bool value)
        {
            if (value)
                return "Yes";
            return "No";
        }
    }
}

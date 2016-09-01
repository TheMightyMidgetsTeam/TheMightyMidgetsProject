using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSite.Classes
{
    public static class Utils
    {
        public static string CutText(string text, int length = 100)
        {
            if (text != null && text.Length >= length)
            {
                return text.Substring(0, length) + "...";
            }
            else
            {
                return text;
            }
        }
    }
}
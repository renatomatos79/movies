using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Framework
{
    public static class ConvertUtils
    {
        public static int ToInt(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                s = "0";
            }

            int result;
            if (int.TryParse(s, out result))
            {
                return result;
            }
            return 0;
        }
    }
}

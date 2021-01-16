using System;
using System.Collections.Generic;
using System.Text;

namespace Menu_Generator.Core
{
    public static class Extensions
    {
        /// <summary>
        /// It's needed until the node could contains empty string
        /// </summary>
        public static int? ParseInt(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return int.Parse(value);
        }
    }
}

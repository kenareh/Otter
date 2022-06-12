using System.Collections.Generic;
using System.Linq;

namespace Otter.Common.Tools
{
    public static class CheckNullOrEmpty
    {
        /// <summary>
        /// if its null or empty returns true
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// if its null or empty returns true
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
        {
            if (list != null && list.Any())
            {
                return false;
            }

            return true;
        }
    }
}
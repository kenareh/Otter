using System;
using System.Collections.Generic;
using System.Linq;

namespace Otter.Common.Tools
{
    public static class TreeUtils
    {
        public static IEnumerable<T> GetAllNodes<T>(this T node, Func<T, IEnumerable<T>> f)
        {
            return GetAllNodes(new[] { node }, f);
        }

        public static IEnumerable<T> GetAllNodes<T>(this IEnumerable<T> e, Func<T, IEnumerable<T>> f)
        {
            return e.SelectMany(c => f(c).GetAllNodes(f)).Concat(e);
        }

        public static IEnumerable<T> SelectNestedChildren<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> selector)
        {
            if (source == null)
                throw new Exception("dlfkdkf");
            foreach (T item in source)
            {
                yield return item;
                foreach (T subItem in SelectNestedChildren(selector(item), selector))
                {
                    yield return subItem;
                }
            }
        }

        //        public static IEnumerable<Chart> SelectNestedCharts(this IEnumerable<Chart> charts)
        //        {
        //            charts.
        //        }
    }
}
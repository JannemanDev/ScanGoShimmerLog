﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanGoShimmerLog.Extensions
{
    public static class IEnumerableExtensions
    {
        public static long? MaxOrDefault<T>(this IEnumerable<T> enumeration, Func<T, long?> selector)
        {
            return enumeration.Any() ? enumeration.Max(selector) : null;
        }

        public static long? MinOrDefault<T>(this IEnumerable<T> enumeration, Func<T, long?> selector)
        {
            return enumeration.Any() ? enumeration.Min(selector) : null;
        }

        public static double? AvgOrDefault<T>(this IEnumerable<T> enumeration, Func<T, long?> selector)
        {
            return enumeration.Any() ? enumeration.Average(selector) : null;
        }

        public static double? Median<TColl, TValue>(this IEnumerable<TColl> source, Func<TColl, TValue> selector)
        {
            return source.Select<TColl, TValue>(selector).Median();
        }

        public static double? Median<T>(this IEnumerable<T> source)
        {
            if (Nullable.GetUnderlyingType(typeof(T)) != null)
                source = source.Where(x => x != null);

            int count = source.Count();
            if (count == 0)
                return null;

            source = source.OrderBy(n => n);

            int midpoint = count / 2;
            if (count % 2 == 0)
                return (Convert.ToDouble(source.ElementAt(midpoint - 1)) + Convert.ToDouble(source.ElementAt(midpoint))) / 2.0;
            else
                return Convert.ToDouble(source.ElementAt(midpoint));
        }
    }
}

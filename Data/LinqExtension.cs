using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Library_API.Data
{
    public static class LinqExtension
    {

        public static IEnumerable<TSource> WhereIf<TSource>(
            this IEnumerable<TSource> source,
            bool condition,
            Func<TSource, bool> predicate)
        {
            if (condition)
                return source.Where(predicate);

            return source;
        }
    }
}

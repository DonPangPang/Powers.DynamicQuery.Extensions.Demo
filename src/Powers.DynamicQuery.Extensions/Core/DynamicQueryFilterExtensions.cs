using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Powers.DynamicQuery.Extensions.Core
{
    public static class DynamicQueryFilterExtensions
    {
        public static IQueryable<TEntity> Filter<TEntity>(this IQueryable<TEntity> query, ICustomQueryable custom)
        {
            return query.AsQueryable();
        }
    }
}

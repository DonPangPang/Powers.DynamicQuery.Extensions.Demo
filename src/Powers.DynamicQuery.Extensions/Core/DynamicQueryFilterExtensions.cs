using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        //TODO: 组装Expression表达式

        private static Expression GetExpression(ExpressionParser expressionParser)
        {
            return null;
        }
    }
}

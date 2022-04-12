using Powers.DynamicQuery.Extensions.Pagination;
using Powers.DynamicQuery.Extensions.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Powers.DynamicQuery.Extensions
{
    public static class DynamicQueryExtensions
    {
        public static IQueryable<TEntity> ApplyDyameicQuery<TEntity>(this IQueryable<TEntity> query, ICustomQueryable parameters)
        {
            if (parameters is null) return query;

            if(parameters is IDynamicQuerySort sort)
            {
                query = query.Sort(sort);
            }

            if(parameters is IDynamicQueryPaging paging)
            {
                query = query.Paginate(paging);
            }

            return query;
        }
    }
}

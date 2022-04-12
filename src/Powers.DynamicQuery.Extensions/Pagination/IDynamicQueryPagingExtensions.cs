using Powers.DynamicQuery.Extensions.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Powers.DynamicQuery.Extensions.Pagination
{
    public static class IDynamicQueryPagingExtensions
    {
        public static IQueryable<TEntity> Paginate<TEntity, TParameter>(this IQueryable<TEntity> query, TParameter parameters)
            where TParameter : class, IDynamicQueryPaging
        {
            if (parameters is null)
            {
                return query;
            }
            return PagedList<TEntity>.ApplyPaged(query, parameters.PageNumber, parameters.PageSize, parameters.IsNeedPaged);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Powers.DynamicQuery.Extensions.Sort
{
    public static class DynamicQuerySortExtensions
    {
        public static IQueryable<TEntity> Sort<TEntity>(this IQueryable<TEntity> query, string fields)
        {
            if (string.IsNullOrEmpty(fields))
            {
                return query;
            }

            var useThenBy = false;

            foreach(var field in fields.Fields())
            {
                var property = PrimitiveExtensions.GetProperty<TEntity>(field);

                if(property is not null)
                {
                    var command = useThenBy ? "ThenBy" : "OrderBy";
                    command += field.IsDescending() ? "Descending" : string.Empty;

                    query = query.OrderBy(property, command);

                    useThenBy = true;
                }
            }


            return query;
        }

        private static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> query, PropertyInfo propertyInfo, string command)
        {
            return query;
        }

        public static IQueryable<TEntity> Sort<TEntity, TParameters>(this IQueryable<TEntity> query, TParameters parameters) where TParameters : IDynamicQuerySort
        {
            if(parameters is null || string.IsNullOrEmpty(parameters.OrderBy))
            {
                return query
            }

            return Sort(query, parameters.OrderBy);
        }
    }
}

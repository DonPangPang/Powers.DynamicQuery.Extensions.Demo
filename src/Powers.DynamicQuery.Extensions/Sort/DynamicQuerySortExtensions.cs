using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
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
                }
                useThenBy = true;
            }


            return query;
        }

        private static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> query, PropertyInfo propertyInfo, string command)
        {
            var type = typeof(TEntity);
            var parameter = Expression.Parameter(type, "p");

            dynamic propertyValue = parameter;
            if (propertyInfo.Name.Contains("."))
            {
                var parts = propertyInfo.Name.Split('.');
                for (var i = 0; i < parts.Length - 1; i++)
                {
                    propertyValue = Expression.PropertyOrField(propertyValue, parts[i]);
                }
            }

            var propertyAccess = Expression.MakeMemberAccess(propertyValue, propertyInfo);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new[] { type, propertyInfo.PropertyType },
                query.Expression, Expression.Quote(orderByExpression));
            return query.Provider.CreateQuery<TEntity>(resultExpression);
        }

        public static IQueryable<TEntity> Sort<TEntity, TParameters>(this IQueryable<TEntity> query, TParameters parameters) 
            where TParameters : class, IDynamicQuerySort
        {
            if(parameters is null || string.IsNullOrEmpty(parameters.OrderBy))
            {
                return query;
            }

            return Sort(query, parameters.OrderBy);
        }
    }
}

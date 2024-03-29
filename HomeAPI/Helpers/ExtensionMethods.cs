﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HomeAPI.Helpers
{
    public static class ExtensionMethods
    {
        public static IQueryable<T> OrderByPropertyName<T>(this IQueryable<T> q, string SortField, string orderType)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, SortField);
            var exp = Expression.Lambda(prop, param);
            string method;
            if (orderType == "asc")
            {
                method = "OrderBy";
            }
            else
            {
                method = "OrderByDescending";
            }

            Type[] types = new Type[] { q.ElementType, exp.Body.Type };
            var rs = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
            return q.Provider.CreateQuery<T>(rs);
        }
    }
}

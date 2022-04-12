using Powers.DynamicQuery.Extensions.Attributes;
using Powers.DynamicQuery.Extensions.Core;
using Powers.DynamicQuery.Extensions.Pagination;
using Powers.DynamicQuery.Extensions.Sort;
using System;
using System.Collections.Generic;
using System.Text;

namespace Powers.DynamicQuery.Extensions
{
    public class UserSearch : IDynamicQuerySort, IDynamicQueryPaging
    {
        [DynamicQuery(Operator = WhereOperator.Equeals)]
        public string Name { get; set; }
        [DynamicQuery(Operator = WhereOperator.GreaterThan, UseOr = true)]
        public int Age { get; set; }

        public string OrderBy { get ; set ; }
        public bool IsNeedPaged { get ; set ; }
        public int PageNumber { get ; set ; }
        public int PageSize { get ; set ; }
    }
}

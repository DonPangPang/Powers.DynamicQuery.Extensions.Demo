using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Powers.DynamicQuery.Extensions.Core
{
    internal class ExpressionParser
    {
        public WhereClause Criteria { get; set; }
        public Expression FieldToFilter { get; set; }
        public Expression FilterBy { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Powers.DynamicQuery.Extensions.Core
{
    internal class ExpressionParserCollection: List<ExpressionParser>
    {
        public ParameterExpression ParameterExpression { get; set; }

        public List<ExpressionParser> Ordered()
        {
            return this.OrderBy(x=>x.Criteria.UseOr).ToList();
        }
    }
}

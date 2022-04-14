using System;
using System.Collections.Generic;
using System.Text;

namespace Powers.DynamicQuery.Extensions.Core
{
    public enum WhereOperator
    {
        Equals,
        NotEquals,
        GreaterThan,
        LessThan,
        GreaterThanOrEqualTo,
        LessThanOrEqualTo,
        Contains,
        StartsWith,
        EndsWith,
        LessThanOrEqualWhenNullable,
        GreaterThanOrEqualWhenNullable
    }
}

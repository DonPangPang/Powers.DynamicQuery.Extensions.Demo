using System;
using System.Collections.Generic;
using System.Text;

namespace Powers.DynamicQuery.Extensions.Core
{
    public enum WhereOperator
    {
        Equeals,
        GreaterThan,
        LessThan,
        GreaterThanOrEqual,
        LessThanOrEqual,
        Contains,
        StartsWith,
        EndsWith,
        LessThanOrEquealWhenNullable,
        GreaterThanOrEquealWhenNullable
    }
}

using Powers.DynamicQuery.Extensions.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Powers.DynamicQuery.Extensions.Attributes
{
    public class DynamicQueryAttribute
    {
        public WhereOperator? Operator { get; set; }
        public bool? CaseSensitive { get; set; } = false;
        public string? HasName { get; set; }
        public bool? UseOr { get; set; } = false;
        public bool? UseNot { get; set; } = false;
    }
}

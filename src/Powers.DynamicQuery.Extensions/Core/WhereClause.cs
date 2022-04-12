using Powers.DynamicQuery.Extensions.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Powers.DynamicQuery.Extensions.Core
{
    [DebuggerDisplay("{FieldName}")]
    internal class WhereClause
    {
        private bool _customName;

        public WhereOperator Operator { get; set; }
        public bool CaseSensitive { get; set; }
        public bool UseNot { get; set; }
        public PropertyInfo Property { get; set; }
        public string FieldName { get; set; }
        public bool UseOr { get; set; }

        public WhereClause()
        {
            Operator = WhereOperator.Equeals;
            UseNot = false;
            CaseSensitive = true;
        }

        public void UpdateAttributeData(DynamicQueryAttribute data)
        {
            Operator = data.Operator;
            UseNot = data.UseNot;
            CaseSensitive = data.CaseSensitive;
            FieldName = data.HasName;
            if (!string.IsNullOrEmpty(FieldName))
            {
                _customName = true;
            }
        }

        public void UpdateValues(PropertyInfo propertyInfo)
        {
            Property = propertyInfo;
            if(!_customName)
            {
                FieldName = Property.Name;
            }
        }
    }
}

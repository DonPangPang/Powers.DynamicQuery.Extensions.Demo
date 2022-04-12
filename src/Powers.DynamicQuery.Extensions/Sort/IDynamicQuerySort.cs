using System;
using System.Collections.Generic;
using System.Text;

namespace Powers.DynamicQuery.Extensions.Sort
{
    public interface IDynamicQuerySort: ICustomQueryable
    {
        public string OrderBy { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Powers.DynamicQuery.Extensions.Pagination
{
    public interface IDynamicQueryPaging: ICustomQueryable
    {
        public int? PageNumber { get; set; }

        public int? PageSize { get; set; }
    }
}

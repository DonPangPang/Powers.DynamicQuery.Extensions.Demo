﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powers.DynamicQuery.Extensions.Helper
{
    /// <summary>
    /// 分页
    /// </summary>
    /// <typeparam name="T"> 每页数据的类型 </typeparam>
    public class PagedList<T> : List<T>
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 是否存在上一页
        /// </summary>
        public bool HasPrevious => CurrentPage > 1;

        /// <summary>
        /// 是否存在下一页
        /// </summary>
        public bool HasNext => CurrentPage < TotalPages;

        /// <summary>
        /// </summary>
        /// <param name="items">      </param>
        /// <param name="count">      </param>
        /// <param name="pageNumber"> </param>
        /// <param name="pageSize">   </param>
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalPages = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);
        }

        ///// <summary>
        ///// </summary>
        ///// <param name="source">     </param>
        ///// <param name="pageNumber"> </param>
        ///// <param name="pageSize">   </param>
        ///// <returns> </returns>
        //public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        //{
        //    var count = await source.CountAsync();
        //    var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        //    return new PagedList<T>(items, count, pageNumber, pageSize);
        //}

        ///// <summary>
        ///// </summary>
        ///// <param name="source">     </param>
        ///// <param name="pageNumber"> </param>
        ///// <param name="pageSize">   </param>
        ///// <param name="isNeedPaged"></param>
        ///// <returns> </returns>
        //public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize, bool isNeedPaged = true)
        //{
        //    var count = await source.CountAsync();
        //    var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        //    return isNeedPaged ? new PagedList<T>(items, count, pageNumber, pageSize) : new PagedList<T>(await source.ToListAsync(), count, 1, count);
        //}

        ///// <summary>
        ///// </summary>
        ///// <param name="source">     </param>
        ///// <param name="pageNumber"> </param>
        ///// <param name="pageSize">   </param>
        ///// <returns> </returns>
        //public static async Task<IQueryable<T>> ApplyPagedAsync(IQueryable<T> source, int pageNumber, int pageSize)
        //{
        //    var count = await source.CountAsync();
        //    var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        //    return items;
        //}

        public static IQueryable<T> ApplyPaged(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return items;
        }

        public static IQueryable<T> ApplyPaged(IQueryable<T> source, int pageNumber, int pageSize, bool isNeedPaged = true)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return isNeedPaged ? items : source;
        }
    }
}

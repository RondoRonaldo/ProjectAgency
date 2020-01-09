using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BLL.Infrastructure
{
    /// <summary>
    /// Linq paging extension
    /// </summary>
    public static class PagingExtension
    {
        /// <summary>
        /// Gets list of items on page
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="pageIndex">Required page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>List of items on requested page</returns>
        public static async Task<IEnumerable<TSource>> Page<TSource>(this IQueryable<TSource> source, int pageIndex,
            int pageSize)
        {
            return source is null
                ? new List<TSource>()
                : await source.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
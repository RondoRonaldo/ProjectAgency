using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BLL.Infrastructure
{
    public static class PagingExtension
    {
        public static async Task<IEnumerable<TSource>> Page<TSource>(this IQueryable<TSource> source, int pageIndex,
            int pageSize)
        {
            return source is null
                ? new List<TSource>()
                : await source.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
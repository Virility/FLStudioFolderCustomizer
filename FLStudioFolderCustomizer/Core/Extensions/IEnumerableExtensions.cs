using System.Collections.Generic;
using System.Linq;

namespace FLStudioFolderCustomizer.Core.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<TSource> IndexRange<TSource>(
            this IEnumerable<TSource> source,
            int fromIndex,
            int toIndex)
        {
            int currIndex = fromIndex;
            while (currIndex <= toIndex)
            {
                yield return source.ElementAt(currIndex);
                currIndex++;
            }
        }
    }
}

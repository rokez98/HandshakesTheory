using System.Linq;
using System.Collections.Generic;


namespace HandshakesTheory.Vk.Extensions
{
    public static class ListExtensions
    {
        public static List<List<T>> Split<T>(this List<T> source, int size)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / size)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
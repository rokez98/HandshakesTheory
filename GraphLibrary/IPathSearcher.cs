using System.Collections.Generic;

namespace GraphLibrary.Models
{
    public interface IPathSearcher<TKey, TData>
    {
        IEnumerable<TData[]> SearchPathes(IGraph<TKey, TData> graph, TKey startVertex, TKey endVertex);
    }
}
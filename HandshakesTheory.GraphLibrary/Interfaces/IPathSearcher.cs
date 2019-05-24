using System.Collections.Generic;

namespace HandshakesTheory.GraphLibrary.Interfaces
{
    public interface IPathSearcher<TKey, TData>
    {
        IEnumerable<TData[]> SearchPathes(IGraph<TKey, TData> graph, TKey startVertex, TKey endVertex);
    }
}
using HandshakesTheory.GraphLibrary.Interfaces;
using System.Collections.Generic;

namespace HandshakesTheory.GraphLibrary.Core
{
    public class PathSearcherContext<TKey, TData>
    {
        private IPathSearcher<TKey, TData> _pathSearcher { get; set; }

        public PathSearcherContext(IPathSearcher<TKey, TData> pathSearcher) {
            _pathSearcher = pathSearcher;
        }

        public IEnumerable<TData[]> Search(IGraph<TKey, TData> graph, TKey startVertex, TKey endVertex) => _pathSearcher?.SearchPathes(graph, startVertex, endVertex);
    }
}

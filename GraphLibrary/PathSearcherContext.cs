using System.Collections.Generic;

namespace GraphLibrary.Models
{
    public class PathSearcherContext<TKey, TData>
    {
        private IPathSearcher<TKey, TData> pathSearcher { get; set; }

        public PathSearcherContext(IPathSearcher<TKey, TData> pathSearcher) {
            this.pathSearcher = pathSearcher;
        }

        public IEnumerable<TData[]> Search(IGraph<TKey, TData> graph, TKey startVertex, TKey endVertex) => pathSearcher?.SearchPathes(graph, startVertex, endVertex);
    }
}

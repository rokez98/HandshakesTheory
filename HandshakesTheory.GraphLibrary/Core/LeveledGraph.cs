using System.Collections.Generic;
using System.Linq;

namespace HandshakesTheory.GraphLibrary.Core
{
    public class LeveledGraph<TKey, TData> : AbstractGraph<TKey, TData>
    {
        public int Depth { get; set; }
        public override int Size { get => Graph.Count; }

        public override void AddEdge(TKey from, TKey to)
        {
            if (Graph.ContainsKey(from) && Graph.ContainsKey(to) && (Graph[from] as DepthVertex<TKey, TData>).Depth < (Graph[to] as DepthVertex<TKey, TData>).Depth) Graph[from].Edges.Add(to);
        }

        public override void AddVertex(TKey key, TData data)
        {
            if (!Graph.ContainsKey(key)) Graph.Add(key, new DepthVertex<TKey, TData> { Data = data });
        }

        public void AddVertex(TKey key, TData data, int depth)
        {
            if (!Graph.ContainsKey(key)) Graph.Add(key, new DepthVertex<TKey, TData> { Data = data, Depth = depth });
        }

        public IEnumerable<TData> GetVertexesOfLevel(long level)
        {
            return Graph.Where(node => (node.Value as DepthVertex<TKey, TData>).Depth == level).Select(node => node.Value.Data);
        }
        
        public static LeveledGraph<TKey, TData> Merge(LeveledGraph<TKey, TData> GraphNormal, LeveledGraph<TKey, TData> GraphReversed)
        {
            LeveledGraph<TKey, TData> mergedGraph = new LeveledGraph<TKey, TData>();

            foreach (var node in GraphNormal.Graph)
                mergedGraph.Graph.Add(node.Key, node.Value);

            foreach (var node in GraphReversed.Graph)
                if (!mergedGraph.Graph.ContainsKey(node.Key)) mergedGraph.Graph.Add(node.Key, node.Value);
                else
                {
                    foreach (var nodeChildId in node.Value.Edges)
                        mergedGraph.Graph[node.Key].Edges.Add(nodeChildId);
                }

            mergedGraph.Depth = GraphNormal.Depth + GraphReversed.Depth;
            return mergedGraph;
        }
    }
}

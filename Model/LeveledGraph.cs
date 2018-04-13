using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandshakesTheory.Models
{
    public class LeveledGraph<TKey, TData> : AbstractGraph<TKey, TData>
    {
        public override int Depth { get; set; }
        public override int Size { get => Graph.Count; }

        public override void AddLink(TKey from, TKey to)
        {
            if (Graph.ContainsKey(from) && (Graph[from] as DepthVertex<TKey, TData>).Depth < (Graph[to] as DepthVertex<TKey, TData>).Depth) Graph[from].Edges.Add(to);
        }

        public override void AddNode(TKey key, TData data, int depth = 0)
        {
            if (!Graph.ContainsKey(key)) Graph.Add(key, new DepthVertex<TKey, TData>(data, depth));
        }

        private TKey[] path = new TKey[10];
        private List<TData[]> answers = new List<TData[]>();

        public void makeAnswer(int population)
        {
            answers.Add(path.Take(population + 1).Select(id => Graph[id].Data).ToArray());
        }

        public List<TData[]> searchAllPathes(TKey from, TKey to)
        {
            DFS(from, to, 0);
            return answers;
        }

        private void DFS(TKey startKey, TKey searchedKey, int depth)
        {
            path[depth] = startKey;
            if (Comparer<TKey>.Equals(startKey,searchedKey)) makeAnswer(depth);

            IVertex<TKey, TData> currentUserNode = Graph[startKey];

            foreach (var child in currentUserNode.Edges)
                DFS(child, searchedKey, depth + 1);
        }

        public IEnumerable<TData> getNodesOfLevel(int level)
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

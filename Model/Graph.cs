using System.Collections.Generic;
using System.Linq;

namespace HandshakesTheory.Models
{
    public enum TreeType
    {
        Normal,
        Reversed
    }

    public class Graph<T>
    {
        struct Node<T>
        {
            public T Data;
            public long Depth;
            public SortedSet<int> Edges;

            public Node(T data, long depth)
            {
                this.Data = data;
                this.Depth = depth;
                this.Edges = new SortedSet<int>();
            }
        }

        public int Depth { get; set; }
        public int Size { get => graph.Count; }

        private Dictionary<int, Node<T>> graph = new Dictionary<int, Node<T>>();

        public void AddNode(int key, T user, int depth)
        {
            if (!graph.ContainsKey(key)) graph.Add(key, new Node<T>(user, depth));
        }
       

        public void AddLink(int from, int to)
        {
            if (graph.ContainsKey(from) && graph[from].Depth < graph[to].Depth) graph[from].Edges.Add(to);
        }

        private List<int> path = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<T[]> answers = new List<T[]>();

        public void makeAnswer(int population)
        {
            answers.Add(path.Take(population + 1).Select(id => graph[id].Data).ToArray());
        }

        public List<T[]> searchAllPathes(int from, int to)
        {
            DFS(from, to, 0);
            return answers;
        }

        private void DFS(int startKey, long searchedKey, int depth)
        {
            path[depth] = startKey;

            if (startKey == searchedKey) makeAnswer(depth);

            Node<T> currentUserNode = graph[startKey];

            foreach (var child in currentUserNode.Edges)
                DFS(child, searchedKey, depth + 1);
        }

        public IEnumerable<T> getNodesOfLevel(int level)
        {
            return graph.Where(node => node.Value.Depth == level).Select(node => node.Value.Data);
        }

        public static Graph<T> Merge(Graph<T> graphNormal, Graph<T> graphReversed)
        {
            Graph<T> mergedGraph = new Graph<T>();

            foreach (var node in graphNormal.graph)
                mergedGraph.graph.Add(node.Key, node.Value);

            foreach (var node in graphReversed.graph)
                if (!mergedGraph.graph.ContainsKey(node.Key)) mergedGraph.graph.Add(node.Key, node.Value);
                else
                {
                    foreach (var nodeChildId in node.Value.Edges)
                        mergedGraph.graph[node.Key].Edges.Add(nodeChildId);
                }

            mergedGraph.Depth = graphNormal.Depth + graphReversed.Depth;
            return mergedGraph;
        }
    }
}

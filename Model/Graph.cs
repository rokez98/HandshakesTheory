using System.Collections.Generic;
using System.Linq;

namespace HandshakesTheory.Models
{
    public enum TreeType
    {
        Normal,
        Reversed
    }

    public struct Node<T>
    {
        public T User;

        public long Level;
        public SortedSet<int> Edges;

        public Node(T user, long lvl)
        {
            User = user;
            this.Level = lvl;
            Edges = new SortedSet<int>();
        }
    }

    public class Graph<T>
    {
        public int Depth { get; set; }
        public int Size { get => socialGraph.Count; }

        private Dictionary<int, Node<T>> socialGraph = new Dictionary<int, Node<T>>();

        public void AddNode(int key,T user, int depth)
        {
            if (!socialGraph.ContainsKey(key)) socialGraph.Add(key, new Node<T>(user, depth));
        }

        public void AddLink(int from, int to)
        {
            if (socialGraph.ContainsKey(from) && socialGraph[from].Level < socialGraph[to].Level) socialGraph[from].Edges.Add(to);
        }

        private List<int> path = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<T[]> answers = new List<T[]>();

        public void makeAnswer(int population)
        {
            answers.Add(path.Take(population + 1).Select(id => socialGraph[id].User).ToArray());
        }

        public List<T[]> searchAllPathes(int from, int to)
        {
            DFS(from, to, 0);

            return answers;
        }

        private void DFS(int currentUserId, long searchedId, int population)
        {
            if (population > Depth) return;

            path[population] = currentUserId;

            if (currentUserId == searchedId) makeAnswer(population);

            Node<T> currentUserNode = socialGraph[currentUserId];

            foreach (var child in currentUserNode.Edges)
                DFS((int)child, searchedId, population + 1);
        }

        public IEnumerable<T> getNodesOfLevel(int level)
        {
            return socialGraph.Where(node => node.Value.Level == level).Select(node => node.Value.User);
        }

        public static Graph<T> Merge(Graph<T> graphNormal, Graph<T> graphReversed)
        {
            Graph<T> graph = new Graph<T>();

            foreach (var node in graphNormal.socialGraph)
            {
                graph.socialGraph.Add(node.Key, node.Value);
            }

            foreach (var node in graphReversed.socialGraph)
            {
                if (!graph.socialGraph.ContainsKey(node.Key)) graph.socialGraph.Add(node.Key, node.Value);
                else
                {
                    foreach (var nodeChildId in node.Value.Edges)
                        graph.socialGraph[node.Key].Edges.Add(nodeChildId);
                }
            }

            graph.Depth = graphNormal.Depth + graphReversed.Depth;

            return graph;
        }
    }
}

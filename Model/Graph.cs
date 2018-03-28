using System.Collections.Generic;
using System.Linq;

namespace TestVkApi
{
    public enum TreeType
    {
        Normal,
        Reversed
    }

    public struct Node
    {
        public VkUser User;
        public long Level;

        public Node(int id, long lvl)
        {
            User = new VkUser(id);
            this.Level = lvl;
        }

        public Node(VkUser user, long lvl)
        {
            User = user;
            this.Level = lvl;
        }
    }

    public class Graph
    {
        public int Depth { get; set; }
        public int Size { get => socialGraph.Count; }

        private Dictionary<int, Node> socialGraph = new Dictionary<int, Node>();

        public void AddNode(int id, int depth)
        {
            if (!socialGraph.ContainsKey(id)) socialGraph.Add(id, new Node(id, depth));
        }

        public void AddNode(VkUser user, int depth)
        {
            if (!socialGraph.ContainsKey(user.Id)) socialGraph.Add(user.Id, new Node(user, depth));
        }

        public void AddLink(int from, int to)
        {
            if (socialGraph.ContainsKey(from) && socialGraph[from].Level < socialGraph[to].Level) socialGraph[from].User.FriendsList.Add(to);
        }

        private List<int> path = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<VkUser[]> answers = new List<VkUser[]>();

        public void makeAnswer(int population)
        {
            answers.Add(path.Take(population + 1).Select(id => socialGraph[id].User).ToArray());
        }

        public List<VkUser[]> searchAllPathes(int from, int to)
        {
            DFS(from, to, 0);

            return answers;
        }

        private void DFS(int currentUserId, long searchedId, int population)
        {
            if (population > Depth) return;

            path[population] = currentUserId;

            if (currentUserId == searchedId) makeAnswer(population);

            Node currentUserNode = socialGraph[currentUserId];

            foreach (var child in currentUserNode.User.FriendsList)
                DFS((int)child, searchedId, population + 1);
        }


        public static Graph Merge(Graph graphNormal, Graph graphReversed)
        {
            Graph graph = new Graph();

            foreach (var node in graphNormal.socialGraph)
            {
                graph.socialGraph.Add(node.Key, node.Value);
            }

            foreach (var node in graphReversed.socialGraph)
            {
                if (!graph.socialGraph.ContainsKey(node.Key)) graph.socialGraph.Add(node.Key, node.Value);
                else
                {
                    foreach (var nodeChildId in node.Value.User.FriendsList)
                        graph.socialGraph[node.Key].User.FriendsList.Add(nodeChildId);
                }
            }

            graph.Depth = graphNormal.Depth + graphReversed.Depth;

            return graph;
        }

        public IEnumerable<int> getUsersIdsOfLevel(int level)
        {
            return socialGraph.Where(node => node.Value.Level == level).Select(node => node.Value.User.Id);
        }

    }
}

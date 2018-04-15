using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphLibrary.Models
{
    public class DfsSearcher<TKey, TData> : IPathSearcher<TKey, TData>
    {
        private List<TKey> path = new List<TKey>();
        private List<TData[]> answers = new List<TData[]>();

        private void makeAnswer(IGraph<TKey, TData> Graph, int population)
        {
            answers.Add(path.Take(population + 1).Select(id => Graph.Graph[id].Data).ToArray());
        }

        private void DFS(IGraph<TKey, TData> Graph ,TKey currentKey, TKey searchedKey, int depth)
        {
            if (path.Count <= depth) path.Add(currentKey);
            else path[depth] = currentKey;

            if (Comparer<TKey>.Equals(currentKey, searchedKey)) makeAnswer(Graph, depth);

            IVertex<TKey, TData> currentVertex = Graph.Graph[currentKey];

            foreach (var childKey in currentVertex.Edges)
                DFS(Graph, childKey, searchedKey, depth + 1);
        }

        public IEnumerable<TData[]> SearchPathes(IGraph<TKey, TData> graph, TKey startVertex, TKey endVertex)
        {
            DFS(graph, startVertex, endVertex, 0);
            return answers;
        }
    }
}

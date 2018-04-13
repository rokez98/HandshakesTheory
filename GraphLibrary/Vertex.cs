using System.Collections.Generic;

namespace GraphLibrary.Models
{
    public class Vertex<TKey, TData> : IVertex<TKey, TData>
    {
        public TData Data { get; set; }
        public ISet<TKey> Edges { get; set; } = new SortedSet<TKey>();

        public Vertex(TData data)
        {
            this.Data = data;
            this.Edges = new SortedSet<TKey>();
        }
    }
}

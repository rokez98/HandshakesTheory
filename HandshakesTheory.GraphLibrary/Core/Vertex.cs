using HandshakesTheory.GraphLibrary.Interfaces;
using System.Collections.Generic;

namespace HandshakesTheory.GraphLibrary.Core
{
    public class Vertex<TKey, TData> : IVertex<TKey, TData>
    {
        public TData Data { get; set; }
        public ISet<TKey> Edges { get; set; } = new SortedSet<TKey>();
    }
}

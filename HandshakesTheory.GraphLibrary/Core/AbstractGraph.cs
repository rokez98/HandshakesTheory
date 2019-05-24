using HandshakesTheory.GraphLibrary.Interfaces;
using System.Collections.Generic;

namespace HandshakesTheory.GraphLibrary.Core
{
    public abstract class AbstractGraph<TKey, TData> : IGraph<TKey, TData>
    {
        public virtual Dictionary<TKey, IVertex<TKey, TData>> Graph { get; } = new Dictionary<TKey, IVertex<TKey, TData>>();

        public IVertex<TKey, TData> this[TKey key] => Graph[key];

        public virtual int Size { get; }

        public abstract void AddEdge(TKey from, TKey to);
        public abstract void AddVertex(TKey key, TData data);
    }
}

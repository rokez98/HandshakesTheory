using System.Collections.Generic;

namespace HandshakesTheory.Models
{
    public abstract class AbstractGraph<TKey, TData> : IGraph<TKey, TData>
    {
        public virtual Dictionary<TKey, IVertex<TKey, TData>> Graph { get; set; } = new Dictionary<TKey, IVertex<TKey, TData>>();

        public virtual int Depth { get; set; }
        public virtual int Size { get; }

        public abstract void AddLink(TKey from, TKey to);
        public abstract void AddNode(TKey key, TData data, int depth);
    }
}

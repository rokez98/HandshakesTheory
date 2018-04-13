using System.Collections.Generic;

namespace GraphLibrary.Models
{
    public interface IGraph<TKey, TData> 
    {
        int Depth { get; set; }
        int Size { get; }

        Dictionary<TKey, IVertex<TKey, TData>> Graph { get; set; }

        void AddNode(TKey key, TData data, int depth);
        void AddLink(TKey from, TKey to);
    }
}

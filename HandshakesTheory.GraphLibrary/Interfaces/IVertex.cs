using System.Collections.Generic;

namespace HandshakesTheory.GraphLibrary.Interfaces
{
    public interface IVertex<TKey, TData>
    {
        TData Data { get; set; }
        ISet<TKey> Edges { get; set; }
    }
}

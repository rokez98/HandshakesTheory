using System.Collections.Generic;

namespace GraphLibrary.Models
{
    public interface IVertex<TKey, TData>
    {
        TData Data { get; set; }
        ISet<TKey> Edges { get; set; }
    }
}

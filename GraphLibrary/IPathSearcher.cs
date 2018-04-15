using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GraphLibrary.Models
{
    public interface IPathSearcher<TKey, TData>
    {
        IEnumerable<TData[]> SearchPathes(IGraph<TKey, TData> graph, TKey startVertex, TKey endVertex);
    }
}
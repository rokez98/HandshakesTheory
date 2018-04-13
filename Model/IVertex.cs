using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandshakesTheory.Models
{
    public interface IVertex<TKey, TData>
    {
        TData Data { get; set; }
        ISet<TKey> Edges { get; set; }
    }
}

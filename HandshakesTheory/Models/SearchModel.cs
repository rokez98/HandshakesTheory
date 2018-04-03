using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandshakesTheory.Models
{
    public class SearchModel
    {
        public int UserId { get; set; }
        public int SearchedId { get; set; }
        public int MaxPathLength { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandshakesTheory.Models
{
    public class SearchModel
    {
        public string UserId { get; set; }
        public string SearchedId { get; set; }
        public int MaxPathLength { get; set; }
    }
}

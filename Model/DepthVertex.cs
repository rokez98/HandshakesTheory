namespace HandshakesTheory.Models
{
    public class DepthVertex<TKey, TData> : Vertex<TKey, TData>
    {
        public long Depth { get; set; }
        public DepthVertex(TData data, long depth) : base(data)
        {
            this.Depth = depth;
        }
    }
}

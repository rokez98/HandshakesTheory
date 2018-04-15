namespace GraphLibrary.Models
{
    public interface IGraph<TKey, TData> 
    {
        int Depth { get; set; }
        int Size { get; }

        IVertex<TKey, TData> this[TKey key] { get; }

        void AddVertex(TKey key, TData data, int depth);
        void AddEdge(TKey from, TKey to);
    }
}

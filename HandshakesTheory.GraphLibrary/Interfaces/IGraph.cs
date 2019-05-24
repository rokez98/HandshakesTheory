namespace HandshakesTheory.GraphLibrary.Interfaces
{
    public interface IGraph<TKey, TData> 
    {
        IVertex<TKey, TData> this[TKey key] { get; }

        void AddVertex(TKey key, TData data);
        void AddEdge(TKey from, TKey to);
    }
}

namespace HandshakesTheory.WebAPI.Models
{
    public class SearchModel
    {
        public User FirstUser { get; set; }
        public User SecondUser { get; set; }
        public int MaxPathLength { get; set; }
    }
}

namespace HandshakesTheory.Models
{
    public class SearchModel
    {
        public VkUser FirstUser { get; set; }
        public VkUser SecondUser { get; set; }
        public int MaxPathLength { get; set; }
    }
}

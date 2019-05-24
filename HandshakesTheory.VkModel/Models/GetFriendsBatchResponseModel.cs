using Newtonsoft.Json;

namespace HandshakesTheory.VkModel.Models
{
    public class GetFriendsBatchResponseModel
    {
        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("friends")]
        public long[] Friends { get; set; }
    }
}
using HandshakesTheory.Vk.Models;
using Newtonsoft.Json;

namespace HandshakesTheory.VkModel.Requests
{
    public class GetDetailsBatchResponseModel
    {
        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("details")]
        public VkUser User { get; set; }
    }
}
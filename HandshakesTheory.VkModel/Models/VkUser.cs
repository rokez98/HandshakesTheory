using HandshakesTheory.Vk.Interfaces;
using Newtonsoft.Json;

namespace HandshakesTheory.Vk.Models
{
    public class VkUser : IUser
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("photo_100")]
        public string PhotoUrl { get; set; }
    }
}

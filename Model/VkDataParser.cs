using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace HandshakesTheory.Models
{
    public class VkDataParser : IVkDataParser
    {

        JToken Parse(string response)
        {
            return JToken.Parse(response)["response"];
        }

        public IEnumerable<VkUser> parseFriends(string response)
        {
            JToken parsedResponse = Parse(response);

            return parsedResponse == null ? Enumerable.Empty<VkUser>() :
                                            parsedResponse["items"].Select(user => new VkUser(int.Parse((string)user))).ToList();
        }

        public IEnumerable<VkUser> parseUsers(string response)
        {
            JToken parsedResponse = Parse(response);

            return parsedResponse == null ? Enumerable.Empty<VkUser>() :
                                            parsedResponse["items"].Select(user => 
                                            new VkUser(
                                            id: int.Parse((string)user["id"]),
                                            firstName: (string)user["first_name"],
                                            lastName: (string)user["last_name"])).ToList();
        }
    }
}

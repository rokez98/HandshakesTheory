using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HandshakesTheory.Models
{
    public class VkDataParser<T> : IVkDataParser<T> where T: new()
    {
        private JToken getResponseSection(string response) => JToken.Parse(response)["response"];
        private static PropertyInfo[] typeProperties { get; set; } = typeof(VkUser).GetProperties();

        private T parseJsonItem(JToken userJson)
        {
            T user = new T();
            foreach (var property in typeProperties)
            {
                var parser = property.PropertyType.GetMethod("Parse", new[] { typeof(string) });
                string fieldJson = (string)userJson[property.CustomAttributes.First().ConstructorArguments.First().Value];
                property.SetValue(user, parser == null ? fieldJson : parser.Invoke(null, new object[] { fieldJson }));
            }
            return user;
        }

        public IEnumerable<T> ParseData(string response)
        {
            JToken parsedResponse = getResponseSection(response);
            return parsedResponse == null ? Enumerable.Empty<T>() : parsedResponse["items"].Select(userInfo => parseJsonItem(userInfo)).ToList();
        }
    }
}

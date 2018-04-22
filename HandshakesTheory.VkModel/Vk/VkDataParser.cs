using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HandshakesTheory.Models
{
    public class VkDataParser : IDataParser
    {
        private JToken getResponseSection(string response) => JToken.Parse(response)["response"];
        private static PropertyInfo[] typeProperties { get; set; } 

        private T parseJsonItem<T>(JToken userJson) where T : new()
        {
            PropertyInfo[] typeProperties = typeof(T).GetProperties(); 

            T user = new T();
            foreach (var property in typeProperties)
            {
                var parser = property.PropertyType.GetMethod("Parse", new[] { typeof(string) });
                var propertyResponseName = property.GetCustomAttribute<VkApiResponseAttribute>()?.Name ?? throw new System.Exception("VkApiResponseAttribute dosen't exist!");           
                string fieldJson = (string)userJson[propertyResponseName];

                property.SetValue(user, parser == null ? fieldJson : parser.Invoke(null, new object[] { fieldJson }));
            }
            return user;
        }

        public IEnumerable<T> ParseData<T>(string response) where T : new()
        {
            JToken parsedResponse = getResponseSection(response);
            return parsedResponse == null ? Enumerable.Empty<T>() : parsedResponse["items"].Select(userInfo => parseJsonItem<T>(userInfo)).ToList();
        }
    }
}

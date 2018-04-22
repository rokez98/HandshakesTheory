using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HandshakesTheory.Models
{
    public class OkDataParser : IDataParser
    {
        private static PropertyInfo[] typeProperties { get; set; }

        private T parseJsonItem<T>(JToken userJson) where T : new()
        {
            PropertyInfo[] typeProperties = typeof(T).GetProperties();

            T user = new T();
            foreach (var property in typeProperties)
            {
                var parser = property.PropertyType.GetMethod("Parse", new[] { typeof(string) });
                var propertyResponseName = property.GetCustomAttribute<OkApiResponseAttribute>()?.Name ?? throw new System.Exception("OkApiResponseAttribute dosen't exist!");
                string fieldJson = (string)userJson[propertyResponseName];

                property.SetValue(user, parser == null ? fieldJson : parser.Invoke(null, new object[] { fieldJson }));
            }
            return user;
        }

        private object parseValueItem<T>(JToken data) where T: new()
        {
            T result = new T();
            var parser = typeof(T).GetMethod("Parse", new[] { typeof(string) });
            return parser == null ? (string)data : parser.Invoke(null, new object[] { (string)data });
        }

        public IEnumerable<T> ParseData<T>(string response) where T : new()
        {
            JToken parsedResponse = JToken.Parse(response);
            return parsedResponse == null ? Enumerable.Empty<T>() : parsedResponse.Select(userInfo => parseJsonItem<T>(userInfo)).ToList();
        }

        public IEnumerable<object> ParseValue<T>(string response) where T: new()
        {
            JToken parsedResponse = JToken.Parse(response);
            return parsedResponse == null ? Enumerable.Empty<object>() : parsedResponse.Select(userInfo => parseValueItem<T>(userInfo)).ToList();
        }
    }
}

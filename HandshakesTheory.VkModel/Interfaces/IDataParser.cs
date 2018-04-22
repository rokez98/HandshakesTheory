using System.Collections.Generic;

namespace HandshakesTheory.Models
{
    public interface IDataParser
    {
        IEnumerable<T> ParseData<T>(string response) where T : new();
    }
}

using System.Collections.Generic;

namespace HandshakesTheory.Models
{
    public interface IVkDataParser<T>
    {
        IEnumerable<T> ParseData(string response);
    }
}

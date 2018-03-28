using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVkApi
{
    public interface IVkDataParser
    {
        IEnumerable<VkUser> parseFriends(string response);
        IEnumerable<VkUser> parseUsers(string response);
    }
}

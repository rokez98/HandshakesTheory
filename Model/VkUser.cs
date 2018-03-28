using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVkApi
{
    public class VkUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SortedSet<int> FriendsList { get; set; }

        public VkUser(int id, string firstName = null, string lastName = null, SortedSet<int> friends = null)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FriendsList = friends ?? new SortedSet<int>();
        }
    }
}

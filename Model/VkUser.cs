using System.Collections.Generic;

namespace HandshakesTheory.Models
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

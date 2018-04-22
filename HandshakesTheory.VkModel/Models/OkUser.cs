using System.Collections.Generic;

namespace HandshakesTheory.Models
{
    public class OkUser : IUser
    {
        [OkApiResponse("uid")]
        public long Id { get; set; }

        [OkApiResponse("first_name")]
        public string FirstName { get; set; }

        [OkApiResponse("last_name")]
        public string LastName { get; set; }

        [OkApiResponse("pic50x50")]
        public string PhotoUrl { get; set; }

        public OkUser(long id = 0, string firstName = null, string lastName = null, string photoUrl = null)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhotoUrl = photoUrl;
        }

        public OkUser()
        {
            this.Id = 0;
            this.FirstName = null;
            this.LastName = null;
            this.PhotoUrl = null;
        }
    }
}

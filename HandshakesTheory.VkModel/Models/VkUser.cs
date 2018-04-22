﻿using System.Collections.Generic;

namespace HandshakesTheory.Models
{
    public class VkUser : IUser
    {
        [VkApiResponse("id")]
        public long Id { get; set; }

        [VkApiResponse("first_name")]
        public string FirstName { get; set; }

        [VkApiResponse("last_name")]
        public string LastName { get; set; }

        [VkApiResponse("photo_100")]
        public string PhotoUrl { get; set; }

        public VkUser(long id = 0, string firstName = null, string lastName = null, string photoUrl = null)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhotoUrl = photoUrl;
        }

        public VkUser()
        {
            this.Id = 0;
            this.FirstName = null;
            this.LastName = null;
            this.PhotoUrl = null;
        }
    }
}
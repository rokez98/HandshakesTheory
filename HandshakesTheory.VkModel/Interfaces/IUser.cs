using System;
using System.Collections.Generic;
using System.Text;

namespace HandshakesTheory.Models
{
    public interface IUser
    {
        long Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhotoUrl { get; set; }
    }
}

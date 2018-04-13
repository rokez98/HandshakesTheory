﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandshakesTheory.Models
{
    public interface IVkDataParser
    {
        IEnumerable<VkUser> parseUsers(string response);
    }
}
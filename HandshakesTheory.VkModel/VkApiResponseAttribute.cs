using System;
using System.Collections.Generic;
using System.Text;

namespace HandshakesTheory.Models
{
    class VkApiResponseAttribute : Attribute
    {
        string Name { get; set; }

        public VkApiResponseAttribute() { }
        public VkApiResponseAttribute(string name)
        {
            this.Name = name;
        }
    }
}

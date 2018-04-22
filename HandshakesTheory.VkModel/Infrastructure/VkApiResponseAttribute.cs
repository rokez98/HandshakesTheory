using System;

namespace HandshakesTheory.Models
{
    public class VkApiResponseAttribute : Attribute
    {
        public string Name { get; set; }

        public VkApiResponseAttribute() { }
        public VkApiResponseAttribute(string name)
        {
            this.Name = name;
        }
    }
}

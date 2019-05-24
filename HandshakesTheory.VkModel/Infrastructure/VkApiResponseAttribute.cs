using System;

namespace HandshakesTheory.Vk.Infrastructure
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

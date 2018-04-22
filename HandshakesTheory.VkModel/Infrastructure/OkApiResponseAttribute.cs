using System;

namespace HandshakesTheory.Models
{
    public class OkApiResponseAttribute : Attribute
    {
        public string Name { get; set; }

        public OkApiResponseAttribute() { }
        public OkApiResponseAttribute(string name)
        {
            this.Name = name;
        }
    }
}

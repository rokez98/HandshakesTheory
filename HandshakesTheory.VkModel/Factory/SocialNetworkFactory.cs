using System;

namespace HandshakesTheory.Models
{
    public class SocialNetworkFactory
    {
        public enum SocialNetworks
        {
            Vk
        }

        public ISocialNetwork CreateSocialNetwork(SocialNetworks snType)
        {   
            switch (snType)
            {
                case SocialNetworks.Vk:  return new Vk();
                default: throw new NotImplementedException();
            }
        }
    }
}

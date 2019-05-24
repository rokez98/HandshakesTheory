using AutoMapper;
using HandshakesTheory.Vk.Models;
using HandshakesTheory.WebAPI.Models;

namespace HandshakesTheory.WebAPI.Profiles
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<User, VkUser>().ReverseMap();
        }
    }
}

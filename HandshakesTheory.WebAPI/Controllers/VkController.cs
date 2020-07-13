using AutoMapper;
using HandshakesTheory.Vk.Core;
using HandshakesTheory.Vk.Interfaces;
using HandshakesTheory.Vk.Models;
using HandshakesTheory.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HandshakesTheory.WebAPI.Controllers
{
    [Route("api/vk")]
    public class VkController : Controller
    {
        private readonly VkNetwork _socialNetwork;
        private readonly IMapper _mapper;

        public VkController(VkNetwork socialNetwork, IMapper mapper)
        {
            _socialNetwork = socialNetwork;
            _mapper = mapper;
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("ping response");
        }

        [HttpPost("search")]
        public IActionResult Search([FromBody] SearchModel searchModel)
        {
            var firstUser = _mapper.Map<User, VkUser>(searchModel.FirstUser);
            var secondUser = _mapper.Map<User, VkUser>(searchModel.SecondUser);

            var pathesList = _socialNetwork.SearchPathesBetweenUsers(firstUser, secondUser, searchModel.MaxPathLength);

            var result = pathesList.OrderBy(p => p.Length).Take(25);
            var mappedResult = _mapper.Map<IEnumerable<IUser[]>, IEnumerable<User[]>>(result);

            return Ok(mappedResult);
        }
    }
}

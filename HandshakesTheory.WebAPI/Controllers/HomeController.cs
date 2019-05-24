using AutoMapper;
using HandshakesTheory.Vk.Core;
using HandshakesTheory.Vk.Interfaces;
using HandshakesTheory.Vk.Models;
using HandshakesTheory.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HandshakesTheory.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        protected readonly VkNetwork _socialNetwork;

        private readonly IMapper _mapper;

        public HomeController(VkNetwork socialNetwork, IMapper mapper)
        {
            _socialNetwork = socialNetwork;
            _mapper = mapper;
        }

        [HttpPost]
        [ActionName("Index")]
        public IActionResult Search(SearchModel searchModel)
        {
            try
            {
                var firstUser = _mapper.Map<User, VkUser>(searchModel.FirstUser);
                var secondUser = _mapper.Map<User, VkUser>(searchModel.SecondUser);

                var pathesList = _socialNetwork.SearchPathesBetweenUsers(firstUser, secondUser, searchModel.MaxPathLength);

                var result = pathesList.OrderBy(p => p.Length).Take(25);
                var mappedResult = _mapper.Map<IEnumerable<IUser[]>, IEnumerable<User[]>>(result);
                return View("Search", mappedResult);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
    }
}

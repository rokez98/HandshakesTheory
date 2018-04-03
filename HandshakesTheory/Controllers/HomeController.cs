using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HandshakesTheory.Models;

namespace HandshakesTheory.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(SearchModel searchModel)
        {
            int userId, searchedId;

            var graph = Vk.BuildSocialGraph(searchModel.UserId, searchModel.SearchedId, searchModel.MaxPathLength, out userId, out searchedId);
            var answers = graph.searchAllPathes(userId, searchedId);

            return View(answers);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
    }
}

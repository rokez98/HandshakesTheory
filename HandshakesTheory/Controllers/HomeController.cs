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
            var graph = Vk.BuildSocialGraph(searchModel.UserId, searchModel.SearchedId, searchModel.MaxPathLength);
            var answers = graph.searchAllPathes(searchModel.UserId, searchModel.SearchedId);

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

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

            try
            {
                var graph = Vk.BuildSocialGraph(searchModel.UserId, searchModel.SearchedId, searchModel.MaxPathLength);
                var answers = graph.searchAllPathes(searchModel.UserId, searchModel.SearchedId);
                return View(answers);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
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

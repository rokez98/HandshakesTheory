using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HandshakesTheory.Models;


namespace HandshakesTheory.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        [HttpPost]
        [ActionName("Index")]
        public IActionResult Search(SearchModel searchModel)
        {
            try
            {
                var pathesList = Vk.SearchPathesBetweenUsers(searchModel.FirstUser, searchModel.SecondUser, searchModel.MaxPathLength);
                return View("Search", pathesList.OrderBy(p => p.Length).Take(50));
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HandshakesTheory.Models;
using Microsoft.Ajax.Utilities;


namespace HandshakesTheory.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Search(SearchModel searchModel)
        {
            try
            {
                var pathesList = Vk.SearchPathesBetweenUsers(searchModel.FirstUser, searchModel.SecondUser, searchModel.MaxPathLength);
                return View(pathesList.OrderBy(p => p.Length).Take(50));
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
    }
}

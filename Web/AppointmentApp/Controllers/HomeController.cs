using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NormalFactory.AppointmentApp.Web.Models;

namespace NormalFactory.AppointmentApp.Web.Controllers
{
    public class HomeController : Controller
    {


        #region Actions

        /// <summary>
        /// Displays the landing page
        /// </summary>
        /// <returns>Landing home page</returns>
        public async Task<IActionResult> Index()
        {
            return View();
        }


        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion
    }
}

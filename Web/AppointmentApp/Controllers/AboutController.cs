using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace NormalFactory.AppointmentApp.Web.Controllers
{
    /// <summary>
    /// Contains functionality to display About page
    /// </summary>
    public class AboutController : Controller
    {
        #region Actions

        /// <summary>
        /// Displays the About page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}

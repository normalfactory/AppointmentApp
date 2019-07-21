using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NormalFactory.AppointmentApp.Web.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: /<controller>/
        public async Task<IActionResult> Requested()
        {
            return View();
        }


        public async Task<IActionResult> Alternative()
        {

            return View();
        }


        public async Task<IActionResult> Confirmed()
        {

            return View();
        }
    }
}

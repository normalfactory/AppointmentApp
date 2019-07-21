using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NormalFactory.AppointmentApp.Web.Models;

namespace NormalFactory.AppointmentApp.Web.Controllers
{
    /// <summary>
    /// Used with home page
    /// </summary>
    public class HomeController : NavController
    {
        #region Private Properties

        /// <summary>
        /// Reference to data access
        /// </summary>
        private IAppointmentDataAccess _appointmentDataAccess;

        #endregion




        #region Constructor

        /// <summary>
        /// Creates new instance and sets data access
        /// </summary>
        /// <param name="appDataAccess">Reference to data acdess; from dependency injection</param>
        public HomeController(IAppointmentDataAccess appDataAccess)
        {
            _appointmentDataAccess = appDataAccess;
        }

        #endregion



        #region Actions

        /// <summary>
        /// Displays the landing page
        /// </summary>
        /// <returns>Landing home page</returns>
        public async Task<IActionResult> Index()
        {
            //- Update Appointment Counts
            var apptStatus = await _appointmentDataAccess.GetAppointmentStatusesAsync();

            UpdateNavBar(apptStatus);


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

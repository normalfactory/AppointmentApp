using System;
using Microsoft.AspNetCore.Mvc;
using NormalFactory.AppointmentApp.Web.Models;

namespace NormalFactory.AppointmentApp.Web.Controllers
{
    /// <summary>
    /// Used to update the navbar counts of the different appointment statuses; to be inherited by other controllers
    /// </summary>
    public class NavController: Controller
    {

        #region Private Properties

        /// <summary>
        /// ViewData key for the request count in navbar
        /// </summary>
        private const string _requestCountViewDataKey = "RequestedCount";

        /// <summary>
        /// ViewData key for the confirmed count in navbar
        /// </summary>
        private const string _confirmedCountViewDataKey = "ConfirmedCount";

        /// <summary>
        /// ViewData key for the alternative count in navbar
        /// </summary>
        private const string _alternativeCountViewDataKey = "AlternativeCount";

        #endregion




        #region Update NavBar

        /// <summary>
        /// Updates the navbar with the counts of the appointments based on the status
        /// </summary>
        /// <param name="model">Contains counts based on the status of the appointment</param>
        public void UpdateNavBar(AppointmentInfoModel model)
        {
            //- Requested
            if (model.RequestedAppointmentCount == 0)
            {
                ViewData[_requestCountViewDataKey] = string.Empty;
            }
            else
            {
                ViewData[_requestCountViewDataKey] = $"[{model.RequestedAppointmentCount.ToString()}] ";
            }


            //- Confirmed
            if (model.ConfirmedAppointmentCount == 0)
            {
                ViewData[_confirmedCountViewDataKey] = string.Empty;
            }
            else
            {
                ViewData[_confirmedCountViewDataKey] = $"[{model.ConfirmedAppointmentCount.ToString()}] ";
            }


            //- Alternative
            if (model.AlternativeAppointmentCount == 0)
            {
                ViewData[_alternativeCountViewDataKey] = string.Empty;
            }
            else
            {
                ViewData[_alternativeCountViewDataKey] = $"[{model.AlternativeAppointmentCount.ToString()}] ";
            }
        }


        #endregion

    }
}

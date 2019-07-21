using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NormalFactory.AppointmentApp.Data;
using NormalFactory.AppointmentApp.Web.Models;
using NormalFactory.AppointmentApp.Web.ViewModels;


namespace NormalFactory.AppointmentApp.Web.Controllers
{
    /// <summary>
    /// Used with the appointments
    /// </summary>
    public class AppointmentController : NavController
    {
        #region Private Properties

        /// <summary>
        /// Reference to the data access
        /// </summary>
        private IAppointmentDataAccess _appointmentDataAccess;

        #endregion



        #region Constructor

        /// <summary>
        /// Creates a new instance and sets the data access
        /// </summary>
        /// <param name="apptDataAccess">Reference to data access; from dependency injection</param>
        public AppointmentController(IAppointmentDataAccess apptDataAccess)
        {
            _appointmentDataAccess = apptDataAccess;
        }

        #endregion



        #region Action: Requested

        /// <summary>
        /// Display appointments that have the status of Requested
        /// </summary>
        /// <returns>View</returns>
        public async Task<IActionResult> Requested()
        {
            return await GetRequestedView();
        }

        /// <summary>
        /// Updates the confirmed appointment and returns updated view
        /// </summary>
        /// <param name="id">Unique identifier of appointment to confirm appointment with</param>
        /// <returns>View</returns>
        public async Task<IActionResult> ConfirmAppt(int id)
        {
            //- ConfirmAppointment
            var isSuccess = await _appointmentDataAccess.SetConfirmAppointmentAsync(id);

            if (isSuccess == false)
            {
                return NotFound();
            }


            return await GetRequestedView();
        }

        /// <summary>
        /// Prepares ViewModel for use with view for requested appointments and updates navbar
        /// </summary>
        /// <returns>View</returns>
        private async Task<IActionResult> GetRequestedView()
        {
            //- Get Appointments
            var requestApptModel = await _appointmentDataAccess.GetAppointmentsAsync(AppointmentApprovalStatuses.Requested);


            //- Update NavBar
            UpdateNavBar(requestApptModel);


            //- Create ViewModel
            RequestedAppointmentViewModel vm = new RequestedAppointmentViewModel()
            {
                Appointments = requestApptModel.Appointments
            };


            return View("Requested", vm);
        }

        #endregion



        #region Action: Confirmed

        /// <summary>
        /// Displays those appointments that have been confirmed
        /// </summary>
        /// <returns>View</returns>
        public async Task<IActionResult> Confirmed()
        {
            //- Get Appointments
            var confirmApptModel = await _appointmentDataAccess.GetAppointmentsAsync(AppointmentApprovalStatuses.Confirmed);


            //- Update NavBar
            UpdateNavBar(confirmApptModel);


            //- Create ViewModel
            ConfirmedAppointmentViewModel vm = new ConfirmedAppointmentViewModel()
            {
                Appointments = confirmApptModel.Appointments
            };

            return View(vm);
        }

        #endregion



        #region Alternative


        public async Task<IActionResult> Alternative()
        {

            return View();
        }

        #endregion

    }
}

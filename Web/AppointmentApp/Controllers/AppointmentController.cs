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
            UpdateNavBar(requestApptModel.StatusInfo);


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
            UpdateNavBar(confirmApptModel.StatusInfo);


            //- Create ViewModel
            ConfirmedAppointmentViewModel vm = new ConfirmedAppointmentViewModel()
            {
                Appointments = confirmApptModel.Appointments
            };

            return View(vm);
        }

        #endregion



        #region Alternative

        /// <summary>
        /// Display page that contains list of confirmed alternative times
        /// </summary>
        public async Task<IActionResult> Alternative()
        {
            //- Get Appointments
            var confirmApptModel = await _appointmentDataAccess.GetAppointmentsAsync(AppointmentApprovalStatuses.Alternative);


            //- Update NavBar
            UpdateNavBar(confirmApptModel.StatusInfo);


            //- Create ViewModel
            AlternativeAppointmentViewModel vm = new AlternativeAppointmentViewModel()
            {
                Appointments = confirmApptModel.Appointments
            };


            return View(vm);
        }

        /// <summary>
        /// Display page that allows user to propose alternative date
        /// </summary>
        /// <param name="id">Unique identifier of the appointment</param>
        /// <returns>View</returns>
        public async Task<IActionResult> EditAlternative(int id)
        {
            //- Get Appointment
            var resultModel = await _appointmentDataAccess.GetAppointmentByIDAsync(id);


            //- Check for Appointment
            if (resultModel.Appointment == null)
            {
                return NotFound();
            }


            //- Navbar
            UpdateNavBar(resultModel.StatusInfo);


            //- Create ViewModel
            EditAlternativeAppointmentViewModel vm = new EditAlternativeAppointmentViewModel()
            {
                Appointment = resultModel.Appointment
            };


            return View(vm);
        }

        /// <summary>
        /// Accepts the proposed datetime from user
        /// </summary>
        /// <param name="id">Unique identifier of the appointment</param>
        /// <param name="model">Only use the alternativedate set by user</param>
        /// <returns>View based on results</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAlternative(int id, EditAlternativeAppointmentViewModel model)
        {
            //- Check Status
            if (ModelState.IsValid == false)
            {
                return View(model);
            }


            //- Update Data Store
            bool isSuccess = await _appointmentDataAccess.SetAlternativeAppointmentAsync(id, model.Appointment.AlternativeDateTimeOffset);

            if (isSuccess == false)
            {
                return NotFound();
            }


            return RedirectToAction("AlternativeConfirmation");
        }

        /// <summary>
        /// Displays confirmation
        /// </summary>
        /// <returns>View</returns>
        public async Task<IActionResult> AlternativeConfirmation()
        {
            //- Update Navbar
            var apptInfo = await _appointmentDataAccess.GetAppointmentStatusesAsync();

            UpdateNavBar(apptInfo);


            return View();
        }

        #endregion

    }
}

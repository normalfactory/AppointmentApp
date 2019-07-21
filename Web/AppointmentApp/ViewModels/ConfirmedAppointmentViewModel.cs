using System;
using System.Collections.Generic;
using NormalFactory.AppointmentApp.Data;

namespace NormalFactory.AppointmentApp.Web.ViewModels
{
    /// <summary>
    /// Contains data for the Appointment\Confirmed view
    /// </summary>
    public class ConfirmedAppointmentViewModel: BaseAppointmentViewModel
    {
        #region Public Properties

        /// <summary>
        /// List of the confirmed appointments
        /// </summary>
        public List<AppointmentRequestDetail> Appointments { get; set; }

        #endregion
    }
}
